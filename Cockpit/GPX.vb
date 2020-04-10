Module GPX

    Public Const LAT = 1
    Public Const LON = 2
    Public Const ALT = 3
    Public Const UTC = 4
    Public Const DST = 5
    Public Const SPD = 6

    Function ReadGPX(FileName As String) As String(,)
        'https://www.experts-exchange.com/questions/23404291/Problems-parsing-GPX-XML-file.html
        'Instantiate an XmlDocument object. 
        Dim xmldoc As New System.Xml.XmlDocument()
        Dim GPSInfoNode As System.Xml.XmlNode

        xmldoc.Load(FileName)


        'Instantiate an XmlNamespaceManager object. 
        Dim xmlnsManager As New System.Xml.XmlNamespaceManager(xmldoc.NameTable)

        'Add the namespaces used in books.xml to the XmlNamespaceManager. 
        xmlnsManager.AddNamespace("nsgpx", "http://www.topografix.com/GPX/1/1")
        xmlnsManager.AddNamespace("nsxsi", "http://www.w3.org/2001/XMLSchema-instance")
        xmlnsManager.AddNamespace("nsmbx", "http://www.motionbased.net/mbx")

        Dim GPSInfo As System.Xml.XmlNodeList

        'Execute the XPath query using the SelectNodes method of the XmlDocument. 
        'Supply the XmlNamespaceManager as the nsmgr parameter. 
        'The matching nodes will be returned as an XmlNodeList. 
        'Use an XmlNode object to iterate through the returned XmlNodeList. 

        GPSInfo = xmldoc.SelectNodes("//nsgpx:gpx/nsgpx:trk/nsgpx:trkseg/nsgpx:trkpt", xmlnsManager)

        Dim GIS(6, 1) As String
        Dim n As Integer

        For Each GPSInfoNode In GPSInfo
            'MsgBox(GPSInfoNode.OuterXml)
            'MsgBox("ELE:" & GPSInfoNode.Item("ele").InnerXml & " TIME:" & GPSInfoNode.Item("time").InnerXml)
            'MsgBox(GPSInfoNode.Attributes.ItemOf("lat").InnerXml)
            'MsgBox(GPSInfoNode.Attributes.ItemOf("lon").InnerXml)
            n += 1
            ReDim Preserve GIS(6, n)
            GIS(LAT, n) = GPSInfoNode.Attributes.ItemOf("lat").InnerXml
            GIS(LON, n) = GPSInfoNode.Attributes.ItemOf("lon").InnerXml
            GIS(ALT, n) = GPSInfoNode.Item("ele").InnerXml
            GIS(UTC, n) = GPSInfoNode.Item("time").InnerXml
            'For Each Attr In GPSInfoNode.Attributes
            '    MsgBox(Attr.InnerText & Attr.Name)
            'Next
        Next GPSInfoNode

        Return GIS

    End Function

    Structure wptType
        Dim lat As Double
        Dim lon As Double
        Dim ele As Double
    End Structure

    Sub GetCourseAndDistance(ByVal pt1 As wptType, ByVal pt2 As wptType, ByRef course As Double, ByRef dist As Double)
        'http://www.tma.dk/gps/
        ' convert latitude and longitude to radians
        Dim lat1 As Double = DegreesToRadians(CDbl(pt1.lat))
        Dim lon1 As Double = DegreesToRadians(CDbl(pt1.lon))
        Dim lat2 As Double = DegreesToRadians(CDbl(pt2.lat))
        Dim lon2 As Double = DegreesToRadians(CDbl(pt2.lon))

        ' compute latitude and longitude differences
        Dim dlat As Double = lat2 - lat1
        Dim dlon As Double = lon2 - lon1

        Dim distanceNorth As Double = dlat
        Dim distanceEast As Double = dlon * Math.Cos(lat1)

        ' compute the distance in radians
        dist = Math.Sqrt(distanceNorth * distanceNorth + distanceEast * distanceEast)

        ' and convert the radians to meters
        dist = RadiansToMeters(dist)

        ' add the elevation difference to the calculation
        Dim dele As Double = CDbl(pt2.ele - pt1.ele)
        dist = Math.Sqrt(dist * dist + dele * dele)

        ' compute the course
        course = Math.Atan2(distanceEast, distanceNorth) Mod (2 * Math.PI)
        course = RadiansToDegrees(course)
        If course < 0 Then
            course += 360
        End If
    End Sub
    Function DegreesToRadians(ByVal degrees As Double) As Double
        Return degrees * Math.PI / 180.0
    End Function

    Function RadiansToDegrees(ByVal radians As Double) As Double
        Return radians * 180.0 / Math.PI
    End Function

    Function RadiansToNauticalMiles(ByVal radians As Double) As Double
        ' There are 60 nautical miles for each degree
        Return radians * 60 * 180 / Math.PI
    End Function

    Function RadiansToMeters(ByVal radians As Double) As Double
        ' there are 1852 meters in a nautical mile
        Return 1852 * RadiansToNauticalMiles(radians)
    End Function

    Public Enum enumLongLat
        Latitude = 1
        Longitude = 2
    End Enum
    Public Enum enumReturnformat
        WithSigns = 0
        NMEA = 1
    End Enum

    Public Function DecimalPosToDegrees(ByVal Decimalpos As Double, ByVal Type As enumLongLat, ByVal Outputformat As enumReturnformat, Optional ByVal SecondResolution As Integer = 2) As String
        'Convert decimal location to NMEA/WGS-84 format
        Dim Deg As Integer = 0
        Dim Min As Double = 0
        Dim Sec As Double = 0
        Dim Dir As String = ""
        Dim tmpPos As Double = Decimalpos
        If tmpPos < 0 Then tmpPos = Decimalpos * -1 'Always do math on positive values

        Deg = CType(Math.Floor(tmpPos), Integer)
        Min = (tmpPos - Deg) * 60
        Sec = (Min - Math.Floor(Min)) * 60
        Min = Math.Floor(Min)
        Sec = Math.Round(Sec, SecondResolution)

        Select Case Type
            Case enumLongLat.Latitude '=1
                If Decimalpos < 0 Then
                    Dir = "S"
                Else
                    Dir = "N"
                End If
            Case enumLongLat.Longitude '=2
                If Decimalpos < 0 Then
                    Dir = "W"
                Else
                    Dir = "E"
                End If
        End Select
        Select Case Outputformat
            Case enumReturnformat.NMEA
                Return AddZeros(Deg, 3) & AddZeros(Min, 2) & AddZeros(Sec, 2)
            Case enumReturnformat.WithSigns
                Return Deg & "°" & Min & """" & Sec & "'" & Dir
            Case Else
                Return ""
        End Select
    End Function


    Public Function AddZeros(ByVal Value As Double, ByVal Zeros As Integer) As String
        If Math.Floor(Value).ToString.Length < Zeros Then
            Return Value.ToString.PadLeft(Zeros, CType("0", Char))
        Else
            Return Value.ToString
        End If
    End Function

End Module

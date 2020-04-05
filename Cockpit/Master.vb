Public Class Master

    Dim GPXFileName As String
    Dim BMPSave As Boolean = False
    Dim SpeedThreshold As Single
    Dim MM As Single

    Private Sub RenderGraph(Titolo As String, MINALT As Single, MAXALT As Single, MINUTC As Date, MAXUTC As Date, MeanSpeed As Single, PeakSpeed As Single, DistanceTot As Single, MovingTime As Single, TotalHigh As Single, TotalDesc As Single, ByRef GIS As String(,), InFile As String)
        Me.Cursor = Cursors.WaitCursor
        Dim bm As New Bitmap(picGraph.ClientSize.Width, picGraph.ClientSize.Height)
        Using gr As Graphics = Graphics.FromImage(bm)
            Dim prev_n As Single
            Dim prev_y As Single

            Dim Xmin As Single = 6
            Dim Xmax As Single = 19
            Dim Ymin As Single = 0
            Dim Ymax As Single = 90
            Dim Xspan As Single = Xmax - Xmin
            Dim Yspan As Single = Ymax - Ymin
            Dim Ratio As Single = Yspan / Xspan
            Dim Ysize As Single = bm.Height / Yspan
            Dim Xsize As Single = bm.Width / Xspan

            Dim n As Single

            gr.Clear(Color.Black)

            Dim fntTitolo As New Font("Arbutus Slab", 24, FontStyle.Regular)
            Dim fore_brush As Brush = Brushes.White
            Dim fnt As New Font("Arbutus Slab", 12, FontStyle.Regular)

            Dim AxisBrush As Brush = Brushes.LightGreen
            Dim AxisFnt As New Font("arial", 1, FontStyle.Regular)

            Dim text_size = gr.MeasureString(Titolo, fntTitolo)

            Dim location_x = (Me.picGraph.Width - text_size.Width) / 2
            Dim location_y = 65
            Dim Delta_y = 25
            Dim LeftSpace = 45

            gr.DrawString(Titolo, fntTitolo, fore_brush, location_x, 10)

            gr.DrawString("Inizio attività = " & MINUTC & "", fnt, fore_brush, LeftSpace, location_y) : location_y += Delta_y
            gr.DrawString("Fine attività = " & MAXUTC & "", fnt, fore_brush, LeftSpace, location_y) : location_y += Delta_y
            gr.DrawString("Durata totale = " & DateDiff(DateInterval.Hour, MINUTC, MAXUTC) & ":" & DateDiff(DateInterval.Minute, MINUTC, MAXUTC) - DateDiff(DateInterval.Hour, MINUTC, MAXUTC) * 60, fnt, fore_brush, LeftSpace, location_y) : location_y += Delta_y
            gr.DrawString("Distanza totale = " & Math.Round(DistanceTot / 1000, 2) & " Km", fnt, fore_brush, LeftSpace, location_y) : location_y += Delta_y

            Dim IntTimeStart As Date = DateAdd(DateInterval.Second, -1 * DatePart(DateInterval.Second, MINUTC), DateAdd(DateInterval.Minute, -1 * DatePart(DateInterval.Minute, MINUTC), MINUTC))
            Dim IntTimeStop As Date = DateAdd(DateInterval.Hour, 1, DateAdd(DateInterval.Second, -1 * DatePart(DateInterval.Second, MAXUTC), DateAdd(DateInterval.Minute, -1 * DatePart(DateInterval.Minute, MAXUTC), MAXUTC)))
            Dim HourStart As Single = DatePart(DateInterval.Hour, IntTimeStart)
            Dim HourStop As Single = HourStart + DateDiff(DateInterval.Hour, IntTimeStart, IntTimeStop)

            Dim StrMovingTime As String
            StrMovingTime = Math.Truncate(Math.Round(MovingTime / 3600, 2)).ToString & ":" & Math.Truncate(Math.Round((Math.Round(MovingTime / 3600, 2) - Math.Truncate(Math.Round(MovingTime / 3600, 2))) * 60, 2)).ToString
            gr.DrawString("Tempo in movimento = " & StrMovingTime & " ", fnt, fore_brush, LeftSpace, location_y) : location_y += Delta_y

            gr.DrawString("Velocità media = " & Math.Round(MeanSpeed, 2) & " Km/h", fnt, fore_brush, LeftSpace, location_y) : location_y += Delta_y
            gr.DrawString("Velocità massima = " & Math.Round(PeakSpeed, 2) & " Km/h", fnt, fore_brush, LeftSpace, location_y) : location_y += Delta_y
            gr.DrawString("Altezza minima = " & Math.Round(MINALT, 2) & " m", fnt, fore_brush, LeftSpace, location_y) : location_y += Delta_y
            gr.DrawString("Altezza massima = " & Math.Round(MAXALT, 2) & " m", fnt, fore_brush, LeftSpace, location_y) : location_y += Delta_y
            gr.DrawString("Scalata = " & TotalHigh & " m", fnt, fore_brush, LeftSpace, location_y) : location_y += Delta_y
            gr.DrawString("Discesa = " & TotalDesc & " m", fnt, fore_brush, LeftSpace, location_y) : location_y += 7.5 * Delta_y
            Dim fntA As New Font("Courgette", 12, FontStyle.Regular)
            gr.DrawString("Epic Day Cockpit by R. Luinetti", fntA, fore_brush, LeftSpace + 27, location_y)

            Dim y As Integer = Year(DateTimePicker1.Value)
            Dim m As Integer = Month(DateTimePicker1.Value)
            Dim d As Integer = DateAndTime.Day(DateTimePicker1.Value)
            Dim j As Double = Days2000(y, m, d, 0, 0, 0, 1)
            Dim ji As Double = Days2000(y, 12, 21, 0, 0, 0, 1)
            Dim je As Double = Days2000(y, 6, 21, 0, 0, 0, 1)
            Dim SunAlt As Double
            Dim MoonAlt As Double
            Dim Counter As Integer

            Dim FILE_NAME As String = "ASTRO.CSV"
            Dim objWriter As New System.IO.StreamWriter(FILE_NAME)

            Dim TZ As TimeZone = TimeZone.CurrentTimeZone
            Dim OffsetTS As TimeSpan = TZ.GetUtcOffset(DateTimePicker1.Value)
            Dim Offset As Single = OffsetTS.TotalHours

            'Altezza Sole & Luna==========================================================================
            SetDisplayPhysicalArea(picGraph, 960, 540, 400, 365, 500, 110)
            SetScale(0, 24, 0, 90)
            Dim NumtimeStart As Single = (DateDiff(DateInterval.Second, CType(MINUTC.ToShortDateString, Date), MINUTC) / 3600) + CType(DateDiff(DateInterval.Second, MINUTC, CType(GIS(UTC, 1), Date)), Single) / 3600
            Dim NumtimeStop As Single = (DateDiff(DateInterval.Second, CType(MINUTC.ToShortDateString, Date), MINUTC) / 3600) + CType(DateDiff(DateInterval.Second, MINUTC, CType(GIS(UTC, GIS.GetUpperBound(1)), Date)), Single) / 3600
            Draw(gr, PenBlue, NumtimeStart, 0, NumtimeStart, 90)
            Draw(gr, PenBlue, NumtimeStop, 0, NumtimeStop, 90)
            DrawLogicRect(gr, Color.Blue, NumtimeStart, 0, NumtimeStop - NumtimeStart, 90)
            Dim LTX, LTY, RTX, RTY, LBX, LBY, RBX, RBY As Single
            GetPhysicalCoords(NumtimeStart, 0, LTX, LTY)
            GetPhysicalCoords(NumtimeStop, 0, RTX, RTY)
            Frame(gr, PenGreen)
            Axes(gr, PenGreen, 0, 0, 1, 5)
            Grid(gr, PenGreen, 0, 0, 3, 10)
            GraphTitle(gr, "Altezza Sole e Luna", "Arbutus Slab", 12)
            XTitle(gr, "Ora locale", "Verdana", 8)
            YTitle(gr, "Altezza °", "Verdana", 8)
            XTickLabel(gr, 0, 3, "Verdana", 7)
            YTickLabel(gr, 0, 20, "Verdana", 7)
            Label(gr, "Solstizio d'estate", "Verdana", 7, Color.Red, 0.5, 80)
            Label(gr, "Altezza sole giorno attività", "Verdana", 7, Color.Yellow, 0.5, 70)
            Label(gr, "Solstizio d'inverno", "Verdana", 7, Color.LightGreen, 0.5, 60)
            Label(gr, "Altezza luna giorno attività", "Verdana", 7, Color.WhiteSmoke, 0.5, 40)

            'Dim SunFile As String = "C:\Users\Roberto\Documents\YouTubeResource\Sun_ico.bmp"
            'Dim bm_sun As New Bitmap(SunFile)
            Dim myAsm As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
            Dim bm_sun As New Bitmap(myAsm.GetManifestResourceStream(Me.GetType, "Sun_ico.bmp")) 'set azione di compilazione dell'immagine = risorsa incorporata
            bm_sun.MakeTransparent(Color.Black)

            'sole
            Dim MaxSunN, MaxSunAlt As Single
            For n = 0 To 24 Step 0.01
                SunAlt = altaz(j + n / 24, sun(j + n / 24, 2), sun(j + n / 24, 3), CInt(LatG.Text) + CInt(LatP.Text) / 60, CInt(LongG.Text) + CInt(LongP.Text) / 60, 1)
                Draw(gr, PenYellow, prev_n, prev_y, n, SunAlt)
                objWriter.WriteLine("SUN" & vbTab & n & vbTab & Convert.ToSingle(SunAlt))
                If Convert.ToSingle(SunAlt) > MaxSunAlt Then
                    MaxSunN = n
                    MaxSunAlt = Convert.ToSingle(SunAlt)
                End If
                prev_n = n
                prev_y = Convert.ToSingle(SunAlt)
            Next n
            DrawLogicPicture(gr, bm_sun, MaxSunN, MaxSunAlt)

            'inverno
            For n = 0 To 24 Step 0.1
                SunAlt = altaz(ji + n / 24, sun(ji + n / 24, 2), sun(ji + n / 24, 3), CInt(LatG.Text) + CInt(LatP.Text) / 60, CInt(LongG.Text) + CInt(LongP.Text) / 60, 1)
                Draw(gr, PenLightGreen, prev_n, prev_y, n, SunAlt)
                objWriter.WriteLine("SUN LOWPOS" & vbTab & n & vbTab & Convert.ToSingle(SunAlt))
                prev_n = n
                prev_y = Convert.ToSingle(SunAlt)
            Next n

            'estate
            For n = 0 To 24 Step 0.1
                SunAlt = altaz(je + n / 24, sun(je + n / 24, 2), sun(je + n / 24, 3), CInt(LatG.Text) + CInt(LatP.Text) / 60, CInt(LongG.Text) + CInt(LongP.Text) / 60, 1)
                Draw(gr, PenRed, prev_n, prev_y, n, SunAlt)
                objWriter.WriteLine("SUN HIPOS" & vbTab & n & vbTab & Convert.ToSingle(SunAlt))
                prev_n = n
                prev_y = Convert.ToSingle(SunAlt)
            Next n

            Dim LatDG As Double
            Dim LongDG As Double
            LatDG = DegDecimal(CInt(LatG.Text), CInt(LatP.Text), CDbl(LatS.Text))
            LongDG = DegDecimal(CInt(LongG.Text), CInt(LongP.Text), CDbl(LongS.Text))

            'LUNA
            'Dim MoonFile As String = "C:\Users\Roberto\Documents\YouTubeResource\Moon_ico.bmp"
            'Dim bm_moon As New Bitmap(MoonFile)
            Dim bm_moon As New Bitmap(myAsm.GetManifestResourceStream(Me.GetType, "Moon_ico.bmp")) 'set azione di compilazione dell'immagine = risorsa incorporata
            Dim MaxMoonN, MaxMoonAlt As Single
            bm_moon.MakeTransparent(Color.FromArgb(255, 2, 2, 2))
            For n = 0 To 24 Step 0.1
                Counter = Counter + 1
                MoonAlt = altaz(j + n / 24, tmoon(j + n / 24, LatDG, LongDG, 2), tmoon(j + n / 24, LatDG, LongDG, 3), CInt(LatG.Text) + CInt(LatP.Text) / 60, CInt(LongG.Text) + CInt(LongP.Text) / 60, 1)
                If Counter > 1 Then Draw(gr, PenLightWhite, prev_n, prev_y, n, Convert.ToSingle(MoonAlt))
                If Convert.ToSingle(MoonAlt) > MaxMoonAlt Then
                    MaxMoonN = n
                    MaxMoonAlt = Convert.ToSingle(MoonAlt)
                End If
                objWriter.WriteLine("MOON" & vbTab & n & vbTab & Convert.ToSingle(MoonAlt))
                prev_n = n
                prev_y = Convert.ToSingle(MoonAlt)
            Next n
            DrawLogicPicture(gr, bm_moon, MaxMoonN, MaxMoonAlt)


            'ALTEZZA =====================================================================================
            Dim Ytop As Single = MAXALT - MAXALT Mod 50 + 50
            Dim Ybot As Single = MINALT - MINALT Mod 50

            SetDisplayPhysicalArea(picGraph, 960, 540, 400, 200, 500, 110)
            SetScale(NumtimeStart, NumtimeStop, Ybot, Ytop)
            Frame(gr, PenGreen)
            Axes(gr, PenGreen, HourStart, 0, 10, 10)
            Axes(gr, PenGreen, NumtimeStart, 0, 1000, 10)
            Grid(gr, PenGreen, HourStart, 0, 3, 50)
            GraphTitle(gr, "Profilo altimetrico", "Arbutus Slab", 12)
            XTitle(gr, "Ora locale", "Verdana", 8)
            YTitle(gr, "Altezza metri", "Verdana", 8)
            XTickLabel(gr, HourStart, 1, "Verdana", 7)
            YTickLabel(gr, 0, 50, "Verdana", 7)
            GetPhysicalCoords(NumtimeStart, Ytop, LBX, LBY)
            GetPhysicalCoords(NumtimeStop, Ytop, RBX, RBY)
            gr.DrawLine(PenCyan, LTX, LTY, LBX, LBY)
            gr.DrawLine(PenCyan, RTX, RTY, RBX, RBY)
            Dim ALTTime As Single
            Dim ALTY As Single

            'MsgBox(DateDiff(DateInterval.Second, CType(MINUTC.ToShortDateString, Date), MINUTC) / 3600)
            For n = 1 To GIS.GetUpperBound(1)
                ALTTime = (DateDiff(DateInterval.Second, CType(MINUTC.ToShortDateString, Date), MINUTC) / 3600) + CType(DateDiff(DateInterval.Second, MINUTC, CType(GIS(UTC, n), Date)), Single) / 3600
                ALTY = CType(GIS(ALT, n).Replace(".", ","), Single) '- MINALT) '/ (MAXALT - MINALT) * 90
                If n > 1 Then Draw(gr, PenYellow, prev_n, prev_y, ALTTime, ALTY)
                prev_n = ALTTime
                prev_y = ALTY
                objWriter.WriteLine("ALTEZZA" & vbTab & ALTTime & vbTab & ALTY)
            Next n


            'DISTANZA
            'Dim DSTTime As Single
            'Dim DTSY As Single
            'Using plot_pen As New Pen(Color.GreenYellow, 0)
            '    'MsgBox(DateDiff(DateInterval.Second, CType(MINUTC.ToShortDateString, Date), MINUTC) / 3600)
            '    For n = 2 To GIS.GetUpperBound(1)
            '        DSTTime = (DateDiff(DateInterval.Second, CType(MINUTC.ToShortDateString, Date), MINUTC) / 3600) + CType(DateDiff(DateInterval.Second, MINUTC, CType(GIS(UTC, n), Date)), Single) / 3600 - Xmin
            '        DTSY = CType(GIS(DST, n).Replace(".", ","), Single) / DistanceTot * 90
            '        If n > 2 Then gr.DrawLine(plot_pen, prev_n, prev_y, DSTTime, DTSY)
            '        prev_n = DSTTime
            '        prev_y = DTSY
            '    Next n
            'End Using

            'VELOCITÀ
            Dim YtopS As Single = PeakSpeed - PeakSpeed Mod 10 + 10
            SetDisplayPhysicalArea(picGraph, 960, 540, 400, 35, 500, 110)
            SetScale(NumtimeStart, NumtimeStop, 0, YtopS)
            Frame(gr, PenGreen)
            Axes(gr, PenGreen, HourStart, 0, 1, 5)
            Axes(gr, PenGreen, NumtimeStart, 0, 1000, 5)
            Grid(gr, PenGreen, HourStart, 0, 3, 10)
            GraphTitle(gr, "Velocità", "Arbutus Slab", 12)
            XTitle(gr, "Ora locale", "Verdana", 8)
            YTitle(gr, "Velocità Km/h", "Verdana", 8)
            XTickLabel(gr, HourStart, 1, "Verdana", 7)
            YTickLabel(gr, 0, 20, "Verdana", 7)

            Dim SPDTime As Single
            Dim SPDY As Single

            'MsgBox(DateDiff(DateInterval.Second, CType(MINUTC.ToShortDateString, Date), MINUTC) / 3600)
            For n = 2 To GIS.GetUpperBound(1)
                SPDTime = (DateDiff(DateInterval.Second, CType(MINUTC.ToShortDateString, Date), MINUTC) / 3600) + CType(DateDiff(DateInterval.Second, MINUTC, CType(GIS(UTC, n), Date)), Single) / 3600
                SPDY = CType(GIS(SPD, n).Replace(".", ","), Single) * 3600 / 1000
                If n > 2 Then Draw(gr, PenYellow, prev_n, prev_y, SPDTime, SPDY)
                prev_n = SPDTime
                prev_y = SPDY
            Next n

            objWriter.Close()
            'Dim LogoFile As String = "C:\Users\Roberto\Documents\YouTubeResource\Logo_BTS_midi.bmp"
            'Dim bm_logo As New Bitmap(LogoFile)
            Dim bm_logo As New Bitmap(myAsm.GetManifestResourceStream(Me.GetType, "Logo_BTS_midi.bmp"))
            bm_logo.MakeTransparent(Color.Black)
            gr.DrawImage(bm_logo, (bm_logo.Width - bm_logo.Width) \ 2 + 75, bm_logo.Height - bm_logo.Height + 350)

        End Using

        picGraph.Image = bm

        Me.Cursor = Cursors.Default

        If BMPSave = True Then
            Clipboard.SetDataObject(DirectCast(picGraph.Image.Clone, Bitmap), True)
            InFile = Replace(InFile, ".gpx", ".bmp")
            bm.Save(InFile, System.Drawing.Imaging.ImageFormat.Bmp)
            BMPSave = False
        End If
    End Sub


    Private Sub CalcolaAltezzaSoleLuna()
        Dim y As Integer = Year(DateTimePicker1.Value)
        Dim m As Integer = Month(DateTimePicker1.Value)
        Dim d As Integer = DateAndTime.Day(DateTimePicker1.Value)
        Dim j As Double = Days2000(y, m, d, 0, 0, 0, 1)
        Dim msg As String = ""
        Dim SunAlt As Double
        Dim MoonAlt As Double
        Dim LatDG As Double
        Dim LongDG As Double

        LatDG = DegDecimal(CInt(LatG.Text), CInt(LatP.Text), CDbl(LatS.Text))
        LongDG = DegDecimal(CInt(LongG.Text), CInt(LongP.Text), CDbl(LongS.Text))

        For n = 0 To 24
            SunAlt = altaz(j + n / 24, sun(j + n / 24, 2), sun(j + n / 24, 3), CInt(LatG.Text) + CInt(LatP.Text) / 60, CInt(LongG.Text) + CInt(LongP.Text) / 60, 1)
            msg = "SUN" & vbCrLf & msg & vbCrLf & CStr(SunAlt)
            MoonAlt = altaz(j + n / 24, tmoon(j + n / 24, LatDG, LongDG, 2), tmoon(j + n / 24, LatDG, LongDG, 3), CInt(LatG.Text) + CInt(LatP.Text) / 60, CInt(LongG.Text) + CInt(LongP.Text) / 60, 1)
            msg = "MOON" & vbCrLf & msg & vbCrLf & CStr(MoonAlt)
        Next n

        MsgBox(LatDG & " " & LongDG & vbCrLf & msg)

    End Sub


    Private Sub ButtonGPX_Click(sender As Object, e As EventArgs) Handles ButtonGPX.Click
        Dim openfiledlg As New OpenFileDialog
        openfiledlg.Filter = "File GPX (*.gpx)|*.gpx"
        Dim result As DialogResult = openfiledlg.ShowDialog()

        If result = Windows.Forms.DialogResult.OK Then
            GPXFileName = openfiledlg.FileName
            RenderData()
        End If

    End Sub

    Private Sub RenderData()
        Dim GIS(,) As String
        Dim MINLAT As Single = 1000000.0
        Dim MAXLAT As Single
        Dim MINLON As Single = 1000000.0
        Dim MAXLON As Single
        Dim MINUTC As Date = Now
        Dim MAXUTC As Date
        Dim MINALT As Single = 1000000.0
        Dim MAXALT As Single
        Dim MEANLAT As Single
        Dim MEANLON As Single
        Dim n As Integer
        Dim Distance As Double = 0
        Dim DistanceTot As Double = 0
        Dim Course As Double = 0
        Dim Source As wptType
        Dim Destination As wptType
        Dim CurrentSpeed As Double = 0
        Dim MaxSpeed As Double = 0
        Dim PrevInstant As Date
        Dim CurrInstant As Date
        Dim FILE_NAME As String = "GIS.CSV"
        Dim objWriter As New System.IO.StreamWriter(FILE_NAME)
        Dim MovingTime As Single
        Dim MovingDistance As Single
        Dim TotalHigh As Single
        Dim TotalDesc As Single
        Dim AverageALTP As Single
        Dim AverageALTC As Single

        objWriter.WriteLine("n" & vbTab & "Course" & vbTab & "Distance" & vbTab & "CurrentSpeed" & vbTab & "ALT" & vbTab & "LAT" & vbTab & "LON" & vbTab & "UTC" & vbTab & "LOCALDATE" & vbTab & "LOCALTIME")

        GIS = GPX.ReadGPX(GPXFileName)

        For n = 1 To GIS.GetUpperBound(1)
            If CType(GIS(LAT, n).Replace(".", ","), Single) > MAXLAT Then MAXLAT = CType(GIS(LAT, n).Replace(".", ","), Single)
            If CType(GIS(LON, n).Replace(".", ","), Single) > MAXLON Then MAXLON = CType(GIS(LON, n).Replace(".", ","), Single)
            If CType(GIS(ALT, n).Replace(".", ","), Single) > MAXALT Then MAXALT = CType(GIS(ALT, n).Replace(".", ","), Single)
            If GIS(UTC, n) > MAXUTC Then MAXUTC = GIS(UTC, n)

            If CType(GIS(LAT, n).Replace(".", ","), Single) < MINLAT Then MINLAT = CType(GIS(LAT, n).Replace(".", ","), Single)
            If CType(GIS(LON, n).Replace(".", ","), Single) < MINLON Then MINLON = CType(GIS(LON, n).Replace(".", ","), Single)
            If CType(GIS(ALT, n).Replace(".", ","), Single) < MINALT Then MINALT = CType(GIS(ALT, n).Replace(".", ","), Single)
            If GIS(UTC, n) < MINUTC Then MINUTC = GIS(UTC, n)

            If n = 1 Then
                Source.lat = CType(GIS(LAT, n).Replace(".", ","), Single)
                Source.lon = CType(GIS(LON, n).Replace(".", ","), Single)
                Source.ele = CType(GIS(ALT, n).Replace(".", ","), Single)
            End If

            Destination.lat = CType(GIS(LAT, n).Replace(".", ","), Single)
            Destination.lon = CType(GIS(LON, n).Replace(".", ","), Single)
            Destination.ele = CType(GIS(ALT, n).Replace(".", ","), Single)

            If n > 1 Then
                GetCourseAndDistance(Source, Destination, Course, Distance)
                DistanceTot += Distance
                GIS(DST, n) = DistanceTot
                PrevInstant = GIS(UTC, n - 1)
                CurrInstant = GIS(UTC, n)
                CurrentSpeed = Distance / DateDiff(DateInterval.Second, PrevInstant, CurrInstant)
                GIS(SPD, n) = CurrentSpeed
                If CurrentSpeed > MaxSpeed Then MaxSpeed = CurrentSpeed
                If n > MM + 1 Then
                    For m = n To (n - MM) Step -1
                        AverageALTC += CType(GIS(ALT, m).Replace(".", ","), Single)
                        AverageALTP += CType(GIS(ALT, m - 1).Replace(".", ","), Single)
                    Next m
                    AverageALTC = AverageALTC / MM
                    AverageALTP = AverageALTP / MM
                    If AverageALTC > AverageALTP Then TotalHigh += AverageALTC - AverageALTP
                    If AverageALTC < AverageALTP Then TotalDesc += AverageALTP - AverageALTC
                End If
                If CurrentSpeed > SpeedThreshold Then
                    MovingTime += DateDiff(DateInterval.Second, PrevInstant, CurrInstant)
                    MovingDistance += Distance
                End If
                Source = Destination
            End If
            objWriter.WriteLine(n & vbTab & Course & vbTab & Distance & vbTab & (CurrentSpeed / 1000 * 3600) & vbTab & CType(GIS(ALT, n).Replace(".", ","), Single) & vbTab & CType(GIS(LAT, n).Replace(".", ","), Single) & vbTab & CType(GIS(LON, n).Replace(".", ","), Single) & vbTab & GIS(UTC, n) & vbTab & Format(CurrInstant, "dd/MM/yyyy") & vbTab & Format(CurrInstant, "HH:mm:ss"))

        Next n

        objWriter.Close()

        DateTimePicker1.Value = MINUTC

        Dim Degrees As String

        MEANLAT = (MINLAT + MAXLAT) / 2
        MEANLON = (MINLON + MAXLON) / 2

        Degrees = DecimalPosToDegrees(MEANLAT, enumLongLat.Latitude, enumReturnformat.WithSigns)
        LatG.Text = Degrees.ToString.Substring(0, InStr(Degrees, "°") - 1)
        LatP.Text = Degrees.ToString.Substring(InStr(Degrees, "°"), InStr(Degrees, """") - InStr(Degrees, "°") - 1)
        LatS.Text = Degrees.ToString.Substring(InStr(Degrees, """"), InStr(Degrees, "'") - InStr(Degrees, """") - 1)
        LatQ.Text = Degrees.ToString.Substring(Degrees.ToString.Length - 1)
        Degrees = DecimalPosToDegrees(MEANLON, enumLongLat.Longitude, enumReturnformat.WithSigns)
        LongG.Text = Degrees.ToString.Substring(0, InStr(Degrees, "°") - 1)
        LongP.Text = Degrees.ToString.Substring(InStr(Degrees, "°"), InStr(Degrees, """") - InStr(Degrees, "°") - 1)
        LongS.Text = Degrees.ToString.Substring(InStr(Degrees, """"), InStr(Degrees, "'") - InStr(Degrees, """") - 1)
        LongQ.Text = Degrees.ToString.Substring(Degrees.ToString.Length - 1)


        Dim MeanSpeed As Single = (DistanceTot / 1000) / (DateDiff(DateInterval.Second, MINUTC, MAXUTC) / 3600)
        Dim PeakSpeed As Single = MaxSpeed * 3600 / 1000

        RenderGraph(Titolo.Text, MINALT, MAXALT, MINUTC, MAXUTC, MeanSpeed, PeakSpeed, DistanceTot, MovingTime, TotalHigh, TotalDesc, GIS, GPXFileName)

    End Sub

    Private Sub Master_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        TrackBarSogliaMovimento.Maximum = 1
        TrackBarSogliaMovimento.Maximum = 20
        TrackBarSogliaMovimento.Value = 5
        SpeedThresholdLBL.Text = "0,5 Km/h"
        SpeedThreshold = 0.5

        TrackBarMM.Maximum = 50
        TrackBarMM.Minimum = 3
        TrackBarMM.Value = 10
        MM = 10
        MMLBL.Text = "10 elementi"
    End Sub

    Private Sub SaveBMP_Click(sender As Object, e As EventArgs) Handles SaveBMP.Click
        BMPSave = True
        If GPXFileName <> "" Then RenderData()
    End Sub


    Private Sub Titolo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Titolo.KeyPress
        If e.KeyChar = vbCr Then
            If GPXFileName <> "" Then RenderData()
        End If
    End Sub

    Private Sub TrackBarSogliaMovimento_Scroll(sender As Object, e As EventArgs) Handles TrackBarSogliaMovimento.Scroll
        SpeedThreshold = TrackBarSogliaMovimento.Value / 10
        SpeedThresholdLBL.Text = SpeedThreshold & " Km/h"
        If GPXFileName <> "" Then RenderData()
    End Sub

    Private Sub TrackBarMM_Scroll(sender As Object, e As EventArgs) Handles TrackBarMM.Scroll
        MM = TrackBarMM.Value
        MMLBL.Text = TrackBarMM.Value & " elementi"
        If GPXFileName <> "" Then RenderData()
    End Sub

End Class

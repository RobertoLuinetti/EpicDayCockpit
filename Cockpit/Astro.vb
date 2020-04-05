Module Astro

    Public Const PI As Double = 3.14159265358979
    Public Const tpi As Double = 6.28318530717958
    Public Const degs As Double = 57.2957795130823
    Public Const rads As Double = 0.0174532925199433

    ' returns Julian day number, greg is switch for Gregorian
    ' or Julian calendars. Default is gregorian.
    Function jDay(year As Integer, month As Integer, day As Integer, hour As Integer, min As Integer, sec As Double, Optional greg As Integer = 10000) As Double
        Dim a As Double
        Dim B As Integer
        a = 10000.0# * year + 100.0# * month + day
        If (a < -47120101) Then
            MsgBox("Warning: date too early for algorithm")
        End If
        If ((greg) = 10000) Then greg = 1
        If (month <= 2) Then
            month = month + 12
            year = year - 1
        End If
        If (greg = 0) Then
            B = -2 + Fix((year + 4716) / 4) - 1179
        Else
            B = Fix(year / 400) - Fix(year / 100) + Fix(year / 4)
        End If
        a = 365.0# * year + 1720996.5
        jDay = a + B + Fix(30.6001 * (month + 1))
        jDay = jDay + day + (hour + min / 60 + sec / 3600) / 24
    End Function

    ' Returns days after 12:00 1/1/2000, greg switch for Gregorian or
    ' Julian calendar - default is Gregorian.
    '


    Function DegArctan(x As Double) As Double
        DegArctan = degs * Math.Atan(x)
        Return DegArctan
    End Function

    Function DegAtan2(y As Double, x As Double) As Double
        DegAtan2 = degs * Math.Atan2(y, x)
        If DegAtan2 < 0 Then DegAtan2 = DegAtan2 + 360
        Return DegAtan2
    End Function

    Function spherical(x As Double, y As Double, z As Double, Index As Integer) As Double
        Dim rho As Double
        rho = x * x + y * y
        Select Case Index
            Case 1
                spherical = Math.Sqrt(rho + z * z)    'returns r
            Case 2
                rho = Math.Sqrt(rho)
                spherical = DegArctan(z / rho)    'returns theta
            Case 3
                rho = Math.Sqrt(rho)
                spherical = DegAtan2(y, x)      'returns phi
        End Select
        Return spherical
    End Function

    Function sun(d As Double, Index As Integer) As Double
        sun = sequatorial(ssun(d, 1), ssun(d, 2), ssun(d, 3), d, Index)
        Return sun
    End Function

    ' returns ecliptic longitude and distance of Sun given
    ' days after J2000.0. Based on method in AA
    Function ssun(d As Double, Index As Integer) As Double
        Dim g As Double
        Dim L As Double
        Dim lambda As Double
        g = range360(357.528 + 0.9856003 * d)
        L = range360(280.461 + 0.9856474 * d)
        Select Case Index
            Case 1
                ssun = 1.00014 - 0.01671 * DegCos(g) - 0.00014 * DegCos(2 * g)
            Case 2
                ssun = 0    'ecliptic latitude of Sun is zero
            Case 3
                ssun = range360(L + 1.915 * DegSin(g) + 0.02 * DegSin(2 * g))
            Case 4  'equation of time
                lambda = range360(L + 1.915 * DegSin(g) + 0.02 * DegSin(2 * g))
                ssun = -1.915 * DegSin(g) - 0.02 * DegSin(2 * g)
                ssun = ssun + 2.466 * DegSin(2 * lambda)
                ssun = ssun - 0.053 * DegSin(4 * lambda)
        End Select
        Return ssun
    End Function

    Public Function range360(x)
        range360 = x - 360 * Int(x / 360)
        Return range360
    End Function

    ' returns equatorial coords given geocentric ecliptic coords
    Function sequatorial(R As Double, theta As Double, phi As Double, d As Double, Index As Integer) As Double
        Dim x As Double, y As Double, z As Double
        x = Rectangular(R, theta, phi, 1)
        y = Rectangular(R, theta, phi, 2)
        z = Rectangular(R, theta, phi, 3)
        sequatorial = spherical(requatorial(x, y, z, d, 1), requatorial(x, y, z, d, 2), requatorial(x, y, z, d, 3), Index)
        Return sequatorial
    End Function

    ' given geocentric ecliptic coordinates, returns geocentric
    ' equatorial coordinates - all cartesian. NB, d is epoch of
    ' frame, use d = 0 if working in J2000.0 frame
    Function requatorial(x As Double, y As Double, z As Double,
    d As Double, Index As Integer) As Double
        Dim obl As Double
        obl = obliquity(d)
        Select Case Index
            Case 1
                requatorial = x
            Case 2
                requatorial = y * DegCos(obl) - z * DegSin(obl)
            Case 3
                requatorial = y * DegSin(obl) + z * DegCos(obl)
        End Select
        Return requatorial
    End Function

    Public Function obliquity(d As Double, Optional Index As Double = 1000000.0) As Double
        ' returns the mean obliquity of equator given date in days after J2000.0
        ' i.e nutation is not taken into account
        ' Simon Telescopium 2010-10-17
        ' modified original to include an index to calculate...
        ' the mean (index missing)
        ' the true obliquity index = 1
        ' based on Meeus ch 22 based on the lower accuracy model accurate to 0.1 arc seconds!
        ' DEPENDENCIES
        ' DegCos()

        Dim T As Double
        T = d / 36525   'julian centuries since J2000.0
        obliquity = -(46.815 + (0.00059 - 0.001813 * T) * T) * T / 3600.0#
        obliquity = obliquity + 23.43929111
        If (Index = 1000000.0) Then 'If IsMissing(Index) Then
            'do nothing
        Else
            'calculate nutation

            Dim ohm As Double
            ohm = 125.04452 - 1934.136261 * T
            Dim L As Double
            L = 280.4665 + 36000.7698 * T
            Dim Lprime As Double
            Lprime = 218.3165 + 481267.8813 * T
            Dim nutation As Double
            nutation = (9.2 / 3600) * DegCos(ohm) + (0.57 / 3600) * DegCos(2 * L) + (0.1 / 3600) * DegCos(2 * Lprime) - (0.09 / 3600) * DegCos(2 * ohm)
            obliquity = obliquity + nutation
        End If
        Return obliquity

    End Function

    ' Given polar coords, returns cartesian coords
    ' r is radius vector, theta is declination like angle, phi is
    ' RA like angle. Index = 1 returns x coord and so on
    Function Rectangular(R As Double, theta As Double, phi As Double,
     Index As Integer) As Double
        Dim r_cos_theta As Double
        r_cos_theta = R * DegCos(theta)
        Select Case Index
            Case 1
                Rectangular = r_cos_theta * DegCos(phi) 'returns x coord
            Case 2
                Rectangular = r_cos_theta * DegSin(phi) 'returns y coord
            Case 3
                Rectangular = R * DegSin(theta)         'returns z coord
        End Select
        Return Rectangular
    End Function

    ' Trig functions working in degrees
    Function DegSin(x As Double) As Double
        DegSin = Math.Sin(rads * x)
        Return DegSin
    End Function

    Function DegArcsin(x As Double) As Double
        DegArcsin = degs * Math.Asin(x)
        Return DegArcsin
    End Function

    Function DegArccos(x As Double) As Double
        DegArccos = degs * Math.Acos(x)
        Return DegArccos
    End Function

    Function DegCos(x As Double) As Double
        DegCos = Math.Cos(rads * x)
        Return DegCos
    End Function
    ' Returns days after 12:00 1/1/2000, greg switch for Gregorian or
    ' Julian calendar - default is Gregorian.
    Public Function Days2000(year As Integer, month As Integer, day As Integer,
    hour As Integer, min As Integer, sec As Double, Optional greg As Integer = 1) _
    As Double
        Dim a As Double
        Dim B As Integer
        If ((greg) = 1) Then greg = 1
        a = 10000.0# * year + 100.0# * month + day
        If (month <= 2) Then
            month = month + 12
            year = year - 1
        End If
        If (greg = 0) Then
            B = -2 + Fix((year + 4716) / 4) - 1179
        Else
            B = Fix(year / 400) - Fix(year / 100) + Fix(year / 4)
        End If
        a = 365.0# * year - 730548.5
        Days2000 = a + B + Fix(30.6001 * (month + 1))
        Days2000 = Days2000 + day + (hour + min / 60 + sec / 3600) / 24
        Return Days2000
    End Function

    ' returns altitude and azimuth of object given RA and DEC of
    ' object, latitude and longitude of observer and days after
    ' J2000.0 From Practial Astronomy with your calculator, 2nd edition eq 25, Peter Duffett-Smith

    Function altaz(d As Double, DEC As Double, RA As Double, GLat As Double, GLong As Double, Index As Integer) As Double
        Dim h As Double, a As Double, sa As Double, cz As Double
        h = gst(d) + GLong - RA
        sa = DegSin(DEC) * DegSin(GLat)
        sa = sa + DegCos(DEC) * DegCos(GLat) * DegCos(h)
        a = DegArcsin(sa)
        cz = DegSin(DEC) - DegSin(GLat) * sa
        cz = cz / (DegCos(GLat) * DegCos(a))
        Select Case Index
            Case 1  'altitude
                altaz = a
            Case 2  'azimuth
                If DegSin(h) < 0 Then
                    altaz = DegArccos(cz)
                Else
                    altaz = 360 - DegArccos(cz)
                End If
        End Select
        Return altaz
    End Function

    ' returns siderial time at longitude zero given days
    ' after J2000.0
    Function gst(days As Double) As Double
        Dim T As Double
        T = days / 36525
        gst = 280.46061837 + 360.98564736629 * days
        gst = gst + 0.000387933 * T ^ 2 - T ^ 3 / 38710000
        gst = range360(gst)
        Return gst
    End Function

    ' returns topocentric coords of moon given days after J2000.0
    ' observer's latitude and longitude.
    Function tmoon(DaysAfterJ2000 As Double, GLat As Double, GLong As Double, Index As Integer) As Double
        Dim x As Double, y As Double, z As Double, xt As Double,
        yt As Double, zt As Double, R As Double, xe As Double,
        ye As Double, ze As Double, lst As Double
        x = rmoon(DaysAfterJ2000, 1)
        y = rmoon(DaysAfterJ2000, 2)
        z = rmoon(DaysAfterJ2000, 3)
        xe = requatorial(x, y, z, DaysAfterJ2000, 1)
        ye = requatorial(x, y, z, DaysAfterJ2000, 2)
        ze = requatorial(x, y, z, DaysAfterJ2000, 3)
        R = rLength(x, y, z)
        lst = gst(DaysAfterJ2000) + GLong
        xt = xe - DegCos(GLat) * DegCos(lst)
        yt = ye - DegCos(GLat) * DegSin(lst)
        zt = ze - DegSin(GLat)
        tmoon = spherical(xt, yt, zt, Index)
        Return tmoon
    End Function

    ' rectangular version of above
    Function rmoon(d As Double, Index As Integer) As Double
        rmoon = Rectangular(smoon(d, 1), smoon(d, 2), smoon(d, 3), Index)
        Return rmoon
    End Function

    ' returns ecliptic longitide, latitude and distance of Moon
    ' (geocentric) given days after J2000.0
    Function smoon(ByVal d As Double, Index As Integer) As Double
        Dim Nm As Double, im As Double, wm As Double,
        am As Double, ecm As Double,
        Mm As Double, em As Double, Ms As Double,
        ws As Double, xv As Double,
        yv As Double, vm As Double, rm As Double, x As Double,
        y As Double, z As Double, lon As Double, lat As Double,
        ls As Double, lm As Double,
        dm As Double, f As Double, dlon As Double, dlat As Double
        d = d + 1.5     'epoch of theory is not same as J2000.0
        Nm = range360(125.1228 - 0.0529538083 * d) * rads
        im = 5.1454 * rads
        wm = range360(318.0634 + 0.1643573223 * d) * rads
        am = 60.2666  '(Earth radii)
        ecm = 0.0549
        Mm = range360(115.3654 + 13.0649929509 * d) * rads
        em = Mm + ecm * Math.Sin(Mm) * (1.0# + ecm * Math.Cos(Mm))
        xv = am * (Math.Cos(em) - ecm)
        yv = am * (Math.Sqrt(1.0# - ecm * ecm) * Math.Sin(em))
        vm = Math.Atan2(yv, xv)
        rm = Math.Sqrt(xv * xv + yv * yv)
        x = Math.Cos(Nm) * Math.Cos(vm + wm) - Math.Sin(Nm) * Math.Sin(vm + wm) * Math.Cos(im)
        x = rm * x
        y = Math.Sin(Nm) * Math.Cos(vm + wm) + Math.Cos(Nm) * Math.Sin(vm + wm) * Math.Cos(im)
        y = rm * y
        z = rm * (Math.Sin(vm + wm) * Math.Sin(im))
        lon = Math.Atan2(y, x)
        If lon < 0 Then lon = tpi + lon
        lat = Math.Atan(z / Math.Sqrt(x * x + y * y))
        ws = range360(282.9404 + 0.0000470935 * d) * rads
        Ms = range360(356.047 + 0.9856002585 * d) * rads
        ls = Ms + ws       'Mean Longitude of the Sun  (Ns=0)
        lm = Mm + wm + Nm  'Mean longitude of the Moon
        dm = lm - ls        'Mean elongation of the Moon
        f = lm - Nm        'Argument of latitude for the Moon
        Select Case Index
            Case 1  '   distance terms earth radii
                rm = rm - 0.58 * Math.Cos(Mm - 2 * dm)
                rm = rm - 0.46 * Math.Cos(2 * dm)
                smoon = rm
            Case 2  '   latitude terms
                dlat = -0.173 * Math.Sin(f - 2 * dm)
                dlat = dlat - 0.055 * Math.Sin(Mm - f - 2 * dm)
                dlat = dlat - 0.046 * Math.Sin(Mm + f - 2 * dm)
                dlat = dlat + 0.033 * Math.Sin(f + 2 * dm)
                dlat = dlat + 0.017 * Math.Sin(2 * Mm + f)
                smoon = lat * degs + dlat
            Case 3  '   longitude terms
                dlon = -1.274 * Math.Sin(Mm - 2 * dm)        '(the Evection)
                dlon = dlon + 0.658 * Math.Sin(2 * dm)       '(the Variation)
                dlon = dlon - 0.186 * Math.Sin(Ms)     '(the Yearly Equation)
                dlon = dlon - 0.059 * Math.Sin(2 * Mm - 2 * dm)
                dlon = dlon - 0.057 * Math.Sin(Mm - 2 * dm + Ms)
                dlon = dlon + 0.053 * Math.Sin(Mm + 2 * dm)
                dlon = dlon + 0.046 * Math.Sin(2 * dm - Ms)
                dlon = dlon + 0.041 * Math.Sin(Mm - Ms)
                dlon = dlon - 0.035 * Math.Sin(dm) '(the Parallactic Equation)
                dlon = dlon - 0.031 * Math.Sin(Mm + Ms)
                dlon = dlon - 0.015 * Math.Sin(2 * f - 2 * dm)
                dlon = dlon + 0.011 * Math.Sin(Mm - 4 * dm)
                smoon = lon * degs + dlon
        End Select
        Return smoon
    End Function

    ' given cartesian coords, returns distance
    Function rLength(x As Double, y As Double, z As Double) As Double
        rLength = Math.Sqrt(x * x + y * y + z * z)
        Return rLength
    End Function

    ' converts degs min sec to decimal deg
    Function DegDecimal(Degrees, Minutes, Seconds)
        'DegDecimal = d + m / 60 + s / 3600
        ' Corrected by SimonTelescopium so that it works with negative degrees correctly i.e.
        ' -45 degrees, 30 minutes and 30 seconds the minutes and seconds are assumed negative if the degrees are negative
        If Degrees < 0 Then
            If Minutes > 0 Then
                Minutes = Minutes * (-1)
            End If
            If Seconds > 0 Then
                Seconds = Seconds * (-1)
            End If
        End If
        DegDecimal = Degrees + (Minutes / 60) + (Seconds / 3600)
        Return DegDecimal
    End Function

End Module



Module Plotter
    Public Xratio As Single
    Public Yratio As Single
    Public PXSpan As Single
    Public PYSpan As Single
    Public PX0 As Single
    Public PY0 As Single
    Public Xmin As Single
    Public Xmax As Single
    Public Ymin As Single
    Public Ymax As Single
    Public Xwide As Integer
    Public Ywide As Integer
    Public PY0R As Single
    Public PX0R As Single

    Public PenRed As New Pen(Color.Red, 0)
    Public PenGreen As New Pen(Color.Green, 0)
    Public PenYellow As New Pen(Color.Yellow, 0)
    Public PenBlue As New Pen(Color.Blue, 0)
    Public PenDarkBlue As New Pen(Color.DarkBlue, 0)
    Public PenLightGreen As New Pen(Color.LightGreen, 0)
    Public PenLightWhite As New Pen(Color.WhiteSmoke, 0)
    Public PenCyan As New Pen(Color.Cyan, 0)

    Public Sub SetDisplayPhysicalArea(VpicGraph As PictureBox, XWAreaPix As Single, YHAreaPix As Single, X0pix As Single, Y0pix As Single, XWDisplayPix As Single, YHDisplayPix As Single)
        VpicGraph.Width = XWAreaPix
        VpicGraph.Height = YHAreaPix
        Xwide = VpicGraph.ClientSize.Width
        Ywide = VpicGraph.ClientSize.Height
        PX0 = X0pix
        PY0 = Ywide - Y0pix
        PXSpan = XWDisplayPix
        PYSpan = YHDisplayPix
        PY0R = Y0pix
        PX0R = X0pix
    End Sub

    Public Sub SetScale(XL As Single, XR As Single, YB As Single, YT As Single)
        Xmin = XL
        Xmax = XR
        Ymin = YB
        Ymax = YT
        Xratio = (Xmax - Xmin) / PXSpan
        Yratio = (Ymax - Ymin) / PYSpan
    End Sub

    Public Sub Frame(gr As Graphics, P As Pen)
        gr.DrawLine(P, PX0, PY0, PX0 + PXSpan, PY0)
        gr.DrawLine(P, PX0 + PXSpan, PY0, PX0 + PXSpan, PY0 - PYSpan)
        gr.DrawLine(P, PX0 + PXSpan, PY0 - PYSpan, PX0, PY0 - PYSpan)
        gr.DrawLine(P, PX0, PY0 - PYSpan, PX0, PY0)
    End Sub

    Public Sub Draw(gr As Graphics, P As Pen, x1 As Single, y1 As Single, x2 As Single, y2 As Single)
        If (y1 > Ymax And y2 > Ymax) Or (y1 < Ymin And y2 < Ymin) Or (x1 > Xmax And x2 > Xmax) Or (x1 < Xmin And x2 < Xmin) Then
        Else
            If x2 > Xmax Then
                y2 = ((y2 - y1) / (x2 - x1)) * (Xmax - x1) + y1
                x2 = Xmax
            End If
            If x2 < Xmin Then
                y2 = ((y2 - y1) / (x2 - x1)) * (Xmax - x1) + y1
                x2 = Xmin
            End If
            If y2 > Ymax Then
                x2 = ((x2 - x1) * (Ymax - y1)) / (y2 - y1) + x1
                y2 = Ymax
            End If
            If y2 < Ymin Then
                x2 = ((x2 - x1) * (Ymin - y1)) / (y2 - y1) + x1
                y2 = Ymin
            End If
            gr.DrawLine(P, PX0 - Xmin / Xratio + x1 / Xratio, PY0 + Ymin / Yratio + y1 / Yratio * -1, PX0 - Xmin / Xratio + x2 / Xratio, PY0 + Ymin / Yratio + y2 / Yratio * -1)
        End If
    End Sub

    Public Sub DrawLogicRect(gr As Graphics, C As Color, RX0 As Single, RY0 As Single, Xw As Single, Yh As Single)
        Dim myPen As New Pen(C)
        Dim mySolidBrush As New SolidBrush(C)
        gr.DrawRectangle(myPen, PX0 - Xmin / Xratio + RX0 / Xratio, PY0 + Ymin / Yratio + RY0 / Yratio * -1 - Yh / Yratio, Xw / Xratio, Yh / Yratio)
        gr.FillRectangle(mySolidBrush, PX0 - Xmin / Xratio + RX0 / Xratio, PY0 + Ymin / Yratio + RY0 / Yratio * -1 - Yh / Yratio, Xw / Xratio, Yh / Yratio)
    End Sub

    Public Sub DrawLogicPicture(gr As Graphics, BM As Bitmap, RX0 As Single, RY0 As Single)
        gr.DrawImage(BM, PX0 - Xmin / Xratio + RX0 / Xratio - Convert.ToSingle(BM.Width / 2), PY0 + Ymin / Yratio + RY0 / Yratio * -1 - Convert.ToSingle(BM.Height / 2))
    End Sub

    Public Sub Plot(gr As Graphics, C As Color, x1 As Single, y1 As Single)
        Dim BMP As New Bitmap(1, 1)
        BMP.SetPixel(0, 0, C)
        If (y1 > Ymax) Or (y1 < Ymin) Or (x1 > Xmax) Or (x1 < Xmin) Then
        Else
            'gr.DrawRectangle(P, PX0 - Xmin / Xratio + x1 / Xratio, PY0 + Ymin / Yratio + y1 / Yratio * -1, 0.5F, 0.5F)
            gr.DrawImage(BMP, New Point(PX0 - Xmin / Xratio + x1 / Xratio, PY0 + Ymin / Yratio + y1 / Yratio * -1))
        End If
    End Sub

    Public Sub Label(gr As Graphics, T As String, Font As String, Size As Single, C As Color, RX0 As Single, RY0 As Single)
        Dim fnt As New Font(Font, Size, FontStyle.Regular)
        Dim brushy As Brush
        brushy = New Drawing.SolidBrush(C)
        gr.DrawString(T, fnt, brushy, PX0 - Xmin / Xratio + RX0 / Xratio, PY0 + Ymin / Yratio + RY0 / Yratio * -1)
    End Sub

    Public Sub GetPhysicalCoords(ByVal XL As Single, ByVal YL As Single, ByRef XP As Single, ByRef YP As Single)
        XP = PX0 - Xmin / Xratio + XL / Xratio
        YP = PY0 + Ymin / Yratio + YL / Yratio * -1
    End Sub

    Public Sub Axes(gr As Graphics, P As Pen, XCenter As Single, YCenter As Single, Optional Xtick As Single = 0, Optional Ytick As Single = 0)
        Draw(gr, P, Xmin, YCenter, Xmax, YCenter)
        Draw(gr, P, XCenter, Ymin, XCenter, Ymax)
        If Xtick <> 0 Then
            For Xn = XCenter To Xmax Step Xtick
                Draw(gr, P, Xn, -Yratio * 3 + YCenter, Xn, Yratio * 3 + YCenter)
            Next Xn
            For Xn = XCenter To Xmin Step -Xtick
                Draw(gr, P, Xn, -Yratio * 3 + YCenter, Xn, Yratio * 3 + YCenter)
            Next Xn
        End If
        If Ytick <> 0 Then
            For Yn = YCenter To Ymax Step Ytick
                Draw(gr, P, -Xratio * 3 + XCenter, Yn, Xratio * 3 + XCenter, Yn)
            Next Yn
            For Yn = YCenter To Ymin Step -Ytick
                Draw(gr, P, -Xratio * 3 + XCenter, Yn, Xratio * 3 + XCenter, Yn)
            Next Yn
        End If
    End Sub

    Public Sub Grid(gr As Graphics, P As Pen, XCenter As Single, YCenter As Single, Xstep As Single, Ystep As Single)
        For Xn = XCenter To Xmax Step Xstep
            Draw(gr, P, Xn, Ymin, Xn, Ymax)
        Next Xn
        For Xn = XCenter To Xmin Step -Xstep
            Draw(gr, P, Xn, Ymin, Xn, Ymax)
        Next Xn

        For Yn = YCenter To Ymax Step Ystep
            Draw(gr, P, Xmin, Yn, Xmax, Yn)
        Next Yn
        For Yn = YCenter To Ymin Step -Ystep
            Draw(gr, P, Xmin, Yn, Xmax, Yn)
        Next Yn
    End Sub

    Public Sub GraphTitle(gr As Graphics, Title As String, Font As String, Size As Single)
        Dim fntTitolo As New Font(Font, Size, FontStyle.Regular)
        Dim fore_brush As Brush = Brushes.White
        Dim text_size = gr.MeasureString(Title, fntTitolo)
        Dim Xt = CInt(((PXSpan - text_size.Width) / 2) + PX0)
        Dim Yt = Ywide - PY0R - PYSpan - text_size.Height
        gr.DrawString(Title, fntTitolo, fore_brush, Xt, Yt)
    End Sub

    Public Sub XTitle(gr As Graphics, Title As String, Font As String, Size As Single)
        Dim fntTitolo As New Font(Font, Size, FontStyle.Regular)
        Dim fore_brush As Brush = Brushes.White
        Dim text_size = gr.MeasureString(Title, fntTitolo)
        Dim Xt = CInt(((PXSpan - text_size.Width) / 2) + PX0)
        Dim Yt = Ywide - PY0R + text_size.Height * 1.2
        gr.DrawString(Title, fntTitolo, fore_brush, Xt, Yt)
    End Sub

    Public Sub XTickLabel(gr As Graphics, XCenter As Single, TiskStep As Single, Font As String, Size As Single)
        Dim Yt As Single
        Dim fntTitolo As New Font(Font, Size, FontStyle.Regular)
        Dim fore_brush As Brush = Brushes.White
        Dim text_size As SizeF
        Dim sf As New StringFormat
        sf.LineAlignment = StringAlignment.Near
        sf.Alignment = StringAlignment.Center
        For Xn = XCenter To Xmax Step TiskStep
            text_size = gr.MeasureString(CStr(Xn), fntTitolo)
            Yt = Ywide - PY0R + text_size.Height / 2
            If PX0 - Xmin / Xratio + Xn / Xratio >= PX0 Then
                gr.DrawString(CStr(Xn), fntTitolo, fore_brush, PX0 - Xmin / Xratio + Xn / Xratio, Yt, sf)
            End If
        Next Xn
        For Xn = XCenter To Xmin Step -TiskStep
            text_size = gr.MeasureString(CStr(Xn), fntTitolo)
            Yt = Ywide - PY0R + text_size.Height / 2
            If PX0 - Xmin / Xratio + Xn / Xratio >= PX0 Then
                gr.DrawString(CStr(Xn), fntTitolo, fore_brush, PX0 - Xmin / Xratio + Xn / Xratio, Yt, sf)
            End If
        Next Xn
    End Sub

    Public Sub YTitle(gr As Graphics, Title As String, Font As String, Size As Single)
        Dim fntTitolo As New Font(Font, Size, FontStyle.Regular)
        Dim fore_brush As Brush = Brushes.White
        Dim text_size = gr.MeasureString(Title, fntTitolo)
        Dim Xt = PX0R - 1.5 * text_size.Height
        Dim Yt = Ywide - PY0R - PYSpan / 2 + text_size.Width / 2
        gr.TranslateTransform(Xt, Yt)
        gr.RotateTransform(-90)
        gr.DrawString(Title, fntTitolo, fore_brush, 0, 0)
        gr.ResetTransform()
    End Sub

    Public Sub YTickLabel(gr As Graphics, Ycenter As Single, TiskStep As Single, Font As String, Size As Single)
        Dim fntTitolo As New Font(Font, Size, FontStyle.Regular)
        Dim fore_brush As Brush = Brushes.White
        Dim text_size As SizeF
        Dim sf As New StringFormat
        sf.LineAlignment = StringAlignment.Center
        sf.Alignment = StringAlignment.Near
        For Yn = Ycenter To Ymax Step TiskStep
            text_size = gr.MeasureString(CStr(Yn), fntTitolo)
            If PY0 + Ymin / Yratio + Yn / Yratio * -1 <= PY0 Then
                gr.DrawString(CStr(Yn), fntTitolo, fore_brush, PX0 + PXSpan, PY0 + Ymin / Yratio + Yn / Yratio * -1, sf)
            End If
        Next Yn
        For Yn = Ycenter To Ymin Step -TiskStep
            text_size = gr.MeasureString(CStr(Yn), fntTitolo)
            If PY0 + Ymin / Yratio + Yn / Yratio * -1 <= PY0 Then
                gr.DrawString(CStr(Yn), fntTitolo, fore_brush, PX0 + PXSpan, PY0 + Ymin / Yratio + Yn / Yratio * -1, sf)
            End If
        Next Yn
    End Sub
End Module


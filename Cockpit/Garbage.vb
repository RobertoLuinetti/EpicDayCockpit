Module Garbage
    'Private Sub TestGraphWrite()
    '    Dim text_size As SizeF
    '    Dim back_brush As Brush = Brushes.Yellow 'COLOR FOR THE BOARDER TEXT
    '    Dim fore_brush As Brush = Brushes.White 'COLOR FOR THE MAIN TEXT

    '    Dim fnt As New Font("Amarante", 15, FontStyle.Regular)
    '    Dim location_x, location_y As Single 'USED IT FOR THE LOCATION
    '    Dim i As Integer

    '    'CREATE A GRAPHIC OBJECT IN THE PICTUREBOX.
    '    Dim grafx = Me.picGraph.CreateGraphics()
    '    'CLEAR THE PICTUREBOX
    '    grafx.Clear(Color.Black)

    '    'LOOK THE REQUIRED SIZE TO DRAW THE TEXT
    '    text_size = grafx.MeasureString("Testo di prova", fnt)

    '    'ELIMINATE THE REDUNDANT CAlCULATION AFTER GETTING THE LOCATION.
    '    location_x = (Me.picGraph.Width - text_size.Width) / 2
    '    location_y = (Me.picGraph.Height - text_size.Height) / 2

    '    'FIRST, DRAW THE BLACK BACKGROUND TO GET THE EFFECT,
    '    'AND THE TEXT MUST BE DRAWN REAPETEDLY FROM THE OFFSET RIGHT, UP TO THE MAIN TEXT IS DRAWN.
    '    'For i = CInt(3) To 0 Step -1
    '    i = 0
    '    grafx.DrawString("Testo di prova", fnt, back_brush,
    '    location_x - i, location_y + i)
    '    'Next
    '    Dim mydataandtimeforsave = DateTime.Now.ToString("yyyyMMddHHmmss")
    '    'DRAW THE ROYAL BLUE FOR THE MAIN TEXT OVER THE BLACk TEXT
    '    grafx.DrawString("Testo di prova" & mydataandtimeforsave.ToString, fnt, fore_brush, location_x, location_y)
    '    Dim bmp As New Bitmap(Me.picGraph.Width, Me.picGraph.Height)
    '    Dim g As Graphics = Graphics.FromImage(bmp)
    '    g.Clear(Color.Transparent)

    '    ''Perform Drawing here
    'End Sub

    'Private Delegate Function FofXY(ByVal x As Single, ByVal y As Single) As Single

    'Private Sub DrawGraph(ByVal func As FofXY)
    '    Me.Cursor = Cursors.WaitCursor

    '    ' Make the Bitmap.
    '    Dim bm As New Bitmap(picGraph.ClientSize.Width, picGraph.ClientSize.Height)
    '    Using gr As Graphics = Graphics.FromImage(bm)
    '        ' Clear.
    '        gr.Clear(Color.Black)
    '        gr.ScaleTransform(15.0F, -15.0F, System.Drawing.Drawing2D.MatrixOrder.Append)
    '        gr.TranslateTransform(bm.Width * 0.5F, bm.Height * 0.5F,
    '            System.Drawing.Drawing2D.MatrixOrder.Append)

    '        ' Draw axes.
    '        Using axis_pen As New Pen(Color.Green, 0)
    '            gr.DrawLine(axis_pen, -8, 0, 8, 0)
    '            gr.DrawLine(axis_pen, 0, -8, 0, 8)
    '            For i As Integer = -8 To 8
    '                gr.DrawLine(axis_pen, i, -0.1F, i, 0.1F)
    '                gr.DrawLine(axis_pen, -0.1F, i, 0.1F, i)
    '            Next i
    '        End Using

    '        ' Graph the equation.
    '        Dim dx As Single = 2.0F / bm.Width
    '        Dim dy As Single = 2.0F / bm.Height
    '        PlotFunction(gr, func, -8, -8, 8, 8, dx, dy)
    '    End Using

    '    ' Display the result.
    '    picGraph.Image = bm
    '    Me.Cursor = Cursors.Default
    'End Sub

    ' Plot a function.
    'Private Sub PlotFunction(ByVal gr As Graphics, ByVal func As FofXY,
    ' ByVal xmin As Single, ByVal ymin As Single, ByVal xmax As Single, ByVal ymax As Single,
    ' ByVal dx As Single, ByVal dy As Single)
    '    ' Plot the function.
    '    Using thin_pen As New Pen(Color.Red, 0)
    '        ' Horizontal comparisons.
    '        For x As Single = xmin To xmax Step dx
    '            Dim last_y As Single = func(x, ymin)
    '            For y As Single = ymin + dy To ymax Step dy
    '                Dim next_y As Single = func(x, y)
    '                If (
    '                    ((last_y <= 0.0F) AndAlso (next_y >= 0.0F)) OrElse
    '                    ((last_y >= 0.0F) AndAlso (next_y <= 0.0F))
    '                   ) _
    '               Then
    '                    ' Plot this point.
    '                    gr.DrawLine(thin_pen, x, y - dy, x, y)
    '                End If
    '                last_y = next_y
    '            Next y
    '        Next x ' Horizontal comparisons.

    '        ' Vertical comparisons.
    '        For y As Single = ymin + dy To ymax Step dy
    '            Dim last_x As Single = func(xmin, y)
    '            For x As Single = xmin + dx To xmax Step dx
    '                Dim next_x As Single = func(x, y)
    '                If (
    '                    ((last_x <= 0.0F) AndAlso (next_x >= 0.0F)) OrElse
    '                    ((last_x >= 0.0F) AndAlso (next_x <= 0.0F))
    '                   ) _
    '                Then
    '                    ' Plot this point.
    '                    gr.DrawLine(thin_pen, x - dx, y, x, y)
    '                End If
    '                last_x = next_x
    '            Next x
    '        Next y ' Vertical comparisons.
    '    End Using
    'End Sub

    '' x^2 + x*y - y = 0
    'Private Function F1(ByVal x As Single, ByVal y As Single) As Single
    '    Return (x * x + x * y - y)
    'End Function

    'Private Function F2(ByVal x As Single, ByVal y As Single) As Single
    '    Return (x * x + x * y - y)
    'End Function
End Module

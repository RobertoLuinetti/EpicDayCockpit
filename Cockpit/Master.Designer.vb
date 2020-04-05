<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Master
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.picGraph = New System.Windows.Forms.PictureBox()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.LatG = New System.Windows.Forms.TextBox()
        Me.LatP = New System.Windows.Forms.TextBox()
        Me.LongP = New System.Windows.Forms.TextBox()
        Me.LongG = New System.Windows.Forms.TextBox()
        Me.LatS = New System.Windows.Forms.TextBox()
        Me.LongS = New System.Windows.Forms.TextBox()
        Me.ButtonGPX = New System.Windows.Forms.Button()
        Me.LatQ = New System.Windows.Forms.TextBox()
        Me.LongQ = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SpeedThr = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Titolo = New System.Windows.Forms.TextBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.CheckBox_H = New System.Windows.Forms.CheckBox()
        Me.CheckBox_V = New System.Windows.Forms.CheckBox()
        Me.CheckBox_HSmooth = New System.Windows.Forms.CheckBox()
        Me.CheckBoxDSmooth = New System.Windows.Forms.CheckBox()
        Me.SaveBMP = New System.Windows.Forms.Button()
        CType(Me.picGraph, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picGraph
        '
        Me.picGraph.BackColor = System.Drawing.Color.Black
        Me.picGraph.Location = New System.Drawing.Point(12, 79)
        Me.picGraph.Name = "picGraph"
        Me.picGraph.Size = New System.Drawing.Size(960, 540)
        Me.picGraph.TabIndex = 0
        Me.picGraph.TabStop = False
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(12, 13)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePicker1.TabIndex = 2
        Me.DateTimePicker1.Value = New Date(2019, 12, 24, 12, 0, 0, 0)
        '
        'LatG
        '
        Me.LatG.Location = New System.Drawing.Point(268, 13)
        Me.LatG.Name = "LatG"
        Me.LatG.Size = New System.Drawing.Size(19, 20)
        Me.LatG.TabIndex = 4
        Me.LatG.Text = "45"
        Me.LatG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LatP
        '
        Me.LatP.Location = New System.Drawing.Point(293, 13)
        Me.LatP.Name = "LatP"
        Me.LatP.Size = New System.Drawing.Size(19, 20)
        Me.LatP.TabIndex = 5
        Me.LatP.Text = "35"
        Me.LatP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LongP
        '
        Me.LongP.Location = New System.Drawing.Point(464, 13)
        Me.LongP.Name = "LongP"
        Me.LongP.Size = New System.Drawing.Size(19, 20)
        Me.LongP.TabIndex = 8
        Me.LongP.Text = "4"
        Me.LongP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LongG
        '
        Me.LongG.Location = New System.Drawing.Point(439, 13)
        Me.LongG.Name = "LongG"
        Me.LongG.Size = New System.Drawing.Size(19, 20)
        Me.LongG.TabIndex = 7
        Me.LongG.Text = "9"
        Me.LongG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LatS
        '
        Me.LatS.Location = New System.Drawing.Point(318, 13)
        Me.LatS.Name = "LatS"
        Me.LatS.Size = New System.Drawing.Size(35, 20)
        Me.LatS.TabIndex = 10
        Me.LatS.Text = "42,7"
        Me.LatS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LongS
        '
        Me.LongS.Location = New System.Drawing.Point(489, 13)
        Me.LongS.Name = "LongS"
        Me.LongS.Size = New System.Drawing.Size(35, 20)
        Me.LongS.TabIndex = 11
        Me.LongS.Text = "28,4"
        Me.LongS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ButtonGPX
        '
        Me.ButtonGPX.Location = New System.Drawing.Point(670, 6)
        Me.ButtonGPX.Name = "ButtonGPX"
        Me.ButtonGPX.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGPX.TabIndex = 13
        Me.ButtonGPX.Text = "GPX"
        Me.ButtonGPX.UseVisualStyleBackColor = True
        '
        'LatQ
        '
        Me.LatQ.Location = New System.Drawing.Point(359, 13)
        Me.LatQ.Name = "LatQ"
        Me.LatQ.Size = New System.Drawing.Size(13, 20)
        Me.LatQ.TabIndex = 14
        Me.LatQ.Text = "N"
        Me.LatQ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LongQ
        '
        Me.LongQ.Location = New System.Drawing.Point(530, 13)
        Me.LongQ.Name = "LongQ"
        Me.LongQ.Size = New System.Drawing.Size(13, 20)
        Me.LongQ.TabIndex = 15
        Me.LongQ.Text = "E"
        Me.LongQ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(235, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "LAT"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(396, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "LONG"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(119, 13)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Soglia movimento Km/h"
        '
        'SpeedThr
        '
        Me.SpeedThr.Location = New System.Drawing.Point(137, 42)
        Me.SpeedThr.Name = "SpeedThr"
        Me.SpeedThr.Size = New System.Drawing.Size(27, 20)
        Me.SpeedThr.TabIndex = 18
        Me.SpeedThr.Text = "0,5"
        Me.SpeedThr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(188, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 13)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Titolo"
        '
        'Titolo
        '
        Me.Titolo.Location = New System.Drawing.Point(228, 42)
        Me.Titolo.Name = "Titolo"
        Me.Titolo.Size = New System.Drawing.Size(422, 20)
        Me.Titolo.TabIndex = 20
        Me.Titolo.Text = "Titolo Titolo Titolo Titolo Titolo Titolo Titolo "
        Me.Titolo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'CheckBox_H
        '
        Me.CheckBox_H.AutoSize = True
        Me.CheckBox_H.Location = New System.Drawing.Point(794, 15)
        Me.CheckBox_H.Name = "CheckBox_H"
        Me.CheckBox_H.Size = New System.Drawing.Size(60, 17)
        Me.CheckBox_H.TabIndex = 22
        Me.CheckBox_H.Text = "Altezza"
        Me.CheckBox_H.UseVisualStyleBackColor = True
        '
        'CheckBox_V
        '
        Me.CheckBox_V.AutoSize = True
        Me.CheckBox_V.Location = New System.Drawing.Point(794, 44)
        Me.CheckBox_V.Name = "CheckBox_V"
        Me.CheckBox_V.Size = New System.Drawing.Size(64, 17)
        Me.CheckBox_V.TabIndex = 23
        Me.CheckBox_V.Text = "Velocità"
        Me.CheckBox_V.UseVisualStyleBackColor = True
        '
        'CheckBox_HSmooth
        '
        Me.CheckBox_HSmooth.AutoSize = True
        Me.CheckBox_HSmooth.Location = New System.Drawing.Point(882, 15)
        Me.CheckBox_HSmooth.Name = "CheckBox_HSmooth"
        Me.CheckBox_HSmooth.Size = New System.Drawing.Size(62, 17)
        Me.CheckBox_HSmooth.TabIndex = 24
        Me.CheckBox_HSmooth.Text = "Smooth"
        Me.CheckBox_HSmooth.UseVisualStyleBackColor = True
        '
        'CheckBoxDSmooth
        '
        Me.CheckBoxDSmooth.AutoSize = True
        Me.CheckBoxDSmooth.Location = New System.Drawing.Point(882, 44)
        Me.CheckBoxDSmooth.Name = "CheckBoxDSmooth"
        Me.CheckBoxDSmooth.Size = New System.Drawing.Size(62, 17)
        Me.CheckBoxDSmooth.TabIndex = 25
        Me.CheckBoxDSmooth.Text = "Smooth"
        Me.CheckBoxDSmooth.UseVisualStyleBackColor = True
        '
        'SaveBMP
        '
        Me.SaveBMP.Location = New System.Drawing.Point(670, 39)
        Me.SaveBMP.Name = "SaveBMP"
        Me.SaveBMP.Size = New System.Drawing.Size(75, 23)
        Me.SaveBMP.TabIndex = 26
        Me.SaveBMP.Text = "Save BMP"
        Me.SaveBMP.UseVisualStyleBackColor = True
        '
        'Master
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 631)
        Me.Controls.Add(Me.SaveBMP)
        Me.Controls.Add(Me.CheckBoxDSmooth)
        Me.Controls.Add(Me.CheckBox_HSmooth)
        Me.Controls.Add(Me.CheckBox_V)
        Me.Controls.Add(Me.CheckBox_H)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Titolo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.SpeedThr)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LongQ)
        Me.Controls.Add(Me.LatQ)
        Me.Controls.Add(Me.ButtonGPX)
        Me.Controls.Add(Me.LongS)
        Me.Controls.Add(Me.LatS)
        Me.Controls.Add(Me.LongP)
        Me.Controls.Add(Me.LongG)
        Me.Controls.Add(Me.LatP)
        Me.Controls.Add(Me.LatG)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.picGraph)
        Me.Name = "Master"
        Me.Text = "Epic Day Cockpit"
        CType(Me.picGraph, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents picGraph As PictureBox
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents LatG As TextBox
    Friend WithEvents LatP As TextBox
    Friend WithEvents LongP As TextBox
    Friend WithEvents LongG As TextBox
    Friend WithEvents LatS As TextBox
    Friend WithEvents LongS As TextBox
    Friend WithEvents ButtonGPX As Button
    Friend WithEvents LatQ As TextBox
    Friend WithEvents LongQ As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents SpeedThr As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Titolo As TextBox
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents CheckBox_H As CheckBox
    Friend WithEvents CheckBox_V As CheckBox
    Friend WithEvents CheckBox_HSmooth As CheckBox
    Friend WithEvents CheckBoxDSmooth As CheckBox
    Friend WithEvents SaveBMP As Button
End Class

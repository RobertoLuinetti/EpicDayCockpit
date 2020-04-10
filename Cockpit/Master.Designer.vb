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
        Me.Titolo = New System.Windows.Forms.TextBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.DebugData = New System.Windows.Forms.CheckBox()
        Me.SaveBMP = New System.Windows.Forms.Button()
        Me.TrackBarSogliaMovimento = New System.Windows.Forms.TrackBar()
        Me.SpeedThresholdLBL = New System.Windows.Forms.Label()
        Me.MMLBL = New System.Windows.Forms.Label()
        Me.TrackBarMM = New System.Windows.Forms.TrackBar()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ComboBoxStepH = New System.Windows.Forms.ComboBox()
        Me.ComboBoxStepS = New System.Windows.Forms.ComboBox()
        Me.VMMLBL = New System.Windows.Forms.Label()
        Me.TrackBarSP = New System.Windows.Forms.TrackBar()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LinkLabelAstro = New System.Windows.Forms.LinkLabel()
        Me.LinkLabelGis = New System.Windows.Forms.LinkLabel()
        CType(Me.picGraph, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBarSogliaMovimento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBarMM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBarSP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picGraph
        '
        Me.picGraph.BackColor = System.Drawing.Color.Black
        Me.picGraph.Location = New System.Drawing.Point(12, 96)
        Me.picGraph.Name = "picGraph"
        Me.picGraph.Size = New System.Drawing.Size(960, 540)
        Me.picGraph.TabIndex = 0
        Me.picGraph.TabStop = False
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(12, 13)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(181, 20)
        Me.DateTimePicker1.TabIndex = 2
        Me.DateTimePicker1.Value = New Date(2019, 12, 24, 12, 0, 0, 0)
        '
        'LatG
        '
        Me.LatG.Location = New System.Drawing.Point(62, 39)
        Me.LatG.Name = "LatG"
        Me.LatG.Size = New System.Drawing.Size(19, 20)
        Me.LatG.TabIndex = 4
        Me.LatG.Text = "45"
        Me.LatG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LatP
        '
        Me.LatP.Location = New System.Drawing.Point(87, 39)
        Me.LatP.Name = "LatP"
        Me.LatP.Size = New System.Drawing.Size(19, 20)
        Me.LatP.TabIndex = 5
        Me.LatP.Text = "35"
        Me.LatP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LongP
        '
        Me.LongP.Location = New System.Drawing.Point(87, 65)
        Me.LongP.Name = "LongP"
        Me.LongP.Size = New System.Drawing.Size(19, 20)
        Me.LongP.TabIndex = 8
        Me.LongP.Text = "4"
        Me.LongP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LongG
        '
        Me.LongG.Location = New System.Drawing.Point(62, 65)
        Me.LongG.Name = "LongG"
        Me.LongG.Size = New System.Drawing.Size(19, 20)
        Me.LongG.TabIndex = 7
        Me.LongG.Text = "9"
        Me.LongG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LatS
        '
        Me.LatS.Location = New System.Drawing.Point(112, 39)
        Me.LatS.Name = "LatS"
        Me.LatS.Size = New System.Drawing.Size(35, 20)
        Me.LatS.TabIndex = 10
        Me.LatS.Text = "42,7"
        Me.LatS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LongS
        '
        Me.LongS.Location = New System.Drawing.Point(112, 65)
        Me.LongS.Name = "LongS"
        Me.LongS.Size = New System.Drawing.Size(35, 20)
        Me.LongS.TabIndex = 11
        Me.LongS.Text = "28,4"
        Me.LongS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ButtonGPX
        '
        Me.ButtonGPX.Location = New System.Drawing.Point(199, 36)
        Me.ButtonGPX.Name = "ButtonGPX"
        Me.ButtonGPX.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGPX.TabIndex = 13
        Me.ButtonGPX.Text = "GPX"
        Me.ButtonGPX.UseVisualStyleBackColor = True
        '
        'LatQ
        '
        Me.LatQ.Location = New System.Drawing.Point(153, 39)
        Me.LatQ.Name = "LatQ"
        Me.LatQ.Size = New System.Drawing.Size(13, 20)
        Me.LatQ.TabIndex = 14
        Me.LatQ.Text = "N"
        Me.LatQ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LongQ
        '
        Me.LongQ.Location = New System.Drawing.Point(153, 65)
        Me.LongQ.Name = "LongQ"
        Me.LongQ.Size = New System.Drawing.Size(13, 20)
        Me.LongQ.TabIndex = 15
        Me.LongQ.Text = "E"
        Me.LongQ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "LAT"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "LONG"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(504, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 13)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Movement threshold"
        '
        'Titolo
        '
        Me.Titolo.Location = New System.Drawing.Point(199, 13)
        Me.Titolo.Name = "Titolo"
        Me.Titolo.Size = New System.Drawing.Size(289, 20)
        Me.Titolo.TabIndex = 20
        Me.Titolo.Text = "Titolo"
        Me.Titolo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'DebugData
        '
        Me.DebugData.AutoSize = True
        Me.DebugData.Location = New System.Drawing.Point(406, 39)
        Me.DebugData.Name = "DebugData"
        Me.DebugData.Size = New System.Drawing.Size(82, 17)
        Me.DebugData.TabIndex = 23
        Me.DebugData.Text = "Debug data"
        Me.DebugData.UseVisualStyleBackColor = True
        '
        'SaveBMP
        '
        Me.SaveBMP.Location = New System.Drawing.Point(199, 65)
        Me.SaveBMP.Name = "SaveBMP"
        Me.SaveBMP.Size = New System.Drawing.Size(75, 23)
        Me.SaveBMP.TabIndex = 26
        Me.SaveBMP.Text = "Save BMP"
        Me.SaveBMP.UseVisualStyleBackColor = True
        '
        'TrackBarSogliaMovimento
        '
        Me.TrackBarSogliaMovimento.Location = New System.Drawing.Point(490, 40)
        Me.TrackBarSogliaMovimento.Name = "TrackBarSogliaMovimento"
        Me.TrackBarSogliaMovimento.Size = New System.Drawing.Size(117, 45)
        Me.TrackBarSogliaMovimento.TabIndex = 27
        Me.TrackBarSogliaMovimento.TickFrequency = 5
        '
        'SpeedThresholdLBL
        '
        Me.SpeedThresholdLBL.AutoSize = True
        Me.SpeedThresholdLBL.Location = New System.Drawing.Point(526, 24)
        Me.SpeedThresholdLBL.Name = "SpeedThresholdLBL"
        Me.SpeedThresholdLBL.Size = New System.Drawing.Size(36, 13)
        Me.SpeedThresholdLBL.TabIndex = 28
        Me.SpeedThresholdLBL.Text = " Km/h"
        '
        'MMLBL
        '
        Me.MMLBL.AutoSize = True
        Me.MMLBL.Location = New System.Drawing.Point(651, 24)
        Me.MMLBL.Name = "MMLBL"
        Me.MMLBL.Size = New System.Drawing.Size(49, 13)
        Me.MMLBL.TabIndex = 31
        Me.MMLBL.Text = "elements"
        '
        'TrackBarMM
        '
        Me.TrackBarMM.Location = New System.Drawing.Point(613, 40)
        Me.TrackBarMM.Name = "TrackBarMM"
        Me.TrackBarMM.Size = New System.Drawing.Size(117, 45)
        Me.TrackBarMM.SmallChange = 2
        Me.TrackBarMM.TabIndex = 30
        Me.TrackBarMM.TickFrequency = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(610, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 13)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "Height moving average "
        '
        'ComboBoxStepH
        '
        Me.ComboBoxStepH.FormattingEnabled = True
        Me.ComboBoxStepH.Location = New System.Drawing.Point(280, 38)
        Me.ComboBoxStepH.Name = "ComboBoxStepH"
        Me.ComboBoxStepH.Size = New System.Drawing.Size(52, 21)
        Me.ComboBoxStepH.TabIndex = 34
        Me.ComboBoxStepH.Text = "50"
        '
        'ComboBoxStepS
        '
        Me.ComboBoxStepS.FormattingEnabled = True
        Me.ComboBoxStepS.Location = New System.Drawing.Point(280, 68)
        Me.ComboBoxStepS.Name = "ComboBoxStepS"
        Me.ComboBoxStepS.Size = New System.Drawing.Size(52, 21)
        Me.ComboBoxStepS.TabIndex = 35
        Me.ComboBoxStepS.Text = "5"
        '
        'VMMLBL
        '
        Me.VMMLBL.AutoSize = True
        Me.VMMLBL.Location = New System.Drawing.Point(766, 24)
        Me.VMMLBL.Name = "VMMLBL"
        Me.VMMLBL.Size = New System.Drawing.Size(49, 13)
        Me.VMMLBL.TabIndex = 38
        Me.VMMLBL.Text = "elements"
        '
        'TrackBarSP
        '
        Me.TrackBarSP.Location = New System.Drawing.Point(736, 42)
        Me.TrackBarSP.Name = "TrackBarSP"
        Me.TrackBarSP.Size = New System.Drawing.Size(117, 45)
        Me.TrackBarSP.SmallChange = 2
        Me.TrackBarSP.TabIndex = 37
        Me.TrackBarSP.TickFrequency = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(733, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(120, 13)
        Me.Label6.TabIndex = 36
        Me.Label6.Text = "Speed moving average "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(338, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 40
        Me.Label4.Text = "Speed gid"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(338, 40)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 13)
        Me.Label7.TabIndex = 39
        Me.Label7.Text = "Altitude grid"
        '
        'LinkLabelAstro
        '
        Me.LinkLabelAstro.AutoSize = True
        Me.LinkLabelAstro.Location = New System.Drawing.Point(403, 59)
        Me.LinkLabelAstro.Name = "LinkLabelAstro"
        Me.LinkLabelAstro.Size = New System.Drawing.Size(31, 13)
        Me.LinkLabelAstro.TabIndex = 41
        Me.LinkLabelAstro.TabStop = True
        Me.LinkLabelAstro.Text = "Astro"
        '
        'LinkLabelGis
        '
        Me.LinkLabelGis.AutoSize = True
        Me.LinkLabelGis.Location = New System.Drawing.Point(403, 77)
        Me.LinkLabelGis.Name = "LinkLabelGis"
        Me.LinkLabelGis.Size = New System.Drawing.Size(25, 13)
        Me.LinkLabelGis.TabIndex = 42
        Me.LinkLabelGis.TabStop = True
        Me.LinkLabelGis.Text = "GIS"
        '
        'Master
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 647)
        Me.Controls.Add(Me.LinkLabelGis)
        Me.Controls.Add(Me.LinkLabelAstro)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.VMMLBL)
        Me.Controls.Add(Me.TrackBarSP)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ComboBoxStepS)
        Me.Controls.Add(Me.ComboBoxStepH)
        Me.Controls.Add(Me.MMLBL)
        Me.Controls.Add(Me.TrackBarMM)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.SpeedThresholdLBL)
        Me.Controls.Add(Me.TrackBarSogliaMovimento)
        Me.Controls.Add(Me.SaveBMP)
        Me.Controls.Add(Me.DebugData)
        Me.Controls.Add(Me.Titolo)
        Me.Controls.Add(Me.Label3)
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
        CType(Me.TrackBarSogliaMovimento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBarMM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBarSP, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents Titolo As TextBox
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents DebugData As CheckBox
    Friend WithEvents SaveBMP As Button
    Friend WithEvents TrackBarSogliaMovimento As TrackBar
    Friend WithEvents SpeedThresholdLBL As Label
    Friend WithEvents MMLBL As Label
    Friend WithEvents TrackBarMM As TrackBar
    Friend WithEvents Label5 As Label
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents ComboBoxStepH As ComboBox
    Friend WithEvents ComboBoxStepS As ComboBox
    Friend WithEvents VMMLBL As Label
    Friend WithEvents TrackBarSP As TrackBar
    Friend WithEvents Label6 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents LinkLabelAstro As LinkLabel
    Friend WithEvents LinkLabelGis As LinkLabel
End Class

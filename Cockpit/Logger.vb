Module Logger
    Enum LogCMD
        NewFile
        Write
        Close
    End Enum

    Dim file As System.IO.StreamWriter

    Public Sub Flog(Filename As String, Command As LogCMD, Optional Message As String = "")

        Select Case Command
            Case LogCMD.NewFile
                file = My.Computer.FileSystem.OpenTextFileWriter(Filename, True)
            Case LogCMD.Write
                file.WriteLine(Message)
            Case LogCMD.Close
                file.Close()
            Case Else
        End Select

    End Sub

End Module

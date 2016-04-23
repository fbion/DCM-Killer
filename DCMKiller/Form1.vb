

Public Class Form1


    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("http://www.baidu.com")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        MsgBox("DCMKiller" & vbCrLf & "本工具快速检测你的电脑是否感染DCM（黑暗幽灵）木马，并尝试清除。" & vbCrLf & vbCrLf & "请注意：本工具不能代替杀毒软件使用，如果怀疑中了此木马，请及时用ARK工具进行清除", MsgBoxStyle.Question, "About")

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        On Error Resume Next
        '通过环境变量来取Windows临时目录
        Dim temppath, DCMPath

        temppath = Environ("WINDIR") & "\Temp"
        DCMPath = Environ("WINDIR") & "\Temp\{E53B9A13-F4C6-4d78-9755-65C029E88F02}"
        '判断是否存在DCM的{E53B9A13-F4C6-4d78-9755-65C029E88F02}文件夹
        If My.Computer.FileSystem.DirectoryExists(DCMPath) Then
            If (MsgBox("检测到DCM工作目录，您的系统很有可能已感染DCM木马，是否尝试清除？", MsgBoxStyle.YesNo, "提示")) = 6 Then
                '先删除TEMP里面的目录
                My.Computer.FileSystem.DeleteDirectory(DCMPath, FileIO.DeleteDirectoryOption.DeleteAllContents)
                '使用CMD命令修复LSP
                Debug.WriteLine(CMD("netsh winsock reset"))
                '然后开始判断系统版本（XP或以上）
                Dim commonfiles = System.Environment.GetFolderPath(System.Environment.SpecialFolder.CommonProgramFiles)
                Dim ver = System.Environment.OSVersion.Version.Major
                If ver = 5 Then
                    My.Computer.FileSystem.DeleteFile(Environ("WINDIR") & "\ntshrui.dll")
                Else
                    My.Computer.FileSystem.DeleteFile(Environ("WINDIR") & "\msls32.dll")
                    My.Computer.FileSystem.DeleteFile(Environ("WINDIR") & "\AduioSes.dll")
                End If
                MsgBox("看起来应该清除完毕了。" & vbCrLf & "接下来，请使用ARK工具解除被挂的钩子和删除文件！", MsgBoxStyle.Question, "About")
            Else
                Exit Sub
            End If
        Else
            MsgBox("未找到DCM工作目录。", MsgBoxStyle.Question, "提示")
        End If

    End Sub

    Function CMD(ByVal Data As String) As String
        Try
            Dim p As New Process()
            p.StartInfo.FileName = "cmd.exe"
            p.StartInfo.UseShellExecute = False
            p.StartInfo.RedirectStandardInput = True
            p.StartInfo.RedirectStandardOutput = True
            p.StartInfo.RedirectStandardError = True
            p.StartInfo.CreateNoWindow = False
            p.Start()
            Application.DoEvents()
            p.StandardInput.WriteLine(Data)
            p.StandardInput.WriteLine("Exit")
            Dim strRst As String = p.StandardOutput.ReadToEnd()
            p.Close()
            Return strRst
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class











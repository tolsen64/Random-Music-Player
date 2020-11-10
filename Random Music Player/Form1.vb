Imports System.ComponentModel
Imports System.IO

Public Class Form1

    Dim FileIDs As New List(Of Integer)
    Dim WithEvents tm As New Timer With {.Enabled = False, .Interval = 1000}
    Dim _rnd As New Random
    Dim fp As Integer = 0

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        CreateDatabase()
        FileIDs = GetPlayableFileIDs()
        lblTotalFiles.Text = "TF: " & FileIDs.Count.ToString
        AddHandler modNAudio.NAudioPlaybackStopped, Sub(ex As Exception) btnPlay.PerformClick()
        AddHandler modNAudio.NAudioFileReadError, Sub(ex As Exception) FileWontPlay(ex)
    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        tm.Stop()
        modNAudio.Stop()
        lblID.Text = 0
        lblFilename.Text = "None"
        lblFileFullPath.Text = "None"
        lblPosition.Text = "0"
        lblRuntime.Text = "0"
        trkSeek.Value = 0
    End Sub

    Private Sub btnPause_Click(sender As Object, e As EventArgs) Handles btnPause.Click
        If btnPause.Text = "Pause" Then
            modNAudio.[Pause]()
            btnPause.Text = "Resume"
        Else
            modNAudio.Resume()
            btnPause.Text = "Pause"
        End If
    End Sub

    Private Sub btnPlay_Click(sender As Object, e As EventArgs) Handles btnPlay.Click
        tm.Stop()
        btnPause.Text = "Pause"
        trkSeek.Value = 0
        lblPosition.Text = "Loading..."
        lblRuntime.Text = "Loading..."
        Dim id As Integer = RndFileId()
        Dim fi As New FileInfo(GetFileToPlay(id))
        lblID.Text = id
        lblFilename.Text = fi.Name
        lblFileFullPath.Text = fi.DirectoryName
        Dim tv As Integer = trkVolume.Value
        Dim ts As TimeSpan
        Task.Run(Sub()
                     modNAudio.PlayFileFile(fi.FullName, CSng(tv) / CSng(100))
                     ts = modNAudio.GetMediaLength()
                     BeginInvoke(Sub()
                                     fp += 1
                                     lblFilesPlayed.Text = "FP: " & fp.ToString
                                     lblRuntime.Text = ts.ToString("mm\:ss")
                                     trkSeek.Maximum = ts.TotalSeconds
                                     trkSeek.TickFrequency = ts.TotalSeconds / 20
                                     tm.Start()
                                 End Sub)
                 End Sub)
    End Sub

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        modNAudio.CloseDevice()
    End Sub

    Private Function RndFileId() As Integer
        Dim lowerbound As Integer = 0
        Dim upperbound As Integer = FileIDs.Count - 1
        RndFileId = FileIDs(_rnd.Next(lowerbound, upperbound))
    End Function

    Private Sub tm_Tick(sender As Object, e As EventArgs) Handles tm.Tick
        Dim ts As TimeSpan = modNAudio.GetMediaPosition()
        trkSeek.BeginInvoke(Sub()
                                lblPosition.Text = ts.ToString("mm\:ss")
                                trkSeek.Value = If(ts.TotalSeconds > trkSeek.Maximum, trkSeek.Maximum, ts.TotalSeconds)
                            End Sub)
    End Sub

    Private Sub btnDontPlayAgain_Click(sender As Object, e As EventArgs) Handles btnDontPlayAgain.Click
        Dim id As Integer = CInt(lblID.Text)
        DontPlayFile(id)
        FileIDs.Remove(id)
        btnPlay.PerformClick()
    End Sub

    Private Sub FileWontPlay(ex As Exception)
        Dim id As Integer = CInt(lblID.Text)
        modSQLite.FileWontPlay(id, ex)
        FileIDs.Remove(id)
        BeginInvoke(Sub() btnPlay.PerformClick())
    End Sub

    Private Sub trkVolume_Scroll(sender As Object, e As EventArgs) Handles trkVolume.Scroll
        modNAudio.SetVolume(CSng(trkVolume.Value) / CSng(100))
    End Sub

    Private Sub trkSeek_Scroll(sender As Object, e As EventArgs) Handles trkSeek.Scroll
        modNAudio.SetCurrentTime(New TimeSpan(0, 0, trkSeek.Value))
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        With New dlgSettings
            If .ShowDialog = DialogResult.OK Then SyncFiles()
        End With
    End Sub

    Private Async Sub SyncFiles()
        Dim lstFolders As List(Of String) = modSQLite.GetFolders
        Await Task.Run(Sub()
                           For Each fldr As String In lstFolders
                               Me.BeginInvoke(Sub()
                                                  lblFileFullPath.Text = fldr
                                                  lblFilename.Text = "Reading folder structure..."
                                              End Sub)
                               Dim fi As FileInfo() = New DirectoryInfo(fldr).GetFiles("*", SearchOption.AllDirectories)
                               Me.BeginInvoke(Sub()
                                                  lblRuntime.Text = fi.Count
                                                  trkSeek.Maximum = fi.Count
                                                  trkSeek.Value = 0
                                              End Sub)
                               For i As Integer = 0 To fi.Count - 1
                                   Select Case fi(i).Extension.ToLower
                                       Case ".aiff", ".mp3", ".wav", ".wma", ".ogg", ".flac"    'These are the filetypes that NAudio can play.
                                           Dim add As Boolean = True
                                           Try
                                               Dim dn As String = fi(i).DirectoryName
                                               Dim fn As String = fi(i).Name
                                           Catch ex As Exception
                                               add = False
                                           End Try
                                           If add Then
                                               Dim ii As Integer = i
                                               Me.BeginInvoke(Sub()
                                                                  lblFileFullPath.Text = fi(ii).DirectoryName
                                                                  lblFilename.Text = fi(ii).Name
                                                                  lblPosition.Text = ii + 1
                                                                  trkSeek.Value = ii
                                                              End Sub)
                                               modSQLite.AddFile(fi(ii))
                                           End If
                                       Case Else
                                           Debug.WriteLine(fi(i).FullName)
                                   End Select
                               Next
                               Me.BeginInvoke(Sub()
                                                  lblFileFullPath.Text = ""
                                                  lblFilename.Text = ""
                                                  lblRuntime.Text = "0"
                                                  lblPosition.Text = "0"
                                                  trkSeek.Value = 0
                                              End Sub)
                           Next
                       End Sub)
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub OpenFolderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenFolderToolStripMenuItem.Click
        Process.Start(lblFileFullPath.Text)
    End Sub

    Private Sub lblFileFullPath_Click(sender As Object, e As EventArgs) Handles lblFileFullPath.Click
        If (Directory.Exists(lblFileFullPath.Text)) Then
            Process.Start(lblFileFullPath.Text)
        Else
            MsgBox("Folder not found")
        End If
    End Sub
End Class

Imports System.Windows.Forms
Imports System.IO

Public Class dlgSettings

    Private Sub dlgSettings_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim lst As List(Of String) = modSQLite.GetFolders
        For Each s As String In lst
            lstFolders.Items.Add(s)
        Next
    End Sub


    Private Sub lstFolders_DragDrop(sender As Object, e As DragEventArgs) Handles lstFolders.DragDrop
        Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
        For Each path In files
            If File.Exists(path) Then
                With New FileInfo(path)
                    lstFolders.Items.Add(.DirectoryName)
                    modSQLite.AddFolder(.DirectoryName)
                End With
            ElseIf Directory.Exists(path) Then
                With New DirectoryInfo(path)
                    lstFolders.Items.Add(.FullName)
                    modSQLite.AddFolder(.FullName)
                End With
            End If
        Next
    End Sub

    Private Sub lstFolders_DragEnter(sender As Object, e As DragEventArgs) Handles lstFolders.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub btnDeleteSelectedFolder_Click(sender As Object, e As EventArgs) Handles btnDeleteSelectedFolder.Click
        Dim path As String = lstFolders.SelectedItem.ToString
        lstFolders.Items.Remove(path)
        modSQLite.DeleteFolder(path)
    End Sub

    Private Sub btnDeleteAllFolders_Click(sender As Object, e As EventArgs) Handles btnDeleteAllFolders.Click
        If MsgBox("Are you sure you want to delete all folders?", vbYesNo Or vbQuestion) = MsgBoxResult.Yes Then
            lstFolders.Items.Clear()
            modSQLite.DeleteAllFolders()
        End If
    End Sub

End Class

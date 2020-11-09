<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class dlgSettings
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lstFolders = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnDeleteSelectedFolder = New System.Windows.Forms.Button()
        Me.btnDeleteAllFolders = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnClosedSyncFiles = New System.Windows.Forms.Button()
        Me.btnCloseNoSync = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lstFolders
        '
        Me.lstFolders.AllowDrop = True
        Me.lstFolders.FormattingEnabled = True
        Me.lstFolders.Location = New System.Drawing.Point(12, 25)
        Me.lstFolders.Name = "lstFolders"
        Me.lstFolders.Size = New System.Drawing.Size(411, 121)
        Me.lstFolders.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(411, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Drag && Drop Folder or File into the box to add the folder."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnDeleteSelectedFolder
        '
        Me.btnDeleteSelectedFolder.Location = New System.Drawing.Point(12, 152)
        Me.btnDeleteSelectedFolder.Name = "btnDeleteSelectedFolder"
        Me.btnDeleteSelectedFolder.Size = New System.Drawing.Size(161, 23)
        Me.btnDeleteSelectedFolder.TabIndex = 3
        Me.btnDeleteSelectedFolder.Text = "Delete Selected Folder"
        Me.btnDeleteSelectedFolder.UseVisualStyleBackColor = True
        '
        'btnDeleteAllFolders
        '
        Me.btnDeleteAllFolders.Location = New System.Drawing.Point(257, 152)
        Me.btnDeleteAllFolders.Name = "btnDeleteAllFolders"
        Me.btnDeleteAllFolders.Size = New System.Drawing.Size(166, 23)
        Me.btnDeleteAllFolders.TabIndex = 4
        Me.btnDeleteAllFolders.Text = "Delete All Folders"
        Me.btnDeleteAllFolders.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(9, 195)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(414, 31)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Syncing files will add new files found in the folder list to the database and del" &
    "ete files not found from the database. Files will not be deleted from the disk."
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnClosedSyncFiles
        '
        Me.btnClosedSyncFiles.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnClosedSyncFiles.Location = New System.Drawing.Point(12, 262)
        Me.btnClosedSyncFiles.Name = "btnClosedSyncFiles"
        Me.btnClosedSyncFiles.Size = New System.Drawing.Size(138, 23)
        Me.btnClosedSyncFiles.TabIndex = 6
        Me.btnClosedSyncFiles.Text = "Close and Sync files"
        Me.btnClosedSyncFiles.UseVisualStyleBackColor = True
        '
        'btnCloseNoSync
        '
        Me.btnCloseNoSync.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCloseNoSync.Location = New System.Drawing.Point(285, 262)
        Me.btnCloseNoSync.Name = "btnCloseNoSync"
        Me.btnCloseNoSync.Size = New System.Drawing.Size(138, 23)
        Me.btnCloseNoSync.TabIndex = 7
        Me.btnCloseNoSync.Text = "Close, do not Sync files"
        Me.btnCloseNoSync.UseVisualStyleBackColor = True
        '
        'dlgSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(435, 297)
        Me.Controls.Add(Me.btnCloseNoSync)
        Me.Controls.Add(Me.btnClosedSyncFiles)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnDeleteAllFolders)
        Me.Controls.Add(Me.btnDeleteSelectedFolder)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lstFolders)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgSettings"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Settings"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lstFolders As ListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnDeleteSelectedFolder As Button
    Friend WithEvents btnDeleteAllFolders As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents btnClosedSyncFiles As Button
    Friend WithEvents btnCloseNoSync As Button
End Class

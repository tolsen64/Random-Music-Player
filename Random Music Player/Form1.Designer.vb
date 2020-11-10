<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblID = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblFilename = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblFileFullPath = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.OpenFolderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.btnPause = New System.Windows.Forms.Button()
        Me.btnPlay = New System.Windows.Forms.Button()
        Me.btnDontPlayAgain = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.lblRuntime = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.lblPosition = New System.Windows.Forms.Label()
        Me.trkVolume = New System.Windows.Forms.TrackBar()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.trkSeek = New System.Windows.Forms.TrackBar()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblTotalFiles = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblFilesPlayed = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblDontPlay = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblWontPlay = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.trkVolume, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trkSeek, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblID)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(75, 37)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "id"
        '
        'lblID
        '
        Me.lblID.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblID.Location = New System.Drawing.Point(3, 16)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(69, 18)
        Me.lblID.TabIndex = 0
        Me.lblID.Text = "0"
        Me.lblID.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.lblFilename)
        Me.GroupBox2.Location = New System.Drawing.Point(93, 28)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(517, 37)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Playing Audio File"
        '
        'lblFilename
        '
        Me.lblFilename.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblFilename.Location = New System.Drawing.Point(3, 16)
        Me.lblFilename.Name = "lblFilename"
        Me.lblFilename.Size = New System.Drawing.Size(511, 18)
        Me.lblFilename.TabIndex = 0
        Me.lblFilename.Text = "None"
        Me.lblFilename.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.lblFileFullPath)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 71)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(598, 37)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Audio File Full Path"
        '
        'lblFileFullPath
        '
        Me.lblFileFullPath.ContextMenuStrip = Me.ContextMenuStrip1
        Me.lblFileFullPath.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblFileFullPath.Location = New System.Drawing.Point(3, 16)
        Me.lblFileFullPath.Name = "lblFileFullPath"
        Me.lblFileFullPath.Size = New System.Drawing.Size(592, 18)
        Me.lblFileFullPath.TabIndex = 0
        Me.lblFileFullPath.Text = "None"
        Me.lblFileFullPath.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTip1.SetToolTip(Me.lblFileFullPath, "Double-Click to open this folder.")
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenFolderToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(140, 26)
        '
        'OpenFolderToolStripMenuItem
        '
        Me.OpenFolderToolStripMenuItem.Name = "OpenFolderToolStripMenuItem"
        Me.OpenFolderToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.OpenFolderToolStripMenuItem.Text = "Open Folder"
        '
        'btnStop
        '
        Me.btnStop.Location = New System.Drawing.Point(12, 165)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(75, 45)
        Me.btnStop.TabIndex = 3
        Me.btnStop.Text = "Stop"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'btnPause
        '
        Me.btnPause.Location = New System.Drawing.Point(93, 165)
        Me.btnPause.Name = "btnPause"
        Me.btnPause.Size = New System.Drawing.Size(75, 45)
        Me.btnPause.TabIndex = 4
        Me.btnPause.Text = "Pause"
        Me.btnPause.UseVisualStyleBackColor = True
        '
        'btnPlay
        '
        Me.btnPlay.Location = New System.Drawing.Point(174, 165)
        Me.btnPlay.Name = "btnPlay"
        Me.btnPlay.Size = New System.Drawing.Size(75, 45)
        Me.btnPlay.TabIndex = 5
        Me.btnPlay.Text = "Play/Next"
        Me.btnPlay.UseVisualStyleBackColor = True
        '
        'btnDontPlayAgain
        '
        Me.btnDontPlayAgain.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDontPlayAgain.Location = New System.Drawing.Point(501, 165)
        Me.btnDontPlayAgain.Name = "btnDontPlayAgain"
        Me.btnDontPlayAgain.Size = New System.Drawing.Size(109, 45)
        Me.btnDontPlayAgain.TabIndex = 7
        Me.btnDontPlayAgain.Text = "Don't Play Again"
        Me.btnDontPlayAgain.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.lblRuntime)
        Me.GroupBox4.Location = New System.Drawing.Point(535, 114)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(75, 42)
        Me.GroupBox4.TabIndex = 8
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Runtime"
        '
        'lblRuntime
        '
        Me.lblRuntime.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblRuntime.Location = New System.Drawing.Point(3, 16)
        Me.lblRuntime.Name = "lblRuntime"
        Me.lblRuntime.Size = New System.Drawing.Size(69, 23)
        Me.lblRuntime.TabIndex = 0
        Me.lblRuntime.Text = "0"
        Me.lblRuntime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.lblPosition)
        Me.GroupBox5.Location = New System.Drawing.Point(12, 114)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(75, 45)
        Me.GroupBox5.TabIndex = 9
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Position"
        '
        'lblPosition
        '
        Me.lblPosition.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPosition.Location = New System.Drawing.Point(3, 16)
        Me.lblPosition.Name = "lblPosition"
        Me.lblPosition.Size = New System.Drawing.Size(69, 26)
        Me.lblPosition.TabIndex = 0
        Me.lblPosition.Text = "0"
        Me.lblPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'trkVolume
        '
        Me.trkVolume.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.trkVolume.Location = New System.Drawing.Point(255, 165)
        Me.trkVolume.Maximum = 100
        Me.trkVolume.Name = "trkVolume"
        Me.trkVolume.Size = New System.Drawing.Size(240, 45)
        Me.trkVolume.TabIndex = 11
        Me.trkVolume.TickFrequency = 10
        Me.trkVolume.TickStyle = System.Windows.Forms.TickStyle.Both
        Me.ToolTip1.SetToolTip(Me.trkVolume, "Volume")
        Me.trkVolume.Value = 50
        '
        'trkSeek
        '
        Me.trkSeek.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.trkSeek.LargeChange = 20
        Me.trkSeek.Location = New System.Drawing.Point(93, 114)
        Me.trkSeek.Maximum = 100
        Me.trkSeek.Name = "trkSeek"
        Me.trkSeek.Size = New System.Drawing.Size(436, 45)
        Me.trkSeek.SmallChange = 10
        Me.trkSeek.TabIndex = 12
        Me.trkSeek.TickFrequency = 10
        Me.trkSeek.TickStyle = System.Windows.Forms.TickStyle.Both
        Me.ToolTip1.SetToolTip(Me.trkSeek, "Volume")
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(622, 24)
        Me.MenuStrip1.TabIndex = 13
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SettingsToolStripMenuItem, Me.ToolStripMenuItem1, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.SettingsToolStripMenuItem.Text = "&Settings"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(113, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblTotalFiles, Me.lblFilesPlayed, Me.lblDontPlay, Me.lblWontPlay})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 222)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(622, 22)
        Me.StatusStrip1.TabIndex = 14
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblTotalFiles
        '
        Me.lblTotalFiles.Name = "lblTotalFiles"
        Me.lblTotalFiles.Size = New System.Drawing.Size(31, 17)
        Me.lblTotalFiles.Text = "TF: 0"
        Me.lblTotalFiles.ToolTipText = "Total Files"
        '
        'lblFilesPlayed
        '
        Me.lblFilesPlayed.Name = "lblFilesPlayed"
        Me.lblFilesPlayed.Size = New System.Drawing.Size(32, 17)
        Me.lblFilesPlayed.Text = "FP: 0"
        Me.lblFilesPlayed.ToolTipText = "Files Played"
        '
        'lblDontPlay
        '
        Me.lblDontPlay.Name = "lblDontPlay"
        Me.lblDontPlay.Size = New System.Drawing.Size(34, 17)
        Me.lblDontPlay.Text = "DP: 0"
        Me.lblDontPlay.ToolTipText = "Don't Play"
        '
        'lblWontPlay
        '
        Me.lblWontPlay.Name = "lblWontPlay"
        Me.lblWontPlay.Size = New System.Drawing.Size(37, 17)
        Me.lblWontPlay.Text = "WP: 0"
        Me.lblWontPlay.ToolTipText = "Won't Play"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(622, 244)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.trkSeek)
        Me.Controls.Add(Me.trkVolume)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.btnDontPlayAgain)
        Me.Controls.Add(Me.btnPlay)
        Me.Controls.Add(Me.btnPause)
        Me.Controls.Add(Me.btnStop)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Random Music Player"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.trkVolume, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trkSeek, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblID As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lblFilename As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents lblFileFullPath As Label
    Friend WithEvents btnStop As Button
    Friend WithEvents btnPause As Button
    Friend WithEvents btnPlay As Button
    Friend WithEvents btnDontPlayAgain As Button
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents lblRuntime As Label
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents lblPosition As Label
    Friend WithEvents trkVolume As TrackBar
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents trkSeek As TrackBar
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents lblTotalFiles As ToolStripStatusLabel
    Friend WithEvents lblFilesPlayed As ToolStripStatusLabel
    Friend WithEvents lblDontPlay As ToolStripStatusLabel
    Friend WithEvents lblWontPlay As ToolStripStatusLabel
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents OpenFolderToolStripMenuItem As ToolStripMenuItem
End Class

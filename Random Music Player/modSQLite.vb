Imports System.Data.SQLite
Imports System.IO
Imports System.Runtime.CompilerServices

Module modSQLite

    Private Function SQLiteConnectionString() As String
        With New SQLiteConnectionStringBuilder
            .DataSource = Path.Combine(My.Application.Info.DirectoryPath, "database.db")
            .DateTimeFormat = SQLiteDateFormats.CurrentCulture
            .DateTimeKind = DateTimeKind.Local
            .Version = 3
            SQLiteConnectionString = .ConnectionString
        End With
    End Function

    Private Function SqlQuery(tsql As String) As DataTable
        SqlQuery = New DataTable
        Using cmd As New SQLiteCommand(tsql, New SQLiteConnection(SQLiteConnectionString, True))
            cmd.Connection.Open()
            SqlQuery.Load(cmd.ExecuteReader)
            cmd.Connection.Close()
        End Using
    End Function

    Private Function SqlScalar(tsql As String) As Object
        Using cmd As New SQLiteCommand(tsql, New SQLiteConnection(SQLiteConnectionString, True))
            cmd.Connection.Open()
            SqlScalar = cmd.ExecuteScalar
            cmd.Connection.Close()
        End Using
    End Function

    Private Function SqlNonQuery(tsql As String) As Integer
        Using cmd As New SQLiteCommand(tsql, New SQLiteConnection(SQLiteConnectionString, True))
            cmd.Connection.Open()
            SqlNonQuery = cmd.ExecuteNonQuery
            cmd.Connection.Close()
        End Using
    End Function

    Public Sub CreateDatabase()
        Dim sql As String = "CREATE TABLE IF NOT EXISTS Files (" &
            "Filename TEXT," &
            "FileDate TEXT," &
            "FileExt TEXT," &
            "Filesize INT," &
            "Filepath TEXT," &
            "LastPlayed TEXT," &
            "TimesPlayed INT," &
            "DoNotPlay INT," &
            "WontPlay INT," &
            "WontPlayReason TEXT," &
            "UNIQUE(Filename,Filepath)" &
            ")"

        SqlNonQuery(sql)

        sql = "CREATE VIEW IF NOT EXISTS vwPlayableFiles AS " &
                "SELECT rowid, Filepath || '\' || Filename File " &
                "FROM Files " &
                "WHERE DoNotPlay = 0 " &
                "AND WontPlay = 0"

        SqlNonQuery(sql)

        sql = "CREATE TABLE IF NOT EXISTS Folders (" &
            "Folder TEXT," &
            "UNIQUE(Folder)" &
            ")"

        SqlNonQuery(sql)
    End Sub

    Public Function AddFile(fi As FileInfo)
        Dim sql As String = "INSERT OR IGNORE INTO Files VALUES ('" & fi.Name.Sqlify & "','" & fi.LastWriteTime & "','" & fi.Extension.Sqlify & "'," & fi.Length & ",'" & fi.DirectoryName.Sqlify & "','',0,0,0,'')"
        SqlNonQuery(sql)
    End Function

    Public Function GetPlayableFileIDs() As List(Of Integer)
        GetPlayableFileIDs = New List(Of Integer)
        Dim dt As DataTable = SqlQuery("SELECT rowid FROM vwPlayableFiles")
        For Each dr As DataRow In dt.Rows
            GetPlayableFileIDs.Add(dr(0))
        Next
        GetPlayableFileIDs.Sort()
    End Function

    Public Sub DontPlayFile(id As Integer)
        SqlNonQuery("UPDATE Files SET DoNotPlay = 1 WHERE rowid = " & id)
    End Sub

    Public Sub FileWontPlay(id As Integer, ex As Exception)
        SqlNonQuery("UPDATE Files SET WontPlay = 1, WontPlayReason = '" & ex.Message & "' WHERE rowid = " & id)
    End Sub

    Public Function GetFileToPlay(id As Integer) As String
        GetFileToPlay = SqlScalar("SELECT Filepath || '\' || Filename File FROM Files WHERE rowid = " & id & "; UPDATE Files SET LastPlayed = DATETIME(), TimesPlayed = TimesPlayed + 1 WHERE rowid = " & id & ";")
    End Function

    Public Function GetFolders() As List(Of String)
        Dim dt As DataTable = SqlQuery("SELECT Folder FROM Folders")
        GetFolders = New List(Of String)
        For Each dr As DataRow In dt.Rows
            GetFolders.Add(dr(0))
        Next
        GetFolders.Sort()
    End Function

    Public Sub AddFolder(name As String)
        SqlNonQuery("INSERT OR IGNORE INTO Folders VALUES ('" & name & "')")
    End Sub

    Public Sub DeleteFolder(name As String)
        SqlNonQuery("DELETE FROM Folders WHERE Folder = '" & name & "'")
    End Sub

    Public Sub DeleteAllFolders()
        SqlNonQuery("DELETE FROM Folders")
    End Sub

    <Extension>
    Private Function Sqlify(value As String) As String
        value = value.Replace("'", "''")
        Return value
    End Function

End Module

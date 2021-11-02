Imports System.Data.Common
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

    Private Function SqlQuery(tsql As String, Optional params As List(Of SQLiteParameter) = Nothing) As DataTable
        SqlQuery = New DataTable
        Using cmd As New SQLiteCommand(tsql, New SQLiteConnection(SQLiteConnectionString, True))
            If params IsNot Nothing Then
                For Each param In params
                    cmd.Parameters.Add(param)
                Next
            End If
            cmd.Connection.Open()
            SqlQuery.Load(cmd.ExecuteReader)
            cmd.Connection.Close()
        End Using
    End Function

    Private Function SqlScalar(tsql As String, Optional params As List(Of SQLiteParameter) = Nothing) As Object
        Using cmd As New SQLiteCommand(tsql, New SQLiteConnection(SQLiteConnectionString, True))
            If params IsNot Nothing Then
                For Each param In params
                    cmd.Parameters.Add(param)
                Next
            End If
            cmd.Connection.Open()
            SqlScalar = cmd.ExecuteScalar
            cmd.Connection.Close()
        End Using
    End Function

    Private Function SqlNonQuery(tsql As String, Optional params As List(Of SQLiteParameter) = Nothing) As Integer
        Using conn As New SQLiteConnection(SQLiteConnectionString, True)
            conn.Open()
            Using cmd As New SQLiteCommand(tsql, conn)
                If params IsNot Nothing Then
                    For Each param In params
                        cmd.Parameters.Add(param)
                    Next
                End If
                SqlNonQuery = cmd.ExecuteNonQuery
            End Using
        End Using
        'Using cmd As New SQLiteCommand(tsql, New SQLiteConnection(SQLiteConnectionString, True))
        '    If params IsNot Nothing Then
        '        For Each param In params
        '            cmd.Parameters.Add(param)
        '        Next
        '    End If
        '    cmd.Connection.Open()
        '    SqlNonQuery = cmd.ExecuteNonQuery
        '    cmd.Connection.Close()
        'End Using
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

    Public Sub AddFile(fi As FileInfo)
        'Dim sql As String = "INSERT OR IGNORE INTO Files VALUES ('" & fi.Name.Sqlify & "','" & fi.LastWriteTime & "','" & fi.Extension.Sqlify & "'," & fi.Length & ",'" & fi.DirectoryName.Sqlify & "','',0,0,0,'')"
        Dim sql As String = "INSERT OR IGNORE INTO Files VALUES (@Name,@LastWriteTime,@Extension,@Length,@DirectoryName,'',0,0,0,'')"
        Dim params As New List(Of SQLiteParameter) From {
            New SQLiteParameter("@Name", DbType.String) With {.Value = fi.Name},
            New SQLiteParameter("@LastWriteTime", DbType.DateTime) With {.Value = fi.LastWriteTime},
            New SQLiteParameter("@Extension", DbType.String) With {.Value = fi.Extension},
            New SQLiteParameter("@Length", DbType.VarNumeric) With {.Value = fi.Length},
            New SQLiteParameter("@DirectoryName", DbType.String) With {.Value = fi.DirectoryName}
        }
        SqlNonQuery(sql, params)
    End Sub

    Public Function GetPlayableFileIDs() As List(Of Integer)
        GetPlayableFileIDs = New List(Of Integer)
        Dim dt As DataTable = SqlQuery("SELECT rowid FROM vwPlayableFiles")
        For Each dr As DataRow In dt.Rows
            GetPlayableFileIDs.Add(dr(0))
        Next
        GetPlayableFileIDs.Sort()
    End Function

    Public Function GetDontPlayCount() As Integer
        Return SqlScalar("SELECT COUNT(*) FROM Files WHERE DoNotPlay = 1")
    End Function

    Public Function GetWontPlayCount() As Integer
        Return SqlScalar("SELECT COUNT(*) FROM Files WHERE WontPlay = 1")
    End Function

    Public Sub DontPlayFile(id As Integer)
        'Dim params As New List(Of SQLiteParameter) From {
        '    New SQLiteParameter("@rowid", DbType.Int32) With {.Value = id}
        '}
        'SqlNonQuery("UPDATE Files SET DoNotPlay = 1 WHERE rowid = @id", params)
        ' Had to comment out the above because SqlNonQuery was throwing "Insufficient parameters supplied to the command" and I couldn't get it to work.
        ' so now just include the id in the command instead of using parameters
        SqlNonQuery($"UPDATE Files SET DoNotPlay = 1 WHERE rowid = {id}")
    End Sub

    Public Sub FileWontPlay(id As Integer, ex As Exception)
        Dim params As New List(Of SQLiteParameter) From {
            New SQLiteParameter("@rowid", DbType.Int32) With {.Value = id},
            New SQLiteParameter("@Message", DbType.String) With {.Value = ex.Message}
        }
        SqlNonQuery("UPDATE Files SET WontPlay = 1, WontPlayReason = @Message WHERE rowid = @rowid", params)
    End Sub

    Public Function GetFileToPlay(id As Integer) As String
        Dim params As New List(Of SQLiteParameter) From {
            New SQLiteParameter("@rowid", DbType.Int32) With {.Value = id}
        }
        GetFileToPlay = SqlScalar("SELECT Filepath || '\' || Filename File FROM Files WHERE rowid = @rowid; UPDATE Files SET LastPlayed = DATETIME(), TimesPlayed = TimesPlayed + 1 WHERE rowid = @rowid;", params)
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
        Dim params As New List(Of SQLiteParameter) From {
            New SQLiteParameter("@name", DbType.String) With {.Value = name}
        }
        SqlNonQuery("INSERT OR IGNORE INTO Folders VALUES (@name)", params)
    End Sub

    Public Sub DeleteFolder(name As String)
        Dim params As New List(Of SQLiteParameter) From {
            New SQLiteParameter("@name", DbType.String) With {.Value = name}
        }
        SqlNonQuery("DELETE FROM Folders WHERE Folder = @name")
    End Sub

    Public Sub DeleteAllFolders()
        SqlNonQuery("DELETE FROM Folders")
    End Sub

End Module

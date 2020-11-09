Imports NAudio
Imports NAudio.Wave


Module modNAudio

    Private WithEvents waveOutDevice As IWavePlayer = New WaveOut With {.DeviceNumber = -1}
    Private audFileReader As AudioFileReader
    Private DoNotRaiseEvent As Boolean = False
    Public Event NAudioPlaybackStopped(ex As Exception)
    Public Event NAudioFileReadError(ex As Exception)

    Public Sub PlayFileFile(filename As String, volume As Single)
        DoNotRaiseEvent = True

        If waveOutDevice.PlaybackState <> PlaybackState.Stopped Then
            waveOutDevice.Stop()
            audFileReader.Close()
            audFileReader.Dispose()
            audFileReader = Nothing
        End If

        Try
            audFileReader = New AudioFileReader(filename) With {.Volume = volume}
        Catch ex As Exception
            Debug.WriteLine("PlayFileFile File=" & filename & "; Err: " & ex.Message)
            RaiseEvent NAudioFileReadError(ex)
            Exit Sub
        End Try

        DoNotRaiseEvent = False
        waveOutDevice.Init(audFileReader)
        waveOutDevice.Play()
    End Sub

    Public Sub [Pause]()
        waveOutDevice.Pause()
    End Sub

    Public Sub [Resume]()
        waveOutDevice.Play()
    End Sub

    Public Sub [Stop]()
        DoNotRaiseEvent = True
        waveOutDevice.Stop()
    End Sub

    Public Sub CloseDevice()
        If waveOutDevice IsNot Nothing Then
            waveOutDevice.Dispose()
            waveOutDevice = Nothing
        End If
        If audFileReader IsNot Nothing Then
            audFileReader.Dispose()
            audFileReader = Nothing
        End If
    End Sub

    Public Function GetMediaLength() As TimeSpan
        Return audFileReader.TotalTime
    End Function

    Public Function GetMediaPosition() As TimeSpan
        If audFileReader Is Nothing Then
            Return New TimeSpan(0)
        Else
            Return audFileReader.CurrentTime
        End If
    End Function

    Public Sub SetVolume(Value As Single)
        If audFileReader IsNot Nothing Then
            audFileReader.Volume = Value
        End If
    End Sub

    Public Sub SetCurrentTime(value As TimeSpan)
        audFileReader.CurrentTime = value
    End Sub

    Private Sub waveOutDevice_PlaybackStopped(sender As Object, e As StoppedEventArgs) Handles waveOutDevice.PlaybackStopped
        If Not DoNotRaiseEvent Then RaiseEvent NAudioPlaybackStopped(e.Exception)
    End Sub

End Module

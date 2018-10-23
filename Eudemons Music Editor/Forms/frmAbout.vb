Public NotInheritable Class frmAbout
  Private WithEvents cUpdate As clsUpdate
  Private tUpdate As Threading.Timer
  Private sUpdate As String = IO.Path.Combine(IO.Path.GetTempPath, "EME_Setup.exe")
  Private ellipsis As String

  Private Sub frmAbout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim ApplicationTitle As String
    If My.Application.Info.Title <> "" Then
      ApplicationTitle = My.Application.Info.Title
    Else
      ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
    End If
    Me.Text = String.Format("About {0}", ApplicationTitle)
    lblProduct.Text = My.Application.Info.ProductName
    lblVersion.Text = String.Format("Version {0}", My.Application.Info.Version.ToString)
    SetUpdateValue("Beginning update check...", True)
    lblCompany.Text = My.Application.Info.CompanyName
    txtDescription.Text = My.Application.Info.Description
    tUpdate = New Threading.Timer(New Threading.TimerCallback(AddressOf CheckForUpdates), Nothing, 1000, 5000)
  End Sub

  Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
    Me.Close()
  End Sub

  Private Sub SetUpdateValue(ByVal Message As String, ByVal Throbber As Boolean)
    If Throbber Then
      If lblUpdate.Image Is Nothing Then lblUpdate.Image = My.Resources.throbber
      If Not lblUpdate.Text = "      " & Message Then lblUpdate.Text = "      " & Message
    Else
      If lblUpdate.Image IsNot Nothing Then lblUpdate.Image = Nothing
      If Not lblUpdate.Text = Message Then lblUpdate.Text = Message
    End If
  End Sub

  Private Sub cmdDonate_Click(sender As System.Object, e As System.EventArgs) Handles cmdDonate.Click
    Diagnostics.Process.Start("http://realityripple.com/donate.php?itm=Eudemons+Music+Editor")
  End Sub

#Region "Updates"
  Private Sub CheckForUpdates(state As Object)
    If InvokeRequired Then
      Invoke(New Threading.TimerCallback(AddressOf CheckForUpdates), state)
      Return
    End If
    If tUpdate IsNot Nothing Then
      tUpdate.Dispose()
      tUpdate = Nothing
    Else
      Return
    End If
    ellipsis = ""
    SetUpdateValue("Checking for updates", True)
    cUpdate = New clsUpdate
    cUpdate.CheckVersion()
  End Sub

  Private Sub cUpdate_CheckingVersion(sender As Object, e As System.EventArgs) Handles cUpdate.CheckingVersion
    If InvokeRequired Then
      Invoke(New EventHandler(AddressOf cUpdate_CheckingVersion), sender, e)
      Return
    End If
    ellipsis &= "."
    If ellipsis = "...." Then ellipsis = ""
    SetUpdateValue("Checking for updates" & ellipsis, True)
  End Sub

  Private Sub cUpdate_CheckProgressChanged(sender As Object, e As clsUpdate.ProgressEventArgs) Handles cUpdate.CheckProgressChanged
    If InvokeRequired Then
      Invoke(New EventHandler(Of clsUpdate.ProgressEventArgs)(AddressOf cUpdate_CheckProgressChanged), sender, e)
      Return
    End If
    ellipsis &= "."
    If ellipsis = "...." Then ellipsis = ""
    SetUpdateValue("Checking for updates" & ellipsis, True)
  End Sub

  Private Sub cUpdate_CheckResult(sender As Object, e As clsUpdate.CheckEventArgs) Handles cUpdate.CheckResult
    If InvokeRequired Then
      Invoke(New EventHandler(Of clsUpdate.CheckEventArgs)(AddressOf cUpdate_CheckResult), sender, e)
      Return
    End If
    If e.Cancelled Then
      SetUpdateValue("Update check cancelled", False)
    ElseIf e.Error IsNot Nothing Then
      SetUpdateValue("Update check failed", False)
    Else
      My.Settings.PriorUpdate = Now
      My.Settings.Save()
      If e.Result = clsUpdate.CheckEventArgs.ResultType.NewUpdate Then
        SetUpdateValue("New version available: " & e.Version, False)
        Using dUpdate As New dlgUpdate(e.Version)
          If dUpdate.ShowDialog(Me) = Windows.Forms.DialogResult.Cancel Then
            SetUpdateValue("Update download cancelled", False)
            Return
          End If
        End Using
        Try
          If IO.File.Exists(sUpdate) Then IO.File.Delete(sUpdate)
          ellipsis = ""
          cUpdate.DownloadUpdate(sUpdate)
        Catch ex As Exception
          SetUpdateValue("Update download file in use", False)
        End Try
      Else
        SetUpdateValue("No new updates", False)
      End If
    End If
  End Sub

  Private Sub cUpdate_DownloadingUpdate(sender As Object, e As System.EventArgs) Handles cUpdate.DownloadingUpdate
    If InvokeRequired Then
      Invoke(New EventHandler(AddressOf cUpdate_DownloadingUpdate), sender, e)
      Return
    End If
    SetUpdateValue("Downloading new version...", True)
  End Sub

  Private Sub cUpdate_UpdateProgressChanged(sender As Object, e As clsUpdate.ProgressEventArgs) Handles cUpdate.UpdateProgressChanged
    If InvokeRequired Then
      Invoke(New EventHandler(Of clsUpdate.ProgressEventArgs)(AddressOf cUpdate_UpdateProgressChanged), sender, e)
      Return
    End If
    SetUpdateValue("Downloading new version: " & e.ProgressPercentage & "%", True)
  End Sub

  Private Sub cUpdate_DownloadResult(sender As Object, e As clsUpdate.DownloadEventArgs) Handles cUpdate.DownloadResult
    If InvokeRequired Then
      Invoke(New EventHandler(Of clsUpdate.DownloadEventArgs)(AddressOf cUpdate_DownloadResult), sender, e)
      Return
    End If
    If e.Cancelled Then
      SetUpdateValue("Update download cancelled", False)
    ElseIf e.Error IsNot Nothing Then
      SetUpdateValue("Update download failed", False)
    Else
      SetUpdateValue("Update download complete", False)
      If Not Authenticode.IsSelfSigned(sUpdate) Then
        SetUpdateValue("Update was not correctly signed", False)
        Return
      End If
      Try
        Dim oProc As New Process
        oProc.StartInfo.FileName = sUpdate
        oProc.StartInfo.Arguments = "/silent"
        oProc.StartInfo.WindowStyle = ProcessWindowStyle.Normal
        oProc.StartInfo.UseShellExecute = False
        oProc.Start()
        Application.Exit()
      Catch ex As Exception
        SetUpdateValue("Update failed to install", False)
      End Try
    End If
  End Sub

#End Region

End Class

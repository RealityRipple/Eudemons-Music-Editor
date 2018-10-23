Public Class frmMain
  Private Structure MusicData
    Dim Name As String
    Dim BGMusic As String
    Dim RangeData() As Ranges
    Friend Structure Ranges
      Dim X, Y, CX, CY As Integer
      Dim BGMusic As String
    End Structure
  End Structure

  Private MusicInfo() As MusicData
  Private bKeepInfo As Boolean
  Private bTranslate As Boolean
  Private MenuMusic As String
  Private ThumbSize As Integer
  Private NoSave As Boolean
  Private isClosing As Boolean
  Private WithEvents cUpdate As clsUpdate
  Private tUpdate As Threading.Timer
  Private sUpdate As String = IO.Path.Combine(IO.Path.GetTempPath, "EME_Setup.exe")

#Region "Window Events"
  Private Sub frmMain_Load(sender As Object, e As System.EventArgs) Handles Me.Load
    If My.Settings.UpgradeSettings Then
      My.Settings.Upgrade()
      My.Settings.UpgradeSettings = False
    End If
    If Command.Contains("/revert") Then
      Revert(Not Command.Contains("/s"))
      End
    Else
      isClosing = False
      If String.IsNullOrEmpty(My.Settings.MusicDir) Then My.Settings.MusicDir = Environment.CurrentDirectory & "\music"
      ThumbSize = 0
      bTranslate = Command.Contains("/translate")
      mnuTranslate.Checked = bTranslate
      bKeepInfo = False
      'LoadSettings()
      tmrStart.Enabled = True
    End If
  End Sub

  Private Sub frmMain_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    If e.CloseReason = CloseReason.UserClosing Then
      If cmdSave.Enabled Then
        Select Case MsgBox("Do you want to save your changes before closing?", MsgBoxStyle.YesNoCancel Or MsgBoxStyle.Question, "Save Changes?")
          Case MsgBoxResult.Yes : isClosing = True : SaveSettings()
          Case MsgBoxResult.No : isClosing = True
          Case MsgBoxResult.Cancel : e.Cancel = True
        End Select
      Else
        isClosing = True
      End If
    Else
      isClosing = True
    End If
  End Sub

  Private Sub pctTitle_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles pctTitle.MouseClick
    If e.Button = Windows.Forms.MouseButtons.Left Then
      Select Case ThumbSize
        Case 0 : ThumbSize = 1
        Case 1 : ThumbSize = 2
        Case 2 : ThumbSize = 2
        Case Else : ThumbSize = 0
      End Select
    ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
      Select Case ThumbSize
        Case 2 : ThumbSize = 1
        Case 1 : ThumbSize = 0
        Case 0 : ThumbSize = 0
        Case Else : ThumbSize = 0
      End Select
    End If
    cmbMaps_SelectedIndexChanged(cmbMaps, New EventArgs)
  End Sub

  Private Sub cmbMaps_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbMaps.SelectedIndexChanged
    NoSave = True
    If String.IsNullOrEmpty(cmbMaps.Text) Then
      lblMapMusic.Enabled = False
      txtMapMusic.Enabled = False
      cmdMapMusicBrowse.Enabled = False
      fraRanges.Enabled = False
      lblRangeCount.Enabled = False
      ntxRangeCount.Enabled = False
      cmbRange.Enabled = False
      lblRangeMusic.Enabled = False
      txtRangeMusic.Enabled = False
      cmdRangeMusicBrowse.Enabled = False
      lblRangePosition.Enabled = False
      ntxRangePositionX.Enabled = False
      ntxRangePositionY.Enabled = False
      lblRangeSize.Enabled = False
      ntxRangePositionCX.Enabled = False
      ntxRangePositionCY.Enabled = False
      ntxRangeEdgeNW.Enabled = False
      ntxRangeEdgeNE.Enabled = False
      lblRangeEdges.Enabled = False
      ntxRangeEdgeSW.Enabled = False
      ntxRangeEdgeSE.Enabled = False
      pctTitle.Image = My.Resources.bg
      ttMain.SetToolTip(pctTitle, Application.ProductName & vbNewLine & "by " & Application.CompanyName)
    Else
      If cmbMaps.Text = "Login Screen" Then
        lblMapMusic.Enabled = True
        txtMapMusic.Enabled = True
        cmdMapMusicBrowse.Enabled = True
        fraRanges.Enabled = False
        lblRangeCount.Enabled = False
        ntxRangeCount.Enabled = False
        cmbRange.Enabled = False
        lblRangeMusic.Enabled = False
        txtRangeMusic.Enabled = False
        cmdRangeMusicBrowse.Enabled = False
        lblRangePosition.Enabled = False
        ntxRangePositionX.Enabled = False
        ntxRangePositionY.Enabled = False
        lblRangeSize.Enabled = False
        ntxRangePositionCX.Enabled = False
        ntxRangePositionCY.Enabled = False
        ntxRangeEdgeNW.Enabled = False
        ntxRangeEdgeNE.Enabled = False
        lblRangeEdges.Enabled = False
        ntxRangeEdgeSW.Enabled = False
        ntxRangeEdgeSE.Enabled = False
        txtMapMusic.Text = MenuMusic
        pctTitle.Image = My.Resources.bg
        ttMain.SetToolTip(pctTitle, Application.ProductName & vbNewLine & "by " & Application.CompanyName)
      Else
        lblMapMusic.Enabled = cmbMaps.Enabled
        txtMapMusic.Enabled = cmbMaps.Enabled
        cmdMapMusicBrowse.Enabled = cmbMaps.Enabled
        fraRanges.Enabled = cmbMaps.Enabled
        lblRangeCount.Enabled = cmbMaps.Enabled
        ntxRangeCount.Enabled = cmbMaps.Enabled
        cmbRange.Enabled = cmbMaps.Enabled
        Dim MapID As String = cmbMaps.Text.Substring(cmbMaps.Text.IndexOf(" [") + 2)
        MapID = MapID.Substring(0, MapID.Length - 1)
        If cmbMaps.Enabled Then
          Dim iMap As Integer = Val(MapID.Substring(3))
          Using iniMiniMap As New clsINI(Environment.CurrentDirectory & "\ani\MiniMap.ANI")
            Dim iFrames As Integer = Val(iniMiniMap.GetValue(iMap, "FrameAmount"))
            Dim iVal As Integer = ThumbSize
            If ThumbSize >= iFrames Then iVal = iFrames - 1
            Dim sImg As String = Environment.CurrentDirectory & "\" & iniMiniMap.GetValue(iMap, "Frame" & iVal).Replace("/"c, "\"c)
            If My.Computer.FileSystem.FileExists(sImg) Then
              Cursor.Current = Cursors.AppStarting
              Select Case IO.Path.GetExtension(sImg).ToLower
                Case ".jpg", ".gif", ".bmp", ".png", ".tiff"
                  pctTitle.Image = Image.FromFile(sImg).Clone
                Case Else
                  Using fI As New FreeImageAPI.FreeImageBitmap(sImg)
                    pctTitle.Image = fI.ToBitmap
                  End Using
              End Select
              ttMain.SetToolTip(pctTitle, "Selected Map" & vbNewLine & "Left click to enlarge. Right click to shrink.")
              Cursor.Current = Cursors.Default
            Else
              pctTitle.Image = My.Resources.bg
              ttMain.SetToolTip(pctTitle, Application.ProductName & vbNewLine & "by " & Application.CompanyName)
            End If
          End Using
        Else
          lblRangeMusic.Enabled = False
          txtRangeMusic.Enabled = False
          cmdRangeMusicBrowse.Enabled = False
          lblRangePosition.Enabled = False
          ntxRangePositionX.Enabled = False
          ntxRangePositionY.Enabled = False
          lblRangeSize.Enabled = False
          ntxRangePositionCX.Enabled = False
          ntxRangePositionCY.Enabled = False
          ntxRangeEdgeNW.Enabled = False
          ntxRangeEdgeNE.Enabled = False
          lblRangeEdges.Enabled = False
          ntxRangeEdgeSW.Enabled = False
          ntxRangeEdgeSE.Enabled = False
        End If
        ShowMusicInfo(MapID)
      End If
    End If
    If pctTitle.Image IsNot Nothing Then
      If pctTitle.Image.Width > 320 Then
        Me.Width = pctTitle.Image.Width + 6
      Else
        Me.Width = 326
      End If
    Else
      Me.Width = 326
    End If
    Me.Height = 316 + pctTitle.Height
    NoSave = False
  End Sub

  Private Sub cmbRange_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbRange.SelectedIndexChanged
    Dim noB As Boolean = Not NoSave
    If noB Then NoSave = True
    If cmbRange.SelectedIndex = -1 Then
      lblRangeMusic.Enabled = False
      txtRangeMusic.Enabled = False
      cmdRangeMusicBrowse.Enabled = False
      lblRangePosition.Enabled = False
      ntxRangePositionX.Enabled = False
      ntxRangePositionY.Enabled = False
      lblRangeSize.Enabled = False
      ntxRangePositionCX.Enabled = False
      ntxRangePositionCY.Enabled = False
      ntxRangeEdgeNW.Enabled = False
      ntxRangeEdgeNE.Enabled = False
      lblRangeEdges.Enabled = False
      ntxRangeEdgeSW.Enabled = False
      ntxRangeEdgeSE.Enabled = False
      lblRangePriority.Enabled = False
      cmdRangePriorityUp.Enabled = False
      cmdRangePriorityDown.Enabled = False
    Else
      lblRangeMusic.Enabled = cmbMaps.Enabled
      txtRangeMusic.Enabled = cmbMaps.Enabled
      cmdRangeMusicBrowse.Enabled = cmbMaps.Enabled
      lblRangePosition.Enabled = cmbMaps.Enabled
      ntxRangePositionX.Enabled = cmbMaps.Enabled
      ntxRangePositionY.Enabled = cmbMaps.Enabled
      lblRangeSize.Enabled = cmbMaps.Enabled
      ntxRangePositionCX.Enabled = cmbMaps.Enabled
      ntxRangePositionCY.Enabled = cmbMaps.Enabled
      ntxRangeEdgeNW.Enabled = cmbMaps.Enabled
      ntxRangeEdgeNE.Enabled = cmbMaps.Enabled
      lblRangeEdges.Enabled = cmbMaps.Enabled
      ntxRangeEdgeSW.Enabled = cmbMaps.Enabled
      ntxRangeEdgeSE.Enabled = cmbMaps.Enabled
      lblRangePriority.Enabled = cmbMaps.Enabled
      cmdRangePriorityUp.Enabled = IIf(cmbRange.SelectedIndex = 0, False, cmbMaps.Enabled)
      cmdRangePriorityDown.Enabled = IIf(cmbRange.SelectedIndex = cmbRange.Items.Count - 1, False, cmbMaps.Enabled)
      Dim MapID As String = cmbMaps.Text.Substring(cmbMaps.Text.IndexOf(" [") + 2)
      MapID = MapID.Substring(0, MapID.Length - 1)
      Dim M As Integer = Array.FindIndex(MusicInfo, Function(data As MusicData) data.Name = MapID)
      If M > -1 Then
        ShowRangeInfo(MusicInfo(M).RangeData, cmbRange.SelectedIndex)
      End If
    End If
    If noB Then NoSave = False
  End Sub

  Private Sub tbsRangeLoc_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles tbsRangeLoc.SelectedIndexChanged
    If Not Me.Visible Then Exit Sub
    If NoSave Then Exit Sub
    Dim MapID As String = cmbMaps.Text.Substring(cmbMaps.Text.IndexOf(" [") + 2)
    MapID = MapID.Substring(0, MapID.Length - 1)
    Dim M As Integer = Array.FindIndex(MusicInfo, Function(data As MusicData) data.Name = MapID)
    If M > -1 Then
      ShowRangeInfo(MusicInfo(M).RangeData, cmbRange.SelectedIndex)
    End If
  End Sub

#Region "Text and Number Boxes"
  Private Sub txtMapMusic_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtMapMusic.TextChanged
    If NoSave Then Exit Sub
    cmdSave.Enabled = True
    If cmbMaps.Text = "Login Screen" Then
      MenuMusic = txtMapMusic.Text
    Else
      Dim MapID As String = cmbMaps.Text.Substring(cmbMaps.Text.IndexOf(" [") + 2)
      MapID = MapID.Substring(0, MapID.Length - 1)
      Dim M As Integer = Array.FindIndex(MusicInfo, Function(data As MusicData) data.Name = MapID)
      If M > -1 Then
        MusicInfo(M).BGMusic = txtMapMusic.Text
      End If
    End If
  End Sub

  Private Sub ntxRangeCount_ValueChanged(sender As System.Object, e As System.EventArgs) Handles ntxRangeCount.ValueChanged
    If Not NoSave Then cmdSave.Enabled = True
    'If NoSave Then Stop
    Dim MapID As String = cmbMaps.Text.Substring(cmbMaps.Text.IndexOf(" [") + 2)
    MapID = MapID.Substring(0, MapID.Length - 1)
    Dim M As Integer = Array.FindIndex(MusicInfo, Function(data As MusicData) data.Name = MapID)
    If M > -1 Then
      If ntxRangeCount.Value = 0 Then
        Erase MusicInfo(M).RangeData
        cmbRange.Items.Clear()
        cmbRange_SelectedIndexChanged(cmbRange, New EventArgs)
        cmbRange.Enabled = False
      Else
        cmbRange.Enabled = True
        ReDim Preserve MusicInfo(M).RangeData(ntxRangeCount.Value - 1)
        cmbRange.Items.Clear()
        For I As Integer = 0 To MusicInfo(M).RangeData.Count - 1
          cmbRange.Items.Add("Range " & I)
        Next
        cmbRange_SelectedIndexChanged(cmbRange, New EventArgs)
      End If
    End If
  End Sub

  Private Sub txtRangeMusic_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtRangeMusic.TextChanged
    If NoSave Then Exit Sub
    cmdSave.Enabled = True
    Dim MapID As String = cmbMaps.Text.Substring(cmbMaps.Text.IndexOf(" [") + 2)
    MapID = MapID.Substring(0, MapID.Length - 1)
    Dim M As Integer = Array.FindIndex(MusicInfo, Function(data As MusicData) data.Name = MapID)
    If M > -1 Then
      If cmbRange.SelectedIndex > -1 AndAlso cmbRange.SelectedIndex < MusicInfo(M).RangeData.Count Then MusicInfo(M).RangeData(cmbRange.SelectedIndex).BGMusic = txtRangeMusic.Text
    End If
  End Sub

  Private Sub ntxRange_GotFocus(sender As Object, e As System.EventArgs) Handles ntxRangePositionX.GotFocus, ntxRangePositionY.GotFocus, ntxRangePositionCX.GotFocus, ntxRangePositionCY.GotFocus, ntxRangeEdgeNW.GotFocus, ntxRangeEdgeNE.GotFocus, ntxRangeEdgeSW.GotFocus, ntxRangeEdgeSE.GotFocus
    CType(sender, NumericUpDown).Select(0, CType(sender, NumericUpDown).Value.ToString.Length)
  End Sub

  Private Sub ntxRange_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles ntxRangePositionX.KeyUp, ntxRangePositionY.KeyUp, ntxRangePositionCX.KeyUp, ntxRangePositionCY.KeyUp, ntxRangeEdgeNW.KeyUp, ntxRangeEdgeNE.KeyUp, ntxRangeEdgeSW.KeyUp, ntxRangeEdgeSE.KeyUp
    If e.KeyCode = Keys.Oemcomma Or e.KeyCode = Keys.Enter Then
      Select Case sender.Name
        Case ntxRangePositionX.Name : ntxRangePositionY.Focus()
        Case ntxRangePositionY.Name : ntxRangePositionCX.Focus()
        Case ntxRangePositionCX.Name : ntxRangePositionCY.Focus()
        Case ntxRangeEdgeNW.Name : ntxRangeEdgeNE.Focus()
        Case ntxRangeEdgeNE.Name : ntxRangeEdgeSW.Focus()
        Case ntxRangeEdgeSW.Name : ntxRangeEdgeSE.Focus()
      End Select
    End If
  End Sub

  Private Sub ntxRangePositionX_ValueChanged(sender As System.Object, e As System.EventArgs) Handles ntxRangePositionX.ValueChanged
    If NoSave Then Exit Sub
    cmdSave.Enabled = True
    If String.IsNullOrEmpty(cmbMaps.Text) Then Exit Sub
    Dim MapID As String = cmbMaps.Text.Substring(cmbMaps.Text.IndexOf(" [") + 2)
    MapID = MapID.Substring(0, MapID.Length - 1)
    Dim M As Integer = Array.FindIndex(MusicInfo, Function(data As MusicData) data.Name = MapID)
    If M > -1 Then
      If cmbRange.SelectedIndex > -1 AndAlso cmbRange.SelectedIndex < MusicInfo(M).RangeData.Count Then MusicInfo(M).RangeData(cmbRange.SelectedIndex).X = ntxRangePositionX.Value - 1
    End If
  End Sub

  Private Sub ntxRangePositionY_ValueChanged(sender As System.Object, e As System.EventArgs) Handles ntxRangePositionY.ValueChanged
    If NoSave Then Exit Sub
    cmdSave.Enabled = True
    If String.IsNullOrEmpty(cmbMaps.Text) Then Exit Sub
    Dim MapID As String = cmbMaps.Text.Substring(cmbMaps.Text.IndexOf(" [") + 2)
    MapID = MapID.Substring(0, MapID.Length - 1)
    Dim M As Integer = Array.FindIndex(MusicInfo, Function(data As MusicData) data.Name = MapID)
    If M > -1 Then
      If cmbRange.SelectedIndex > -1 AndAlso cmbRange.SelectedIndex < MusicInfo(M).RangeData.Count Then MusicInfo(M).RangeData(cmbRange.SelectedIndex).Y = ntxRangePositionY.Value - 1
    End If
  End Sub

  Private Sub ntxRangePositionCX_ValueChanged(sender As System.Object, e As System.EventArgs) Handles ntxRangePositionCX.ValueChanged
    If NoSave Then Exit Sub
    cmdSave.Enabled = True
    If String.IsNullOrEmpty(cmbMaps.Text) Then Exit Sub
    Dim MapID As String = cmbMaps.Text.Substring(cmbMaps.Text.IndexOf(" [") + 2)
    MapID = MapID.Substring(0, MapID.Length - 1)
    Dim M As Integer = Array.FindIndex(MusicInfo, Function(data As MusicData) data.Name = MapID)
    If M > -1 Then
      If cmbRange.SelectedIndex > -1 AndAlso cmbRange.SelectedIndex < MusicInfo(M).RangeData.Count Then MusicInfo(M).RangeData(cmbRange.SelectedIndex).CX = ntxRangePositionCX.Value + 2
    End If
  End Sub

  Private Sub ntxRangePositionCY_ValueChanged(sender As System.Object, e As System.EventArgs) Handles ntxRangePositionCY.ValueChanged
    If NoSave Then Exit Sub
    cmdSave.Enabled = True
    If String.IsNullOrEmpty(cmbMaps.Text) Then Exit Sub
    Dim MapID As String = cmbMaps.Text.Substring(cmbMaps.Text.IndexOf(" [") + 2)
    MapID = MapID.Substring(0, MapID.Length - 1)
    Dim M As Integer = Array.FindIndex(MusicInfo, Function(data As MusicData) data.Name = MapID)
    If M > -1 Then
      If cmbRange.SelectedIndex > -1 AndAlso cmbRange.SelectedIndex < MusicInfo(M).RangeData.Count Then MusicInfo(M).RangeData(cmbRange.SelectedIndex).CY = ntxRangePositionCY.Value + 2
    End If
  End Sub

  Private Sub ntxRangeEdgeNW_ValueChanged(sender As System.Object, e As System.EventArgs) Handles ntxRangeEdgeNW.ValueChanged
    If NoSave Then Exit Sub
    cmdSave.Enabled = True
    If String.IsNullOrEmpty(cmbMaps.Text) Then Exit Sub
    Dim MapID As String = cmbMaps.Text.Substring(cmbMaps.Text.IndexOf(" [") + 2)
    MapID = MapID.Substring(0, MapID.Length - 1)
    Dim M As Integer = Array.FindIndex(MusicInfo, Function(data As MusicData) data.Name = MapID)
    If M > -1 Then
      If cmbRange.SelectedIndex > -1 AndAlso cmbRange.SelectedIndex < MusicInfo(M).RangeData.Count Then
        MusicInfo(M).RangeData(cmbRange.SelectedIndex).X = ntxRangeEdgeNW.Value - 1
        MusicInfo(M).RangeData(cmbRange.SelectedIndex).CX = ntxRangeEdgeSW.Value - ntxRangeEdgeNW.Value + 2
      End If
    End If
  End Sub

  Private Sub ntxRangeEdgeNE_ValueChanged(sender As System.Object, e As System.EventArgs) Handles ntxRangeEdgeNE.ValueChanged
    If NoSave Then Exit Sub
    cmdSave.Enabled = True
    If String.IsNullOrEmpty(cmbMaps.Text) Then Exit Sub
    Dim MapID As String = cmbMaps.Text.Substring(cmbMaps.Text.IndexOf(" [") + 2)
    MapID = MapID.Substring(0, MapID.Length - 1)
    Dim M As Integer = Array.FindIndex(MusicInfo, Function(data As MusicData) data.Name = MapID)
    If M > -1 Then
      If cmbRange.SelectedIndex > -1 AndAlso cmbRange.SelectedIndex < MusicInfo(M).RangeData.Count Then
        MusicInfo(M).RangeData(cmbRange.SelectedIndex).Y = ntxRangeEdgeNE.Value - 1
        MusicInfo(M).RangeData(cmbRange.SelectedIndex).CY = ntxRangeEdgeSE.Value - ntxRangeEdgeNE.Value + 2
      End If
    End If
  End Sub

  Private Sub ntxRangeEdgeSW_ValueChanged(sender As System.Object, e As System.EventArgs) Handles ntxRangeEdgeSW.ValueChanged
    If NoSave Then Exit Sub
    cmdSave.Enabled = True
    If String.IsNullOrEmpty(cmbMaps.Text) Then Exit Sub
    Dim MapID As String = cmbMaps.Text.Substring(cmbMaps.Text.IndexOf(" [") + 2)
    MapID = MapID.Substring(0, MapID.Length - 1)
    Dim M As Integer = Array.FindIndex(MusicInfo, Function(data As MusicData) data.Name = MapID)
    If M > -1 Then
      If cmbRange.SelectedIndex > -1 AndAlso cmbRange.SelectedIndex < MusicInfo(M).RangeData.Count Then MusicInfo(M).RangeData(cmbRange.SelectedIndex).CX = ntxRangeEdgeSW.Value - ntxRangeEdgeNW.Value + 2
    End If
  End Sub

  Private Sub ntxRangeEdgeSE_ValueChanged(sender As System.Object, e As System.EventArgs) Handles ntxRangeEdgeSE.ValueChanged
    If NoSave Then Exit Sub
    cmdSave.Enabled = True
    If String.IsNullOrEmpty(cmbMaps.Text) Then Exit Sub
    Dim MapID As String = cmbMaps.Text.Substring(cmbMaps.Text.IndexOf(" [") + 2)
    MapID = MapID.Substring(0, MapID.Length - 1)
    Dim M As Integer = Array.FindIndex(MusicInfo, Function(data As MusicData) data.Name = MapID)
    If M > -1 Then
      If cmbRange.SelectedIndex > -1 AndAlso cmbRange.SelectedIndex < MusicInfo(M).RangeData.Count Then MusicInfo(M).RangeData(cmbRange.SelectedIndex).CY = ntxRangeEdgeSE.Value - ntxRangeEdgeNE.Value + 2
    End If
  End Sub
#End Region

#Region "Buttons"
  Private Sub cmdMapMusicBrowse_Click(sender As System.Object, e As System.EventArgs) Handles cmdMapMusicBrowse.Click
    Dim cdlOpenMusic As New OpenFileDialog With {.AutoUpgradeEnabled = True,
                                               .CheckFileExists = True,
                                               .Filter = IIf(cmbMaps.SelectedIndex = 0, "MP3 Files|*.mp3", "All Media Files|*.mp3;*.wma;*.wav;*.mid;*.midi;*.ogg;*.flac|MP3 Files|*.mp3|WMA Files|*.wma|WAV Files|*.wav|MIDI Files|*.mid;*.midi|OGG Files|*.ogg|FLAC Files|*.flac|All Files|*.*"),
                                               .InitialDirectory = My.Settings.MusicDir,
                                               .Multiselect = False,
                                               .ShowHelp = False,
                                               .ShowReadOnly = False,
                                               .Title = "Select Music File for Map Background Music..."}
    If cdlOpenMusic.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
      Dim sFile As String = cdlOpenMusic.FileName
      My.Settings.MusicDir = IO.Path.GetDirectoryName(sFile)
      If sFile.StartsWith(Environment.CurrentDirectory) Then
        sFile = sFile.Substring(Environment.CurrentDirectory.Length)
        If sFile.StartsWith("\") Then sFile = sFile.Substring(1)
        sFile = sFile.Replace("\"c, "/"c)
      End If
      txtMapMusic.Text = sFile
    End If
  End Sub

  Private Sub cmdRangeMusicBrowse_Click(sender As System.Object, e As System.EventArgs) Handles cmdRangeMusicBrowse.Click
    Dim cdlOpenMusic As New OpenFileDialog With {.AutoUpgradeEnabled = True,
                                               .CheckFileExists = True,
                                               .Filter = "All Media Files|*.mp3;*.wma;*.wav;*.mid;*.midi;*.ogg;*.flac|MP3 Files|*.mp3|WMA Files|*.wma|WAV Files|*.wav|MIDI Files|*.mid;*.midi|OGG Files|*.ogg|FLAC Files|*.flac|All Files|*.*",
                                               .InitialDirectory = My.Settings.MusicDir,
                                               .Multiselect = False,
                                               .ShowHelp = False,
                                               .ShowReadOnly = False,
                                               .Title = "Select Music File for Range Background Music..."}
    If cdlOpenMusic.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
      Dim sFile As String = cdlOpenMusic.FileName
      My.Settings.MusicDir = IO.Path.GetDirectoryName(sFile)
      If sFile.StartsWith(Environment.CurrentDirectory) Then
        sFile = sFile.Substring(Environment.CurrentDirectory.Length)
        If sFile.StartsWith("\") Then sFile = sFile.Substring(1)
        sFile = sFile.Replace("\"c, "/"c)
      End If
      txtRangeMusic.Text = sFile
    End If
  End Sub

  Private Sub cmdRangePriorityUp_Click(sender As System.Object, e As System.EventArgs) Handles cmdRangePriorityUp.Click
    Dim MapID As String = cmbMaps.Text.Substring(cmbMaps.Text.IndexOf(" [") + 2)
    MapID = MapID.Substring(0, MapID.Length - 1)
    Dim M As Integer = Array.FindIndex(MusicInfo, Function(data As MusicData) data.Name = MapID)
    If M > -1 Then
      If cmbRange.SelectedIndex > 0 Then
        Dim tmpRange As MusicData.Ranges = MusicInfo(M).RangeData(cmbRange.SelectedIndex - 1)
        MusicInfo(M).RangeData(cmbRange.SelectedIndex - 1) = MusicInfo(M).RangeData(cmbRange.SelectedIndex)
        MusicInfo(M).RangeData(cmbRange.SelectedIndex) = tmpRange
        cmdSave.Enabled = True
      End If
    End If
    cmbRange.SelectedIndex -= 1
  End Sub

  Private Sub cmdRangePriorityDown_Click(sender As System.Object, e As System.EventArgs) Handles cmdRangePriorityDown.Click
    Dim MapID As String = cmbMaps.Text.Substring(cmbMaps.Text.IndexOf(" [") + 2)
    MapID = MapID.Substring(0, MapID.Length - 1)
    Dim M As Integer = Array.FindIndex(MusicInfo, Function(data As MusicData) data.Name = MapID)
    If M > -1 Then
      If cmbRange.SelectedIndex < cmbRange.Items.Count - 1 Then
        Dim tmpRange As MusicData.Ranges = MusicInfo(M).RangeData(cmbRange.SelectedIndex + 1)
        MusicInfo(M).RangeData(cmbRange.SelectedIndex + 1) = MusicInfo(M).RangeData(cmbRange.SelectedIndex)
        MusicInfo(M).RangeData(cmbRange.SelectedIndex) = tmpRange
        cmdSave.Enabled = True
      End If
    End If
    cmbRange.SelectedIndex += 1
  End Sub

  Private Sub cmdSave_Click(sender As System.Object, e As System.EventArgs) Handles cmdSave.Click
    SaveSettings()
  End Sub

  Private Sub cmdClose_Click(sender As System.Object, e As System.EventArgs) Handles cmdClose.Click
    Me.Close()
  End Sub
#End Region

#Region "Menus"
  Private Sub mnuFile_DropDownOpening(sender As Object, e As System.EventArgs) Handles mnuFile.DropDownOpening
    mnuSave.Enabled = cmdSave.Enabled
    mnuTranslate.Checked = bTranslate
  End Sub

  Private Sub mnuReload_Click(sender As System.Object, e As System.EventArgs) Handles mnuReload.Click
    If MsgBox("Warning - Any changes you've made will not be saved." & vbNewLine & "Are you sure you want to reload all settings?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Reload Settings?") = MsgBoxResult.Yes Then
      bKeepInfo = False
      LoadSettings()
    End If
  End Sub

  Private Sub mnuSave_Click(sender As System.Object, e As System.EventArgs) Handles mnuSave.Click
    SaveSettings()
  End Sub

  Private Sub mnuRevert_Click(sender As System.Object, e As System.EventArgs) Handles mnuRevert.Click
    If MsgBox("Warning - This option will undo any changes you've made to Eudemons and return it to its original state." & vbNewLine & "Do you want to Revert all Settings?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Revert Settings?") = MsgBoxResult.Yes Then
      Revert(True)
      bKeepInfo = False
      LoadSettings()
    End If
  End Sub

  Private Sub mnuTranslate_Click(sender As System.Object, e As System.EventArgs) Handles mnuTranslate.Click
    bTranslate = Not bTranslate
    mnuTranslate.Checked = bTranslate
    bKeepInfo = True
    LoadSettings()
  End Sub

  Private Sub mnuImport_Click(sender As System.Object, e As System.EventArgs) Handles mnuImport.Click
    Dim cdlImport As New OpenFileDialog With {.CheckFileExists = True, .Filter = "Eudemons Music Pack|*.emp|All Files|*.*", .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments, .Multiselect = False, .ShowReadOnly = False, .Title = "Import Music Pack..."}
    If cdlImport.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
      Cursor.Current = Cursors.WaitCursor
      Dim fileData() As Byte = My.Computer.FileSystem.ReadAllBytes(cdlImport.FileName)
      Dim iniData() As Byte = Nothing
      Dim loginData() As Byte = Nothing
      Dim musicInfo() As MusicFile = Nothing
      If ReadMusicPack(fileData, iniData, loginData, musicInfo) Then
        If iniData IsNot Nothing And loginData IsNot Nothing And musicInfo IsNot Nothing Then
          If Not My.Computer.FileSystem.FileExists(Environment.CurrentDirectory & "\ini\bgmusic.ini.bak") Then My.Computer.FileSystem.MoveFile(Environment.CurrentDirectory & "\ini\bgmusic.ini", Environment.CurrentDirectory & "\ini\bgmusic.ini.bak")
          If Not My.Computer.FileSystem.FileExists(Environment.CurrentDirectory & "\sound\backGround.mp3.bak") Then My.Computer.FileSystem.MoveFile(Environment.CurrentDirectory & "\sound\backGround.mp3", Environment.CurrentDirectory & "\sound\backGround.mp3.bak")
          Dim BackupDir As String = Environment.CurrentDirectory & "\music\bak"
          If Not My.Computer.FileSystem.DirectoryExists(BackupDir) Then
            Try
              My.Computer.FileSystem.CreateDirectory(BackupDir)
              For Each File In My.Computer.FileSystem.GetFiles(Environment.CurrentDirectory & "\music")
                My.Computer.FileSystem.MoveFile(File, BackupDir & "\" & IO.Path.GetFileName(File))
              Next
            Catch ex As Exception
              Cursor.Current = Cursors.Default
              MsgBox("Failed to back up music!" & vbNewLine & ex.Message, MsgBoxStyle.Critical)
              Exit Sub
            End Try
          End If
          My.Computer.FileSystem.WriteAllBytes(Environment.CurrentDirectory & "\ini\bgmusic.ini", iniData, False)
          My.Computer.FileSystem.WriteAllBytes(Environment.CurrentDirectory & "\sound\backGround.mp3", loginData, False)
          For Each file In musicInfo
            My.Computer.FileSystem.WriteAllBytes(Environment.CurrentDirectory & "\music\" & file.Filename, file.Data, False)
          Next
          Cursor.Current = Cursors.Default
          MsgBox("Eudemons Music Pack has been imported!", MsgBoxStyle.Information, "Import Complete")
          bKeepInfo = False
          LoadSettings()
        End If
      End If
    End If
  End Sub

  Private Sub mnuExport_Click(sender As System.Object, e As System.EventArgs) Handles mnuExport.Click
    Dim cdlExport As New SaveFileDialog With {.AddExtension = True, .CheckPathExists = True, .Filter = "Eumemons Music Pack|*.emp", .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments, .OverwritePrompt = True, .Title = "Export Music Pack..."}
    If cdlExport.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
      Cursor.Current = Cursors.WaitCursor
      Dim iniData() As Byte = My.Computer.FileSystem.ReadAllBytes(Environment.CurrentDirectory & "\ini\bgmusic.ini")
      Dim loginData() As Byte = My.Computer.FileSystem.ReadAllBytes(Environment.CurrentDirectory & "\sound\backGround.mp3")
      Dim sFiles() As String = My.Computer.FileSystem.GetFiles(Environment.CurrentDirectory & "\music\", FileIO.SearchOption.SearchTopLevelOnly).ToArray
      Dim musicInfo(sFiles.Count - 1) As MusicFile
      For I As Integer = 0 To sFiles.Count - 1
        musicInfo(I).Filename = IO.Path.GetFileName(sFiles(I))
        musicInfo(I).Data = My.Computer.FileSystem.ReadAllBytes(sFiles(I))
      Next
      Dim bData() As Byte = CreateMusicPack(iniData, loginData, musicInfo)
      Do
        Dim di = My.Computer.FileSystem.GetDriveInfo(cdlExport.FileName.Substring(0, 3))
        If di.AvailableFreeSpace < bData.Length Then
          If MsgBox("You do not have enough free space on drive " & cdlExport.FileName.Substring(0, 2) & " to export this music pack." & vbNewLine & "Please free at least " & FormatNumber(bData.Length - di.AvailableFreeSpace, 0, TriState.False, TriState.False, TriState.True) & " bytes to continue.", MsgBoxStyle.RetryCancel Or MsgBoxStyle.Critical, "Out of Drive Space") = MsgBoxResult.Retry Then
            Continue Do
          Else
            Cursor.Current = Cursors.Default
            Exit Sub
          End If
        Else
          Exit Do
        End If
      Loop
      My.Computer.FileSystem.WriteAllBytes(cdlExport.FileName, bData, False)
      Cursor.Current = Cursors.Default
      MsgBox("Eudemons Music Pack saved to " & cdlExport.FileName & "!", MsgBoxStyle.Information, "Export Complete!")
    End If
  End Sub

  Private Sub mnuExit_Click(sender As System.Object, e As System.EventArgs) Handles mnuExit.Click
    Me.Close()
  End Sub

  Private Sub mnuMapView_DropDownOpening(sender As Object, e As System.EventArgs) Handles mnuMapView.DropDownOpening
    Select Case ThumbSize
      Case 0 : mnuView1.Checked = True
      Case 1 : mnuView2.Checked = True
      Case 2 : mnuView3.Checked = True
      Case Else : mnuView1.Checked = True
    End Select
  End Sub

  Private Sub mnuView_Click(sender As System.Object, e As System.EventArgs) Handles mnuView1.Click, mnuView2.Click, mnuView3.Click
    If mnuView1.Checked Then
      If Not ThumbSize = 0 Then
        ThumbSize = 0
        cmbMaps_SelectedIndexChanged(cmbMaps, New EventArgs)
      End If
    ElseIf mnuView2.Checked Then
      If Not ThumbSize = 1 Then
        ThumbSize = 1
        cmbMaps_SelectedIndexChanged(cmbMaps, New EventArgs)
      End If
    ElseIf mnuView3.Checked Then
      If Not ThumbSize = 2 Then
        ThumbSize = 2
        cmbMaps_SelectedIndexChanged(cmbMaps, New EventArgs)
      End If
    Else
      mnuView1.Checked = True
      mnuView_Click(sender, e)
    End If
  End Sub

  Private Sub mnuTips_Click(sender As System.Object, e As System.EventArgs) Handles mnuTips.Click
    Process.Start(Application.StartupPath & "\Tips.txt")
  End Sub

  Private Sub mnuWebpage_Click(sender As System.Object, e As System.EventArgs) Handles mnuWebpage.Click
    Process.Start("http://realityripple.com/Software/Applications/Eudemons_Music_Editor/")
  End Sub

  Private Sub mnuAbout_Click(sender As System.Object, e As System.EventArgs) Handles mnuAbout.Click
    frmAbout.ShowDialog(Me)
  End Sub
#End Region
#End Region

#Region "Subroutines"
  Dim lblProgress As Label
  Private Sub LoadSettings()
    lblProgress = New Label
    lblProgress.Text = "0%"
    lblProgress.Anchor = AnchorStyles.Left
    lblProgress.AutoSize = True
    pnlMain.Controls.Remove(cmdSave)
    pnlMain.Controls.Add(lblProgress, 1, 3)
    pctProgress.Visible = True
    pctTitle.Image = My.Resources.bg
    ttMain.SetToolTip(pctTitle, Application.ProductName & vbNewLine & "by " & Application.CompanyName)
    If Not bKeepInfo Then
      MenuMusic = "sound/backGround.mp3"
      Erase MusicInfo
    End If
    cmbMaps.Items.Clear()
    cmbMaps.Items.Add("Login Screen")
    cmbMaps.Enabled = False
    cmdSave.Enabled = False
    mnuFile.Enabled = False
    cmbMaps.SelectedIndex = 0
    Me.UseWaitCursor = True
    Application.DoEvents()
    ReadGameMapINI()
    pctProgress.Visible = False
    pnlMain.Controls.Remove(lblProgress)
    lblProgress = Nothing
    pnlMain.Controls.Add(cmdSave, 1, 3)
  End Sub

  Private Sub SaveSettings()
    If MsgBox("Warning! These settings will change INI data and files in your Eudemons directory. While the initial settings will be backed up, it may still be dangerous to use this program." & vbNewLine & vbNewLine & "Are you sure you want to save these settings?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Save Music Settings?") = MsgBoxResult.Yes Then
      Dim BackupDir As String = Environment.CurrentDirectory & "\music\bak"
      If Not My.Computer.FileSystem.DirectoryExists(BackupDir) Then
        Try
          My.Computer.FileSystem.CreateDirectory(BackupDir)
          For Each File In My.Computer.FileSystem.GetFiles(Environment.CurrentDirectory & "\music")
            My.Computer.FileSystem.CopyFile(File, BackupDir & "\" & IO.Path.GetFileName(File))
          Next
        Catch ex As Exception
          MsgBox("Failed to back up music!" & vbNewLine & ex.Message, MsgBoxStyle.Critical)
          Exit Sub
        End Try
      End If
      If Not My.Computer.FileSystem.FileExists(Environment.CurrentDirectory & "\ini\bgmusic.ini.bak") Then
        Try
          My.Computer.FileSystem.CopyFile(Environment.CurrentDirectory & "\ini\bgmusic.ini", Environment.CurrentDirectory & "\ini\bgmusic.ini.bak", False)
        Catch ex As Exception
          MsgBox("Failed to back up bgmusic.ini!" & vbNewLine & ex.Message, MsgBoxStyle.Critical)
          Exit Sub
        End Try
      End If

      If My.Computer.FileSystem.FileExists(MenuMusic) And MenuMusic.Substring(1, 2) = ":\" Then
        If Not My.Computer.FileSystem.FileExists(Environment.CurrentDirectory & "\sound\backGround.mp3.bak") Then
          Try
            My.Computer.FileSystem.CopyFile(Environment.CurrentDirectory & "\sound\backGround.mp3", Environment.CurrentDirectory & "\sound\backGround.mp3.bak", False)
          Catch ex As Exception
            MsgBox("Failed to back up menu music!" & vbNewLine & ex.Message, MsgBoxStyle.Critical)
            Exit Sub
          End Try
        End If
        My.Computer.FileSystem.CopyFile(MenuMusic, Environment.CurrentDirectory & "\sound\backGround.mp3", True)
      End If

      Using NewINI As New clsINI(Environment.CurrentDirectory & "\ini\bgmusic.ini")
        For Each item In MusicInfo
          If String.IsNullOrEmpty(item.BGMusic) Then
            NewINI.SetValue(item.Name, "Bgmusic", Nothing)
          Else
            If My.Computer.FileSystem.FileExists(item.BGMusic) And item.BGMusic.Substring(1, 2) = ":\" Then
              Dim OldName As String = NewINI.GetValue(item.Name, "Bgmusic")
              If String.IsNullOrEmpty(OldName) Then
                Dim iTry As Integer = 1
                Do
                  OldName = "music/" & item.Name.Substring(3) & "-" & iTry & ".mp3"
                  If My.Computer.FileSystem.FileExists(Environment.CurrentDirectory & "\" & OldName.Replace("/"c, "\"c)) Then
                    iTry += 1
                  Else
                    Exit Do
                  End If
                Loop
                'New file will be created for this map!
              ElseIf IO.Path.GetExtension(OldName).ToLower <> IO.Path.GetExtension(item.BGMusic).ToLower Then
                OldName = IO.Path.ChangeExtension(OldName, IO.Path.GetExtension(item.BGMusic))
              End If
              Dim FPath As String = Environment.CurrentDirectory & "\" & OldName.Replace("/"c, "\"c)

              My.Computer.FileSystem.CopyFile(item.BGMusic, FPath, True)
              NewINI.SetValue(item.Name, "Bgmusic", OldName)

            Else
              NewINI.SetValue(item.Name, "Bgmusic", item.BGMusic)
            End If
          End If


          If item.RangeData IsNot Nothing AndAlso item.RangeData.Count > 0 Then
            NewINI.SetValue(item.Name, "RangMusicAmount", item.RangeData.Count)
            For I As Integer = 0 To item.RangeData.Count - 1
              If String.IsNullOrEmpty(item.RangeData(I).BGMusic) Then
                NewINI.SetValue(item.Name, "x" & I, Nothing)
                NewINI.SetValue(item.Name, "y" & I, Nothing)
                NewINI.SetValue(item.Name, "cx" & I, Nothing)
                NewINI.SetValue(item.Name, "cy" & I, Nothing)
                NewINI.SetValue(item.Name, "RangMusic" & I, Nothing)
              Else
                If My.Computer.FileSystem.FileExists(item.RangeData(I).BGMusic) And item.RangeData(I).BGMusic.Substring(1, 2) = ":\" Then
                  Dim OldRName As String = NewINI.GetValue(item.Name, "RangMusic" & I)

                  If String.IsNullOrEmpty(OldRName) Then
                    Dim iTry As Integer = 1
                    Do
                      OldRName = "music/" & item.Name.Substring(3) & "-" & iTry & ".mp3"
                      If My.Computer.FileSystem.FileExists(Environment.CurrentDirectory & "\" & OldRName.Replace("/"c, "\"c)) Then
                        iTry += 1
                      Else
                        Exit Do
                      End If
                    Loop
                    'New file will be created for this map!
                  ElseIf IO.Path.GetExtension(OldRName).ToLower <> IO.Path.GetExtension(item.RangeData(I).BGMusic).ToLower Then
                    OldRName = IO.Path.ChangeExtension(OldRName, IO.Path.GetExtension(item.RangeData(I).BGMusic))
                  End If

                  Dim FPath As String = Environment.CurrentDirectory & "\" & OldRName.Replace("/"c, "\"c)

                  My.Computer.FileSystem.CopyFile(item.RangeData(I).BGMusic, FPath, True)

                  NewINI.SetValue(item.Name, "RangMusic" & I, OldRName)
                  NewINI.SetValue(item.Name, "x" & I, item.RangeData(I).X)
                  NewINI.SetValue(item.Name, "y" & I, item.RangeData(I).Y)
                  NewINI.SetValue(item.Name, "cx" & I, item.RangeData(I).CX)
                  NewINI.SetValue(item.Name, "cy" & I, item.RangeData(I).CY)
                Else
                  NewINI.SetValue(item.Name, "RangMusic" & I, item.RangeData(I).BGMusic)
                  NewINI.SetValue(item.Name, "x" & I, item.RangeData(I).X)
                  NewINI.SetValue(item.Name, "y" & I, item.RangeData(I).Y)
                  NewINI.SetValue(item.Name, "cx" & I, item.RangeData(I).CX)
                  NewINI.SetValue(item.Name, "cy" & I, item.RangeData(I).CY)
                End If
              End If

            Next
          Else
            NewINI.SetValue(item.Name, "RangMusicAmount", Nothing)
          End If
        Next
      End Using
      MsgBox("Your new soundtrack has been saved!" & vbNewLine & vbNewLine & "If Eudemons is running, you may need to go to a different map for changes to take effect.", MsgBoxStyle.Information, "Settings Saved!")
      cmdSave.Enabled = False
    End If
  End Sub

  Private Sub Revert(Alert As Boolean)
    Dim bINI, bMenu, bMusic As Boolean
    If My.Computer.FileSystem.FileExists(Environment.CurrentDirectory & "\ini\bgmusic.ini.bak") Then
      My.Computer.FileSystem.MoveFile(Environment.CurrentDirectory & "\ini\bgmusic.ini.bak", Environment.CurrentDirectory & "\ini\bgmusic.ini", True)
      bINI = True
    End If
    If My.Computer.FileSystem.FileExists(Environment.CurrentDirectory & "\sound\backGround.mp3.bak") Then
      My.Computer.FileSystem.MoveFile(Environment.CurrentDirectory & "\sound\backGround.mp3.bak", Environment.CurrentDirectory & "\sound\backGround.mp3", True)
      bMenu = True
    End If
    If My.Computer.FileSystem.DirectoryExists(Environment.CurrentDirectory & "\music\bak") AndAlso My.Computer.FileSystem.GetFiles(Environment.CurrentDirectory & "\music\bak").Count > 0 Then
      For Each File In My.Computer.FileSystem.GetFiles(Environment.CurrentDirectory & "\music")
        My.Computer.FileSystem.DeleteFile(File)
      Next
      For Each File In My.Computer.FileSystem.GetFiles(Environment.CurrentDirectory & "\music\bak")
        My.Computer.FileSystem.MoveFile(File, Environment.CurrentDirectory & "\music\" & IO.Path.GetFileName(File))
      Next
      My.Computer.FileSystem.DeleteDirectory(Environment.CurrentDirectory & "\music\bak", FileIO.DeleteDirectoryOption.DeleteAllContents)
      bMusic = True
    End If

    Dim sMsg As String = String.Empty
    If bINI Or bMenu Or bMusic Then
      sMsg &= "All changes have been reverted." & vbNewLine
      If bINI Then sMsg &= " • bgmusic.ini backup restored." & vbNewLine
      If bMenu Then sMsg &= " • Login window music backup restored." & vbNewLine
      If bMusic Then sMsg &= " • In-game music backup restored." & vbNewLine
    Else
      sMsg &= "No changes were made to be reverted."
    End If
    If Alert Then MsgBox(sMsg, MsgBoxStyle.Information, "Eudemons Music Editor")
  End Sub

#Region "Map List"
  Private Sub SetMapText(sText As String)
    cmbMaps.Text = sText
  End Sub

  Private Sub AddToMapList(sName As String)
    Try
      cmbMaps.Items.Add(sName)
      'Me.BeginInvoke(New Threading.ParameterizedThreadStart(AddressOf SetMapText), sName)
      If Not bKeepInfo Then
        Dim MapID As String = sName.Substring(sName.IndexOf(" [") + 2)
        MapID = MapID.Substring(0, MapID.Length - 1)
        If MusicInfo Is Nothing Then
          ReDim MusicInfo(0)
          MusicInfo(0).Name = MapID
        Else
          ReDim Preserve MusicInfo(MusicInfo.Length)
          MusicInfo(MusicInfo.Length - 1).Name = MapID
        End If
        ReadMusicINI(MapID)
      End If
    Catch
      If Me.Disposing Or Me.IsDisposed Then End
    End Try
  End Sub

  Private Sub MapListComplete()
    cmbMaps.SelectedIndex = -1
    cmbMaps.Enabled = True
    'cmdSave.Enabled = True
    mnuFile.Enabled = True
    bKeepInfo = False
    Me.UseWaitCursor = False
  End Sub
#End Region

#Region "INI Reading"
  Private Sub ReadGameMapINI()
    Using iRead As New clsINI(Environment.CurrentDirectory & "\ini\GameMap.ini")
      Dim sSections() As String = iRead.GetSections
      For S As Integer = 0 To sSections.Length - 1
        Dim sName As String = iRead.GetValue(sSections(S), "Name")
        If Not String.IsNullOrEmpty(sName) Then
          Dim bName() As Byte = System.Text.Encoding.GetEncoding("latin1").GetBytes(sName)
          Dim sChi As String = System.Text.Encoding.GetEncoding("chinese").GetString(bName)
          If sChi = sName Then
            AddToMapList(sName & " [" & sSections(S) & "]")
          Else
            If bTranslate Then
              Dim trans As New Translator
              Dim sEng As String = trans.ChineseToEnglish(sChi)
              AddToMapList("* " & sEng & " [" & sSections(S) & "]")
            Else
              AddToMapList(sChi & " [" & sSections(S) & "]")
            End If
          End If
        End If
        If lblProgress IsNot Nothing Then
          Dim sPercent As String = "Reading map " & (S + 1) & " of " & sSections.Count & "       " & FormatPercent((S + 1) / sSections.Length, 0, TriState.UseDefault, TriState.False, TriState.False)
          If Not lblProgress.Text = sPercent Then
            lblProgress.Text = sPercent
            Application.DoEvents()
          End If
        Else
          Application.DoEvents()
        End If
        If isClosing Then Exit Sub
      Next
    End Using
    MapListComplete()
  End Sub

  Private Sub ReadMusicINI(MapID As String)
    Using iRead As New clsINI(Environment.CurrentDirectory & "\ini\bgmusic.ini")
      If iRead.GetSections.Contains(MapID) Then
        If Array.Exists(MusicInfo, Function(data As MusicData) data.Name = MapID) Then
          Dim MusicID As Integer = Array.FindIndex(MusicInfo, Function(data As MusicData) data.Name = MapID)
          MusicInfo(MusicID).BGMusic = iRead.GetValue(MapID, "Bgmusic")
          Dim Ranges As String = iRead.GetValue(MapID, "RangMusicAmount")
          Dim iRanges As Integer = IIf(String.IsNullOrEmpty(Ranges), 0, Ranges)
          If iRanges > 0 Then
            ReDim MusicInfo(MusicID).RangeData(iRanges - 1)
            For I As Integer = 0 To iRanges - 1
              MusicInfo(MusicID).RangeData(I).BGMusic = iRead.GetValue(MapID, "RangMusic" & I)
              MusicInfo(MusicID).RangeData(I).X = Val(iRead.GetValue(MapID, "x" & I))
              MusicInfo(MusicID).RangeData(I).Y = Val(iRead.GetValue(MapID, "y" & I))
              MusicInfo(MusicID).RangeData(I).CX = Val(iRead.GetValue(MapID, "cx" & I))
              MusicInfo(MusicID).RangeData(I).CY = Val(iRead.GetValue(MapID, "cy" & I))
            Next
          Else
            Erase MusicInfo(MusicID).RangeData
          End If

        End If
      Else
        If Array.Exists(MusicInfo, Function(data As MusicData) data.Name = MapID) Then
          Dim MusicID As Integer = Array.FindIndex(MusicInfo, Function(data As MusicData) data.Name = MapID)
          MusicInfo(MusicID).BGMusic = String.Empty
          Erase MusicInfo(MusicID).RangeData
        End If
      End If
    End Using
  End Sub
#End Region

#Region "Show Info"
  Private Sub ShowMusicInfo(MapID As String)
    If MusicInfo Is Nothing Then Exit Sub
    If Array.Exists(MusicInfo, Function(data As MusicData) data.Name = MapID) Then
      Dim iMusic As Integer = Array.FindIndex(MusicInfo, Function(data As MusicData) data.Name = MapID)
      Dim Music As MusicData = MusicInfo(iMusic)
      txtMapMusic.Text = Music.BGMusic
      If Music.RangeData Is Nothing Then
        ntxRangeCount.Value = 0
      Else
        ntxRangeCount.Value = Music.RangeData.Count
      End If
      If ntxRangeCount.Value > 0 Then
        cmbRange.Enabled = True
        cmbRange.SelectedIndex = 0
      Else
        cmbRange.SelectedIndex = -1
        txtRangeMusic.Text = String.Empty
        ntxRangePositionX.Value = 1
        ntxRangePositionY.Value = 1
        ntxRangePositionCX.Value = 0
        ntxRangePositionCY.Value = 0
        ntxRangeEdgeNW.Value = 1
        ntxRangeEdgeNE.Value = 1
        ntxRangeEdgeSW.Value = 1
        ntxRangeEdgeSE.Value = 1
        cmbRange.Enabled = False
      End If
    Else
      txtMapMusic.Text = String.Empty
      ntxRangeCount.Value = 0
      cmbRange.SelectedIndex = -1
      txtRangeMusic.Text = String.Empty
      ntxRangePositionX.Value = 1
      ntxRangePositionY.Value = 1
      ntxRangePositionCX.Value = 0
      ntxRangePositionCY.Value = 0
      ntxRangeEdgeNW.Value = 1
      ntxRangeEdgeNE.Value = 1
      ntxRangeEdgeSW.Value = 1
      ntxRangeEdgeSE.Value = 1
    End If
  End Sub

  Private Sub ShowRangeInfo(data() As MusicData.Ranges, Index As Integer)
    If data IsNot Nothing AndAlso data.Count > Index Then
      txtRangeMusic.Text = data(Index).BGMusic
      ntxRangePositionX.Value = data(Index).X + 1
      ntxRangePositionY.Value = data(Index).Y + 1
      ntxRangePositionCX.Value = IIf(data(Index).CX > 1, data(Index).CX - 2, 0)
      ntxRangePositionCY.Value = IIf(data(Index).CY > 1, data(Index).CY - 2, 0)
      ntxRangeEdgeNW.Value = data(Index).X + 1
      ntxRangeEdgeNE.Value = data(Index).Y + 1
      ntxRangeEdgeSW.Value = IIf(data(Index).CX > 1, data(Index).CX + data(Index).X - 1, 1)
      ntxRangeEdgeSE.Value = IIf(data(Index).CY > 1, data(Index).CY + data(Index).Y - 1, 1)
    Else
      txtRangeMusic.Text = ""
      ntxRangePositionX.Value = 1
      ntxRangePositionY.Value = 1
      ntxRangePositionCX.Value = 0
      ntxRangePositionCY.Value = 0
      ntxRangeEdgeNW.Value = 1
      ntxRangeEdgeNE.Value = 1
      ntxRangeEdgeSW.Value = 1
      ntxRangeEdgeSE.Value = 1
    End If
  End Sub
#End Region

#Region "MusicPacks"

  Private Structure MusicFile
    Dim Filename As String
    Dim Data() As Byte
  End Structure

  Private Function CreateMusicPack(iniData() As Byte, loginData() As Byte, musicData() As MusicFile) As Byte()
    Using outPkt As New DataBuffer
      outPkt.InsertDwordString("EMP1")
      outPkt.InsertUInt32(&H1)
      outPkt.InsertCString("bgmusic.ini")
      outPkt.InsertUInt64(iniData.Length)
      outPkt.InsertByteArray(iniData)
      outPkt.InsertUInt32(&H1)
      outPkt.InsertCString("backGround.mp3")
      outPkt.InsertUInt64(loginData.Length)
      outPkt.InsertByteArray(loginData)
      outPkt.InsertUInt32(musicData.Count)
      For Each music As MusicFile In musicData
        outPkt.InsertCString(music.Filename)
        outPkt.InsertUInt64(music.Data.Length)
        outPkt.InsertByteArray(music.Data)
      Next
      Return outPkt.GetData
    End Using
  End Function

  Private Function ReadMusicPack(fileData() As Byte, ByRef iniData() As Byte, ByRef loginData() As Byte, ByRef musicInfo() As MusicFile) As Boolean
    Using inPkt As New DataReader(fileData)
      Dim HDR As String = inPkt.ReadDWORDString
      If HDR = "EMP1" Then
        Dim iniCount As UInt32 = inPkt.ReadUInt32
        If iniCount = 1 Then
          Dim iniName As String = inPkt.ReadCString
          If iniName = "bgmusic.ini" Then
            Dim iniSize As UInt64 = inPkt.ReadUInt64
            iniData = inPkt.ReadByteArray(iniSize)
          Else
            MsgBox("Invalid INI name! [" & iniName & "]", MsgBoxStyle.Critical)
            Return False
          End If
        Else
          MsgBox("Invalid number of INI files! [" & iniCount & "]", MsgBoxStyle.Critical)
          Return False
        End If

        Dim loginCount As UInt32 = inPkt.ReadUInt32
        If loginCount = 1 Then
          Dim loginName As String = inPkt.ReadCString
          If loginName = "backGround.mp3" Then
            Dim loginSize As UInt64 = inPkt.ReadUInt64
            loginData = inPkt.ReadByteArray(loginSize)
          Else
            MsgBox("Invalid Login Screen name! [" & loginName & "]", MsgBoxStyle.Critical)
            Return False
          End If
        Else
          MsgBox("Invalid number of Login Screen files! [" & loginCount & "]", MsgBoxStyle.Critical)
          Return False
        End If

        Dim musicCount As UInt32 = inPkt.ReadUInt32
        If musicCount = 0 Then
          Erase musicInfo
        Else
          ReDim musicInfo(musicCount - 1)
          For I As Integer = 0 To musicCount - 1
            musicInfo(I).Filename = inPkt.ReadCString
            Dim fileSize As UInt32 = inPkt.ReadUInt64
            musicInfo(I).Data = inPkt.ReadByteArray(fileSize)
          Next
        End If
        Return True
      Else
        MsgBox("Unable to determine Eudemons Music Pack version! [" & HDR & "]", MsgBoxStyle.Critical)
        Return False
      End If
    End Using
  End Function
#End Region
#End Region

  Private Sub tmrStart_Tick(sender As System.Object, e As System.EventArgs) Handles tmrStart.Tick
    tmrStart.Enabled = False
    LoadSettings()
    tUpdate = New Threading.Timer(New Threading.TimerCallback(AddressOf CheckForUpdates), Nothing, 1000, 5000)
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
    If DateDiff(DateInterval.Day, My.Settings.PriorUpdate, Now) > 30 Then
      cUpdate = New clsUpdate
      cUpdate.CheckVersion()
    End If
  End Sub

  Private Sub cUpdate_CheckResult(sender As Object, e As clsUpdate.CheckEventArgs) Handles cUpdate.CheckResult
    If InvokeRequired Then
      Invoke(New EventHandler(Of clsUpdate.CheckEventArgs)(AddressOf cUpdate_CheckResult), sender, e)
      Return
    End If
    If e.Cancelled Then

    ElseIf e.Error IsNot Nothing Then

    Else
      My.Settings.PriorUpdate = Now
      My.Settings.Save()
      If e.Result = clsUpdate.CheckEventArgs.ResultType.NewUpdate Then
        Using dUpdate As New dlgUpdate(e.Version)
          If dUpdate.ShowDialog(Me) = Windows.Forms.DialogResult.Cancel Then Return
        End Using
        Try
          If IO.File.Exists(sUpdate) Then IO.File.Delete(sUpdate)
          cUpdate.DownloadUpdate(sUpdate)
        Catch ex As Exception
          MsgBox("There was an error beginning the update process." & vbNewLine & "The Update file is currently in use. Please make sure the update installer is not already running!", MsgBoxStyle.Critical)
        End Try
      End If
    End If
  End Sub

  Private Sub cUpdate_DownloadResult(sender As Object, e As clsUpdate.DownloadEventArgs) Handles cUpdate.DownloadResult
    If InvokeRequired Then
      Invoke(New EventHandler(Of clsUpdate.DownloadEventArgs)(AddressOf cUpdate_DownloadResult), sender, e)
      Return
    End If
    If e.Cancelled Then
      MsgBox("There was an error during the update process." & vbNewLine & "Downloading the Update file has been canceled.", MsgBoxStyle.Exclamation)
    ElseIf e.Error IsNot Nothing Then
      MsgBox("There was an error during the update process." & vbNewLine & "Downloading the Update file has failed.", MsgBoxStyle.Critical)
    Else
      If Not Authenticode.IsSelfSigned(sUpdate) Then
        MsgBox("There was an error during the update process." & vbNewLine & "The Update file is not correctly signed.", MsgBoxStyle.Critical)
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
        MsgBox("There was an error during the update process." & vbNewLine & "The Installer has failed to start.", MsgBoxStyle.Critical)
      End Try
    End If
  End Sub

#End Region
End Class
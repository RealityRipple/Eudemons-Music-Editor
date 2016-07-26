<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
    Me.pnlMain = New System.Windows.Forms.TableLayoutPanel()
    Me.pctTitle = New System.Windows.Forms.PictureBox()
    Me.lblMap = New System.Windows.Forms.Label()
    Me.cmbMaps = New System.Windows.Forms.ComboBox()
    Me.cmdClose = New System.Windows.Forms.Button()
    Me.cmdSave = New System.Windows.Forms.Button()
    Me.pnlMapData = New System.Windows.Forms.TableLayoutPanel()
    Me.lblMapMusic = New System.Windows.Forms.Label()
    Me.txtMapMusic = New System.Windows.Forms.TextBox()
    Me.cmdMapMusicBrowse = New System.Windows.Forms.Button()
    Me.fraRanges = New System.Windows.Forms.GroupBox()
    Me.pnlRanges = New System.Windows.Forms.TableLayoutPanel()
    Me.lblRangeCount = New System.Windows.Forms.Label()
    Me.ntxRangeCount = New System.Windows.Forms.NumericUpDown()
    Me.fraRange = New System.Windows.Forms.GroupBox()
    Me.cmbRange = New System.Windows.Forms.ComboBox()
    Me.pnlRange = New System.Windows.Forms.TableLayoutPanel()
    Me.lblRangePriority = New System.Windows.Forms.Label()
    Me.lblRangeMusic = New System.Windows.Forms.Label()
    Me.txtRangeMusic = New System.Windows.Forms.TextBox()
    Me.cmdRangeMusicBrowse = New System.Windows.Forms.Button()
    Me.fraRangeLoc = New System.Windows.Forms.GroupBox()
    Me.tbsRangeLoc = New System.Windows.Forms.TabControl()
    Me.tabPosition = New System.Windows.Forms.TabPage()
    Me.pnlRangePosition = New System.Windows.Forms.TableLayoutPanel()
    Me.ntxRangePositionCY = New System.Windows.Forms.NumericUpDown()
    Me.lblRangePosition = New System.Windows.Forms.Label()
    Me.ntxRangePositionCX = New System.Windows.Forms.NumericUpDown()
    Me.lblRangeSize = New System.Windows.Forms.Label()
    Me.ntxRangePositionY = New System.Windows.Forms.NumericUpDown()
    Me.ntxRangePositionX = New System.Windows.Forms.NumericUpDown()
    Me.tabEdges = New System.Windows.Forms.TabPage()
    Me.pnlRangeEdge = New System.Windows.Forms.TableLayoutPanel()
    Me.ntxRangeEdgeNW = New System.Windows.Forms.NumericUpDown()
    Me.lblRangeEdges = New System.Windows.Forms.Label()
    Me.ntxRangeEdgeSE = New System.Windows.Forms.NumericUpDown()
    Me.ntxRangeEdgeSW = New System.Windows.Forms.NumericUpDown()
    Me.ntxRangeEdgeNE = New System.Windows.Forms.NumericUpDown()
    Me.cmdRangePriorityUp = New System.Windows.Forms.Button()
    Me.cmdRangePriorityDown = New System.Windows.Forms.Button()
    Me.pctProgress = New System.Windows.Forms.PictureBox()
    Me.ttMain = New System.Windows.Forms.ToolTip(Me.components)
    Me.mnuMain = New System.Windows.Forms.MenuStrip()
    Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuReload = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuSave = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuRevert = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuFileSpace1 = New System.Windows.Forms.ToolStripSeparator()
    Me.mnuTranslate = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuFileSpace2 = New System.Windows.Forms.ToolStripSeparator()
    Me.mnuImport = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuExport = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuFileSpace3 = New System.Windows.Forms.ToolStripSeparator()
    Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuMapView = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuView1 = New Eudemons_Music_Editor.ToolStripRadioButtonMenuItem()
    Me.mnuView2 = New Eudemons_Music_Editor.ToolStripRadioButtonMenuItem()
    Me.mnuView3 = New Eudemons_Music_Editor.ToolStripRadioButtonMenuItem()
    Me.mnuHelp = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuTips = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuWebpage = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuHelpSpace = New System.Windows.Forms.ToolStripSeparator()
    Me.mnuAbout = New System.Windows.Forms.ToolStripMenuItem()
    Me.tmrStart = New System.Windows.Forms.Timer(Me.components)
    Me.pnlMain.SuspendLayout()
    CType(Me.pctTitle, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.pnlMapData.SuspendLayout()
    Me.fraRanges.SuspendLayout()
    Me.pnlRanges.SuspendLayout()
    CType(Me.ntxRangeCount, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.fraRange.SuspendLayout()
    Me.pnlRange.SuspendLayout()
    Me.fraRangeLoc.SuspendLayout()
    Me.tbsRangeLoc.SuspendLayout()
    Me.tabPosition.SuspendLayout()
    Me.pnlRangePosition.SuspendLayout()
    CType(Me.ntxRangePositionCY, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.ntxRangePositionCX, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.ntxRangePositionY, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.ntxRangePositionX, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.tabEdges.SuspendLayout()
    Me.pnlRangeEdge.SuspendLayout()
    CType(Me.ntxRangeEdgeNW, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.ntxRangeEdgeSE, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.ntxRangeEdgeSW, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.ntxRangeEdgeNE, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.pctProgress, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.mnuMain.SuspendLayout()
    Me.SuspendLayout()
    '
    'pnlMain
    '
    Me.pnlMain.ColumnCount = 3
    Me.pnlMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
    Me.pnlMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
    Me.pnlMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
    Me.pnlMain.Controls.Add(Me.pctTitle, 0, 0)
    Me.pnlMain.Controls.Add(Me.lblMap, 0, 1)
    Me.pnlMain.Controls.Add(Me.cmbMaps, 1, 1)
    Me.pnlMain.Controls.Add(Me.cmdClose, 2, 3)
    Me.pnlMain.Controls.Add(Me.cmdSave, 1, 3)
    Me.pnlMain.Controls.Add(Me.pnlMapData, 0, 2)
    Me.pnlMain.Controls.Add(Me.pctProgress, 0, 3)
    Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
    Me.pnlMain.Location = New System.Drawing.Point(0, 24)
    Me.pnlMain.Name = "pnlMain"
    Me.pnlMain.RowCount = 4
    Me.pnlMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
    Me.pnlMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
    Me.pnlMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
    Me.pnlMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
    Me.pnlMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
    Me.pnlMain.Size = New System.Drawing.Size(320, 368)
    Me.pnlMain.TabIndex = 0
    '
    'pctTitle
    '
    Me.pctTitle.Anchor = System.Windows.Forms.AnchorStyles.Top
    Me.pctTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.pnlMain.SetColumnSpan(Me.pctTitle, 3)
    Me.pctTitle.Image = Global.Eudemons_Music_Editor.My.Resources.Resources.bg
    Me.pctTitle.Location = New System.Drawing.Point(0, 0)
    Me.pctTitle.Margin = New System.Windows.Forms.Padding(0)
    Me.pctTitle.Name = "pctTitle"
    Me.pctTitle.Size = New System.Drawing.Size(320, 104)
    Me.pctTitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
    Me.pctTitle.TabIndex = 0
    Me.pctTitle.TabStop = False
    Me.ttMain.SetToolTip(Me.pctTitle, "Eudemons Music Editor" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "by RealityRipple Software")
    '
    'lblMap
    '
    Me.lblMap.Anchor = System.Windows.Forms.AnchorStyles.Left
    Me.lblMap.AutoSize = True
    Me.lblMap.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.lblMap.Location = New System.Drawing.Point(3, 109)
    Me.lblMap.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
    Me.lblMap.Name = "lblMap"
    Me.lblMap.Size = New System.Drawing.Size(31, 13)
    Me.lblMap.TabIndex = 1
    Me.lblMap.Text = "Map:"
    '
    'cmbMaps
    '
    Me.cmbMaps.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.cmbMaps.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
    Me.cmbMaps.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
    Me.pnlMain.SetColumnSpan(Me.cmbMaps, 2)
    Me.cmbMaps.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cmbMaps.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.cmbMaps.FormattingEnabled = True
    Me.cmbMaps.Location = New System.Drawing.Point(35, 105)
    Me.cmbMaps.Margin = New System.Windows.Forms.Padding(1)
    Me.cmbMaps.MaxDropDownItems = 15
    Me.cmbMaps.Name = "cmbMaps"
    Me.cmbMaps.Size = New System.Drawing.Size(284, 21)
    Me.cmbMaps.TabIndex = 2
    Me.ttMain.SetToolTip(Me.cmbMaps, "Map to edit.")
    '
    'cmdClose
    '
    Me.cmdClose.Anchor = System.Windows.Forms.AnchorStyles.Right
    Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.cmdClose.Location = New System.Drawing.Point(244, 345)
    Me.cmdClose.Margin = New System.Windows.Forms.Padding(1)
    Me.cmdClose.Name = "cmdClose"
    Me.cmdClose.Size = New System.Drawing.Size(75, 22)
    Me.cmdClose.TabIndex = 7
    Me.cmdClose.Text = "Close"
    Me.ttMain.SetToolTip(Me.cmdClose, "Close Eudemons Music Editor.")
    Me.cmdClose.UseVisualStyleBackColor = True
    '
    'cmdSave
    '
    Me.cmdSave.Anchor = System.Windows.Forms.AnchorStyles.Right
    Me.cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.cmdSave.Location = New System.Drawing.Point(157, 345)
    Me.cmdSave.Margin = New System.Windows.Forms.Padding(1)
    Me.cmdSave.Name = "cmdSave"
    Me.cmdSave.Size = New System.Drawing.Size(85, 22)
    Me.cmdSave.TabIndex = 6
    Me.cmdSave.Text = "Save Changes"
    Me.ttMain.SetToolTip(Me.cmdSave, "Save all changes to Eudemons music.")
    Me.cmdSave.UseVisualStyleBackColor = True
    '
    'pnlMapData
    '
    Me.pnlMapData.ColumnCount = 3
    Me.pnlMain.SetColumnSpan(Me.pnlMapData, 3)
    Me.pnlMapData.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
    Me.pnlMapData.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
    Me.pnlMapData.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
    Me.pnlMapData.Controls.Add(Me.lblMapMusic, 0, 0)
    Me.pnlMapData.Controls.Add(Me.txtMapMusic, 1, 0)
    Me.pnlMapData.Controls.Add(Me.cmdMapMusicBrowse, 2, 0)
    Me.pnlMapData.Controls.Add(Me.fraRanges, 0, 1)
    Me.pnlMapData.Dock = System.Windows.Forms.DockStyle.Fill
    Me.pnlMapData.Location = New System.Drawing.Point(0, 127)
    Me.pnlMapData.Margin = New System.Windows.Forms.Padding(0)
    Me.pnlMapData.Name = "pnlMapData"
    Me.pnlMapData.RowCount = 2
    Me.pnlMapData.RowStyles.Add(New System.Windows.Forms.RowStyle())
    Me.pnlMapData.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
    Me.pnlMapData.Size = New System.Drawing.Size(320, 217)
    Me.pnlMapData.TabIndex = 8
    '
    'lblMapMusic
    '
    Me.lblMapMusic.Anchor = System.Windows.Forms.AnchorStyles.Left
    Me.lblMapMusic.AutoSize = True
    Me.lblMapMusic.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.lblMapMusic.Location = New System.Drawing.Point(3, 4)
    Me.lblMapMusic.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
    Me.lblMapMusic.Name = "lblMapMusic"
    Me.lblMapMusic.Size = New System.Drawing.Size(99, 13)
    Me.lblMapMusic.TabIndex = 0
    Me.lblMapMusic.Text = "Background Music:"
    '
    'txtMapMusic
    '
    Me.txtMapMusic.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.txtMapMusic.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
    Me.txtMapMusic.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem
    Me.txtMapMusic.Location = New System.Drawing.Point(102, 1)
    Me.txtMapMusic.Margin = New System.Windows.Forms.Padding(0)
    Me.txtMapMusic.Name = "txtMapMusic"
    Me.txtMapMusic.Size = New System.Drawing.Size(141, 20)
    Me.txtMapMusic.TabIndex = 1
    Me.ttMain.SetToolTip(Me.txtMapMusic, "Map music file.")
    '
    'cmdMapMusicBrowse
    '
    Me.cmdMapMusicBrowse.Anchor = System.Windows.Forms.AnchorStyles.Right
    Me.cmdMapMusicBrowse.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.cmdMapMusicBrowse.Location = New System.Drawing.Point(244, 0)
    Me.cmdMapMusicBrowse.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
    Me.cmdMapMusicBrowse.Name = "cmdMapMusicBrowse"
    Me.cmdMapMusicBrowse.Size = New System.Drawing.Size(75, 22)
    Me.cmdMapMusicBrowse.TabIndex = 2
    Me.cmdMapMusicBrowse.Text = "Browse..."
    Me.ttMain.SetToolTip(Me.cmdMapMusicBrowse, "Browse for Map MP3 file.")
    Me.cmdMapMusicBrowse.UseVisualStyleBackColor = True
    '
    'fraRanges
    '
    Me.pnlMapData.SetColumnSpan(Me.fraRanges, 3)
    Me.fraRanges.Controls.Add(Me.pnlRanges)
    Me.fraRanges.Dock = System.Windows.Forms.DockStyle.Fill
    Me.fraRanges.Location = New System.Drawing.Point(2, 24)
    Me.fraRanges.Margin = New System.Windows.Forms.Padding(2, 2, 2, 0)
    Me.fraRanges.Name = "fraRanges"
    Me.fraRanges.Size = New System.Drawing.Size(316, 193)
    Me.fraRanges.TabIndex = 3
    Me.fraRanges.TabStop = False
    Me.fraRanges.Text = "Ranges"
    '
    'pnlRanges
    '
    Me.pnlRanges.ColumnCount = 2
    Me.pnlRanges.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
    Me.pnlRanges.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
    Me.pnlRanges.Controls.Add(Me.lblRangeCount, 0, 0)
    Me.pnlRanges.Controls.Add(Me.ntxRangeCount, 1, 0)
    Me.pnlRanges.Controls.Add(Me.fraRange, 0, 1)
    Me.pnlRanges.Dock = System.Windows.Forms.DockStyle.Fill
    Me.pnlRanges.Location = New System.Drawing.Point(3, 16)
    Me.pnlRanges.Margin = New System.Windows.Forms.Padding(0)
    Me.pnlRanges.Name = "pnlRanges"
    Me.pnlRanges.RowCount = 2
    Me.pnlRanges.RowStyles.Add(New System.Windows.Forms.RowStyle())
    Me.pnlRanges.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
    Me.pnlRanges.Size = New System.Drawing.Size(310, 174)
    Me.pnlRanges.TabIndex = 0
    '
    'lblRangeCount
    '
    Me.lblRangeCount.Anchor = System.Windows.Forms.AnchorStyles.Left
    Me.lblRangeCount.AutoSize = True
    Me.lblRangeCount.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.lblRangeCount.Location = New System.Drawing.Point(3, 3)
    Me.lblRangeCount.Margin = New System.Windows.Forms.Padding(3, 0, 0, 1)
    Me.lblRangeCount.Name = "lblRangeCount"
    Me.lblRangeCount.Size = New System.Drawing.Size(73, 13)
    Me.lblRangeCount.TabIndex = 0
    Me.lblRangeCount.Text = "Range Count:"
    '
    'ntxRangeCount
    '
    Me.ntxRangeCount.Anchor = System.Windows.Forms.AnchorStyles.Left
    Me.ntxRangeCount.Location = New System.Drawing.Point(76, 0)
    Me.ntxRangeCount.Margin = New System.Windows.Forms.Padding(0, 0, 0, 1)
    Me.ntxRangeCount.Name = "ntxRangeCount"
    Me.ntxRangeCount.Size = New System.Drawing.Size(55, 20)
    Me.ntxRangeCount.TabIndex = 1
    Me.ntxRangeCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    Me.ttMain.SetToolTip(Me.ntxRangeCount, "Number of Ranges on map.")
    '
    'fraRange
    '
    Me.pnlRanges.SetColumnSpan(Me.fraRange, 2)
    Me.fraRange.Controls.Add(Me.cmbRange)
    Me.fraRange.Controls.Add(Me.pnlRange)
    Me.fraRange.Dock = System.Windows.Forms.DockStyle.Fill
    Me.fraRange.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.fraRange.Location = New System.Drawing.Point(2, 23)
    Me.fraRange.Margin = New System.Windows.Forms.Padding(2)
    Me.fraRange.Name = "fraRange"
    Me.fraRange.Size = New System.Drawing.Size(310, 149)
    Me.fraRange.TabIndex = 12
    Me.fraRange.TabStop = False
    '
    'cmbRange
    '
    Me.cmbRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cmbRange.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.cmbRange.FormattingEnabled = True
    Me.cmbRange.Location = New System.Drawing.Point(9, 0)
    Me.cmbRange.Name = "cmbRange"
    Me.cmbRange.Size = New System.Drawing.Size(99, 21)
    Me.cmbRange.TabIndex = 3
    Me.ttMain.SetToolTip(Me.cmbRange, "Edit selected Range.")
    '
    'pnlRange
    '
    Me.pnlRange.ColumnCount = 4
    Me.pnlRange.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
    Me.pnlRange.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
    Me.pnlRange.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
    Me.pnlRange.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
    Me.pnlRange.Controls.Add(Me.lblRangePriority, 3, 1)
    Me.pnlRange.Controls.Add(Me.lblRangeMusic, 0, 1)
    Me.pnlRange.Controls.Add(Me.txtRangeMusic, 1, 1)
    Me.pnlRange.Controls.Add(Me.cmdRangeMusicBrowse, 2, 1)
    Me.pnlRange.Controls.Add(Me.fraRangeLoc, 0, 2)
    Me.pnlRange.Controls.Add(Me.cmdRangePriorityUp, 3, 2)
    Me.pnlRange.Controls.Add(Me.cmdRangePriorityDown, 3, 3)
    Me.pnlRange.Dock = System.Windows.Forms.DockStyle.Fill
    Me.pnlRange.Location = New System.Drawing.Point(3, 16)
    Me.pnlRange.Margin = New System.Windows.Forms.Padding(0)
    Me.pnlRange.Name = "pnlRange"
    Me.pnlRange.RowCount = 4
    Me.pnlRange.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
    Me.pnlRange.RowStyles.Add(New System.Windows.Forms.RowStyle())
    Me.pnlRange.RowStyles.Add(New System.Windows.Forms.RowStyle())
    Me.pnlRange.RowStyles.Add(New System.Windows.Forms.RowStyle())
    Me.pnlRange.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
    Me.pnlRange.Size = New System.Drawing.Size(304, 130)
    Me.pnlRange.TabIndex = 4
    '
    'lblRangePriority
    '
    Me.lblRangePriority.Anchor = System.Windows.Forms.AnchorStyles.None
    Me.lblRangePriority.AutoSize = True
    Me.lblRangePriority.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.lblRangePriority.Location = New System.Drawing.Point(246, 11)
    Me.lblRangePriority.Margin = New System.Windows.Forms.Padding(0)
    Me.lblRangePriority.Name = "lblRangePriority"
    Me.lblRangePriority.Size = New System.Drawing.Size(41, 13)
    Me.lblRangePriority.TabIndex = 12
    Me.lblRangePriority.Text = "Priority:"
    Me.ttMain.SetToolTip(Me.lblRangePriority, resources.GetString("lblRangePriority.ToolTip"))
    '
    'lblRangeMusic
    '
    Me.lblRangeMusic.Anchor = System.Windows.Forms.AnchorStyles.Left
    Me.lblRangeMusic.AutoSize = True
    Me.lblRangeMusic.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.lblRangeMusic.Location = New System.Drawing.Point(3, 11)
    Me.lblRangeMusic.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
    Me.lblRangeMusic.Name = "lblRangeMusic"
    Me.lblRangeMusic.Size = New System.Drawing.Size(38, 13)
    Me.lblRangeMusic.TabIndex = 3
    Me.lblRangeMusic.Text = "Music:"
    Me.ttMain.SetToolTip(Me.lblRangeMusic, "Select a file on your computer for the Range" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "to play when you enter that area of" & _
        " the Map.")
    '
    'txtRangeMusic
    '
    Me.txtRangeMusic.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.txtRangeMusic.Location = New System.Drawing.Point(41, 8)
    Me.txtRangeMusic.Margin = New System.Windows.Forms.Padding(0)
    Me.txtRangeMusic.Name = "txtRangeMusic"
    Me.txtRangeMusic.Size = New System.Drawing.Size(112, 20)
    Me.txtRangeMusic.TabIndex = 4
    Me.ttMain.SetToolTip(Me.txtRangeMusic, "Range music file.")
    '
    'cmdRangeMusicBrowse
    '
    Me.cmdRangeMusicBrowse.Anchor = System.Windows.Forms.AnchorStyles.Right
    Me.cmdRangeMusicBrowse.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.cmdRangeMusicBrowse.Location = New System.Drawing.Point(154, 7)
    Me.cmdRangeMusicBrowse.Margin = New System.Windows.Forms.Padding(1, 0, 0, 0)
    Me.cmdRangeMusicBrowse.Name = "cmdRangeMusicBrowse"
    Me.cmdRangeMusicBrowse.Size = New System.Drawing.Size(75, 22)
    Me.cmdRangeMusicBrowse.TabIndex = 5
    Me.cmdRangeMusicBrowse.Text = "Browse..."
    Me.ttMain.SetToolTip(Me.cmdRangeMusicBrowse, "Browse for Range MP3 file.")
    Me.cmdRangeMusicBrowse.UseVisualStyleBackColor = True
    '
    'fraRangeLoc
    '
    Me.pnlRange.SetColumnSpan(Me.fraRangeLoc, 3)
    Me.fraRangeLoc.Controls.Add(Me.tbsRangeLoc)
    Me.fraRangeLoc.Dock = System.Windows.Forms.DockStyle.Fill
    Me.fraRangeLoc.Location = New System.Drawing.Point(1, 30)
    Me.fraRangeLoc.Margin = New System.Windows.Forms.Padding(1)
    Me.fraRangeLoc.Name = "fraRangeLoc"
    Me.fraRangeLoc.Padding = New System.Windows.Forms.Padding(3, 2, 2, 2)
    Me.pnlRange.SetRowSpan(Me.fraRangeLoc, 2)
    Me.fraRangeLoc.Size = New System.Drawing.Size(227, 99)
    Me.fraRangeLoc.TabIndex = 6
    Me.fraRangeLoc.TabStop = False
    Me.fraRangeLoc.Text = "Range Location"
    '
    'tbsRangeLoc
    '
    Me.tbsRangeLoc.Controls.Add(Me.tabPosition)
    Me.tbsRangeLoc.Controls.Add(Me.tabEdges)
    Me.tbsRangeLoc.Dock = System.Windows.Forms.DockStyle.Fill
    Me.tbsRangeLoc.Location = New System.Drawing.Point(3, 15)
    Me.tbsRangeLoc.Name = "tbsRangeLoc"
    Me.tbsRangeLoc.SelectedIndex = 0
    Me.tbsRangeLoc.Size = New System.Drawing.Size(222, 82)
    Me.tbsRangeLoc.TabIndex = 16
    '
    'tabPosition
    '
    Me.tabPosition.Controls.Add(Me.pnlRangePosition)
    Me.tabPosition.Location = New System.Drawing.Point(4, 22)
    Me.tabPosition.Margin = New System.Windows.Forms.Padding(0)
    Me.tabPosition.Name = "tabPosition"
    Me.tabPosition.Size = New System.Drawing.Size(214, 56)
    Me.tabPosition.TabIndex = 0
    Me.tabPosition.Text = "Position/Size"
    Me.tabPosition.UseVisualStyleBackColor = True
    '
    'pnlRangePosition
    '
    Me.pnlRangePosition.AutoSize = True
    Me.pnlRangePosition.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
    Me.pnlRangePosition.ColumnCount = 3
    Me.pnlRangePosition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
    Me.pnlRangePosition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
    Me.pnlRangePosition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
    Me.pnlRangePosition.Controls.Add(Me.ntxRangePositionCY, 2, 1)
    Me.pnlRangePosition.Controls.Add(Me.lblRangePosition, 0, 0)
    Me.pnlRangePosition.Controls.Add(Me.ntxRangePositionCX, 1, 1)
    Me.pnlRangePosition.Controls.Add(Me.lblRangeSize, 0, 1)
    Me.pnlRangePosition.Controls.Add(Me.ntxRangePositionY, 2, 0)
    Me.pnlRangePosition.Controls.Add(Me.ntxRangePositionX, 1, 0)
    Me.pnlRangePosition.Dock = System.Windows.Forms.DockStyle.Fill
    Me.pnlRangePosition.Location = New System.Drawing.Point(0, 0)
    Me.pnlRangePosition.Margin = New System.Windows.Forms.Padding(0)
    Me.pnlRangePosition.Name = "pnlRangePosition"
    Me.pnlRangePosition.RowCount = 2
    Me.pnlRangePosition.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
    Me.pnlRangePosition.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
    Me.pnlRangePosition.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
    Me.pnlRangePosition.Size = New System.Drawing.Size(214, 56)
    Me.pnlRangePosition.TabIndex = 0
    '
    'ntxRangePositionCY
    '
    Me.ntxRangePositionCY.Anchor = System.Windows.Forms.AnchorStyles.Left
    Me.ntxRangePositionCY.Location = New System.Drawing.Point(168, 32)
    Me.ntxRangePositionCY.Margin = New System.Windows.Forms.Padding(1)
    Me.ntxRangePositionCY.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
    Me.ntxRangePositionCY.Name = "ntxRangePositionCY"
    Me.ntxRangePositionCY.Size = New System.Drawing.Size(45, 20)
    Me.ntxRangePositionCY.TabIndex = 5
    Me.ntxRangePositionCY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    Me.ttMain.SetToolTip(Me.ntxRangePositionCY, "Range height.")
    '
    'lblRangePosition
    '
    Me.lblRangePosition.Anchor = System.Windows.Forms.AnchorStyles.Left
    Me.lblRangePosition.AutoSize = True
    Me.lblRangePosition.Location = New System.Drawing.Point(3, 7)
    Me.lblRangePosition.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
    Me.lblRangePosition.Name = "lblRangePosition"
    Me.lblRangePosition.Size = New System.Drawing.Size(47, 13)
    Me.lblRangePosition.TabIndex = 0
    Me.lblRangePosition.Text = "Position:"
    Me.ttMain.SetToolTip(Me.lblRangePosition, "The position should be one value less than the given coordinates in game." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "The re" & _
        "ason for this is the Range's position starts at 0,0" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "while the Map coordinates s" & _
        "tart with 1,1.")
    '
    'ntxRangePositionCX
    '
    Me.ntxRangePositionCX.Anchor = System.Windows.Forms.AnchorStyles.Right
    Me.ntxRangePositionCX.Location = New System.Drawing.Point(121, 32)
    Me.ntxRangePositionCX.Margin = New System.Windows.Forms.Padding(1)
    Me.ntxRangePositionCX.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
    Me.ntxRangePositionCX.Name = "ntxRangePositionCX"
    Me.ntxRangePositionCX.Size = New System.Drawing.Size(45, 20)
    Me.ntxRangePositionCX.TabIndex = 4
    Me.ntxRangePositionCX.TabStop = False
    Me.ntxRangePositionCX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    Me.ttMain.SetToolTip(Me.ntxRangePositionCX, "Range width.")
    '
    'lblRangeSize
    '
    Me.lblRangeSize.Anchor = System.Windows.Forms.AnchorStyles.Left
    Me.lblRangeSize.AutoSize = True
    Me.lblRangeSize.Location = New System.Drawing.Point(3, 35)
    Me.lblRangeSize.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
    Me.lblRangeSize.Name = "lblRangeSize"
    Me.lblRangeSize.Size = New System.Drawing.Size(30, 13)
    Me.lblRangeSize.TabIndex = 3
    Me.lblRangeSize.Text = "Size:"
    Me.ttMain.SetToolTip(Me.lblRangeSize, resources.GetString("lblRangeSize.ToolTip"))
    '
    'ntxRangePositionY
    '
    Me.ntxRangePositionY.Anchor = System.Windows.Forms.AnchorStyles.Left
    Me.ntxRangePositionY.Location = New System.Drawing.Point(168, 4)
    Me.ntxRangePositionY.Margin = New System.Windows.Forms.Padding(1)
    Me.ntxRangePositionY.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
    Me.ntxRangePositionY.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
    Me.ntxRangePositionY.Name = "ntxRangePositionY"
    Me.ntxRangePositionY.Size = New System.Drawing.Size(45, 20)
    Me.ntxRangePositionY.TabIndex = 2
    Me.ntxRangePositionY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    Me.ttMain.SetToolTip(Me.ntxRangePositionY, "Range Y position.")
    Me.ntxRangePositionY.Value = New Decimal(New Integer() {1, 0, 0, 0})
    '
    'ntxRangePositionX
    '
    Me.ntxRangePositionX.Anchor = System.Windows.Forms.AnchorStyles.Right
    Me.ntxRangePositionX.Location = New System.Drawing.Point(121, 4)
    Me.ntxRangePositionX.Margin = New System.Windows.Forms.Padding(1)
    Me.ntxRangePositionX.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
    Me.ntxRangePositionX.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
    Me.ntxRangePositionX.Name = "ntxRangePositionX"
    Me.ntxRangePositionX.Size = New System.Drawing.Size(45, 20)
    Me.ntxRangePositionX.TabIndex = 1
    Me.ntxRangePositionX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    Me.ttMain.SetToolTip(Me.ntxRangePositionX, "Range X position.")
    Me.ntxRangePositionX.Value = New Decimal(New Integer() {1, 0, 0, 0})
    '
    'tabEdges
    '
    Me.tabEdges.Controls.Add(Me.pnlRangeEdge)
    Me.tabEdges.Location = New System.Drawing.Point(4, 22)
    Me.tabEdges.Margin = New System.Windows.Forms.Padding(0)
    Me.tabEdges.Name = "tabEdges"
    Me.tabEdges.Size = New System.Drawing.Size(214, 56)
    Me.tabEdges.TabIndex = 1
    Me.tabEdges.Text = "Edges"
    Me.tabEdges.UseVisualStyleBackColor = True
    '
    'pnlRangeEdge
    '
    Me.pnlRangeEdge.ColumnCount = 3
    Me.pnlRangeEdge.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
    Me.pnlRangeEdge.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
    Me.pnlRangeEdge.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
    Me.pnlRangeEdge.Controls.Add(Me.ntxRangeEdgeNW, 0, 0)
    Me.pnlRangeEdge.Controls.Add(Me.lblRangeEdges, 0, 1)
    Me.pnlRangeEdge.Controls.Add(Me.ntxRangeEdgeSE, 2, 2)
    Me.pnlRangeEdge.Controls.Add(Me.ntxRangeEdgeSW, 0, 2)
    Me.pnlRangeEdge.Controls.Add(Me.ntxRangeEdgeNE, 2, 0)
    Me.pnlRangeEdge.Dock = System.Windows.Forms.DockStyle.Fill
    Me.pnlRangeEdge.Location = New System.Drawing.Point(0, 0)
    Me.pnlRangeEdge.Margin = New System.Windows.Forms.Padding(0)
    Me.pnlRangeEdge.Name = "pnlRangeEdge"
    Me.pnlRangeEdge.RowCount = 3
    Me.pnlRangeEdge.RowStyles.Add(New System.Windows.Forms.RowStyle())
    Me.pnlRangeEdge.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
    Me.pnlRangeEdge.RowStyles.Add(New System.Windows.Forms.RowStyle())
    Me.pnlRangeEdge.Size = New System.Drawing.Size(214, 56)
    Me.pnlRangeEdge.TabIndex = 0
    '
    'ntxRangeEdgeNW
    '
    Me.ntxRangeEdgeNW.Location = New System.Drawing.Point(1, 1)
    Me.ntxRangeEdgeNW.Margin = New System.Windows.Forms.Padding(1)
    Me.ntxRangeEdgeNW.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
    Me.ntxRangeEdgeNW.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
    Me.ntxRangeEdgeNW.Name = "ntxRangeEdgeNW"
    Me.ntxRangeEdgeNW.Size = New System.Drawing.Size(45, 20)
    Me.ntxRangeEdgeNW.TabIndex = 0
    Me.ttMain.SetToolTip(Me.ntxRangeEdgeNW, "Northwestern edge of the Range.")
    Me.ntxRangeEdgeNW.Value = New Decimal(New Integer() {1, 0, 0, 0})
    '
    'lblRangeEdges
    '
    Me.lblRangeEdges.Anchor = System.Windows.Forms.AnchorStyles.None
    Me.lblRangeEdges.AutoSize = True
    Me.pnlRangeEdge.SetColumnSpan(Me.lblRangeEdges, 3)
    Me.lblRangeEdges.Location = New System.Drawing.Point(15, 22)
    Me.lblRangeEdges.Name = "lblRangeEdges"
    Me.lblRangeEdges.Size = New System.Drawing.Size(183, 12)
    Me.lblRangeEdges.TabIndex = 4
    Me.lblRangeEdges.Text = "Enter farthest edges in each direction"
    Me.lblRangeEdges.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'ntxRangeEdgeSE
    '
    Me.ntxRangeEdgeSE.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.ntxRangeEdgeSE.Location = New System.Drawing.Point(168, 35)
    Me.ntxRangeEdgeSE.Margin = New System.Windows.Forms.Padding(1)
    Me.ntxRangeEdgeSE.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
    Me.ntxRangeEdgeSE.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
    Me.ntxRangeEdgeSE.Name = "ntxRangeEdgeSE"
    Me.ntxRangeEdgeSE.Size = New System.Drawing.Size(45, 20)
    Me.ntxRangeEdgeSE.TabIndex = 3
    Me.ttMain.SetToolTip(Me.ntxRangeEdgeSE, "Southeastern edge of the Range.")
    Me.ntxRangeEdgeSE.Value = New Decimal(New Integer() {1, 0, 0, 0})
    '
    'ntxRangeEdgeSW
    '
    Me.ntxRangeEdgeSW.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.ntxRangeEdgeSW.Location = New System.Drawing.Point(1, 35)
    Me.ntxRangeEdgeSW.Margin = New System.Windows.Forms.Padding(1)
    Me.ntxRangeEdgeSW.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
    Me.ntxRangeEdgeSW.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
    Me.ntxRangeEdgeSW.Name = "ntxRangeEdgeSW"
    Me.ntxRangeEdgeSW.Size = New System.Drawing.Size(45, 20)
    Me.ntxRangeEdgeSW.TabIndex = 2
    Me.ttMain.SetToolTip(Me.ntxRangeEdgeSW, "Southwestern edge of the Range.")
    Me.ntxRangeEdgeSW.Value = New Decimal(New Integer() {1, 0, 0, 0})
    '
    'ntxRangeEdgeNE
    '
    Me.ntxRangeEdgeNE.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.ntxRangeEdgeNE.Location = New System.Drawing.Point(168, 1)
    Me.ntxRangeEdgeNE.Margin = New System.Windows.Forms.Padding(1)
    Me.ntxRangeEdgeNE.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
    Me.ntxRangeEdgeNE.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
    Me.ntxRangeEdgeNE.Name = "ntxRangeEdgeNE"
    Me.ntxRangeEdgeNE.Size = New System.Drawing.Size(45, 20)
    Me.ntxRangeEdgeNE.TabIndex = 1
    Me.ttMain.SetToolTip(Me.ntxRangeEdgeNE, "Northeastern edge of the Range.")
    Me.ntxRangeEdgeNE.Value = New Decimal(New Integer() {1, 0, 0, 0})
    '
    'cmdRangePriorityUp
    '
    Me.cmdRangePriorityUp.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.cmdRangePriorityUp.Location = New System.Drawing.Point(229, 29)
    Me.cmdRangePriorityUp.Margin = New System.Windows.Forms.Padding(0)
    Me.cmdRangePriorityUp.Name = "cmdRangePriorityUp"
    Me.cmdRangePriorityUp.Size = New System.Drawing.Size(75, 22)
    Me.cmdRangePriorityUp.TabIndex = 13
    Me.cmdRangePriorityUp.Text = "Move Up"
    Me.ttMain.SetToolTip(Me.cmdRangePriorityUp, "Raise the priority of this range.")
    Me.cmdRangePriorityUp.UseVisualStyleBackColor = True
    '
    'cmdRangePriorityDown
    '
    Me.cmdRangePriorityDown.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.cmdRangePriorityDown.Location = New System.Drawing.Point(229, 51)
    Me.cmdRangePriorityDown.Margin = New System.Windows.Forms.Padding(0)
    Me.cmdRangePriorityDown.Name = "cmdRangePriorityDown"
    Me.cmdRangePriorityDown.Size = New System.Drawing.Size(75, 22)
    Me.cmdRangePriorityDown.TabIndex = 14
    Me.cmdRangePriorityDown.Text = "Move Down"
    Me.ttMain.SetToolTip(Me.cmdRangePriorityDown, "Lower priority of this range.")
    Me.cmdRangePriorityDown.UseVisualStyleBackColor = True
    '
    'pctProgress
    '
    Me.pctProgress.Anchor = System.Windows.Forms.AnchorStyles.None
    Me.pctProgress.Image = Global.Eudemons_Music_Editor.My.Resources.Resources.throbber
    Me.pctProgress.Location = New System.Drawing.Point(9, 348)
    Me.pctProgress.Name = "pctProgress"
    Me.pctProgress.Size = New System.Drawing.Size(16, 16)
    Me.pctProgress.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
    Me.pctProgress.TabIndex = 9
    Me.pctProgress.TabStop = False
    Me.pctProgress.Visible = False
    '
    'mnuMain
    '
    Me.mnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile, Me.mnuMapView, Me.mnuHelp})
    Me.mnuMain.Location = New System.Drawing.Point(0, 0)
    Me.mnuMain.Name = "mnuMain"
    Me.mnuMain.Size = New System.Drawing.Size(320, 24)
    Me.mnuMain.TabIndex = 1
    Me.mnuMain.Text = "Eudemons Music Editor Menu"
    '
    'mnuFile
    '
    Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuReload, Me.mnuSave, Me.mnuRevert, Me.mnuFileSpace1, Me.mnuTranslate, Me.mnuFileSpace2, Me.mnuImport, Me.mnuExport, Me.mnuFileSpace3, Me.mnuExit})
    Me.mnuFile.Name = "mnuFile"
    Me.mnuFile.Size = New System.Drawing.Size(37, 20)
    Me.mnuFile.Text = "&File"
    '
    'mnuReload
    '
    Me.mnuReload.Name = "mnuReload"
    Me.mnuReload.ShortcutKeys = System.Windows.Forms.Keys.F5
    Me.mnuReload.Size = New System.Drawing.Size(230, 22)
    Me.mnuReload.Text = "Re&load Settings"
    '
    'mnuSave
    '
    Me.mnuSave.Name = "mnuSave"
    Me.mnuSave.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
    Me.mnuSave.Size = New System.Drawing.Size(230, 22)
    Me.mnuSave.Text = "&Save Changes"
    '
    'mnuRevert
    '
    Me.mnuRevert.Name = "mnuRevert"
    Me.mnuRevert.ShortcutKeys = CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.Delete), System.Windows.Forms.Keys)
    Me.mnuRevert.Size = New System.Drawing.Size(230, 22)
    Me.mnuRevert.Text = "&Revert Settings"
    '
    'mnuFileSpace1
    '
    Me.mnuFileSpace1.Name = "mnuFileSpace1"
    Me.mnuFileSpace1.Size = New System.Drawing.Size(227, 6)
    '
    'mnuTranslate
    '
    Me.mnuTranslate.Name = "mnuTranslate"
    Me.mnuTranslate.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.T), System.Windows.Forms.Keys)
    Me.mnuTranslate.Size = New System.Drawing.Size(230, 22)
    Me.mnuTranslate.Text = "Translate Map Names"
    '
    'mnuFileSpace2
    '
    Me.mnuFileSpace2.Name = "mnuFileSpace2"
    Me.mnuFileSpace2.Size = New System.Drawing.Size(227, 6)
    '
    'mnuImport
    '
    Me.mnuImport.Name = "mnuImport"
    Me.mnuImport.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
    Me.mnuImport.Size = New System.Drawing.Size(230, 22)
    Me.mnuImport.Text = "&Import Pack..."
    '
    'mnuExport
    '
    Me.mnuExport.Name = "mnuExport"
    Me.mnuExport.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
    Me.mnuExport.Size = New System.Drawing.Size(230, 22)
    Me.mnuExport.Text = "&Export Pack..."
    '
    'mnuFileSpace3
    '
    Me.mnuFileSpace3.Name = "mnuFileSpace3"
    Me.mnuFileSpace3.Size = New System.Drawing.Size(227, 6)
    '
    'mnuExit
    '
    Me.mnuExit.Name = "mnuExit"
    Me.mnuExit.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
    Me.mnuExit.Size = New System.Drawing.Size(230, 22)
    Me.mnuExit.Text = "E&xit"
    '
    'mnuMapView
    '
    Me.mnuMapView.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuView1, Me.mnuView2, Me.mnuView3})
    Me.mnuMapView.Name = "mnuMapView"
    Me.mnuMapView.Size = New System.Drawing.Size(71, 20)
    Me.mnuMapView.Text = "Map &View"
    '
    'mnuView1
    '
    Me.mnuView1.Checked = True
    Me.mnuView1.CheckOnClick = True
    Me.mnuView1.CheckState = System.Windows.Forms.CheckState.Checked
    Me.mnuView1.Name = "mnuView1"
    Me.mnuView1.Size = New System.Drawing.Size(121, 22)
    Me.mnuView1.Text = "1 (128px)"
    '
    'mnuView2
    '
    Me.mnuView2.CheckOnClick = True
    Me.mnuView2.Name = "mnuView2"
    Me.mnuView2.Size = New System.Drawing.Size(121, 22)
    Me.mnuView2.Text = "2 (256px)"
    '
    'mnuView3
    '
    Me.mnuView3.CheckOnClick = True
    Me.mnuView3.Name = "mnuView3"
    Me.mnuView3.Size = New System.Drawing.Size(121, 22)
    Me.mnuView3.Text = "3 (512px)"
    '
    'mnuHelp
    '
    Me.mnuHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuTips, Me.mnuWebpage, Me.mnuHelpSpace, Me.mnuAbout})
    Me.mnuHelp.Name = "mnuHelp"
    Me.mnuHelp.Size = New System.Drawing.Size(44, 20)
    Me.mnuHelp.Text = "&Help"
    '
    'mnuTips
    '
    Me.mnuTips.Name = "mnuTips"
    Me.mnuTips.ShortcutKeys = System.Windows.Forms.Keys.F1
    Me.mnuTips.Size = New System.Drawing.Size(169, 22)
    Me.mnuTips.Text = "&Tips"
    '
    'mnuWebpage
    '
    Me.mnuWebpage.Name = "mnuWebpage"
    Me.mnuWebpage.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.W), System.Windows.Forms.Keys)
    Me.mnuWebpage.Size = New System.Drawing.Size(169, 22)
    Me.mnuWebpage.Text = "&Webpage"
    '
    'mnuHelpSpace
    '
    Me.mnuHelpSpace.Name = "mnuHelpSpace"
    Me.mnuHelpSpace.Size = New System.Drawing.Size(166, 6)
    '
    'mnuAbout
    '
    Me.mnuAbout.Name = "mnuAbout"
    Me.mnuAbout.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
    Me.mnuAbout.Size = New System.Drawing.Size(169, 22)
    Me.mnuAbout.Text = "&About..."
    '
    'tmrStart
    '
    Me.tmrStart.Interval = 500
    '
    'frmMain
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(320, 392)
    Me.Controls.Add(Me.pnlMain)
    Me.Controls.Add(Me.mnuMain)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.MainMenuStrip = Me.mnuMain
    Me.MaximizeBox = False
    Me.Name = "frmMain"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Eudemons Music Editor"
    Me.pnlMain.ResumeLayout(False)
    Me.pnlMain.PerformLayout()
    CType(Me.pctTitle, System.ComponentModel.ISupportInitialize).EndInit()
    Me.pnlMapData.ResumeLayout(False)
    Me.pnlMapData.PerformLayout()
    Me.fraRanges.ResumeLayout(False)
    Me.pnlRanges.ResumeLayout(False)
    Me.pnlRanges.PerformLayout()
    CType(Me.ntxRangeCount, System.ComponentModel.ISupportInitialize).EndInit()
    Me.fraRange.ResumeLayout(False)
    Me.pnlRange.ResumeLayout(False)
    Me.pnlRange.PerformLayout()
    Me.fraRangeLoc.ResumeLayout(False)
    Me.tbsRangeLoc.ResumeLayout(False)
    Me.tabPosition.ResumeLayout(False)
    Me.tabPosition.PerformLayout()
    Me.pnlRangePosition.ResumeLayout(False)
    Me.pnlRangePosition.PerformLayout()
    CType(Me.ntxRangePositionCY, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.ntxRangePositionCX, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.ntxRangePositionY, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.ntxRangePositionX, System.ComponentModel.ISupportInitialize).EndInit()
    Me.tabEdges.ResumeLayout(False)
    Me.pnlRangeEdge.ResumeLayout(False)
    Me.pnlRangeEdge.PerformLayout()
    CType(Me.ntxRangeEdgeNW, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.ntxRangeEdgeSE, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.ntxRangeEdgeSW, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.ntxRangeEdgeNE, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.pctProgress, System.ComponentModel.ISupportInitialize).EndInit()
    Me.mnuMain.ResumeLayout(False)
    Me.mnuMain.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents pnlMain As System.Windows.Forms.TableLayoutPanel
  Friend WithEvents pctTitle As System.Windows.Forms.PictureBox
  Friend WithEvents lblMap As System.Windows.Forms.Label
  Friend WithEvents cmbMaps As System.Windows.Forms.ComboBox
  Friend WithEvents cmdClose As System.Windows.Forms.Button
  Friend WithEvents cmdSave As System.Windows.Forms.Button
  Friend WithEvents pnlMapData As System.Windows.Forms.TableLayoutPanel
  Friend WithEvents lblMapMusic As System.Windows.Forms.Label
  Friend WithEvents txtMapMusic As System.Windows.Forms.TextBox
  Friend WithEvents cmdMapMusicBrowse As System.Windows.Forms.Button
  Friend WithEvents fraRanges As System.Windows.Forms.GroupBox
  Friend WithEvents pnlRanges As System.Windows.Forms.TableLayoutPanel
  Friend WithEvents lblRangeCount As System.Windows.Forms.Label
  Friend WithEvents ntxRangeCount As System.Windows.Forms.NumericUpDown
  Friend WithEvents ntxRangePositionCY As System.Windows.Forms.NumericUpDown
  Friend WithEvents ntxRangePositionCX As System.Windows.Forms.NumericUpDown
  Friend WithEvents lblRangeSize As System.Windows.Forms.Label
  Friend WithEvents ntxRangePositionY As System.Windows.Forms.NumericUpDown
  Friend WithEvents ntxRangePositionX As System.Windows.Forms.NumericUpDown
  Friend WithEvents lblRangePosition As System.Windows.Forms.Label
  Friend WithEvents cmdRangeMusicBrowse As System.Windows.Forms.Button
  Friend WithEvents txtRangeMusic As System.Windows.Forms.TextBox
  Friend WithEvents lblRangeMusic As System.Windows.Forms.Label
  Friend WithEvents fraRange As System.Windows.Forms.GroupBox
  Friend WithEvents cmbRange As System.Windows.Forms.ComboBox
  Friend WithEvents pnlRange As System.Windows.Forms.TableLayoutPanel
  Friend WithEvents ttMain As System.Windows.Forms.ToolTip
  Friend WithEvents mnuMain As System.Windows.Forms.MenuStrip
  Friend WithEvents mnuFile As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuReload As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuSave As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuRevert As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuFileSpace2 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents mnuImport As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuExport As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuFileSpace3 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents mnuExit As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuHelp As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuTips As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuAbout As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuFileSpace1 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents mnuTranslate As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuWebpage As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuHelpSpace As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents mnuMapView As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuView1 As ToolStripRadioButtonMenuItem
  Friend WithEvents mnuView2 As ToolStripRadioButtonMenuItem
  Friend WithEvents mnuView3 As ToolStripRadioButtonMenuItem
  Friend WithEvents lblRangePriority As System.Windows.Forms.Label
  Friend WithEvents cmdRangePriorityUp As System.Windows.Forms.Button
  Friend WithEvents cmdRangePriorityDown As System.Windows.Forms.Button
  Friend WithEvents fraRangeLoc As System.Windows.Forms.GroupBox
  Friend WithEvents pnlRangePosition As System.Windows.Forms.TableLayoutPanel
  Friend WithEvents tbsRangeLoc As System.Windows.Forms.TabControl
  Friend WithEvents tabPosition As System.Windows.Forms.TabPage
  Friend WithEvents tabEdges As System.Windows.Forms.TabPage
  Friend WithEvents pnlRangeEdge As System.Windows.Forms.TableLayoutPanel
  Friend WithEvents ntxRangeEdgeNW As System.Windows.Forms.NumericUpDown
  Friend WithEvents lblRangeEdges As System.Windows.Forms.Label
  Friend WithEvents ntxRangeEdgeSE As System.Windows.Forms.NumericUpDown
  Friend WithEvents ntxRangeEdgeSW As System.Windows.Forms.NumericUpDown
  Friend WithEvents ntxRangeEdgeNE As System.Windows.Forms.NumericUpDown
  Friend WithEvents tmrStart As System.Windows.Forms.Timer
  Friend WithEvents pctProgress As System.Windows.Forms.PictureBox

End Class

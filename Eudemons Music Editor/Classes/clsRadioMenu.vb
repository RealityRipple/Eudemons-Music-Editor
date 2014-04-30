Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles

Public Class ToolStripRadioButtonMenuItem
  Inherits ToolStripMenuItem

  Public Sub New()
    MyBase.New()
    Initialize()
  End Sub

  Public Sub New(ByVal text As String)
    MyBase.New(text, Nothing, CType(Nothing, EventHandler))
    Initialize()
  End Sub

  Public Sub New(ByVal image As Image)
    MyBase.New(Nothing, image, CType(Nothing, EventHandler))
    Initialize()
  End Sub

  Public Sub New(ByVal text As String, ByVal image As Image)
    MyBase.New(text, image, CType(Nothing, EventHandler))
    Initialize()
  End Sub

  Public Sub New(ByVal text As String, _
      ByVal image As Image, ByVal onClick As EventHandler)
    MyBase.New(text, image, onClick)
    Initialize()
  End Sub

  Public Sub New(ByVal text As String, ByVal image As Image, _
      ByVal onClick As EventHandler, ByVal name As String)
    MyBase.New(text, image, onClick, name)
    Initialize()
  End Sub

  Public Sub New(ByVal text As String, ByVal image As Image, _
      ByVal ParamArray dropDownItems() As ToolStripItem)
    MyBase.New(text, image, dropDownItems)
    Initialize()
  End Sub

  Public Sub New(ByVal text As String, ByVal image As Image, _
      ByVal onClick As EventHandler, ByVal shortcutKeys As Keys)
    MyBase.New(text, image, onClick)
    Initialize()
    Me.ShortcutKeys = shortcutKeys
  End Sub

  ' Called by all constructors to initialize CheckOnClick.
  Private Sub Initialize()
    CheckOnClick = True
  End Sub

  Protected Overrides Sub OnCheckedChanged(ByVal e As EventArgs)

    MyBase.OnCheckedChanged(e)

    ' If this item is no longer in the checked state or if its 
    ' parent has not yet been initialized, do nothing.
    If Not Checked OrElse Me.Parent Is Nothing Then Return

    ' Clear the checked state for all siblings. 
    For Each item As ToolStripItem In Parent.Items

      Dim radioItem As ToolStripRadioButtonMenuItem = _
          TryCast(item, ToolStripRadioButtonMenuItem)
      If radioItem IsNot Nothing AndAlso _
          radioItem IsNot Me AndAlso _
          radioItem.Checked Then

        radioItem.Checked = False

        ' Only one item can be selected at a time, 
        ' so there is no need to continue.
        Return

      End If
    Next

  End Sub

  Protected Overrides Sub OnClick(ByVal e As EventArgs)

    ' If the item is already in the checked state, do not call 
    ' the base method, which would toggle the value. 
    If Checked Then Return

    MyBase.OnClick(e)
  End Sub

  ' Let the item paint itself, and then paint the RadioButton
  ' where the check mark is normally displayed.
  Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)

    If Image IsNot Nothing Then
      ' If the client sets the Image property, the selection behavior
      ' remains unchanged, but the RadioButton is not displayed and the
      ' selection is indicated only by the selection rectangle. 
      MyBase.OnPaint(e)
      Return
    Else
      ' If the Image property is not set, call the base OnPaint method 
      ' with the CheckState property temporarily cleared to prevent
      ' the check mark from being painted.
      Dim currentState As CheckState = Me.CheckState
      Me.CheckState = CheckState.Unchecked
      MyBase.OnPaint(e)
      Me.CheckState = currentState
    End If

    ' Determine the correct state of the RadioButton.
    Dim buttonState As RadioButtonState = RadioButtonState.UncheckedNormal
    If Enabled Then
      If mouseDownState Then
        If Checked Then
          buttonState = RadioButtonState.CheckedPressed
        Else
          buttonState = RadioButtonState.UncheckedPressed
        End If
      ElseIf mouseHoverState Then
        If Checked Then
          buttonState = RadioButtonState.CheckedHot
        Else
          buttonState = RadioButtonState.UncheckedHot
        End If
      Else
        If Checked Then buttonState = RadioButtonState.CheckedNormal
      End If
    Else
      If Checked Then
        buttonState = RadioButtonState.CheckedDisabled
      Else
        buttonState = RadioButtonState.UncheckedDisabled
      End If
    End If

    ' Calculate the position at which to display the RadioButton.
    Dim offset As Int32 = CInt((ContentRectangle.Height - _
        RadioButtonRenderer.GetGlyphSize( _
        e.Graphics, buttonState).Height) / 2)
    Dim imageLocation As Point = New Point( _
        ContentRectangle.Location.X + 4, _
        ContentRectangle.Location.Y + offset)

    ' Paint the RadioButton. 
    RadioButtonRenderer.DrawRadioButton( _
        e.Graphics, imageLocation, buttonState)

  End Sub

  Private mouseHoverState As Boolean = False

  Protected Overrides Sub OnMouseEnter(ByVal e As EventArgs)
    mouseHoverState = True

    ' Force the item to repaint with the new RadioButton state.
    Invalidate()

    MyBase.OnMouseEnter(e)
  End Sub

  Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
    mouseHoverState = False
    MyBase.OnMouseLeave(e)
  End Sub

  Private mouseDownState As Boolean = False

  Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
    mouseDownState = True

    ' Force the item to repaint with the new RadioButton state.
    Invalidate()

    MyBase.OnMouseDown(e)
  End Sub

  Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
    mouseDownState = False
    MyBase.OnMouseUp(e)
  End Sub

  ' Enable the item only if its parent item is in the checked state 
  ' and its Enabled property has not been explicitly set to false. 
  Public Overrides Property Enabled() As Boolean
    Get
      Dim ownerMenuItem As ToolStripMenuItem = _
          TryCast(OwnerItem, ToolStripMenuItem)

      ' Use the base value in design mode to prevent the designer
      ' from setting the base value to the calculated value.
      If Not DesignMode AndAlso ownerMenuItem IsNot Nothing AndAlso _
          ownerMenuItem.CheckOnClick Then
        Return MyBase.Enabled AndAlso ownerMenuItem.Checked
      Else
        Return MyBase.Enabled
      End If
    End Get

    Set(ByVal value As Boolean)
      MyBase.Enabled = value
    End Set
  End Property

  ' When OwnerItem becomes available, if it is a ToolStripMenuItem 
  ' with a CheckOnClick property value of true, subscribe to its 
  ' CheckedChanged event. 
  Protected Overrides Sub OnOwnerChanged(ByVal e As EventArgs)

    Dim ownerMenuItem As ToolStripMenuItem = _
        TryCast(OwnerItem, ToolStripMenuItem)

    If ownerMenuItem IsNot Nothing AndAlso _
        ownerMenuItem.CheckOnClick Then
      AddHandler ownerMenuItem.CheckedChanged, New  _
          EventHandler(AddressOf OwnerMenuItem_CheckedChanged)
    End If

    MyBase.OnOwnerChanged(e)

  End Sub

  ' When the checked state of the parent item changes, 
  ' repaint the item so that the new Enabled state is displayed. 
  Private Sub OwnerMenuItem_CheckedChanged( _
      ByVal sender As Object, ByVal e As EventArgs)
    Invalidate()
  End Sub

End Class
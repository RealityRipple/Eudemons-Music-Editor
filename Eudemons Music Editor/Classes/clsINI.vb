Public Class clsINI
  Implements IDisposable

  Private INIFile As String
  Private Sections() As String
  Private Keys()() As String

  <Runtime.InteropServices.DllImport("kernel32.dll", CharSet:=Runtime.InteropServices.CharSet.Unicode, setlasterror:=True)>
  Private Shared Function GetPrivateProfileStringW(lpApplicationName As String, lpKeyName As String, lpDefault As String, lpReturnedString As String, nSize As Int32, lpFileName As String) As Integer
  End Function

  <Runtime.InteropServices.DllImport("kernel32.dll", CharSet:=Runtime.InteropServices.CharSet.Unicode, setlasterror:=True)>
  Private Shared Function WritePrivateProfileStringW(lpApplicationName As String, lpKeyName As String, lpString As String, lpFileName As String) As Integer
  End Function

  Public Sub New(FileName As String)
    INIFile = FileName
    Dim sTmp As String = CleanRet(INIRead(INIFile, Nothing, Nothing, ""))
    Sections = sTmp.Split(vbNullChar)
    ReDim Keys(Sections.Length - 1)
    For I = 0 To Sections.Length - 1
      If Sections(I).Length > 0 Then
        sTmp = CleanRet(INIRead(INIFile, Sections(I), Nothing, ""))
        sTmp.Replace(vbNullChar & vbNullChar, vbNullChar)
        Keys(I) = sTmp.Split(vbNullChar)
      End If
    Next
  End Sub

  Public Function GetSections() As String()
    Return Sections
  End Function

  Public Function GetKeys(Section As String) As String()
    For I As Integer = 0 To Sections.Length - 1
      If Sections(I) = Section Then
        Return Keys(I)
      End If
    Next
    Return Nothing
  End Function

  Public Function GetValue(Section As String, Key As String) As String
    Return INIRead(INIFile, Section, Key, String.Empty)
  End Function

  Public Sub SetValue(Section As String, Key As String, Value As String)
    INIWrite(INIFile, Section, Key, Value)
    If Sections Is Nothing Then
      ReDim Sections(0)
      Sections(0) = Section
      ReDim Keys(0)(0)
    ElseIf Not Sections.Contains(Section) Then
      ReDim Preserve Sections(Sections.Length)
      ReDim Preserve Keys(Keys.Length)
      Sections(Sections.Length - 1) = Section
    End If
    Dim iSection As Integer = Array.FindIndex(Sections, Function(sSection As String) sSection = Section)
    If Keys Is Nothing Then
      ReDim Keys(0)(0)
      Keys(0)(0) = Key
    ElseIf Keys(iSection) Is Nothing Then
      ReDim Preserve Keys(iSection)(0)
      Keys(iSection)(0) = Key
    ElseIf Not Keys(iSection).Contains(Key) Then
      ReDim Preserve Keys(iSection)(Keys(iSection).Count)
      Keys(iSection)(Keys(iSection).Count - 1) = Key
    End If
  End Sub

  Private Function CleanRet(sTmp As String) As String
    sTmp.Replace(vbNullChar & vbNullChar, vbNullChar)
    If sTmp.Length > 0 Then
      Do While sTmp.Substring(sTmp.Length - 1) = vbNullChar
        sTmp = sTmp.Substring(0, sTmp.Length - 1)
      Loop
    End If
    Return sTmp
  End Function

  Private Function INIRead(INIPath As String, SectionName As String, KeyName As String, DefaultValue As String) As String
    Dim sData As String = Space(65535)
    Dim n As Integer = GetPrivateProfileStringW(SectionName, KeyName, DefaultValue, sData, sData.Length, INIPath)
    If n > 0 Then
      Return sData.Substring(0, n)
    Else
      Return DefaultValue
    End If
  End Function

  Private Sub INIWrite(INIPath As String, SectionName As String, KeyName As String, Value As String)
    Dim Written As Integer = WritePrivateProfileStringW(SectionName, KeyName, Value, INIPath)
    If Not Written = 1 Then
      MsgBox("Could not write to INI file", MsgBoxStyle.Exclamation)
    End If
  End Sub

#Region "IDisposable Support"
  Private disposedValue As Boolean ' To detect redundant calls

  ' IDisposable
  Protected Overridable Sub Dispose(disposing As Boolean)
    If Not Me.disposedValue Then
      If disposing Then
        INIFile = Nothing
        Erase Sections
        Erase Keys
        ' TODO: dispose managed state (managed objects).
      End If

      ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
      ' TODO: set large fields to null.
    End If
    Me.disposedValue = True
  End Sub

  ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
  'Protected Overrides Sub Finalize()
  '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
  '    Dispose(False)
  '    MyBase.Finalize()
  'End Sub

  ' This code added by Visual Basic to correctly implement the disposable pattern.
  Public Sub Dispose() Implements IDisposable.Dispose
    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    Dispose(True)
    GC.SuppressFinalize(Me)
  End Sub
#End Region

End Class
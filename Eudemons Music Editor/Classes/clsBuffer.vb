Imports System.IO
Imports System.Text
Public Class DataBuffer
  Implements IDisposable
  Private m_Stream As MemoryStream
  Private m_Length As Integer
  Public Sub New()
    m_Stream = New MemoryStream
  End Sub

  Public Sub InsertBoolean(bVal As Boolean)
    InsertUInt32(IIf(bVal, 1, 0))
  End Sub

  Public Sub InsertByte(bVal As Byte)
    m_Stream.WriteByte(bVal)
    m_Length += 1
  End Sub

  Public Sub InsertString(sVal As String, Optional CodePage As Integer = 0)
    InsertByteArray(System.Text.Encoding.GetEncoding(CodePage).GetBytes(sVal))
  End Sub

  Public Sub InsertByteArray(bVal() As Byte)
    If bVal Is Nothing Then Exit Sub
    m_Stream.Write(bVal, 0, bVal.Length)
    m_Length += bVal.Length
  End Sub

  Public Sub InsertSByte(bVal As SByte)
    m_Stream.WriteByte(bVal)
    m_Length += 1
  End Sub

  Public Sub InsertSByteArray(bVal() As SByte)
    If bVal Is Nothing Then Exit Sub
    Dim bResult(bVal.Length - 1) As Byte
    Buffer.BlockCopy(bVal, 0, bResult, 0, bResult.Length)
    m_Stream.Write(bResult, 0, bResult.Length)
    m_Length += bResult.Length
  End Sub

  Public Sub InsertInt16(iVal As Int16)
    m_Stream.Write(BitConverter.GetBytes(iVal), 0, 2)
    m_Length += 2
  End Sub

  Public Sub InsertUInt16(iVal As UInt16)
    m_Stream.Write(BitConverter.GetBytes(iVal), 0, 2)
    m_Length += 2
  End Sub

  Public Sub InsertInt16Array(iVal() As Int16)
    If iVal Is Nothing Then Exit Sub
    Dim bResult(iVal.Length * 2 - 1) As Byte
    Buffer.BlockCopy(iVal, 0, bResult, 0, bResult.Length)
    m_Stream.Write(bResult, 0, bResult.Length)
    m_Length += bResult.Length
  End Sub

  Public Sub InsertUInt16Array(iVal() As UInt16)
    If iVal Is Nothing Then Exit Sub
    Dim bResult(iVal.Length * 2 - 1) As Byte
    Buffer.BlockCopy(iVal, 0, bResult, 0, bResult.Length)
    m_Stream.Write(bResult, 0, bResult.Length)
    m_Length += bResult.Length
  End Sub

  Public Sub InsertInt32(iVal As Int32)
    m_Stream.SetLength(m_Length + 4)
    m_Stream.Write(BitConverter.GetBytes(iVal), 0, 4)
    m_Length += 4
  End Sub

  Public Sub InsertUInt32(iVal As UInt32)
    m_Stream.Write(BitConverter.GetBytes(iVal), 0, 4)
    m_Length += 4
  End Sub

  Public Sub InsertInt32Array(iVal() As Int32)
    If iVal Is Nothing Then Exit Sub
    Dim bResult(iVal.Length * 4 - 1) As Byte
    Buffer.BlockCopy(iVal, 0, bResult, 0, bResult.Length)
    m_Stream.Write(bResult, 0, bResult.Length)
    m_Length += bResult.Length
  End Sub

  Public Sub InsertUInt32Array(iVal() As UInt32)
    If iVal Is Nothing Then Exit Sub
    Dim bResult(iVal.Length * 4 - 1) As Byte
    Buffer.BlockCopy(iVal, 0, bResult, 0, bResult.Length)
    m_Stream.Write(bResult, 0, bResult.Length)
    m_Length += bResult.Length
  End Sub

  Public Sub InsertInt64(iVal As Int64)
    m_Stream.Write(BitConverter.GetBytes(iVal), 0, 8)
    m_Length += 8
  End Sub

  Public Sub InsertUInt64(iVal As UInt64)
    m_Stream.Write(BitConverter.GetBytes(iVal), 0, 8)
    m_Length += 8
  End Sub

  Public Sub InsertInt64Array(iVal() As Int64)
    If iVal Is Nothing Then Exit Sub
    Dim bResult(iVal.Length * 8 - 1) As Byte
    Buffer.BlockCopy(iVal, 0, bResult, 0, bResult.Length)
    m_Stream.Write(bResult, 0, bResult.Length)
    m_Length += bResult.Length
  End Sub

  Public Sub InsertUInt64Array(iVal() As UInt64)
    If iVal Is Nothing Then Exit Sub
    Dim bResult(iVal.Length * 8 - 1) As Byte
    Buffer.BlockCopy(iVal, 0, bResult, 0, bResult.Length)
    m_Stream.Write(bResult, 0, bResult.Length)
    m_Length += bResult.Length
  End Sub

  Public Sub InsertCString(sVal As String)
    InsertCString(sVal, Encoding.ASCII)
  End Sub

  Public Sub InsertCString(sVal As String, eVal As Encoding)
    If String.IsNullOrEmpty(sVal) Then
      InsertByte(0)
    Else
      InsertByteArray(eVal.GetBytes(sVal))
      Dim bNull(eVal.GetByteCount(vbNullChar) - 1) As Byte
      InsertByteArray(bNull)
    End If
  End Sub

  Public Sub InsertDwordString(sVal As String)
    InsertDwordString(sVal, 0)
  End Sub

  Public Sub InsertDWORDString(sVal As String, bPadding As Byte)
    If sVal.Length < 4 Then
      Dim iNulls As Integer = 4 - sVal.Length
      For I As Integer = 0 To iNulls - 1
        InsertByte(bPadding)
      Next
    End If
    Dim bVal() As Byte = Encoding.ASCII.GetBytes(sVal)
    For I As Integer = bVal.Length - 1 To 0 Step -1
      InsertByte(bVal(I))
    Next
  End Sub

  Public Overridable Function GetData() As Byte()
    If m_Length > 0 Then
      Dim bData(m_Length - 1) As Byte
      Buffer.BlockCopy(m_Stream.GetBuffer, 0, bData, 0, m_Length)
      Return bData
    Else
      Return Nothing
    End If
  End Function

  Public Overridable ReadOnly Property Length() As Integer
    Get
      Return m_Length
    End Get
  End Property

#Region "IDisposable Support"
  Private disposedValue As Boolean ' To detect redundant calls

  ' IDisposable
  Protected Overridable Sub Dispose(disposing As Boolean)
    If Not Me.disposedValue Then
      If disposing Then
        ' TODO: dispose managed state (managed objects).
        m_Stream = Nothing
        m_Length = 0
      End If

      ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
      ' TODO: set large fields to null.
    End If
    Me.disposedValue = True
  End Sub

  ' TODO: override Finalize() only if Dispose( disposing As Boolean) above has code to free unmanaged resources.
  'Protected Overrides Sub Finalize()
  '    ' Do not change this code.  Put cleanup code in Dispose( disposing As Boolean) above.
  '    Dispose(False)
  '    MyBase.Finalize()
  'End Sub

  ' This code added by Visual Basic to correctly implement the disposable pattern.
  Public Sub Dispose() Implements IDisposable.Dispose
    ' Do not change this code.  Put cleanup code in Dispose( disposing As Boolean) above.
    Dispose(True)
    GC.SuppressFinalize(Me)
  End Sub
#End Region
End Class
Public Class DataReader
  Implements IDisposable
  Private m_Data() As Byte
  Private m_Index As Integer
  Public Sub New(sStream As Stream, iLength As Integer)
    ReDim m_Data(iLength - 1)
    sStream.Read(m_Data, 0, iLength)
  End Sub

  Public Sub New(bData() As Byte)
    m_Data = bData
  End Sub

  Public Function GetAllBytes() As Byte()
    Return m_Data
  End Function

  Public Function ReadBoolean() As Boolean
    If m_Index >= m_Data.Length Then Return Nothing
    Return ReadInt32() <> 0
  End Function

  Public Function ReadByte() As Byte
    If m_Index >= m_Data.Length Then Return Nothing
    m_Index += 1
    Return m_Data(m_Index - 1)
  End Function

  Public Function ReadByteArray(iItems As Integer) As Byte()
    If m_Index + iItems > m_Data.Length Then Return Nothing
    Dim bData(iItems - 1) As Byte
    Buffer.BlockCopy(m_Data, m_Index, bData, 0, iItems)
    m_Index += iItems
    Return bData
  End Function

  Public Function ReadNullTerminatedByteArray() As Byte()
    If m_Index >= m_Data.Length Then Return Nothing
    Dim I As Integer = m_Index
    While I < (m_Data.Length - 1) And m_Data(I) > 0
      I += 1
    End While
    Dim bBytes(I - m_Index - 1) As Byte
    Buffer.BlockCopy(m_Data, m_Index, bBytes, 0, bBytes.Length)
    m_Index = I + 1
    Return bBytes
  End Function

  Public Function ReadInt16() As Int16
    If m_Index + 1 >= m_Data.Length Then Return Nothing
    Dim iRet As Int16 = BitConverter.ToInt16(m_Data, m_Index)
    m_Index += 2
    Return iRet
  End Function

  Public Function ReadInt16Array(iItems As Integer) As Int16()
    If m_Index + 1 + (iItems * 2) > m_Data.Length Then Return Nothing
    Dim iData(iItems - 1) As Int16
    Buffer.BlockCopy(m_Data, m_Index, iData, 0, iItems * 2)
    m_Index += iItems * 2
    Return iData
  End Function

  Public Function ReadUInt16() As UInt16
    If m_Index + 1 >= m_Data.Length Then Return Nothing
    Dim iRet As UInt16 = BitConverter.ToUInt16(m_Data, m_Index)
    m_Index += 2
    Return iRet
  End Function

  Public Function ReadUInt16Array(iItems As Integer) As UInt16()
    If m_Index + 1 + (iItems * 2) > m_Data.Length Then Return Nothing
    Dim iData(iItems - 1) As UInt16
    Buffer.BlockCopy(m_Data, m_Index, iData, 0, iItems * 2)
    m_Index += iItems * 2
    Return iData
  End Function

  Public Function ReadInt32() As Int32
    If m_Index + 3 >= m_Data.Length Then Return Nothing
    Dim iRet As Int32 = BitConverter.ToInt32(m_Data, m_Index)
    m_Index += 4
    Return iRet
  End Function

  Public Function ReadInt32Array(iItems As Integer) As Int32()
    If m_Index + 3 + (iItems * 4) > m_Data.Length Then Return Nothing
    Dim iData(iItems - 1) As Int32
    Buffer.BlockCopy(m_Data, m_Index, iData, 0, iItems * 4)
    m_Index += iItems * 4
    Return iData
  End Function

  Public Function ReadUInt32() As UInt32
    If m_Index + 3 >= m_Data.Length Then Return Nothing
    Dim iRet As UInt32 = BitConverter.ToUInt32(m_Data, m_Index)
    m_Index += 4
    Return iRet
  End Function

  Public Function ReadUInt32Array(iItems As Integer) As UInt32()
    If m_Index + 3 + (iItems * 4) > m_Data.Length Then Return Nothing
    Dim iData(iItems - 1) As UInt32
    Buffer.BlockCopy(m_Data, m_Index, iData, 0, iItems * 4)
    m_Index += iItems * 4
    Return iData
  End Function

  Public Function ReadInt64() As Int64
    If m_Index + 7 >= m_Data.Length Then Return Nothing
    Dim iRet As Int64 = BitConverter.ToInt64(m_Data, m_Index)
    m_Index += 8
    Return iRet
  End Function

  Public Function ReadInt64Array(iItems As Integer) As Int64()
    If m_Index + 7 + (iItems * 8) > m_Data.Length Then Return Nothing
    Dim iData(iItems - 1) As Int64
    Buffer.BlockCopy(m_Data, m_Index, iData, 0, iItems * 8)
    m_Index += iItems * 8
    Return iData
  End Function

  Public Function ReadUInt64() As UInt64
    If m_Index + 7 >= m_Data.Length Then Return Nothing
    Dim iRet As UInt64 = BitConverter.ToUInt64(m_Data, m_Index)
    m_Index += 8
    Return iRet
  End Function

  Public Function ReadUInt64Array(iItems As Integer) As UInt64()
    If m_Index + 7 + (iItems * 8) > m_Data.Length Then Return Nothing
    Dim iData(iItems - 1) As UInt64
    Buffer.BlockCopy(m_Data, m_Index, iData, 0, iItems * 8)
    m_Index += iItems * 8
    Return iData
  End Function

  Public Function Peek() As Integer
    If m_Index >= m_Data.Length - 1 Then Return -1
    Return m_Data(m_Index)
  End Function

  Public Function ReadDWORDString() As String
    If m_Index + 3 >= m_Data.Length Then Return Nothing
    Dim bVal() As Byte = ReadByteArray(4)
    If bVal Is Nothing Then Return Nothing
    Dim sRet As String = Encoding.ASCII.GetString(bVal)
    Return StrReverse(Replace(sRet, vbNullChar, String.Empty))
  End Function

  Public Function ReadCStringArray(Count As Integer) As String()
    If m_Index >= m_Data.Length Then Return Nothing
    Dim sTmp(Count - 1) As String
    For I As Integer = 0 To Count - 1
      sTmp(I) = ReadCString()
    Next
    Return sTmp
  End Function

  Public Function ReadCStringArray(Count As Integer, eVal As Encoding) As String()
    If m_Index >= m_Data.Length Then Return Nothing
    Dim sTmp(Count - 1) As String
    For I As Integer = 0 To Count - 1
      sTmp(I) = ReadCString(eVal)
    Next
    Return sTmp
  End Function

  Public Function ReadCString() As String
    If m_Index >= m_Data.Length Then Return Nothing
    Return ReadCString(Encoding.ASCII)
  End Function

  Public Function ReadCString(eVal As Encoding) As String
    If m_Index >= m_Data.Length Then Return String.Empty
    Dim i As Integer = m_Index
    If eVal.Equals(Encoding.Unicode) Or eVal.Equals(Encoding.BigEndianUnicode) Then
      While ((i < m_Data.Length - 1) And ((i + 1 < m_Data.Length - 1) And m_Data(i) > 0))
        i += 1
      End While
    Else
      While ((i < (m_Data.Length - 1)) And (m_Data(i) > 0))
        i += 1
      End While
    End If
    Dim sRet As String = eVal.GetString(m_Data, m_Index, i - m_Index)
    m_Index = i + 1
    Return sRet
  End Function

  Public Overridable ReadOnly Property Length As Integer
    Get
      Return m_Data.Length
    End Get
  End Property

  Public Overridable ReadOnly Property Position As Integer
    Get
      Return m_Index
    End Get
  End Property

#Region "IDisposable Support"
  Private disposedValue As Boolean
  Protected Overridable Sub Dispose(disposing As Boolean)
    If Not Me.disposedValue Then
      If disposing Then
        m_Index = 0
        m_Data = Nothing
      End If
    End If
    Me.disposedValue = True
  End Sub
  Public Sub Dispose() Implements IDisposable.Dispose
    Dispose(True)
    GC.SuppressFinalize(Me)
  End Sub
#End Region
End Class
Public Class Translator
  Private Const ycU As String = "https://yourculture.uk/wp-admin/admin-ajax.php"
  Private cJar As Net.CookieContainer
  Private ycKey As String
  Private sCacheStorage As String

  Public Sub New()
    sCacheStorage = IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Application.CompanyName, Application.ProductName)
    Try
      clsUpdate.ModernProtcol()
      Using wsClient As New WebClientCore
        wsClient.Timeout = 15
        Dim sData As String = wsClient.DownloadString("https://yourculture.uk/free-translation-service/")
        If Not sData.Contains("""security_check"":""") Then Return
        sData = sData.Substring(sData.IndexOf("""security_check"":""") + 18)
        If sData.Contains("""") Then sData = sData.Substring(0, sData.IndexOf(""""))
        ycKey = sData
        cJar = wsClient.CookieJar
      End Using
    Catch ex As Exception
    End Try
  End Sub

  Public Function ChineseToEnglish(sChinese As String) As String
    Dim sCache As String = GetFromCache(sChinese)
    If Not String.IsNullOrEmpty(sCache) Then Return sCache
    If String.IsNullOrEmpty(ycKey) Then Return sChinese
    Try
      Using wsClient As New WebClientCore
        If cJar IsNot Nothing Then
          wsClient.CookieJar = cJar
          wsClient.SendCookieJar = True
        End If
        Dim postVals As String = "action=tr-box-request&text_to_translate=" & sChinese.Replace(" ", "+") & "&from_language=zh&to_language=en&security_check=" & ycKey
        wsClient.Timeout = 15
        wsClient.Encoding = System.Text.Encoding.UTF8
        wsClient.Headers.Add("content-type", "application/x-www-form-urlencoded; charset=UTF-8")
        wsClient.Headers.Add("X-Requested-With", "XMLHttpRequest")
        wsClient.Headers.Add("Accept", "*/*")
        wsClient.Headers.Add("Accept-Language", "en-US;en;q=0.5")
        wsClient.Headers.Add("Accept-Encoding", "gzip, deflate, br")
        Dim sJSON As String = wsClient.UploadString(New Uri(ycU), postVals)
        Dim sRet As String = sJSON
        If sRet.Contains("""translatedText"":null") Then
          Stop
          Return sChinese
        End If
        If sRet.Contains("""translatedText"":""") Then sRet = sRet.Substring(sRet.IndexOf("""translatedText"":""") + 18)
        If sRet.Contains(""",") Then sRet = sRet.Substring(0, sRet.IndexOf(""","))
        If sRet.Contains("&#") Or sRet.Contains("\u") Then sRet = HexDecode(sRet)
        If Not sRet = System.Text.Encoding.GetEncoding(28591).GetString(System.Text.Encoding.UTF8.GetBytes(sRet)) Then
          If Not sChinese.Contains(vbLf) Then
            Dim sNew() As Char = sChinese.ToCharArray
            Dim sRetry As String = ""
            For I As Integer = 0 To sNew.Length - 1
              sRetry &= sNew(I) & vbLf
            Next
            Return ChineseToEnglish(sRetry.Trim)
          End If
          If Not sChinese.Contains("|") Then
            Return ChineseToEnglish(sChinese.Replace(vbLf, "|"))
          End If
          If sRet.Contains("|") Then sRet = sRet.Replace("|", " ")
          While sRet.Contains("  ")
            sRet = sRet.Replace("  ", " ")
          End While
          Return sRet
        End If
        If sRet.Contains("|") Then sRet = sRet.Replace("|", " ")
        While sRet.Contains("  ")
          sRet = sRet.Replace("  ", " ")
        End While
        AddToCache(sChinese, sRet)
        Return sRet
      End Using
    Catch ex As Exception
      Return sChinese
    End Try
  End Function

  Private Sub AddToCache(sIn As String, sOut As String)
    sIn = SafeCN(sIn)
    sOut = SafeCN(sOut)
    If Not IO.Directory.Exists(IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Application.CompanyName)) Then IO.Directory.CreateDirectory(IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Application.CompanyName))
    If Not IO.Directory.Exists(sCacheStorage) Then IO.Directory.CreateDirectory(sCacheStorage)
    Dim sFile As String = IO.Path.Combine(sCacheStorage, "translate.cache")
    If Not IO.File.Exists(sFile) Then IO.File.WriteAllText(sFile, ";Chinese Translation Cache for Eudemons Online Map Names" & vbNewLine)
    Using iniInfo As New clsINI(sFile)
      iniInfo.SetValue("Translations", sIn, sOut)
    End Using
  End Sub

  Private Function GetFromCache(sIn As String) As String
    sIn = SafeCN(sIn)
    If Not IO.Directory.Exists(IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Application.CompanyName)) Then Return Nothing
    If Not IO.Directory.Exists(sCacheStorage) Then Return Nothing
    Dim sFile As String = IO.Path.Combine(sCacheStorage, "translate.cache")
    If Not IO.File.Exists(sFile) Then Return Nothing
    Using iniInfo As New clsINI(sFile)
      If Not iniInfo.GetSections.Contains("Translations") Then Return Nothing
      If Not iniInfo.GetKeys("Translations").Contains(sIn) Then Return Nothing
      Dim sRet As String = SafeCNBack(iniInfo.GetValue("Translations", sIn))
      Return sRet
    End Using
  End Function

  Public Shared Function HexDecode([string] As String) As String
    Dim sRet As String = String.Empty
    If String.IsNullOrEmpty([string]) Then Return [string]
    For I As Integer = 0 To [string].Length - 1
      If [string](I) = "&" Then
        If [string].Length - I > 1 AndAlso [string](I + 1) = "#" Then
          If [string].Length - I > 2 AndAlso [string](I + 2) = "x" Then
            If [string].Length - I > 4 AndAlso [string](I + 4) = ";" Then
              Dim hVal As String = [string](I + 3)
              sRet &= Chr(Convert.ToByte(hVal, 16))
              I += 4
            ElseIf [string].Length - I > 5 AndAlso [string](I + 5) = ";" Then
              Dim hVal As String = [string](I + 3) & [string](I + 4)
              sRet &= Chr(Convert.ToByte(hVal, 16))
              I += 5
            Else
              sRet &= [string](I)
            End If
          Else
            If [string].Length - I > 3 AndAlso [string](I + 3) = ";" Then
              Dim hVal As String = [string](I + 2)
              sRet &= Chr(Convert.ToByte(hVal, 10))
              I += 3
            ElseIf [string].Length - I > 4 AndAlso [string](I + 4) = ";" Then
              Dim hVal As String = [string](I + 2) & [string](I + 3)
              sRet &= Chr(Convert.ToByte(hVal, 10))
              I += 4
            Else
              sRet &= [string](I)
            End If
          End If
        Else
          sRet &= [string](I)
        End If
      ElseIf [string](I) = "\" Then
        If [string].Length - I > 1 AndAlso [string](I + 1) = "u" Then
          If [string].Length - I > 5 Then
            Dim hVal As String = [string].Substring(I + 2, 4)
            sRet &= ChrW(Convert.ToUInt16(hVal, 16))
            I += 5
          Else
            sRet &= [string](I)
          End If
        Else
          sRet &= [string](I)
        End If
      Else
        sRet &= [string](I)
      End If
    Next
    Return sRet
  End Function

  Private Function SafeCN(sIn As String) As String
    Dim bIn() As Byte = System.Text.Encoding.UTF8.GetBytes(sIn)
    Return ToBase32String(bIn)
  End Function

  Private Function SafeCNBack(sIn As String) As String
    Dim bOut() As Byte = FromBase32String(sIn)
    Return System.Text.Encoding.UTF8.GetString(bOut)
  End Function

  Private Function ToBase32String(ByVal input As Byte()) As String
    Dim Base32AllowedCharacters As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567"
    If input Is Nothing OrElse input.Length = 0 Then Return String.Empty
    Dim bits = input.[Select](Function(b) Convert.ToString(b, 2).PadLeft(8, "0"c)).Aggregate(Function(a, b) a + b).PadRight(CInt((Math.Ceiling((input.Length * 8) / 5.0R) * 5)), "0"c)
    Dim result = Enumerable.Range(0, bits.Length / 5).[Select](Function(i) Base32AllowedCharacters.Substring(Convert.ToInt32(bits.Substring(i * 5, 5), 2), 1)).Aggregate(Function(a, b) a + b)
    Return result
  End Function

  Private Function FromBase32String(ByVal input As String) As Byte()
    Dim Base32AllowedCharacters As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567"
    If String.IsNullOrEmpty(input) Then
      Return New Byte(-1) {}
    End If
    Try
      Dim bits = input.ToUpper().ToCharArray().[Select](Function(c) Convert.ToString(Base32AllowedCharacters.IndexOf(c), 2).PadLeft(5, "0"c)).Aggregate(Function(a, b) a + b)
      Do Until bits.Length Mod 8 = 0
        bits &= "0"
      Loop
      Dim result() As Byte = Enumerable.Range(0, bits.Length / 8).[Select](Function(i) Convert.ToByte(bits.Substring(i * 8, 8), 2)).ToArray()
      Do While result.Last = 0
        ReDim Preserve result(result.Length - 2)
      Loop
      Return result
    Catch ex As Exception
      Return New Byte(-1) {}
    End Try
  End Function
End Class
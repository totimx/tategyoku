Public Class FormatCheck

#Region "入力チェックロジック部"



    Public Shared Function CheckIsNotBlank(ByVal input As String, ByRef msg As String)
        If input Is Nothing OrElse input.Trim() = "" Then
            msg = "必須項目です。"
            Return False
        End If
        Return True
    End Function


    ''' <summary>
    ''' 入力チェック(文字列)
    ''' </summary>
    ''' <param name="input">入力文字列</param>
    ''' <param name="msg">エラー時メッセージ</param>
    ''' <param name="convertedValue">変換後文字列</param>
    ''' <param name="regExPattern">REGEXパターン</param>
    ''' <returns>true:入力OK (変換あり含む), false: 入力NG</returns>
    ''' <remarks></remarks>
    Public Shared Function CheckString(ByVal input As String, ByVal maxLength As Integer,
                                       ByRef msg As String, ByRef convertedValue As String,
                                       Optional ByVal regExPattern As String = Nothing) As Boolean

        convertedValue = input

        '未入力はチェックしない。
        If input Is Nothing OrElse
           input.Trim() = "" Then
            Return True
        End If

        '長さチェック
        If maxLength > 0 AndAlso ConvertUtil.LenB(input) > maxLength Then
            msg = "入力桁数が大きすぎます(最大入力桁数=" & maxLength & ")"
            Return False
        End If

        'パターンチェック
        If regExPattern IsNot Nothing Then

            Dim regex As New System.Text.RegularExpressions.Regex(regExPattern)

            If regex.IsMatch(input) = False Then
                msg = "パターン[" & regExPattern.ToString & "]に不一致"
                Return False
            End If
        End If

        Return True
    End Function

    ''' <summary>
    ''' 入力チェック(日付)
    ''' </summary>
    ''' <param name="input">入力文字列</param>
    ''' <param name="msg">エラー時メッセージ</param>
    ''' <param name="convertedValue">変換後文字列</param>
    ''' <returns>true:入力OK (変換あり含む), false: 入力NG</returns>
    ''' <remarks></remarks>
    Public Shared Function CheckDate(ByVal input As String, ByRef msg As String,
                                     ByRef convertedValue As DateTime) As Boolean

        Dim dt As Date

        '入力完了時は日付チェックを行う。
        If (Date.TryParse(input, dt) = False) AndAlso
           (Date.TryParseExact(input, {"yyyyMMdd", "yyMMdd", "yyyy/MM/dd", "yy/MM/dd", "yyyyMM", "yyMM", "yy/MM"},
                               New Globalization.CultureInfo("ja-JP"),
                                Globalization.DateTimeStyles.None, dt) = False) Then
            msg = "不正な日付"
            Return False
        End If
        If dt.CompareTo(New Date(1980, 1, 1)) < 0 Then
            msg = "不正な日付"
            Return False
        End If

        '変換後日付
        convertedValue = dt

        Return True
    End Function

    ''' <summary>
    ''' 入力チェック(時刻)
    ''' </summary>
    ''' <param name="input">入力文字列</param>
    ''' <param name="msg">エラー時メッセージ</param>
    ''' <param name="convertedValue">変換後文字列</param>
    ''' <returns>true:入力OK (変換あり含む), false: 入力NG</returns>
    ''' <remarks></remarks>
    Public Shared Function CheckTime(ByVal input As String, ByRef msg As String,
                                     ByRef convertedValue As String) As Boolean

        Dim dt As DateTime

        '入力完了時は時刻チェックを行う。
        If (DateTime.TryParse(input, dt) = False) AndAlso
               (Date.TryParseExact(input, {"HHmm", "HHmmss", "HH:mm", "HH:mm:ss"},
                                   New Globalization.CultureInfo("ja-JP"),
                                    Globalization.DateTimeStyles.None, dt) = False) Then
            msg = "不正な時刻"
            Return False
        End If

        '変換後時刻
        convertedValue = dt

        Return True

    End Function

    ''' <summary>
    ''' 入力チェック(数値)
    ''' </summary>
    ''' <param name="input">入力文字列</param>
    ''' <param name="msg">エラー時メッセージ</param>
    ''' <param name="convertedValue">変換後文字列</param>
    ''' <returns>true:入力OK (変換あり含む), false: 入力NG</returns>
    ''' <remarks></remarks>
    Public Shared Function CheckNum(ByVal input As String, ByVal minValue As Long, ByVal maxValue As Long,
                                    ByRef msg As String, ByRef convertedValue As Long) As Boolean

        Dim num As Long

        '---------------------------数値チェック
        If Long.TryParse(input, num) = False Then
            msg = "数値ではありません。"
            Return False
        End If

        '---------------------------大小チェック
        If num < minValue Then
            msg = "最小値[" & minValue & "]より小さいです。"
            Return False
        ElseIf num > maxValue Then
            msg = "最大値[" & maxValue & "]を超えています。"
            Return False
        End If

        convertedValue = num

        Return True
    End Function


#End Region

End Class

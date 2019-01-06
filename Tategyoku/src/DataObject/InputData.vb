Imports KComLib

Public Class InputData
    Implements KComLib.CsvInterface

    ''' <summary>登録NO (0 は未設定)</summary>
    Public Property RowId As Integer = 0
    ''' <summary>索引NO (0 は未設定)</summary>
    Public Property PairNewRowId As Integer = 0
    ''' <summary>日付</summary>
    Public Property OrderDate As Date
    ''' <summary>商品名</summary>
    Public Property Meigara As String
    ''' <summary>倍率</summary>
    Public Property Bairitu As Integer
    ''' <summary>区分</summary>
    Public Property IsNew As Boolean
    ''' <summary>限月</summary>
    Public Property Gentuki As Date
    ''' <summary>売買区別</summary>
    Public Property IsSell As Boolean
    ''' <summary>場節</summary>
    Public Property Basetu As String
    ''' <summary>発注時間</summary>
    Public Property SortTime As DateTime
    ''' <summary>枚数</summary>
    Public Property Maisu As Integer
    ''' <summary>約定値段</summary>
    Public Property YakujouNedan As Integer
    ''' <summary>取引所税</summary>
    Public Property TorihikijoZei As Long
    ''' <summary>委託手数料</summary>
    Public Property ItakuTesuuryo As Long
    ''' <summary>消費税</summary>
    Public Property ShouhiZei As Long
    ''' <summary>行使価格</summary>
    Public Property KousiKakaku As Long
    ''' <summary>メモ</summary>
    Public Property Memo As String


    '-------画面表示用項目
    Public ReadOnly Property Kubun As String
        Get
            Return IIf(IsNew, "新規", "仕切")
        End Get
    End Property

    Public ReadOnly Property UriKaiKubun As String
        Get
            Return IIf(IsSell, "売", "買")
        End Get
    End Property

    Public ReadOnly Property HiyouGoukei As Long
        Get
            Dim val As Long = TorihikijoZei + ItakuTesuuryo + ShouhiZei + KousiKakaku
            Return val
        End Get
    End Property


    Public ReadOnly Property YakujouKingaku As Long
        Get
            Dim val As Long = Maisu * YakujouNedan * Bairitu
            Return val
        End Get
    End Property

    ''' <summary>相手(仕切りの場合のみ設定可能)</summary>
    ''' <remarks>※CSV非出力項目</remarks>
    Public Property PairData As InputData

#Region "DATデータコンバート"

    Public Sub SetDataFromDATFileText(ByVal line As String)

        Dim len As Integer = 0
        Dim idx As Integer = 0
        Dim wk As String = ""

        idx += len : len = 10 : wk = KComLib.ConvertUtil.MidB(line, idx, len) : DateTime.TryParseExact(wk, "yyyy/MM/dd", C_CULTUREINFO, Nothing, OrderDate)
        idx += len : len = 10 : wk = KComLib.ConvertUtil.MidB(line, idx, len) : Meigara = wk
        idx += len : len = 7 : wk = KComLib.ConvertUtil.MidB(line, idx, len) : Integer.TryParse(wk, Bairitu)
        idx += len : len = 4 : wk = KComLib.ConvertUtil.MidB(line, idx, len) : IsNew = (wk = "新規")
        idx += len : len = 7 : wk = KComLib.ConvertUtil.MidB(line, idx, len) : DateTime.TryParseExact(wk, "yyyy/MM", C_CULTUREINFO, Nothing, Gentuki)
        idx += len : len = 2 : wk = KComLib.ConvertUtil.MidB(line, idx, len) : IsSell = (wk = "売")
        idx += len : len = 6 : wk = KComLib.ConvertUtil.MidB(line, idx, len) : Basetu = wk
        If Integer.TryParse(wk, Nothing) = True Then
            Dim dt As DateTime
            DateTime.TryParseExact(wk, "HHmmss", C_CULTUREINFO, Nothing, dt)
            Basetu = dt.ToString("HH:mm:ss")
        End If

        idx += len : len = 5 : wk = KComLib.ConvertUtil.MidB(line, idx, len) : Integer.TryParse(wk, Maisu)
        idx += len : len = 7 : wk = KComLib.ConvertUtil.MidB(line, idx, len) : Integer.TryParse(wk, YakujouNedan)
        idx += len : len = 10
        idx += len : len = 8
        idx += len : len = 5
        idx += len : len = 10
        idx += len : len = 6
        idx += len : len = 5
        idx += len : len = 7
        idx += len : len = 7
        idx += len : len = 10
        idx += len : len = 10
        idx += len : len = 10 : wk = KComLib.ConvertUtil.MidB(line, idx, len) : Long.TryParse(wk, TorihikijoZei)
        idx += len : len = 10 : wk = KComLib.ConvertUtil.MidB(line, idx, len) : Long.TryParse(wk, ItakuTesuuryo)
        idx += len : len = 10 : wk = KComLib.ConvertUtil.MidB(line, idx, len) : Long.TryParse(wk, ShouhiZei)
        idx += len : len = 10
        idx += len : len = 10 : wk = KComLib.ConvertUtil.MidB(line, idx, len) : Long.TryParse(wk, KousiKakaku)
        idx += len : len = 20 : wk = KComLib.ConvertUtil.MidB(line, idx, len) : Memo = wk
        idx += len : len = 10
        idx += len : len = 5 : wk = KComLib.ConvertUtil.MidB(line, idx, len) : Integer.TryParse(wk, RowId)
        idx += len : len = 5 : wk = KComLib.ConvertUtil.MidB(line, idx, len) : Integer.TryParse(wk, PairNewRowId)
        idx += len : len = 6
        idx += len : len = 10
        idx += len : len = 6 : wk = KComLib.ConvertUtil.MidB(line, idx, len) : DateTime.TryParseExact(wk, "HHmmss", C_CULTUREINFO, Nothing, SortTime)
        idx += len : len = 10
        idx += len : len = 10
    End Sub

#End Region
#Region "CSV内容チェック"
    Public Shared Function CheckStringArray(ByVal vals As String()) As List(Of String)
        Dim errMsg As New List(Of String)

        Dim i As Integer = -1
        i += 1 'RowId
        If vals(i).Trim.Length > 0 AndAlso vals(i).Trim < "0" Then
            CheckNumber(i, errMsg, vals(i), 1, C_MAXDATA_COUNT * 10)
        End If

        i += 1 'PairNewRowId
        If vals(i).Trim.Length > 0 AndAlso vals(i).Trim < "0" Then
            CheckNumber(i, errMsg, vals(i), 1, C_MAXDATA_COUNT * 10)
        End If

        i += 1 'OrderDate
        CheckRequired(i, errMsg, vals(i))

        'i += 1 : Me.SortTime = DateTime.ParseExact(vals(i).PadLeft(6, "0"), "HHmmss", C_CULTUREINFO)
        'i += 1 : Me.Basetu = vals(i)
        'i += 1 : Me.Brand = vals(i)
        'i += 1 : Me.Magnification = Integer.Parse(vals(i))
        'i += 1 : Me.IsNew = (vals(i) = "新規")
        'i += 1 : Me.ContractMonth = DateTime.ParseExact(vals(i), "yyyyMM", C_CULTUREINFO)
        'i += 1 : Me.IsSell = (vals(i) = "売")
        'i += 1 : Me.OrderCount = Integer.Parse(vals(i))
        'i += 1 : Me.ContractPrice = Integer.Parse(vals(i))
        'i += 1 : Me.TransactionTax = Long.Parse(vals(i))
        'i += 1 : Me.Commision = Long.Parse(vals(i))
        'i += 1 : Me.ConsumptionTax = Long.Parse(vals(i))
        'i += 1 : Me.StrikePrice = Long.Parse(vals(i))

        Return errMsg
    End Function

    Private Shared Function CheckRequired(ByVal dataIdx As Integer, ByVal errMsg As List(Of String), ByVal input As String)
        If FormatCheck.CheckIsNotBlank(input, Nothing) = False Then
            errMsg.Add(String.Format("[{0}:{1}]必須入力項目です。", dataIdx, CsvHeaders(dataIdx)))
            Return False
        End If
        Return True
    End Function
    Private Shared Function CheckNumber(ByVal dataIdx As Integer, ByVal errMsg As List(Of String),
                                 ByVal input As String, ByVal minValue As Long, ByVal maxValue As Long) As Boolean

        If FormatCheck.CheckIsNotBlank(input, Nothing) = True Then

            Dim msg As String = ""
            Dim value As Long = -1
            If FormatCheck.CheckNum(input, minValue, maxValue, msg, value) = False Then
                errMsg.Add(String.Format("[{0}:{1}]{2}  -入力値=[{3}]", dataIdx, CsvHeaders(dataIdx), msg, input))
                Return False
            End If
        End If

        Return True
    End Function


#End Region
#Region "CSV出力(CsvOutInterface)"

    ''' <summary>CSVヘッダ</summary>
    Public Shared ReadOnly CsvHeaders As String() =
    {"登録NO", "索引NO", "日付", "発注時刻", "場節", "商品名", "倍率", "区分", "限月", "売買区別",
        "枚数", "約定値段", "取引所税", "委託手数料", "消費税", "行使価格", "メモ"}

    ''' <summary>CSVヘッダ</summary>
    Public Shared ReadOnly DataNames As String() =
    {"RowId", "PairNewRowId", "OrderDate", "SortTime", "Basetu",
    "Meigara", "Bairitu", "IsNew", "Gentuki", "IsSell", "Maisu", "YakujouNedan",
    "TorihikijoZei", "ItakuTesuuryo", "ShouhiZei", "KousiKakaku", "Memo"}

    Public Property OutCsvPath As String Implements CsvInterface.OutCsvPath

    Public Function GetCsvHeaders(ByVal Optional version As Integer = 0) As IEnumerable(Of String) Implements CsvInterface.GetCsvHeaders
        Return CsvHeaders
    End Function

    ''' <summary>
    ''' CSV出力用にString配列に変換
    ''' </summary>
    Public Function ObjToStringArray(ByVal Optional version As Integer = 0) As IEnumerable(Of String) Implements CsvInterface.ObjToStringArray

        Dim arr As New List(Of String)

        arr.Add(RowId)
        arr.Add(PairNewRowId)
        arr.Add(Me.OrderDate.ToString("yyyyMMdd"))
        arr.Add(SortTime.ToString("HHmmss"))
        arr.Add(Basetu)
        arr.Add(Meigara)
        arr.Add(Bairitu)
        arr.Add(Kubun)
        arr.Add(Gentuki.ToString("yyyyMM"))
        arr.Add(UriKaiKubun)
        arr.Add(Maisu)
        arr.Add(YakujouNedan)
        arr.Add(TorihikijoZei)
        arr.Add(ItakuTesuuryo)
        arr.Add(ShouhiZei)
        arr.Add(KousiKakaku)
        arr.Add(Memo)
        Return arr.ToArray()
    End Function




    Public Sub StringArrayToObj(ByVal vals As String()) Implements CsvInterface.StringArrayToObj

        Dim i As Integer = -1
        i += 1 : Me.RowId = Integer.Parse(vals(i))
        i += 1 : Me.PairNewRowId = Integer.Parse(vals(i))
        i += 1 : Me.OrderDate = DateTime.ParseExact(vals(i), "yyyyMMdd", C_CULTUREINFO)
        i += 1 : Me.SortTime = DateTime.ParseExact(vals(i).PadLeft(6, "0"), "HHmmss", C_CULTUREINFO)
        i += 1 : Me.Basetu = vals(i)
        i += 1 : Me.Meigara = vals(i)
        i += 1 : Me.Bairitu = Integer.Parse(vals(i))
        i += 1 : Me.IsNew = (vals(i) = "新規")
        i += 1 : Me.Gentuki = DateTime.ParseExact(vals(i), "yyyyMM", C_CULTUREINFO)
        i += 1 : Me.IsSell = (vals(i) = "売")
        i += 1 : Me.Maisu = Integer.Parse(vals(i))
        i += 1 : Me.YakujouNedan = Integer.Parse(vals(i))
        i += 1 : Me.TorihikijoZei = Long.Parse(vals(i))
        i += 1 : Me.ItakuTesuuryo = Long.Parse(vals(i))
        i += 1 : Me.ShouhiZei = Long.Parse(vals(i))
        i += 1 : Me.KousiKakaku = Long.Parse(vals(i))
        i += 1 : Me.Memo = vals(i)
    End Sub

#End Region


    Public Overrides Function ToString() As String
        Dim sb As New Text.StringBuilder

        sb.AppendFormat("{0}-{1} {2}{3}[{4}/{5}] {6:yy/MM/dd} {7:HH:mm:ss} {8}",
                            RowId,
                            IIf(PairNewRowId >= 0, PairNewRowId.ToString, ""),
                            IIf(IsNew, "新", "仕"),
                            IIf(IsSell, "売", "買"),
                            Meigara.Substring(0, Math.Min(6, Meigara.Length)),
                            Gentuki,
                            OrderDate,
                            SortTime,
                            Basetu)
        Return sb.ToString
    End Function

    ''' <summary>クローン</summary>
    Public Function Clone() As Object Implements ICloneable.Clone
        Dim aCopy As InputData = CType(MemberwiseClone(), InputData)

        Return aCopy
    End Function



End Class

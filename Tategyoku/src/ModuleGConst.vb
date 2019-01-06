''' <summary>
''' グローバル定数 / コード(ENUM)定義
''' </summary>
Public Module ModuleGConst

    Public Const C_DATETIME_FORMAT As String = "yyyy/MM/dd HH:mm:ss"
    Public ReadOnly C_CULTUREINFO As Globalization.CultureInfo = New Globalization.CultureInfo("ja-JP")
    Public ReadOnly C_SYSTEM_ENCODING As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift-JIS")

    Public Const C_MAXDATA_COUNT As Integer = 10000

    Public G_Ini As IniFile

End Module
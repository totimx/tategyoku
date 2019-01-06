<Serializable()>
Public Class IniFile

    <Serializable()>
    Public Structure DirSettings
        Dim DataRoot As String
        Dim LogRoot As String
        Dim UserPref As String
    End Structure


    ''' <summary>ディレクトリ設定</summary>
    Public Property DIRS As DirSettings


    ''' <summary>クローン</summary>
    Public Function Clone() As IniFile
        Dim aCopy As IniFile = CType(MemberwiseClone(), IniFile)
        Return aCopy
    End Function

End Class
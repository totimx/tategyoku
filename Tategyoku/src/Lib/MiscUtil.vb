Public Class MiscUtil
    Public Shared Function LoadCsv(Of T As {New, CsvInterface})(ByVal path As String, Optional ByVal almWhenFileNotFound As Boolean = True) As List(Of T)

        Dim row As Integer = -1
        Try
            Dim objList As New List(Of T)
            Dim fldLists As List(Of String()) = CsvFileIO.ReadCsv(path, C_SYSTEM_ENCODING)

            If fldLists Is Nothing Then Return Nothing

            For row = 1 To fldLists.Count - 1
                Dim flds As String() = fldLists(row)
                Dim obj As New T()
                obj.StringArrayToObj(flds)
                objList.Add(obj)
            Next

            Return objList

        Catch ex As Exception
            AlmLog.Instance.Out(Alms.Id.FileReadErr, "CSVファイル読込み失敗", "path=" & path, "row=" & row, method:=Reflection.MethodInfo.GetCurrentMethod)
            Throw
        End Try

    End Function
End Class

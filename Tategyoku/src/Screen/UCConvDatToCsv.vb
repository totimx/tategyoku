Public Class UCConvDatToCsv
    Private Sub TxtDatPath_DragEnter(sender As Object, e As DragEventArgs) Handles TxtDatPath.DragEnter
        'コントロール内にドラッグされたとき実行される
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            'ドラッグされたデータ形式を調べ、ファイルのときはコピーとする
            e.Effect = DragDropEffects.Copy
        Else
            'ファイル以外は受け付けない
            e.Effect = DragDropEffects.None
        End If

    End Sub

    Private Sub TxtDatPath_DragDrop(sender As Object, e As DragEventArgs) Handles TxtDatPath.DragDrop
        Dim fileNames As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())
        TxtDatPath.Text = fileNames(0)
        TxtCsvPath.Text = fileNames(0).Replace(".dat", ".csv").Replace(".DAT", ".csv")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim inTxt As String() = IO.File.ReadAllLines(TxtDatPath.Text, C_SYSTEM_ENCODING)
        Dim inDataList As New List(Of InputData)

        For Each line In inTxt
            Dim inData As New InputData
            inData.SetDataFromDATFileText(line)
            inDataList.Add(inData)
        Next

        CreateCsv(TxtCsvPath.Text, inDataList.ToArray())

    End Sub

    ''' <summary>
    ''' CSVファイル出力
    ''' </summary>
    ''' <param name="path">ファイル名</param>
    ''' <param name="orgDatas">出力元データ</param>
    Public Shared Sub CreateCsv(ByVal path As String, ByVal orgDatas As CsvInterface())

        If orgDatas Is Nothing Then
            AlmLog.Instance.Out(Alms.Id.FileWriteWar, "オブジェクトが存在しないため保存できません", path, method:=Reflection.MethodInfo.GetCurrentMethod)
            Return
        ElseIf orgDatas.Length = 0 Then
            AlmLog.Instance.Out(Alms.Id.FileWriteWar, "出力データが０件です", path, method:=Reflection.MethodInfo.GetCurrentMethod)
            Return
        ElseIf orgDatas(0) Is Nothing Then
            AlmLog.Instance.Out(Alms.Id.FileWriteWar, "オブジェクトが存在しないため保存できません", path, method:=Reflection.MethodInfo.GetCurrentMethod)
            Return
        End If
        Using sw As New IO.StreamWriter(path, append:=False, encoding:=C_SYSTEM_ENCODING)
            'ヘッダ出力(初回のみ)
            Dim flds As IEnumerable(Of String) = orgDatas(0).GetCsvHeaders
            sw.WriteLine(CsvFileIO.ToCsvString(flds, useQuote:=True))

            'エントリー書出し
            For Each row In orgDatas
                flds = row.ObjToStringArray()
                sw.WriteLine(CsvFileIO.ToCsvString(flds, useQuote:=False))
            Next
        End Using

    End Sub


End Class

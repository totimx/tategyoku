Public Class UCInputList

    Private _filePath As String

    Private _inputList As List(Of InputData)


    Private Sub UCInputList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupDgv1()
        Me.Dgv1.Visible = False
        Me.PnlErr.Dock = DockStyle.Fill
        Me.PnlErr.BringToFront()
        Me.PnlErr.Visible = False
    End Sub

    Private Sub SetupDgv1()
        Dim headerStr As String() = InputData.CsvHeaders
        Dim colNames As String() = InputData.DataNames
        Dim colWidth As Integer() = {45, 45, 90, 54, 54, 90, 63, 36, 63, 18, 45, 63, 90, 90, 90, 90, 180}

        With Me.Dgv1
            'カラム初期化
            For i As Integer = 0 To headerStr.Length - 1
                Dim colIdx = .Columns.Add(colNames(i), headerStr(i))
                .Columns(colIdx).Width = colWidth(i)

                Select Case colIdx
                    Case 2 : .Columns(colIdx).DefaultCellStyle.Format = "yyyy/MM/dd"
                    Case 3 : .Columns(colIdx).DefaultCellStyle.Format = "HH:mm:ss"
                    Case 8 : .Columns(colIdx).DefaultCellStyle.Format = "yyyy/MM"
                    Case 0, 1, 4, 5, 6, 7, 9 : .Columns(colIdx).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Case 10, 11, 12, 13, 14, 15
                        .Columns(colIdx).DefaultCellStyle.Format = "#,0"
                        .Columns(colIdx).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Case 16 : .Columns(colIdx).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End Select
            Next

            Dim newCol As New DataGridViewTextBoxColumn() With {.Name = "CsvRow", .HeaderText = "行", .Width = 45}
            .Columns.Insert(0, newCol)
        End With

    End Sub

    Public Sub OpenFile(ByVal filePath As String)

        Me.Dgv1.Visible = False
        Me.PnlErr.Visible = False


        'ファイル妥当性チェック
        Dim errMsg As String = CheckCSVFile(filePath)
        If errMsg.Length > 0 Then
            LblErrInfo.Text = errMsg
            Me.PnlErr.Visible = True

            Return  '//-------
        End If

        '入力データとして読込み
        Me._inputList = MiscUtil.LoadCsv(Of InputData)(filePath)

        'データグリッドに読込み
        BindDataToDgv1(Me._inputList)
        Me.Dgv1.Visible = True

    End Sub

    Private Sub BindDataToDgv1(ByVal indatList As List(Of InputData))

        Me.Dgv1.Rows.Clear()

        For Each indat In indatList
            Dim row As Integer = Me.Dgv1.Rows.Add

            Me.Dgv1("CsvRow", row).Value = row
            Me.Dgv1("RowId", row).Value = indat.RowId
            Me.Dgv1("PairNewRowId", row).Value = indat.PairNewRowId
            Me.Dgv1("OrderDate", row).Value = indat.OrderDate
            Me.Dgv1("SortTime", row).Value = indat.SortTime
            Me.Dgv1("Basetu", row).Value = indat.Basetu
            Me.Dgv1("Meigara", row).Value = indat.Meigara
            Me.Dgv1("Bairitu", row).Value = indat.Bairitu
            Me.Dgv1("IsNew", row).Value = indat.Kubun
            Me.Dgv1("Gentuki", row).Value = indat.Gentuki
            Me.Dgv1("IsSell", row).Value = indat.UriKaiKubun
            Me.Dgv1("Maisu", row).Value = indat.Maisu
            Me.Dgv1("YakujouNedan", row).Value = indat.YakujouNedan
            Me.Dgv1("TorihikijoZei", row).Value = indat.TorihikijoZei
            Me.Dgv1("ItakuTesuuryo", row).Value = indat.ItakuTesuuryo
            Me.Dgv1("ShouhiZei", row).Value = indat.ShouhiZei
            Me.Dgv1("KousiKakaku", row).Value = indat.KousiKakaku
            Me.Dgv1("Memo", row).Value = indat.Memo
        Next
    End Sub


    Private Function CheckCSVFile(ByVal filePath As String) As String

        Dim ttlMsg As New Text.StringBuilder

        If IO.File.Exists(filePath) = False Then
            ttlMsg.Append("ファイルが存在しません。")
            Return ttlMsg.ToString    '//-----------
        End If

        Me._filePath = filePath
        Dim lines As List(Of String()) = CsvFileIO.ReadCsv(filePath, C_SYSTEM_ENCODING)

        For i As Integer = 1 To lines.Count - 1 '先頭行はヘッダ
            Dim errMsg As List(Of String) = InputData.CheckStringArray(lines(i))

            If errMsg.Count > 0 Then
                ttlMsg.AppendFormat("----{0} 行目にエラーがあります。", i)
                For Each emsg In errMsg
                    ttlMsg.Append("   ")
                    ttlMsg.AppendLine(emsg)
                Next
                ttlMsg.AppendLine()
            End If
        Next

        Return ttlMsg.ToString

    End Function

End Class

Imports KComLib

Public Class MainForm

    Private _scrnInputList As UCInputList
    Private _scrnConvDatToCsv As UCConvDatToCsv


    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '****************************************************************
        'INIファイル読み込み
        '****************************************************************
        '読込み先決定
        Dim iniFileDir As New IO.DirectoryInfo(My.Application.Info.DirectoryPath & "\Ini")   '実行ファイルカレントパス

        '指定した Iniディレクトリが存在しない場合は、Iniディレクトリパスを探す。
        If iniFileDir.Exists = False Then
            iniFileDir = New IO.DirectoryInfo("..\..\..\Ini")   'AppConfig読込
        End If

        '設定ファイル読込
        G_Ini = New IniFile
        XmlReadWrite.Load(iniFileDir.FullName, G_Ini)


        '****************************************************************
        'アラームログ開始
        '****************************************************************
        AlmLog.Initialize(G_Ini.DIRS.LogRoot & "\" & System.Reflection.Assembly.GetExecutingAssembly().GetName.Name)
        AlmLog.Instance.StartThread()


    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click

        If Me._scrnConvDatToCsv Is Nothing Then
            Me._scrnConvDatToCsv = New UCConvDatToCsv
            Me.PnlMain.Controls.Add(Me._scrnConvDatToCsv)
            Me._scrnConvDatToCsv.Dock = DockStyle.Fill
        End If
        Me._scrnConvDatToCsv.BringToFront()

        Me.Text = "健玉分析"

    End Sub

    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem5.Click

        '----ファイルオープン
        Dim ofd As New OpenFileDialog()

        'はじめに表示されるフォルダを指定する
        '指定しない（空の文字列）の時は、現在のディレクトリが表示される
        ofd.InitialDirectory = G_Ini.DIRS.DataRoot
        ofd.Filter = "CSVファイル(*.csv)|*.csv|すべてのファイル(*.*)|*.*"
        ofd.FilterIndex = 1
        ofd.Title = "開くファイルを選択してください"
        ofd.RestoreDirectory = True

        'ファイルオープンダイアログを表示する
        If ofd.ShowDialog() <> DialogResult.OK Then
            Return      '//---------
        End If

        Me.Text = "健玉分析 - " & ofd.FileName


        '----画面表示
        If Me._scrnInputList Is Nothing Then
            Me._scrnInputList = New UCInputList
            Me.PnlMain.Controls.Add(Me._scrnInputList)
            Me._scrnInputList.Dock = DockStyle.Fill
        End If
        Me._scrnInputList.OpenFile(ofd.FileName)
        Me._scrnInputList.BringToFront()

    End Sub
End Class

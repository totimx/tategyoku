<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCConvDatToCsv
    Inherits System.Windows.Forms.UserControl

    'UserControl はコンポーネント一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtCsvPath = New System.Windows.Forms.TextBox()
        Me.TxtDatPath = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Meiryo UI", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button1.Location = New System.Drawing.Point(680, 176)
        Me.Button1.Margin = New System.Windows.Forms.Padding(7, 9, 7, 9)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(175, 72)
        Me.Button1.TabIndex = 14
        Me.Button1.Text = "変換"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Meiryo UI", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(30, 111)
        Me.Label2.Margin = New System.Windows.Forms.Padding(7, 0, 7, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(148, 25)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "出力CSVファイル"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Meiryo UI", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(30, 41)
        Me.Label1.Margin = New System.Windows.Forms.Padding(7, 0, 7, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(149, 25)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "入力DATファイル"
        '
        'TxtCsvPath
        '
        Me.TxtCsvPath.Font = New System.Drawing.Font("Meiryo UI", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtCsvPath.Location = New System.Drawing.Point(247, 100)
        Me.TxtCsvPath.Margin = New System.Windows.Forms.Padding(7, 9, 7, 9)
        Me.TxtCsvPath.Name = "TxtCsvPath"
        Me.TxtCsvPath.Size = New System.Drawing.Size(608, 33)
        Me.TxtCsvPath.TabIndex = 11
        '
        'TxtDatPath
        '
        Me.TxtDatPath.AllowDrop = True
        Me.TxtDatPath.Font = New System.Drawing.Font("Meiryo UI", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtDatPath.Location = New System.Drawing.Point(247, 33)
        Me.TxtDatPath.Margin = New System.Windows.Forms.Padding(7, 9, 7, 9)
        Me.TxtDatPath.Name = "TxtDatPath"
        Me.TxtDatPath.Size = New System.Drawing.Size(608, 33)
        Me.TxtDatPath.TabIndex = 10
        '
        'UCConvDatToCsv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtCsvPath)
        Me.Controls.Add(Me.TxtDatPath)
        Me.Font = New System.Drawing.Font("メイリオ", 9.0!)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "UCConvDatToCsv"
        Me.Size = New System.Drawing.Size(879, 279)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TxtCsvPath As TextBox
    Friend WithEvents TxtDatPath As TextBox
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UCInputList
    Inherits System.Windows.Forms.UserControl

    'UserControl はコンポーネント一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Dgv1 = New System.Windows.Forms.DataGridView()
        Me.PnlErr = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblErrInfo = New System.Windows.Forms.Label()
        CType(Me.Dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlErr.SuspendLayout()
        Me.SuspendLayout()
        '
        'Dgv1
        '
        Me.Dgv1.AllowDrop = True
        Me.Dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv1.Location = New System.Drawing.Point(0, 0)
        Me.Dgv1.Name = "Dgv1"
        Me.Dgv1.RowTemplate.Height = 21
        Me.Dgv1.Size = New System.Drawing.Size(1057, 655)
        Me.Dgv1.TabIndex = 0
        '
        'PnlErr
        '
        Me.PnlErr.AutoScroll = True
        Me.PnlErr.BackColor = System.Drawing.Color.OldLace
        Me.PnlErr.Controls.Add(Me.LblErrInfo)
        Me.PnlErr.Controls.Add(Me.Label1)
        Me.PnlErr.Location = New System.Drawing.Point(10, 13)
        Me.PnlErr.Name = "PnlErr"
        Me.PnlErr.Size = New System.Drawing.Size(200, 100)
        Me.PnlErr.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(10, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ファイル読込みエラー"
        '
        'LblErrInfo
        '
        Me.LblErrInfo.AutoSize = True
        Me.LblErrInfo.ForeColor = System.Drawing.Color.Black
        Me.LblErrInfo.Location = New System.Drawing.Point(10, 41)
        Me.LblErrInfo.Name = "LblErrInfo"
        Me.LblErrInfo.Size = New System.Drawing.Size(68, 18)
        Me.LblErrInfo.TabIndex = 0
        Me.LblErrInfo.Text = "エラー詳細"
        '
        'UCInputList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PnlErr)
        Me.Controls.Add(Me.Dgv1)
        Me.Font = New System.Drawing.Font("メイリオ", 9.0!)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "UCInputList"
        Me.Size = New System.Drawing.Size(1057, 655)
        CType(Me.Dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlErr.ResumeLayout(False)
        Me.PnlErr.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Dgv1 As DataGridView
    Friend WithEvents PnlErr As Panel
    Friend WithEvents LblErrInfo As Label
    Friend WithEvents Label1 As Label
End Class

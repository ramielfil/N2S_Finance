<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class N2S_CalEcr
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.TileBar1 = New DevExpress.XtraBars.Navigation.TileBar()
        Me.GridCalcul = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.GridCalcul, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TileBar1
        '
        Me.TileBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TileBar1.DropDownOptions.BeakColor = System.Drawing.Color.Empty
        Me.TileBar1.Location = New System.Drawing.Point(0, 0)
        Me.TileBar1.Name = "TileBar1"
        Me.TileBar1.ScrollMode = DevExpress.XtraEditors.TileControlScrollMode.ScrollButtons
        Me.TileBar1.Size = New System.Drawing.Size(800, 450)
        Me.TileBar1.TabIndex = 0
        Me.TileBar1.Text = "TileBar1"
        '
        'GridCalcul
        '
        Me.GridCalcul.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridCalcul.Location = New System.Drawing.Point(0, 0)
        Me.GridCalcul.MainView = Me.GridView1
        Me.GridCalcul.Name = "GridCalcul"
        Me.GridCalcul.Size = New System.Drawing.Size(800, 450)
        Me.GridCalcul.TabIndex = 1
        Me.GridCalcul.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridCalcul
        Me.GridView1.Name = "GridView1"
        '
        'N2S_CalEcr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.GridCalcul)
        Me.Controls.Add(Me.TileBar1)
        Me.Name = "N2S_CalEcr"
        Me.Text = "N2S_Calcul"
        CType(Me.GridCalcul, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TileBar1 As DevExpress.XtraBars.Navigation.TileBar
    Friend WithEvents GridCalcul As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
End Class

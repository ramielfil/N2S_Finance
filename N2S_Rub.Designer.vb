<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class N2S_Rub
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(N2S_Rub))
        Me.TileBar1 = New DevExpress.XtraBars.Navigation.TileBar()
        Me.TileBar2 = New DevExpress.XtraBars.Navigation.TileBar()
        Me.GridRubriques = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.C_Rub = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.C_Type = New System.Windows.Forms.ComboBox()
        Me.C_Content = New DevExpress.XtraEditors.TextEdit()
        Me.T_Contenu = New DevExpress.XtraEditors.LabelControl()
        Me.T_Type = New DevExpress.XtraEditors.LabelControl()
        Me.BTN_V01 = New DevExpress.XtraEditors.SimpleButton()
        Me.BTN_V02 = New DevExpress.XtraEditors.SimpleButton()
        Me.BTN_V03 = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.GridRubriques, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C_Rub.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C_Content.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TileBar1
        '
        Me.TileBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TileBar1.DropDownOptions.BeakColor = System.Drawing.Color.Empty
        Me.TileBar1.Location = New System.Drawing.Point(0, 0)
        Me.TileBar1.Name = "TileBar1"
        Me.TileBar1.ScrollMode = DevExpress.XtraEditors.TileControlScrollMode.ScrollButtons
        Me.TileBar1.Size = New System.Drawing.Size(800, 150)
        Me.TileBar1.TabIndex = 0
        Me.TileBar1.Text = "TileBar1"
        '
        'TileBar2
        '
        Me.TileBar2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TileBar2.DropDownOptions.BeakColor = System.Drawing.Color.Empty
        Me.TileBar2.Location = New System.Drawing.Point(0, 150)
        Me.TileBar2.Name = "TileBar2"
        Me.TileBar2.ScrollMode = DevExpress.XtraEditors.TileControlScrollMode.ScrollButtons
        Me.TileBar2.Size = New System.Drawing.Size(800, 300)
        Me.TileBar2.TabIndex = 1
        Me.TileBar2.Text = "TileBar2"
        '
        'GridRubriques
        '
        Me.GridRubriques.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridRubriques.Location = New System.Drawing.Point(0, 150)
        Me.GridRubriques.MainView = Me.GridView1
        Me.GridRubriques.Name = "GridRubriques"
        Me.GridRubriques.Size = New System.Drawing.Size(800, 300)
        Me.GridRubriques.TabIndex = 2
        Me.GridRubriques.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridRubriques
        Me.GridView1.Name = "GridView1"
        '
        'C_Rub
        '
        Me.C_Rub.Location = New System.Drawing.Point(76, 18)
        Me.C_Rub.Name = "C_Rub"
        Me.C_Rub.Size = New System.Drawing.Size(125, 22)
        Me.C_Rub.TabIndex = 18
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.Location = New System.Drawing.Point(12, 20)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(52, 16)
        Me.LabelControl1.TabIndex = 17
        Me.LabelControl1.Text = "Rubrique"
        '
        'C_Type
        '
        Me.C_Type.FormattingEnabled = True
        Me.C_Type.Items.AddRange(New Object() {""})
        Me.C_Type.Location = New System.Drawing.Point(265, 16)
        Me.C_Type.Name = "C_Type"
        Me.C_Type.Size = New System.Drawing.Size(121, 24)
        Me.C_Type.TabIndex = 19
        '
        'C_Content
        '
        Me.C_Content.Location = New System.Drawing.Point(470, 18)
        Me.C_Content.Name = "C_Content"
        Me.C_Content.Size = New System.Drawing.Size(125, 22)
        Me.C_Content.TabIndex = 21
        '
        'T_Contenu
        '
        Me.T_Contenu.Appearance.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.T_Contenu.Appearance.Options.UseFont = True
        Me.T_Contenu.Location = New System.Drawing.Point(404, 20)
        Me.T_Contenu.Name = "T_Contenu"
        Me.T_Contenu.Size = New System.Drawing.Size(48, 16)
        Me.T_Contenu.TabIndex = 20
        Me.T_Contenu.Text = "Contenu"
        '
        'T_Type
        '
        Me.T_Type.Appearance.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.T_Type.Appearance.Options.UseFont = True
        Me.T_Type.Location = New System.Drawing.Point(220, 20)
        Me.T_Type.Name = "T_Type"
        Me.T_Type.Size = New System.Drawing.Size(28, 16)
        Me.T_Type.TabIndex = 22
        Me.T_Type.Text = "Type"
        '
        'BTN_V01
        '
        Me.BTN_V01.ImageOptions.Image = CType(resources.GetObject("BTN_V01.ImageOptions.Image"), System.Drawing.Image)
        Me.BTN_V01.Location = New System.Drawing.Point(662, 12)
        Me.BTN_V01.Name = "BTN_V01"
        Me.BTN_V01.Size = New System.Drawing.Size(103, 29)
        Me.BTN_V01.TabIndex = 23
        Me.BTN_V01.Text = "Ajouter"
        '
        'BTN_V02
        '
        Me.BTN_V02.ImageOptions.Image = CType(resources.GetObject("BTN_V02.ImageOptions.Image"), System.Drawing.Image)
        Me.BTN_V02.Location = New System.Drawing.Point(662, 48)
        Me.BTN_V02.Name = "BTN_V02"
        Me.BTN_V02.Size = New System.Drawing.Size(103, 29)
        Me.BTN_V02.TabIndex = 24
        Me.BTN_V02.Text = "Modifier"
        '
        'BTN_V03
        '
        Me.BTN_V03.ImageOptions.Image = CType(resources.GetObject("BTN_V03.ImageOptions.Image"), System.Drawing.Image)
        Me.BTN_V03.Location = New System.Drawing.Point(662, 84)
        Me.BTN_V03.Name = "BTN_V03"
        Me.BTN_V03.Size = New System.Drawing.Size(103, 29)
        Me.BTN_V03.TabIndex = 25
        Me.BTN_V03.Text = "Supprimer"
        '
        'N2S_Rub
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.BTN_V03)
        Me.Controls.Add(Me.BTN_V02)
        Me.Controls.Add(Me.BTN_V01)
        Me.Controls.Add(Me.T_Type)
        Me.Controls.Add(Me.C_Content)
        Me.Controls.Add(Me.T_Contenu)
        Me.Controls.Add(Me.C_Type)
        Me.Controls.Add(Me.C_Rub)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.GridRubriques)
        Me.Controls.Add(Me.TileBar2)
        Me.Controls.Add(Me.TileBar1)
        Me.Name = "N2S_Rub"
        Me.Text = "Liste Rubrique"
        CType(Me.GridRubriques, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C_Rub.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C_Content.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TileBar1 As DevExpress.XtraBars.Navigation.TileBar
    Friend WithEvents TileBar2 As DevExpress.XtraBars.Navigation.TileBar
    Friend WithEvents GridRubriques As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents C_Rub As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents C_Content As DevExpress.XtraEditors.TextEdit
    Friend WithEvents T_Contenu As DevExpress.XtraEditors.LabelControl
    Friend WithEvents T_Type As DevExpress.XtraEditors.LabelControl
    Friend WithEvents C_Type As ComboBox
    Friend WithEvents BTN_V01 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BTN_V02 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BTN_V03 As DevExpress.XtraEditors.SimpleButton
End Class

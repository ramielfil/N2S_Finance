<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class N2S_JnlM
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(N2S_JnlM))
        Me.TileBar1 = New DevExpress.XtraBars.Navigation.TileBar()
        Me.TileBar2 = New DevExpress.XtraBars.Navigation.TileBar()
        Me.GridJournaux = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.C_JNL = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.C_PERIODE = New DevExpress.XtraEditors.DateEdit()
        Me.BTN_V03 = New DevExpress.XtraEditors.SimpleButton()
        Me.BTN_V02 = New DevExpress.XtraEditors.SimpleButton()
        Me.BTN_V01 = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.GridJournaux, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C_JNL.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C_PERIODE.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C_PERIODE.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'GridJournaux
        '
        Me.GridJournaux.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridJournaux.Location = New System.Drawing.Point(0, 150)
        Me.GridJournaux.MainView = Me.GridView1
        Me.GridJournaux.Name = "GridJournaux"
        Me.GridJournaux.Size = New System.Drawing.Size(800, 300)
        Me.GridJournaux.TabIndex = 2
        Me.GridJournaux.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridJournaux
        Me.GridView1.Name = "GridView1"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.Location = New System.Drawing.Point(12, 32)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(43, 16)
        Me.LabelControl1.TabIndex = 18
        Me.LabelControl1.Text = "Journal"
        '
        'C_JNL
        '
        Me.C_JNL.Location = New System.Drawing.Point(66, 29)
        Me.C_JNL.Name = "C_JNL"
        Me.C_JNL.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.C_JNL.Size = New System.Drawing.Size(171, 22)
        Me.C_JNL.TabIndex = 19
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Appearance.Options.UseFont = True
        Me.LabelControl2.Location = New System.Drawing.Point(251, 32)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(44, 16)
        Me.LabelControl2.TabIndex = 20
        Me.LabelControl2.Text = "Période"
        '
        'C_PERIODE
        '
        Me.C_PERIODE.EditValue = Nothing
        Me.C_PERIODE.Location = New System.Drawing.Point(305, 29)
        Me.C_PERIODE.Name = "C_PERIODE"
        Me.C_PERIODE.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.C_PERIODE.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.C_PERIODE.Size = New System.Drawing.Size(125, 22)
        Me.C_PERIODE.TabIndex = 21
        '
        'BTN_V03
        '
        Me.BTN_V03.ImageOptions.Image = CType(resources.GetObject("BTN_V03.ImageOptions.Image"), System.Drawing.Image)
        Me.BTN_V03.Location = New System.Drawing.Point(685, 91)
        Me.BTN_V03.Name = "BTN_V03"
        Me.BTN_V03.Size = New System.Drawing.Size(103, 29)
        Me.BTN_V03.TabIndex = 28
        Me.BTN_V03.Text = "Supprimer"
        '
        'BTN_V02
        '
        Me.BTN_V02.ImageOptions.Image = CType(resources.GetObject("BTN_V02.ImageOptions.Image"), System.Drawing.Image)
        Me.BTN_V02.Location = New System.Drawing.Point(685, 55)
        Me.BTN_V02.Name = "BTN_V02"
        Me.BTN_V02.Size = New System.Drawing.Size(103, 29)
        Me.BTN_V02.TabIndex = 27
        Me.BTN_V02.Text = "Modifier"
        '
        'BTN_V01
        '
        Me.BTN_V01.ImageOptions.Image = CType(resources.GetObject("BTN_V01.ImageOptions.Image"), System.Drawing.Image)
        Me.BTN_V01.Location = New System.Drawing.Point(685, 19)
        Me.BTN_V01.Name = "BTN_V01"
        Me.BTN_V01.Size = New System.Drawing.Size(103, 29)
        Me.BTN_V01.TabIndex = 26
        Me.BTN_V01.Text = "Ajouter"
        '
        'N2S_JnlM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.BTN_V03)
        Me.Controls.Add(Me.BTN_V02)
        Me.Controls.Add(Me.BTN_V01)
        Me.Controls.Add(Me.C_PERIODE)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.C_JNL)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.GridJournaux)
        Me.Controls.Add(Me.TileBar2)
        Me.Controls.Add(Me.TileBar1)
        Me.Name = "N2S_JnlM"
        Me.Text = "NS_JnlM"
        CType(Me.GridJournaux, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C_JNL.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C_PERIODE.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C_PERIODE.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TileBar1 As DevExpress.XtraBars.Navigation.TileBar
    Friend WithEvents TileBar2 As DevExpress.XtraBars.Navigation.TileBar
    Friend WithEvents GridJournaux As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents C_JNL As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents C_PERIODE As DevExpress.XtraEditors.DateEdit
    Friend WithEvents BTN_V03 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BTN_V02 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BTN_V01 As DevExpress.XtraEditors.SimpleButton
End Class

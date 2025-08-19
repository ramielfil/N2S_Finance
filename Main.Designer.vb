Partial Public Class Main
    Inherits DevExpress.XtraBars.Ribbon.RibbonForm

    ''' <summary>
    ''' Required designer variable.
    ''' </summary>
    Private components As System.ComponentModel.IContainer = Nothing

    ''' <summary>
    ''' Clean up any resources being used.
    ''' </summary>
    ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso (components IsNot Nothing) Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

#Region "Windows Form Designer generated code"

    ''' <summary>
    ''' Required method for Designer support - do not modify
    ''' the contents of this method with the code editor.
    ''' </summary>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.ribbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem2 = New DevExpress.XtraBars.BarButtonItem()
        Me.ribbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.N2S_Parametrage = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        CType(Me.ribbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ribbonControl1
        '
        Me.ribbonControl1.EmptyAreaImageOptions.ImagePadding = New System.Windows.Forms.Padding(35, 37, 35, 37)
        Me.ribbonControl1.ExpandCollapseItem.Id = 0
        Me.ribbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.ribbonControl1.ExpandCollapseItem, Me.ribbonControl1.SearchEditItem, Me.BarButtonItem1, Me.BarButtonItem2})
        Me.ribbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.ribbonControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.ribbonControl1.MaxItemId = 3
        Me.ribbonControl1.Name = "ribbonControl1"
        Me.ribbonControl1.OptionsMenuMinWidth = 385
        Me.ribbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.ribbonPage1})
        Me.ribbonControl1.Size = New System.Drawing.Size(884, 193)
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "Rubrique"
        Me.BarButtonItem1.Id = 1
        Me.BarButtonItem1.ImageOptions.Image = CType(resources.GetObject("BarButtonItem1.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem1.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem1.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem1.Name = "BarButtonItem1"
        '
        'BarButtonItem2
        '
        Me.BarButtonItem2.Caption = "BarButtonItem2"
        Me.BarButtonItem2.Id = 2
        Me.BarButtonItem2.Name = "BarButtonItem2"
        '
        'ribbonPage1
        '
        Me.ribbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.N2S_Parametrage})
        Me.ribbonPage1.Name = "ribbonPage1"
        Me.ribbonPage1.Text = "Paramétrage"
        '
        'N2S_Parametrage
        '
        Me.N2S_Parametrage.ItemLinks.Add(Me.BarButtonItem1)
        Me.N2S_Parametrage.Name = "N2S_Parametrage"
        Me.N2S_Parametrage.Text = "Paramétrage"
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 443)
        Me.Controls.Add(Me.ribbonControl1)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Main"
        Me.Ribbon = Me.ribbonControl1
        Me.Text = "Page d'accueil"
        CType(Me.ribbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private WithEvents ribbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Private WithEvents ribbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Private WithEvents N2S_Parametrage As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem2 As DevExpress.XtraBars.BarButtonItem
End Class

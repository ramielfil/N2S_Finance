Imports System.ComponentModel
Imports System.Text


Partial Public Class Main
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        N2S_Rub.Show()
    End Sub

    Private Sub JournalMensuel_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles JournalMensuel.ItemClick
        N2S_JnlM.Show()
    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        N2S_CalEcr.Show()
    End Sub
End Class

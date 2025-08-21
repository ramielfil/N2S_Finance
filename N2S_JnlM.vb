Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid

Public Class N2S_JnlM

    ' ✅ Variable pour stocker l'ID de la ligne sélectionnée
    Private SelectedID As Integer = -1

    ' ======================================================
    ' ▶ Chargement du Form
    ' ======================================================
    Private Sub N2S_JnlM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ChargerJournauxLookup()
        ChargerGrid()
        ViderEntete()
        ConfigurerGrid() ' → on bloque l’édition + format de la date
    End Sub

    ' ======================================================
    ' ▶ Charger la liste des journaux dans le LookUpEdit
    ' ======================================================
    Private Sub ChargerJournauxLookup()
        Try
            F_CheckConnection()
            Dim query As String = "SELECT JO_Num, JO_Intitule FROM F_JOURNAUX ORDER BY JO_Num"
            Dim cmd As New SqlCommand(query, V_SqlConnection)
            Dim dt As New DataTable()
            dt.Load(cmd.ExecuteReader())

            C_JNL.Properties.DataSource = dt
            C_JNL.Properties.DisplayMember = "JO_Num" ' affichage lisible
            C_JNL.Properties.ValueMember = "JO_Num"        ' valeur stockée
            C_JNL.Properties.NullText = ""
        Catch ex As Exception
            XtraMessageBox.Show("Erreur lors du chargement des journaux : " & ex.Message,
                                "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ======================================================
    ' ▶ Charger les données dans le Grid
    ' ======================================================
    Private Sub ChargerGrid()
        Try
            F_CheckConnection()
            Dim query As String =
                "SELECT JournalID, MoisAnnee, Journal
                 FROM N2S_JournalMensuel
                 ORDER BY MoisAnnee DESC"

            Dim cmd As New SqlCommand(query, V_SqlConnection)
            Dim dt As New DataTable()
            dt.Load(cmd.ExecuteReader())
            GridJournaux.DataSource = dt
        Catch ex As Exception
            XtraMessageBox.Show("Erreur lors du chargement du tableau : " & ex.Message,
                                "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ======================================================
    ' ▶ Ajouter
    ' ======================================================
    Private Sub BTN_V01_Click(sender As Object, e As EventArgs) Handles BTN_V01.Click
        If Not ValiderSaisie() Then Exit Sub
        Try
            F_CheckConnection()
            Dim query As String =
                "INSERT INTO N2S_JournalMensuel (MoisAnnee, Journal, DateCreation, DateModification) 
                 VALUES (@MoisAnnee, @Journal, GETDATE(), GETDATE())"

            Dim cmd As New SqlCommand(query, V_SqlConnection)
            cmd.Parameters.AddWithValue("@MoisAnnee", CDate(C_PERIODE.EditValue))
            cmd.Parameters.AddWithValue("@Journal", C_JNL.EditValue.ToString())
            cmd.ExecuteNonQuery()

            ChargerGrid()
            ViderEntete()
            XtraMessageBox.Show("Ajout effectué avec succès.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            XtraMessageBox.Show("Erreur lors de l'ajout : " & ex.Message,
                                "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ======================================================
    ' ▶ Modifier
    ' ======================================================
    Private Sub BTN_V02_Click(sender As Object, e As EventArgs) Handles BTN_V02.Click
        If SelectedID = -1 Then
            XtraMessageBox.Show("Veuillez sélectionner une ligne à modifier.", "Erreur",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If Not ValiderSaisie() Then Exit Sub

        Try
            F_CheckConnection()
            Dim query As String =
                "UPDATE N2S_JournalMensuel
                 SET MoisAnnee=@MoisAnnee,
                     Journal=@Journal,
                     DateModification=GETDATE()
                 WHERE JournalID=@ID"

            Dim cmd As New SqlCommand(query, V_SqlConnection)
            cmd.Parameters.AddWithValue("@MoisAnnee", CDate(C_PERIODE.EditValue))
            cmd.Parameters.AddWithValue("@Journal", C_JNL.EditValue.ToString())
            cmd.Parameters.AddWithValue("@ID", SelectedID)
            cmd.ExecuteNonQuery()

            ChargerGrid()
            ViderEntete()
            XtraMessageBox.Show("Modification effectuée avec succès.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            XtraMessageBox.Show("Erreur lors de la modification : " & ex.Message,
                                "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ======================================================
    ' ▶ Supprimer
    ' ======================================================
    Private Sub BTN_V03_Click(sender As Object, e As EventArgs) Handles BTN_V03.Click
        If SelectedID = -1 Then
            XtraMessageBox.Show("Veuillez sélectionner une ligne à supprimer.", "Erreur",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If XtraMessageBox.Show("Confirmer la suppression ?", "Confirmation",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                F_CheckConnection()
                Dim query As String = "DELETE FROM N2S_JournalMensuel WHERE JournalID=@ID"
                Dim cmd As New SqlCommand(query, V_SqlConnection)
                cmd.Parameters.AddWithValue("@ID", SelectedID)
                cmd.ExecuteNonQuery()

                ChargerGrid()
                ViderEntete()
                XtraMessageBox.Show("Suppression effectuée.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                XtraMessageBox.Show("Erreur lors de la suppression : " & ex.Message,
                                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    ' ======================================================
    ' ▶ Focus sur une ligne du Grid → Mettre SelectedID
    ' ======================================================
    Private Sub GridView1_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        Try
            Dim rowHandle As Integer = e.FocusedRowHandle
            If rowHandle >= 0 Then
                SelectedID = Convert.ToInt32(GridView1.GetRowCellValue(rowHandle, "JournalID"))
            Else
                SelectedID = -1
            End If
        Catch
            SelectedID = -1
        End Try
    End Sub

    ' ======================================================
    ' ▶ Double-clic dans la Grid → Charger l'entête
    ' ======================================================
    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        Try
            Dim rowHandle As Integer = GridView1.FocusedRowHandle
            If rowHandle >= 0 Then
                SelectedID = Convert.ToInt32(GridView1.GetRowCellValue(rowHandle, "JournalID"))
                C_PERIODE.EditValue = GridView1.GetRowCellValue(rowHandle, "MoisAnnee")
                C_JNL.EditValue = GridView1.GetRowCellValue(rowHandle, "Journal").ToString()
            End If
        Catch ex As Exception
            XtraMessageBox.Show("Erreur lors du chargement de la ligne : " & ex.Message,
                                "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ======================================================
    ' ▶ Vider l’entête
    ' ======================================================
    Private Sub ViderEntete()
        C_PERIODE.EditValue = Nothing
        C_JNL.EditValue = Nothing
        SelectedID = -1
    End Sub

    ' ======================================================
    ' ▶ Contrôle de saisie
    ' ======================================================
    Private Function ValiderSaisie() As Boolean
        If C_PERIODE.EditValue Is Nothing Then
            XtraMessageBox.Show("Veuillez choisir une période.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        If C_JNL.EditValue Is Nothing Then
            XtraMessageBox.Show("Veuillez choisir un journal.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        Return True
    End Function

    ' ======================================================
    ' ▶ Configurer le Grid (Lecture seule + Format Date)
    ' ======================================================
    Private Sub ConfigurerGrid()
        ' Grid en lecture seule
        GridView1.OptionsBehavior.Editable = False
        GridView1.OptionsBehavior.ReadOnly = True

        ' Masquer l’ID dans le grid
        GridView1.Columns("JournalID").Visible = False

        ' Format date MM/yyyy
        GridView1.Columns("MoisAnnee").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        GridView1.Columns("MoisAnnee").DisplayFormat.FormatString = "MM/yyyy"
    End Sub

    ' ======================================================
    ' ▶ Formatter le DateEdit pour MM/yyyy
    ' ======================================================
    Private Sub C_PERIODE_EditValueChanged(sender As Object, e As EventArgs) Handles C_PERIODE.EditValueChanged
        C_PERIODE.Properties.DisplayFormat.FormatString = "MM/yyyy"
        C_PERIODE.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        C_PERIODE.Properties.EditFormat.FormatString = "MM/yyyy"
        C_PERIODE.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        C_PERIODE.Properties.Mask.EditMask = "MM/yyyy"

        C_PERIODE.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Classic
        C_PERIODE.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearView
    End Sub

End Class

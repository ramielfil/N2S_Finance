Imports System.Data.SqlClient
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Base

''' <summary>
''' Formulaire de gestion des rubriques N2S avec DevExpress GridControl
''' Affiche RubriqueFormat sous forme de texte (Formule de calcul / Compte comptable)
''' Permet d'ajouter, modifier et supprimer des rubriques.
''' </summary>
Public Class N2S_Rub

    Private selectedRubriqueID As Integer = 0 ' Id de la rubrique sélectionnée

    ' ================================
    ' FORM LOAD
    ' ================================
    Private Sub N2S_Rub_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Initialisation ComboBox
            C_Type.Items.Clear()
            C_Type.Items.Add("Formule de calcul")
            C_Type.Items.Add("Compte comptable")

            ' Charger les rubriques
            ChargerRubriques()

            ' Configurer l'affichage texte pour la colonne RubriqueFormat
            Dim view As GridView = CType(GridRubriques.MainView, GridView)
            AddHandler view.CustomColumnDisplayText, AddressOf GridView_CustomColumnDisplayText

        Catch ex As Exception
            MessageBox.Show("Erreur lors du chargement : " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ================================
    ' UTILITAIRES
    ' ================================
    Private Sub ViderChamps()
        C_Rub.Clear()
        C_Type.SelectedIndex = -1
        C_Content.Clear()
        selectedRubriqueID = 0
    End Sub

    Private Sub ChargerRubriques()
        Try
            Dim query As String = "SELECT RubriqueID, RubriqueNom, RubriqueFormat, RubriqueContent FROM N2S_Rubrique"
            F_CheckConnection()

            Using reader As SqlDataReader = F_GetDataReader(query)
                Dim dt As New DataTable()
                dt.Load(reader)
                GridRubriques.DataSource = dt
            End Using

            ' ⚡ Récupérer le GridView principal
            Dim view As GridView = CType(GridRubriques.MainView, GridView)

            ' ⚡ Masquer la colonne RubriqueID
            If view.Columns.ColumnByFieldName("RubriqueID") IsNot Nothing Then
                view.Columns("RubriqueID").Visible = False
            End If

            ' ⚡ Rendre le GridView totalement non modifiable
            view.OptionsBehavior.Editable = False

        Catch ex As Exception
            MessageBox.Show("Erreur lors du chargement des rubriques : " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Function MapperTypeEnValeur(typeText As String) As Integer
        Select Case typeText
            Case "Formule de calcul" : Return 1
            Case "Compte comptable" : Return 2
            Case Else : Return 0
        End Select
    End Function

    Private Function MapperValeurEnType(typeValue As Integer) As String
        Select Case typeValue
            Case 1 : Return "Formule de calcul"
            Case 2 : Return "Compte comptable"
            Case Else : Return ""
        End Select
    End Function

    ' ================================
    ' BOUTONS
    ' ================================
    Private Sub BTN_V01_Click(sender As Object, e As EventArgs) Handles BTN_V01.Click
        Try
            Dim nom As String = C_Rub.Text.Trim()
            Dim typeText As String = If(C_Type.SelectedItem IsNot Nothing, C_Type.SelectedItem.ToString(), "")
            Dim contenu As String = C_Content.Text.Trim()

            If String.IsNullOrEmpty(nom) OrElse String.IsNullOrEmpty(typeText) OrElse String.IsNullOrEmpty(contenu) Then
                MessageBox.Show("Veuillez remplir tous les champs.", "Champs manquants", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim typeValue As Integer = MapperTypeEnValeur(typeText)
            Dim query As String = $"INSERT INTO N2S_Rubrique (RubriqueNom, RubriqueFormat, RubriqueContent) VALUES ('{nom.Replace("'", "''")}', {typeValue}, '{contenu.Replace("'", "''")}')"
            F_ExecuteQuery(query)

            ChargerRubriques()
            ViderChamps()
            MessageBox.Show("Rubrique ajoutée avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Erreur lors de l'insertion : " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BTN_V02_Click(sender As Object, e As EventArgs) Handles BTN_V02.Click
        Try
            If selectedRubriqueID = 0 Then
                MessageBox.Show("Veuillez sélectionner une rubrique à modifier.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim nom As String = C_Rub.Text.Trim()
            Dim typeText As String = If(C_Type.SelectedItem IsNot Nothing, C_Type.SelectedItem.ToString(), "")
            Dim contenu As String = C_Content.Text.Trim()

            If String.IsNullOrEmpty(nom) OrElse String.IsNullOrEmpty(typeText) OrElse String.IsNullOrEmpty(contenu) Then
                MessageBox.Show("Veuillez remplir tous les champs.", "Champs manquants", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim typeValue As Integer = MapperTypeEnValeur(typeText)
            Dim query As String = $"UPDATE N2S_Rubrique SET RubriqueNom='{nom.Replace("'", "''")}', RubriqueFormat={typeValue}, RubriqueContent='{contenu.Replace("'", "''")}' WHERE RubriqueID={selectedRubriqueID}"
            F_ExecuteQuery(query)

            ChargerRubriques()
            ViderChamps()
            MessageBox.Show("Rubrique modifiée avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Erreur lors de la modification : " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BTN_V03_Click(sender As Object, e As EventArgs) Handles BTN_V03.Click
        Try
            Dim view As GridView = CType(GridRubriques.MainView, GridView)
            If selectedRubriqueID = 0 AndAlso view.FocusedRowHandle >= 0 Then
                selectedRubriqueID = Convert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, "RubriqueID"))
            End If

            If selectedRubriqueID = 0 Then
                MessageBox.Show("Veuillez sélectionner une rubrique à supprimer.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim confirm As DialogResult = MessageBox.Show("Voulez-vous vraiment supprimer cette rubrique ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If confirm = DialogResult.Yes Then
                Dim query As String = $"DELETE FROM N2S_Rubrique WHERE RubriqueID={selectedRubriqueID}"
                F_ExecuteQuery(query)
                ChargerRubriques()
                ViderChamps()
                MessageBox.Show("Rubrique supprimée avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Erreur lors de la suppression : " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ================================
    ' GRID EVENTS
    ' ================================
    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        Try
            Dim view As GridView = CType(sender, GridView)
            Dim rowHandle As Integer = view.FocusedRowHandle
            If rowHandle >= 0 Then
                selectedRubriqueID = Convert.ToInt32(view.GetRowCellValue(rowHandle, "RubriqueID"))
                C_Rub.Text = view.GetRowCellValue(rowHandle, "RubriqueNom").ToString()
                C_Type.SelectedItem = MapperValeurEnType(Convert.ToInt32(view.GetRowCellValue(rowHandle, "RubriqueFormat")))
                C_Content.Text = view.GetRowCellValue(rowHandle, "RubriqueContent").ToString()
            End If
        Catch ex As Exception
            MessageBox.Show("Erreur lors de la sélection de la rubrique : " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Convertir RubriqueFormat de chiffre en texte pour affichage
    Private Sub GridView_CustomColumnDisplayText(sender As Object, e As CustomColumnDisplayTextEventArgs)
        If e.Column.FieldName = "RubriqueFormat" Then
            e.DisplayText = MapperValeurEnType(Convert.ToInt32(e.Value))
        End If
    End Sub

End Class

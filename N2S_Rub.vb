Imports System.Data.SqlClient
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Base

''' <summary>
''' Formulaire de gestion des rubriques N2S avec DevExpress GridControl
''' Gère les opérations CRUD (Create, Read, Update, Delete) sur la table N2S_Rubrique
''' </summary>
Public Class N2S_Rub

    ' ================================
    ' VARIABLES GLOBALES
    ' ================================
    Private selectedRubriqueID As Integer = 0 ' Id de la rubrique sélectionnée

    ' ================================
    ' FORM LOAD
    ' ================================
    Private Sub N2S_Rub_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Initialisation ComboBox Type
            C_Type.Items.Clear()
            C_Type.Items.Add("Formule de calcul")
            C_Type.Items.Add("Compte comptable")

            ' Charger les rubriques depuis la base
            ChargerRubriques()

            ' Gestion de l’affichage texte pour RubriqueFormat
            Dim view As GridView = CType(GridRubriques.MainView, GridView)
            AddHandler view.CustomColumnDisplayText, AddressOf GridView_CustomColumnDisplayText

        Catch ex As Exception
            MessageBox.Show("Erreur lors du chargement : " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ================================
    ' UTILITAIRES
    ' ================================
    ''' <summary>
    ''' Vide tous les champs du formulaire
    ''' </summary>
    Private Sub ViderChamps()
        C_Code.Clear()
        C_Rub.Clear()
        C_Type.SelectedIndex = -1
        C_Content.Clear()
        selectedRubriqueID = 0
    End Sub

    ''' <summary>
    ''' Recharge les rubriques dans le GridControl
    ''' </summary>
    Private Sub ChargerRubriques()
        Try
            Dim query As String = "SELECT RubriqueID, RubriqueCode, RubriqueNom, RubriqueFormat, RubriqueContent FROM N2S_Rubrique"
            F_CheckConnection()

            Using reader As SqlDataReader = F_GetDataReader(query)
                Dim dt As New DataTable()
                dt.Load(reader)
                GridRubriques.DataSource = dt
            End Using

            ' ⚡ Configuration GridView
            Dim view As GridView = CType(GridRubriques.MainView, GridView)

            ' Masquer l’ID car inutile pour l’utilisateur
            If view.Columns.ColumnByFieldName("RubriqueID") IsNot Nothing Then
                view.Columns("RubriqueID").Visible = False
            End If

            ' Empêcher toute modification directe dans la grille
            view.OptionsBehavior.Editable = False

        Catch ex As Exception
            MessageBox.Show("Erreur lors du chargement des rubriques : " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Conversion entre valeur numérique et texte pour RubriqueFormat
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
    ' BOUTON AJOUTER
    ' ================================
    Private Sub BTN_V01_Click(sender As Object, e As EventArgs) Handles BTN_V01.Click
        Try
            Dim code As String = C_Code.Text.Trim()
            Dim nom As String = C_Rub.Text.Trim()
            Dim typeText As String = If(C_Type.SelectedItem IsNot Nothing, C_Type.SelectedItem.ToString(), "")
            Dim contenu As String = C_Content.Text.Trim()

            ' Vérifier les champs obligatoires
            If String.IsNullOrEmpty(code) OrElse String.IsNullOrEmpty(nom) OrElse String.IsNullOrEmpty(typeText) OrElse String.IsNullOrEmpty(contenu) Then
                MessageBox.Show("Veuillez remplir tous les champs.", "Champs manquants", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim typeValue As Integer = MapperTypeEnValeur(typeText)

            ' Requête d’insertion
            Dim query As String =
                $"INSERT INTO N2S_Rubrique (RubriqueCode, RubriqueNom, RubriqueFormat, RubriqueContent) " &
                $"VALUES ('{code.Replace("'", "''")}', '{nom.Replace("'", "''")}', {typeValue}, '{contenu.Replace("'", "''")}')"

            F_ExecuteQuery(query)

            ChargerRubriques()
            ViderChamps()
            MessageBox.Show("Rubrique ajoutée avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Erreur lors de l'insertion : " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ================================
    ' BOUTON MODIFIER
    ' ================================
    Private Sub BTN_V02_Click(sender As Object, e As EventArgs) Handles BTN_V02.Click
        Try
            If selectedRubriqueID = 0 Then
                MessageBox.Show("Veuillez sélectionner une rubrique à modifier.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim code As String = C_Code.Text.Trim()
            Dim nom As String = C_Rub.Text.Trim()
            Dim typeText As String = If(C_Type.SelectedItem IsNot Nothing, C_Type.SelectedItem.ToString(), "")
            Dim contenu As String = C_Content.Text.Trim()

            If String.IsNullOrEmpty(code) OrElse String.IsNullOrEmpty(nom) OrElse String.IsNullOrEmpty(typeText) OrElse String.IsNullOrEmpty(contenu) Then
                MessageBox.Show("Veuillez remplir tous les champs.", "Champs manquants", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim typeValue As Integer = MapperTypeEnValeur(typeText)

            ' Requête de mise à jour
            Dim query As String =
                $"UPDATE N2S_Rubrique " &
                $"SET RubriqueCode='{code.Replace("'", "''")}', " &
                $"RubriqueNom='{nom.Replace("'", "''")}', " &
                $"RubriqueFormat={typeValue}, " &
                $"RubriqueContent='{contenu.Replace("'", "''")}' " &
                $"WHERE RubriqueID={selectedRubriqueID}"

            F_ExecuteQuery(query)

            ChargerRubriques()
            ViderChamps()
            MessageBox.Show("Rubrique modifiée avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Erreur lors de la modification : " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ================================
    ' BOUTON SUPPRIMER
    ' ================================
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

            ' Confirmation
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
                ' ⚡ Remplir les champs du formulaire à partir de la ligne sélectionnée
                selectedRubriqueID = Convert.ToInt32(view.GetRowCellValue(rowHandle, "RubriqueID"))
                C_Code.Text = view.GetRowCellValue(rowHandle, "RubriqueCode").ToString()
                C_Rub.Text = view.GetRowCellValue(rowHandle, "RubriqueNom").ToString()
                C_Type.SelectedItem = MapperValeurEnType(Convert.ToInt32(view.GetRowCellValue(rowHandle, "RubriqueFormat")))
                C_Content.Text = view.GetRowCellValue(rowHandle, "RubriqueContent").ToString()
            End If
        Catch ex As Exception
            MessageBox.Show("Erreur lors de la sélection de la rubrique : " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Gestion de l’affichage texte pour RubriqueFormat
    Private Sub GridView_CustomColumnDisplayText(sender As Object, e As CustomColumnDisplayTextEventArgs)
        If e.Column.FieldName = "RubriqueFormat" Then
            e.DisplayText = MapperValeurEnType(Convert.ToInt32(e.Value))
        End If
    End Sub

End Class

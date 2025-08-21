Imports System.Data.SqlClient
Imports System.Configuration

Public Class N2S_CalEcr

    ' ✅ Au chargement du formulaire
    Private Sub N2S_CalEcr_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Charger et afficher les calculs dans le Grid
            ChargerCalculRubriques()
        Catch ex As Exception
            MessageBox.Show("Erreur au chargement : " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Récupère la dernière date (MoisAnnee) depuis la table N2S_JournalMensuel
    ''' </summary>
    Private Function GetDerniereDate() As Date
        F_CheckConnection()

        ' Modifier ici selon la colonne qui identifie l'ordre d'insertion
        Dim cmd As New SqlCommand("SELECT TOP 1 MoisAnnee FROM N2S_JournalMensuel ORDER BY JournalID DESC", V_SqlConnection)
        Dim result = cmd.ExecuteScalar()

        If result IsNot Nothing AndAlso Not IsDBNull(result) Then
            Return Convert.ToDateTime(result).Date
        Else
            Throw New Exception("Aucune date trouvée dans N2S_JournalMensuel.")
        End If
    End Function


    ''' <summary>
    ''' Charge les rubriques et calcule les soldes à partir de F_ECRITUREC
    ''' </summary>
    Private Sub ChargerCalculRubriques()
        ' Dernière date MoisAnnee
        Dim derniereDate As Date = GetDerniereDate()

        ' DataTable pour stocker les résultats
        Dim dtResult As New DataTable()
        dtResult.Columns.Add("RubriqueCode", GetType(String))
        dtResult.Columns.Add("RubriqueContent", GetType(String))  ' Début du compte
        dtResult.Columns.Add("RubriqueNom", GetType(String))
        dtResult.Columns.Add("Mvts_Debiteurs", GetType(Decimal))
        dtResult.Columns.Add("Mvts_Crediteurs", GetType(Decimal))
        dtResult.Columns.Add("Solde", GetType(Decimal))

        ' Assurer que la connexion globale est ouverte
        F_CheckConnection()

        ' 1️⃣ Charger toutes les rubriques
        Dim rubriques As New List(Of (Code As String, Nom As String, Content As String))()
        Using cmdRub As New SqlCommand("SELECT RubriqueCode, RubriqueNom, RubriqueContent FROM N2S_Rubrique", V_SqlConnection)
            Using readerRub As SqlDataReader = cmdRub.ExecuteReader()
                While readerRub.Read()
                    rubriques.Add((
                        readerRub("RubriqueCode").ToString(),
                        readerRub("RubriqueNom").ToString(),
                        readerRub("RubriqueContent").ToString()
                    ))
                End While
            End Using
        End Using

        ' 2️⃣ Calculer les montants pour chaque rubrique
        For Each rub In rubriques
            Dim req As String =
                "SELECT 
                    SUM(F_ECRITUREC.EC_Montant * (1 - F_ECRITUREC.EC_Sens)) AS Mvts_Debiteurs,
                    SUM(F_ECRITUREC.EC_Montant * F_ECRITUREC.EC_Sens) AS Mvts_Crediteurs,
                    SUM(F_ECRITUREC.EC_Montant * (1 - F_ECRITUREC.EC_Sens)) 
                    - SUM(F_ECRITUREC.EC_Montant * F_ECRITUREC.EC_Sens) AS Solde
                 FROM dbo.F_COMPTEG
                 INNER JOIN dbo.F_ECRITUREC 
                    ON F_COMPTEG.CG_Num = F_ECRITUREC.CG_Num
                 WHERE F_COMPTEG.CG_Type = 0
                   AND F_ECRITUREC.CG_Num LIKE @CompteDebut + '%'
                   AND F_ECRITUREC.JM_Date = @Date"

            Using cmd As New SqlCommand(req, V_SqlConnection)
                cmd.Parameters.AddWithValue("@CompteDebut", rub.Content)
                cmd.Parameters.AddWithValue("@Date", derniereDate)

                Using reader As SqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        Dim debit As Decimal = If(IsDBNull(reader("Mvts_Debiteurs")), 0D, Convert.ToDecimal(reader("Mvts_Debiteurs")))
                        Dim credit As Decimal = If(IsDBNull(reader("Mvts_Crediteurs")), 0D, Convert.ToDecimal(reader("Mvts_Crediteurs")))
                        Dim solde As Decimal = If(IsDBNull(reader("Solde")), 0D, Convert.ToDecimal(reader("Solde")))

                        ' Ajouter ligne dans le DataTable
                        dtResult.Rows.Add(rub.Code, rub.Content, rub.Nom, debit, credit, solde)
                    End If
                End Using
            End Using
        Next

        ' 3️⃣ Lier le résultat au Grid
        GridCalcul.DataSource = dtResult
    End Sub

End Class

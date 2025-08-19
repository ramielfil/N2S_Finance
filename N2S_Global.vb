Imports System.Configuration
Imports System.Data.SqlClient

Module N2S_Global

    ' 🔗 Variable globale : connexion SQL à la base de données
    Public V_SqlConnection As SqlConnection

    ' 📌 Fonction : Créer et ouvrir une connexion à la base de données
    Public Sub F_CreateConnection()
        ' Récupérer la chaîne de connexion depuis App.config
        Dim V_ConnectionString As String
        V_ConnectionString = ConfigurationManager.AppSettings("connectionString")

        ' Initialiser la connexion SQL
        V_SqlConnection = New SqlConnection

        ' Si la connexion est déjà ouverte, on la ferme
        If V_SqlConnection.State = ConnectionState.Open Then
            V_SqlConnection.Close()
        End If

        ' Définir la chaîne de connexion
        V_SqlConnection.ConnectionString = V_ConnectionString

        ' Ouvrir la connexion
        V_SqlConnection.Open()
    End Sub

    ' 📌 Fonction : Vérifier si la connexion est ouverte, sinon la créer
    Public Sub F_CheckConnection()
        ' Si la connexion est inexistante ou fermée, on la recrée
        If V_SqlConnection Is Nothing OrElse V_SqlConnection.State = ConnectionState.Closed Then
            F_CreateConnection()
        End If
    End Sub

    ' 📌 Fonction : Fermer la connexion si elle est ouverte
    Public Sub F_CloseConnection()
        If V_SqlConnection.State = ConnectionState.Open Then
            V_SqlConnection.Close()
        End If
    End Sub

    ' 📌 Fonction : Exécuter une requête SQL qui ne retourne pas de données
    ' Exemple : INSERT, UPDATE, DELETE
    Public Sub F_ExecuteQuery(ByVal V_SqlQuery As String)
        ' Vérifier que la connexion est ouverte
        F_CheckConnection()

        ' Créer et exécuter la commande SQL
        Dim V_SqlCommand As New SqlCommand(V_SqlQuery, V_SqlConnection)
        V_SqlCommand.ExecuteNonQuery()
    End Sub

    ' 📌 Fonction : Exécuter une requête SQL et récupérer les résultats via SqlDataReader
    ' Exemple : SELECT * FROM MaTable
    Public Function F_GetDataReader(ByVal V_SqlQuery As String) As SqlDataReader
        ' Vérifier que la connexion est ouverte
        F_CheckConnection()

        ' Créer la commande SQL
        Dim V_SqlCommand As New SqlCommand(V_SqlQuery, V_SqlConnection)

        ' Exécuter la commande et récupérer les données
        Dim V_DataReader As SqlDataReader
        V_DataReader = V_SqlCommand.ExecuteReader()

        ' Retourner le DataReader au code appelant
        Return V_DataReader
    End Function

End Module

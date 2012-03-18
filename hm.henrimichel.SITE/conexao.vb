Imports Npgsql

Public Class conexao

    Private Shared _server As String = "postgresql01.henrimichel.com.br"
    Private Shared _porta As String = "5432"
    Private Shared _login As String = "henrimichel"
    Private Shared _senhas As String = "vln1526hnri"
    Private Shared _database As String = "henrimichel"

    Private Shared _strConexao As String = String.Format("Server={0};Port={1};User Id={2};Password={3};Database={4}", _server, _porta, _login, _senhas, _database)

    Public Shared Function Selecione(ByVal Tabela As String) As DataTable

        Dim conn As NpgsqlConnection = New NpgsqlConnection(_strConexao)

        Try
            conn.Open()

            Dim SQL As String = "Select * From " + Tabela

            Dim da As Npgsql.NpgsqlDataAdapter = New NpgsqlDataAdapter(SQL, conn)

            Dim ds As DataSet = New DataSet()

            da.Fill(ds, Tabela)

            Return ds.Tables(Tabela)

        Catch ex As Exception

            Return Nothing

        Finally
            conn.Close()
        End Try

    End Function

    Public Sub incluir(ByVal campos As String, ByVal valores As String, ByVal tabela As String)

        Dim conn As NpgsqlConnection = New NpgsqlConnection(_strConexao)

        Try

            conn.Open()

            Dim SQL As String = String.Format("INSERT INTO {0} ({1}) VALUES {2} ", tabela, campos, valores)

            Dim command As Npgsql.NpgsqlCommand = New NpgsqlCommand(SQL, conn)

            command.ExecuteNonQuery()


        Catch ex As Exception

        Finally
            conn.Close()
        End Try

    End Sub


    Public Shared Function SelecionarTwitcamHash() As String

        Dim conn As NpgsqlConnection = New NpgsqlConnection(_strConexao)

        Try
            conn.Open()

            Dim SQL As String = "Select Hash From ""Twitcam"" order by ""DataInclusao"""

            Dim da As Npgsql.NpgsqlDataAdapter = New NpgsqlDataAdapter(SQL, conn)

            Dim ds As DataSet = New DataSet()

            da.Fill(ds, "twitcam")

            Return ds.Tables("Twitcam").Rows.Item(0).ToString

        Catch ex As Exception

            Return Nothing

        Finally
            conn.Close()
        End Try

    End Function


End Class

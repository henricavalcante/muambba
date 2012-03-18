Imports System.Xml
Imports hm.framework
Imports Npgsql

Partial Public Class _Default
    Inherits System.Web.UI.Page

    Private _server As String = "postgresql01.henrimichel.com.br"
    Private _porta As String = "5432"
    Private _login As String = "henrimichel"
    Private _senhas As String = "vln1526hnri"
    Private _database As String = "henrimichel"

    Private _strConexao As String = String.Format("Server={0};Port={1};User Id={2};Password={3};Database={4}", _server, _porta, _login, _senhas, _database)

    Public TwitCamHash As String = String.Empty

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            
            ListarTweetsToMe()
            ListarTweetsFromMe()

            'GetTwitCamHash()


        Catch ex As Exception

            JavaScriptAjax.ShowMsg(Me.Page, ex.Message)
        End Try



    End Sub
    Private Sub ListarTweetsFromMe()

        Dim twitter As New XmlDocument()
        twitter.Load("http://twitter.com/statuses/user_timeline/162149585.rss")
        Dim twitterNodes As XmlNodeList = twitter.SelectNodes("/rss/channel/item")

        repTwitterFromMe.DataSource = twitterNodes
        repTwitterFromMe.DataBind()



    End Sub
    Private Sub ListarTweetsToMe()

        Dim twitter As New XmlDocument()
        twitter.Load("http://search.twitter.com/search.rss?q=@henricavalcante")
        Dim twitterNodes As XmlNodeList = twitter.SelectNodes("/rss/channel/item")

        repTwitterToMe.DataSource = twitterNodes
        repTwitterToMe.DataBind()


    End Sub
    Private Sub GetTwitCamHash()

        Dim conn As NpgsqlConnection = New NpgsqlConnection(_strConexao)
        Dim ds As DataSet = Nothing

        Try
            conn.Open()

            Dim SQL As String

            Dim command As Npgsql.NpgsqlCommand

            If Request("twitcamhash") <> String.Empty Then

                SQL = "INSERT INTO twitcam(""Hash"") VALUES ('" + Request("twitcamhash") + "')"
                command = New NpgsqlCommand(SQL, conn)
                command.ExecuteNonQuery()

            End If
            SQL = "Select ""Hash"" From ""twitcam"" order by ""DataInclusao"" desc"

            command = New NpgsqlCommand(SQL, conn)

            TwitCamHash = command.ExecuteScalar()

        Catch ex As Exception

            Throw

        Finally
            conn.Close()
        End Try
    End Sub

    Public Function GetTweets(ByVal tweets As String) As String

        Dim newStr As String = Nothing
        tweets = tweets.Replace("&", "&amp;")
        tweets = tweets.Replace("&lt;", "&lt;")
        tweets = tweets.Replace("&gt;", "&gt;")
        tweets = tweets.Replace("&quot;", "")
        Dim count As Integer = tweets.Length
        newStr = tweets.Substring(tweets.IndexOf(": ") + 2)

        'Dim i As Integer = newStr.IndexOf("http://")
        'If i <> -1 Then
        '    Dim firstPart As String = newStr.Substring(0, i)
        '    Dim newStrLen As Integer = newStr.Length
        '    Dim firstPartLen As Integer = firstPart.Length
        '    Dim endPartlen As Integer = newStrLen - firstPartLen
        '    Dim strUrl As String = newStr.Substring(i, endPartlen)
        '    strUrl = "<a href=""" & strUrl & """ class='LinkDataTwitts'>" & strUrl & "</a>"
        '    newStr = firstPart & strUrl
        'End If

        Return newStr

    End Function
    Public Function GetAutor(ByVal autor As String) As String

        Return autor.Substring(0, autor.IndexOf("@"))

    End Function


End Class
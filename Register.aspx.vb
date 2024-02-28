
Imports MySql.Data.MySqlClient
Public Class Register
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnRegister_Click(sender As Object, e As EventArgs)
        Dim username As String = InputUsername.Text.Trim()
        Dim email As String = InputEmail.Text.Trim()
        Dim password As String = InputPassword.Text.Trim()


        Dim dbController As New DatabaseController()
        Dim parameters As New List(Of MySqlParameter)()
        parameters.Add(New MySqlParameter("nickname", username))
        parameters.Add(New MySqlParameter("mail", email))
        parameters.Add(New MySqlParameter("password", HashHelper.ComputeSHA1(password))) ' Note: You should hash passwords before storing them in the database

        Dim success As Boolean = dbController.InsertRecord("users", parameters.ToArray())

        If success Then
            Response.Redirect("./Default.aspx")
        Else
            ' Registration failed
            er1.InnerText = "Registration failed. Please try again."
        End If
    End Sub
End Class
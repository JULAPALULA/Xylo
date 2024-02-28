Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        ' Create an instance of DatabaseController
        Dim dbController As New DatabaseController()

        ' Call the ValidateUser method on the instance
        Dim isAuthenticated As Boolean = dbController.ValidateUser(InputEmail.Text, InputPassword.Text)

        If isAuthenticated Then
            Session("mail") = InputEmail.Text.Trim()
            Response.Redirect("./Intranet/Unity/index.html?token=" + dbController.GetUserToken(InputEmail.Text.Trim()))
        Else
            er1.InnerText = "Invalid email or password. Please try again."
        End If
    End Sub


    Protected Sub btnPlayAsGuest_Click(sender As Object, e As EventArgs)

    End Sub
End Class
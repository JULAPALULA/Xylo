Public Class SMChecker
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim _email As String = Session("mail").ToString()

            Dim dbController As New DatabaseController()

            If (dbController.CheckTokenByEmail(_email)) Then
                ServerResponse.InnerText = "msg_ok"
            Else
                ServerResponse.InnerText = "msg_fail"
            End If
        End If
    End Sub

End Class
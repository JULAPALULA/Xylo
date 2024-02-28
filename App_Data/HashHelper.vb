Imports System.Security.Cryptography
Imports System.Text

Public Class HashHelper
    Public Shared Function ComputeSHA1(input As String) As String
        Using sha1 As New SHA1Managed()
            Dim bytes As Byte() = Encoding.UTF8.GetBytes(input)
            Dim hashBytes As Byte() = sha1.ComputeHash(bytes)

            Dim builder As New StringBuilder()
            For Each b As Byte In hashBytes
                builder.Append(b.ToString("x2"))
            Next

            Return builder.ToString()
        End Using
    End Function
End Class

Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Imports Org.BouncyCastle.Crypto

Public Class DatabaseController
    Private connectionString As String = ConfigurationManager.ConnectionStrings("ConexionUP").ConnectionString

    Public Function CheckTokenByEmail(email As String) As String
        Dim query As String = "SELECT token FROM users WHERE mail LIKE @mail"
        Dim parameters As New List(Of MySqlParameter)()
        parameters.Add(New MySqlParameter("@mail", email))

        Try
            Using connection As New MySqlConnection(connectionString)
                Using command As New MySqlCommand(query, connection)
                    command.Parameters.AddRange(parameters.ToArray())

                    connection.Open()

                    Dim token As Object = command.ExecuteScalar()

                    If token IsNot Nothing AndAlso Not IsDBNull(token) Then
                        Return True
                    Else
                        Return False
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function GetUserToken(email As String) As String
        Dim query As String = "SELECT token FROM users WHERE mail = @mail"

        ' Create parameters for the query
        Dim parameters As New List(Of MySqlParameter)()
        parameters.Add(New MySqlParameter("@mail", email))

        Try
            Using connection As New MySqlConnection(connectionString)
                Using command As New MySqlCommand(query, connection)
                    command.Parameters.AddRange(parameters.ToArray())

                    connection.Open()

                    Dim token As Object = command.ExecuteScalar()

                    If token IsNot Nothing AndAlso Not IsDBNull(token) Then
                        Return token.ToString()
                    Else
                        Return String.Empty
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return String.Empty
        End Try
    End Function

    Public Function InsertRecord(tableName As String, parameters As MySqlParameter()) As Boolean
        Using connection As New MySqlConnection(connectionString)
            Dim parameterNames As String = String.Join(", ", parameters.Select(Function(param) param.ParameterName))
            Dim parameterValues As String = String.Join(", ", parameters.Select(Function(param) "@" & param.ParameterName))

            Dim query As String = $"INSERT INTO {tableName} ({parameterNames}) VALUES ({parameterValues})"
            Dim command As New MySqlCommand(query, connection)
            command.Parameters.AddRange(parameters)

            Try
                connection.Open()
                command.ExecuteNonQuery()
                Return True
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try
        End Using
    End Function

    Public Function ValidateUser(email As String, password As String) As Boolean
        Dim query As String = "SELECT COUNT(*) FROM users WHERE mail = @mail AND password = @password"

        Dim parameters As New List(Of MySqlParameter)()
        parameters.Add(New MySqlParameter("@mail", email))
        parameters.Add(New MySqlParameter("@password", HashHelper.ComputeSHA1(password)))

        Try
            Using connection As New MySqlConnection(connectionString)
                Using command As New MySqlCommand(query, connection)
                    command.Parameters.AddRange(parameters.ToArray())

                    connection.Open()

                    Dim result As Integer = Convert.ToInt32(command.ExecuteScalar())

                    Return result > 0
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function
    Public Sub SelectRecord(tableName As String)
        Using connection As New MySqlConnection(connectionString)

            Dim query As String = $"SELECT * FROM {tableName}"
            Dim command As New MySqlCommand(query, connection)

            Try
                connection.Open()
                command.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Using
    End Sub
    Public Function ExecuteCustomQuery(query As String, Optional parameters As MySqlParameter() = Nothing) As Boolean
        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                If parameters IsNot Nothing Then
                    command.Parameters.AddRange(parameters)
                End If

                Try
                    connection.Open()
                    command.ExecuteNonQuery()
                    Return True
                Catch ex As Exception
                    MsgBox(ex.Message)
                    Return False
                End Try
            End Using
        End Using
    End Function
End Class

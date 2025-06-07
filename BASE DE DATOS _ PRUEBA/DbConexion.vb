Imports System.Data.SqlClient

Public Module DbConnection
    Public Function GetConnectionString() As String

        Return "Data Source=.;Initial Catalog=ColegioDB;Integrated Security=True;"

    End Function


End Module

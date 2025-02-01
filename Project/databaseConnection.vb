Imports System.Data.SqlClient

Public Class databaseConnection
	Public connect_db As New SqlConnection With {.ConnectionString = "Server=DESKTOP-0OS5DTE\SQLEXPRESS; database=matildo; user=sa; password=shs;"}
	Public cmd As SqlCommand

	Public Function HasConnection() As Boolean
		Try
			connect_db.Open()
			MsgBox("Connection Successssful!")
			connect_db.Close()
			Return True
		Catch ex As Exception
			MsgBox(ex.Message)
			Return False
		End Try
	End Function
End Class
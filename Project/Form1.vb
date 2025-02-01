Imports System.Data.SqlClient

Public Class Form1
	Dim connect As New databaseConnection

	Public Sub logIn()
		Dim logInCommand As New SqlCommand("SELECT * FROM LogIn_Table WHERE Uname = @Uname AND Pword = @Pword", connect.connect_db)
		logInCommand.Parameters.AddWithValue("@Uname", TextBox1.Text)
		logInCommand.Parameters.AddWithValue("@Pword", TextBox2.Text)

		Dim Adapter As New SqlDataAdapter(logInCommand)
		Dim logInTable As New DataTable
		Adapter.Fill(logInTable)

		If logInTable.Rows.Count <= 0 Then
			MsgBox("Invalid username or password.", vbInformation, "Log In")
		Else
			Form3.Show()
			Me.Hide()

			TextBox1.Text = ""
			TextBox2.Text = ""
		End If
	End Sub

	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
		If TextBox1.Text = "" And TextBox2.Text = "" Then
			MsgBox("Enter username/password.", vbInformation, "Log In")
		Else
			logIn()
		End If
	End Sub
	Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
		Form2.Show()
		Me.Hide()
	End Sub

	Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
		Me.Close()
	End Sub
End Class

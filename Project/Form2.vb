Imports System.Data.SqlClient

Public Class Form2
	Dim connect As New databaseConnection

	Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
		Form1.Show()
		Me.Close()
	End Sub

	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
		If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Then
			MsgBox("Do not leave field/s empty.", vbInformation, "Add User")
		ElseIf TextBox4.Text = TextBox5.Text Then
			Dim addUser As New SqlCommand("INSERT INTO LogIn_Table (EmpID, EmpName, Uname, Pword) VALUES (@EmpID, @EmpName, @Uname, @Pword)", connect.connect_db)
			addUser.Parameters.AddWithValue("EmpID", TextBox1.Text)
			addUser.Parameters.AddWithValue("EmpName", TextBox2.Text)
			addUser.Parameters.AddWithValue("Uname", TextBox3.Text)
			addUser.Parameters.AddWithValue("Pword", TextBox4.Text)

			connect.connect_db.Open()
			addUser.ExecuteNonQuery()
			connect.connect_db.Close()

			MsgBox("User added.", vbInformation, "Add user")
			If vbOK Then
				Form3.Show()
				Me.Hide()
			End If
		Else
			MsgBox("Password does not match.", vbInformation, "Add User")
		End If
	End Sub
End Class
Imports System.Data.SqlClient

Public Class Form4
	Dim connect As New databaseConnection
	Dim sqlsource As New BindingSource

	Public Sub loadProductGroup()
		Dim getProductGroup As New SqlCommand("SELECT * FROM ProductGroup_Table", connect.connect_db)
		Dim productGroupAdapter As New SqlDataAdapter(getProductGroup)
		Dim productGroupTable As New DataSet
		productGroupAdapter.Fill(productGroupTable)
		Dim productGroupOut As DataTableCollection = productGroupTable.Tables

		Dim viewProductGroup As New DataView(productGroupOut(0))
		DataGridView1.DataSource = viewProductGroup
		DataGridView1.Refresh()
	End Sub

	Public Sub addProductGroup()
		Dim addProductGroupItem As New SqlCommand("INSERT INTO ProductGroup_Table (ProductGroup) VALUES (@ProductGroup)", connect.connect_db)
		addProductGroupItem.Parameters.AddWithValue("@ProductGroup", TextBox1.Text)

		connect.connect_db.Open()
		addProductGroupItem.ExecuteNonQuery()
		connect.connect_db.Close()

		MsgBox("Product group added.", vbInformation, "Add Product Group")
	End Sub

	Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		loadProductGroup()
	End Sub

	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
		If TextBox1.Text = "" Then
			MsgBox("Enter product group to add.", vbInformation, "Add Product Group")
		Else
			addProductGroup()
			loadProductGroup()
			TextBox1.Text = ""
		End If
	End Sub

	Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
		Me.Close()
	End Sub
End Class
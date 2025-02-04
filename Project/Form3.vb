Imports System.Data.SqlClient

Public Class Form3
	Dim connect As New databaseConnection
	Dim sqlSource As New BindingSource

	Dim storeProductID As String
	Dim storeProductName As String
	Dim storeProductPrice As String
	Dim storeProductGroup As String
	Dim storeProductDateAq As Date
	Dim storeProductDateExp As Date

	Public Function setID() As Integer
		Dim randomID As Integer
		Dim idTable As New DataTable

		Randomize()

		randomID = CInt(Int((799999 - 100000 + 1) * Rnd() + 100000))

		Do
			randomID = CInt(Int((799999 - 100000 + 1) * Rnd() + 100000))

			Dim idCommand As New SqlCommand("SELECT ProductID FROM Product_Table WHERE ProductID = @productID", connect.connect_db)
			idCommand.Parameters.AddWithValue("@productID", randomID)

			Dim idAdapter As New SqlDataAdapter(idCommand)
			idTable.Clear()
			idAdapter.Fill(idTable)

		Loop While idTable.Rows.Count >= 1

		Return randomID
	End Function

	Public Sub Clear()
		TextBox2.Text = ""
		TextBox3.Text = ""
		ComboBox1.SelectedIndex = 0
	End Sub

	Public Sub refreshTotalItemCount()
		Dim fetchProductList As New SqlCommand("SELECT * FROM Product_Table", connect.connect_db)
		Dim totalAdapter As New SqlDataAdapter(fetchProductList)
		Dim productDataTable As New DataSet
		totalAdapter.Fill(productDataTable)

		Dim totalItems As Integer = productDataTable.Tables(0).Rows.Count
		Label7.Text = "Total items: " & totalItems
	End Sub

	Public Sub refreshSearchItemCount()
		Dim searchItems As Integer = DataGridView1.Rows.Count - 1
		Label7.Text = "Search matches: " & searchItems & " items."
	End Sub

	Public Sub addProducts()
		Dim addProductItem As New SqlCommand("INSERT INTO Product_Table (ProductID, ProductName, ProductPrice, ProductGroup, DateAq, DateExp) values (@ProductID, @ProductName, @ProductPrice, @ProductGroup, @DateAq, @DateExp)", connect.connect_db)
		addProductItem.Parameters.AddWithValue("@ProductID", TextBox1.Text)
		addProductItem.Parameters.AddWithValue("@ProductName", TextBox2.Text)
		addProductItem.Parameters.AddWithValue("@ProductPrice", TextBox3.Text)
		addProductItem.Parameters.AddWithValue("@ProductGroup", ComboBox1.Text)
		addProductItem.Parameters.AddWithValue("@DateAq", DateTimePicker1.Value)
		addProductItem.Parameters.AddWithValue("@DateExp", DateTimePicker2.Value)

		connect.connect_db.Open()
		addProductItem.ExecuteNonQuery()
		connect.connect_db.Close()

		TextBox1.Text = setID()
		TextBox2.Text = ""
		TextBox3.Text = ""

		MsgBox("Added product successfully.", vbInformation, "Add Product")
	End Sub

	Public Sub editProduct()
		Dim editProductItem As New SqlCommand("Update Product_Table SET ProductName = @updateProductName, ProductPrice = @updateProductPrice, ProductGroup = @updateProductGroup, DateAq = @updateDateaq, DateExp = @updateDateExp WHERE ProductID = @currentProductID", connect.connect_db)
		editProductItem.Parameters.AddWithValue("@currentProductID", storeProductID)
		editProductItem.Parameters.AddWithValue("@updateProductName", TextBox2.Text)
		editProductItem.Parameters.AddWithValue("@updateProductPrice", TextBox3.Text)
		editProductItem.Parameters.AddWithValue("@updateProductGroup", ComboBox1.Text)
		editProductItem.Parameters.AddWithValue("@updateDateAq", DateTimePicker1.Value)
		editProductItem.Parameters.AddWithValue("@updateDateExp", DateTimePicker2.Value)

		connect.connect_db.Open()
		editProductItem.ExecuteNonQuery()
		connect.connect_db.Close()

		MsgBox("Product updated.", vbOK, "Edit Product")
	End Sub

	Public Sub deleteProduct()
		Dim deleteProduct As New SqlCommand("DELETE FROM Product_Table WHERE ProductID = @deleteProductID", connect.connect_db)
		deleteProduct.Parameters.AddWithValue("@deleteProductID", storeProductID)

		connect.connect_db.Open()
		deleteProduct.ExecuteNonQuery()
		connect.connect_db.Close()
	End Sub

	Public Sub searchProduct()
		Dim search As New SqlCommand("SELECT * FROM Product_Table WHERE ProductID LIKE @searchText OR ProductName LIKE @searchText OR ProductPrice LIKE @searchText OR ProductGroup LIKE @searchText OR DateAq LIKE @searchText OR DateExp LIKE @searchText", connect.connect_db)
		search.Parameters.AddWithValue("@searchText", "%" & TextBox4.Text & "%")

		Dim searchAdapter As New SqlDataAdapter(search)
		Dim searchData As New DataSet
		searchAdapter.Fill(searchData)
		Dim searchTable As DataTableCollection = searchData.Tables

		Dim searchView As New DataView(searchTable(0))
		sqlSource.DataSource = searchView
		DataGridView1.DataSource = searchView
		DataGridView1.Refresh()
	End Sub

	Public Sub loadProductGroup()
		Dim fetchProductGroup As New SqlCommand("SELECT * FROM ProductGroup_Table ORDER BY ProductGroup ASC", connect.connect_db)
		Dim groupFetch As New SqlDataAdapter(fetchProductGroup)
		Dim groupDataTable As New DataTable()
		groupFetch.Fill(groupDataTable)

		ComboBox1.DataSource = groupDataTable
		ComboBox1.DisplayMember = "ProductGroup"
	End Sub

	Public Sub loadProdcts()
		Dim fetchProductList As New SqlCommand("SELECT * FROM Product_Table", connect.connect_db)
		Dim productAdapter As New SqlDataAdapter(fetchProductList)
		Dim productDataTable As New DataSet
		productAdapter.Fill(productDataTable)
		Dim productTable As DataTableCollection = productDataTable.Tables

		Dim fetchedTable As New DataView(productTable(0))
		DataGridView1.DataSource = fetchedTable
		DataGridView1.Refresh()
	End Sub

	Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		TextBox1.Text = setID()
		loadProdcts()
		loadProductGroup()
		refreshTotalItemCount()

		TextBox1.ReadOnly = True
		ComboBox1.SelectedIndex = 0
	End Sub

	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
		If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or ComboBox1.Text = "" Then
			MsgBox("Enter required fields.", vbInformation, "Add Product")
		Else
			addProducts()
			loadProdcts()
			loadProductGroup()
			refreshTotalItemCount()
			Clear()
		End If
	End Sub

	Dim editMode As Boolean = False

	Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
		If storeProductID = "" Then
			MsgBox("Select product to edit.")
		Else
			If editMode = False Then
				Dim confirmEdit As String = MsgBox("Do you want to edit " & storeProductName & "?", vbYesNo, "Edit")

				If confirmEdit = vbYes Then
					TextBox1.Text = storeProductID
					TextBox2.Text = storeProductName
					TextBox3.Text = storeProductPrice
					ComboBox1.Text = storeProductGroup
					DateTimePicker1.Value = storeProductDateAq
					DateTimePicker2.Value = storeProductDateExp

					editMode = True
					Button2.Text = "Update"
					Button1.Enabled = False
					Button3.Enabled = False
				Else
					MsgBox("Edit canceled.", vbOK)
				End If
			ElseIf editMode = True Then
				editProduct()
				loadProdcts()
				loadProductGroup()
				Clear()

				TextBox1.Text = setID()
				Button2.Text = "Edit"
				Button1.Enabled = True
				Button3.Enabled = False
				editMode = False
			End If
		End If
	End Sub

	Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
		Dim deleteConfirmation As String = MsgBox("Do you want to delete " & storeProductName & "?", vbYesNo, "Delete")
		If deleteConfirmation = vbYes Then
			deleteProduct()
			loadProdcts()
			loadProductGroup()
		Else
			MsgBox("Delete canceled", vbInformation, "Delete")
		End If
	End Sub
	Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
		If TextBox4.Text = "" Then
			MsgBox("Search bar empty!", vbInformation, "Search")
		Else
			searchProduct()
			refreshSearchItemCount()
		End If
	End Sub

	Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
		loadProdcts()
		loadProductGroup()
		refreshTotalItemCount()
		TextBox4.Text = ""
	End Sub

	Private Sub ComboBox1_Click(sender As Object, e As EventArgs) Handles ComboBox1.Click
		loadProductGroup()
	End Sub

	Private Sub AddProductGroupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddProductGroupToolStripMenuItem.Click
		Form4.ShowDialog()
	End Sub

	Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
		Dim index As Integer = e.RowIndex

		Dim selectedItem As DataGridViewRow = DataGridView1.Rows(index)

		storeProductID = selectedItem.Cells(0).Value.ToString()
		storeProductName = selectedItem.Cells(1).Value.ToString()
		storeProductPrice = selectedItem.Cells(2).Value.ToString()
		storeProductGroup = selectedItem.Cells(3).Value.ToString()
		storeProductDateAq = selectedItem.Cells(4).Value
		storeProductDateExp = selectedItem.Cells(5).Value
	End Sub
End Class
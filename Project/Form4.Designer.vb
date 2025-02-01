<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form4
	Inherits System.Windows.Forms.Form

	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> _
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		Try
			If disposing AndAlso components IsNot Nothing Then
				components.Dispose()
			End If
		Finally
			MyBase.Dispose(disposing)
		End Try
	End Sub

	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer

	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.  
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> _
	Private Sub InitializeComponent()
		Me.TextBox1 = New System.Windows.Forms.TextBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Button1 = New System.Windows.Forms.Button()
		Me.Button2 = New System.Windows.Forms.Button()
		Me.DataGridView1 = New System.Windows.Forms.DataGridView()
		CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'TextBox1
		'
		Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
		Me.TextBox1.Location = New System.Drawing.Point(148, 41)
		Me.TextBox1.Name = "TextBox1"
		Me.TextBox1.Size = New System.Drawing.Size(270, 26)
		Me.TextBox1.TabIndex = 2
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
		Me.Label1.Location = New System.Drawing.Point(29, 44)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(113, 20)
		Me.Label1.TabIndex = 3
		Me.Label1.Text = "Product Group"
		'
		'Button1
		'
		Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
		Me.Button1.Location = New System.Drawing.Point(33, 88)
		Me.Button1.Name = "Button1"
		Me.Button1.Size = New System.Drawing.Size(185, 29)
		Me.Button1.TabIndex = 4
		Me.Button1.Text = "Add"
		Me.Button1.UseVisualStyleBackColor = True
		'
		'Button2
		'
		Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
		Me.Button2.Location = New System.Drawing.Point(233, 88)
		Me.Button2.Name = "Button2"
		Me.Button2.Size = New System.Drawing.Size(185, 29)
		Me.Button2.TabIndex = 5
		Me.Button2.Text = "Cancel"
		Me.Button2.UseVisualStyleBackColor = True
		'
		'DataGridView1
		'
		Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.DataGridView1.Location = New System.Drawing.Point(446, 12)
		Me.DataGridView1.Name = "DataGridView1"
		Me.DataGridView1.Size = New System.Drawing.Size(338, 140)
		Me.DataGridView1.TabIndex = 6
		'
		'Form4
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(800, 167)
		Me.Controls.Add(Me.DataGridView1)
		Me.Controls.Add(Me.Button2)
		Me.Controls.Add(Me.Button1)
		Me.Controls.Add(Me.TextBox1)
		Me.Controls.Add(Me.Label1)
		Me.MaximizeBox = False
		Me.Name = "Form4"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "Form4"
		CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents TextBox1 As TextBox
	Friend WithEvents Label1 As Label
	Friend WithEvents Button1 As Button
	Friend WithEvents Button2 As Button
	Friend WithEvents DataGridView1 As DataGridView
End Class

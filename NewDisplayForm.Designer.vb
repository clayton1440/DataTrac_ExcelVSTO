<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class NewDisplayForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.DisplayName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComPort = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BaudRate = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TriColorMode = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.NativeFlash = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.RadioButton5 = New System.Windows.Forms.RadioButton()
        Me.NativeBeep = New System.Windows.Forms.RadioButton()
        Me.DisplayAddress = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.ColumnCount = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.RowCount = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.yPos = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.xPos = New System.Windows.Forms.NumericUpDown()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.CancelButton1 = New System.Windows.Forms.Button()
        Me.SaveButton1 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.DisplayAddress, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.ColumnCount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RowCount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.yPos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.xPos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DisplayName
        '
        Me.DisplayName.Location = New System.Drawing.Point(12, 28)
        Me.DisplayName.Name = "DisplayName"
        Me.DisplayName.Size = New System.Drawing.Size(258, 20)
        Me.DisplayName.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Address"
        '
        'ComPort
        '
        Me.ComPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComPort.FormattingEnabled = True
        Me.ComPort.Location = New System.Drawing.Point(78, 73)
        Me.ComPort.Name = "ComPort"
        Me.ComPort.Size = New System.Drawing.Size(93, 21)
        Me.ComPort.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(75, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "COM Port"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(185, 57)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Baud Rate"
        '
        'BaudRate
        '
        Me.BaudRate.FormattingEnabled = True
        Me.BaudRate.Items.AddRange(New Object() {"9600", "19200"})
        Me.BaudRate.Location = New System.Drawing.Point(188, 73)
        Me.BaudRate.Name = "BaudRate"
        Me.BaudRate.Size = New System.Drawing.Size(82, 21)
        Me.BaudRate.TabIndex = 6
        Me.BaudRate.Text = "19200"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TriColorMode)
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 112)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(82, 61)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Color Mode"
        '
        'TriColorMode
        '
        Me.TriColorMode.AutoSize = True
        Me.TriColorMode.Location = New System.Drawing.Point(6, 38)
        Me.TriColorMode.Name = "TriColorMode"
        Me.TriColorMode.Size = New System.Drawing.Size(64, 17)
        Me.TriColorMode.TabIndex = 1
        Me.TriColorMode.TabStop = True
        Me.TriColorMode.Text = "Tri-Color"
        Me.TriColorMode.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(6, 19)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(52, 17)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Mono"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RadioButton3)
        Me.GroupBox2.Controls.Add(Me.NativeFlash)
        Me.GroupBox2.Location = New System.Drawing.Point(100, 112)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(82, 61)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Native Flash"
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Checked = True
        Me.RadioButton3.Location = New System.Drawing.Point(6, 38)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(50, 17)
        Me.RadioButton3.TabIndex = 1
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "False"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'NativeFlash
        '
        Me.NativeFlash.AutoSize = True
        Me.NativeFlash.Location = New System.Drawing.Point(6, 19)
        Me.NativeFlash.Name = "NativeFlash"
        Me.NativeFlash.Size = New System.Drawing.Size(47, 17)
        Me.NativeFlash.TabIndex = 0
        Me.NativeFlash.Text = "True"
        Me.NativeFlash.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.RadioButton5)
        Me.GroupBox3.Controls.Add(Me.NativeBeep)
        Me.GroupBox3.Location = New System.Drawing.Point(188, 112)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(82, 61)
        Me.GroupBox3.TabIndex = 9
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Native Beep"
        '
        'RadioButton5
        '
        Me.RadioButton5.AutoSize = True
        Me.RadioButton5.Checked = True
        Me.RadioButton5.Location = New System.Drawing.Point(6, 38)
        Me.RadioButton5.Name = "RadioButton5"
        Me.RadioButton5.Size = New System.Drawing.Size(50, 17)
        Me.RadioButton5.TabIndex = 1
        Me.RadioButton5.TabStop = True
        Me.RadioButton5.Text = "False"
        Me.RadioButton5.UseVisualStyleBackColor = True
        '
        'NativeBeep
        '
        Me.NativeBeep.AutoSize = True
        Me.NativeBeep.Location = New System.Drawing.Point(6, 19)
        Me.NativeBeep.Name = "NativeBeep"
        Me.NativeBeep.Size = New System.Drawing.Size(47, 17)
        Me.NativeBeep.TabIndex = 0
        Me.NativeBeep.Text = "True"
        Me.NativeBeep.UseVisualStyleBackColor = True
        '
        'DisplayAddress
        '
        Me.DisplayAddress.Location = New System.Drawing.Point(12, 73)
        Me.DisplayAddress.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.DisplayAddress.Name = "DisplayAddress"
        Me.DisplayAddress.Size = New System.Drawing.Size(52, 20)
        Me.DisplayAddress.TabIndex = 10
        Me.DisplayAddress.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.ColumnCount)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.RowCount)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 179)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(126, 106)
        Me.GroupBox4.TabIndex = 11
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Size"
        '
        'ColumnCount
        '
        Me.ColumnCount.Location = New System.Drawing.Point(18, 74)
        Me.ColumnCount.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.ColumnCount.Name = "ColumnCount"
        Me.ColumnCount.Size = New System.Drawing.Size(64, 20)
        Me.ColumnCount.TabIndex = 14
        Me.ColumnCount.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(15, 59)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Columns"
        '
        'RowCount
        '
        Me.RowCount.Location = New System.Drawing.Point(18, 34)
        Me.RowCount.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.RowCount.Name = "RowCount"
        Me.RowCount.Size = New System.Drawing.Size(64, 20)
        Me.RowCount.TabIndex = 12
        Me.RowCount.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Rows"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.yPos)
        Me.GroupBox5.Controls.Add(Me.Label7)
        Me.GroupBox5.Controls.Add(Me.xPos)
        Me.GroupBox5.Controls.Add(Me.Label8)
        Me.GroupBox5.Location = New System.Drawing.Point(144, 179)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(126, 106)
        Me.GroupBox5.TabIndex = 12
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Position"
        '
        'yPos
        '
        Me.yPos.Location = New System.Drawing.Point(18, 74)
        Me.yPos.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.yPos.Name = "yPos"
        Me.yPos.Size = New System.Drawing.Size(64, 20)
        Me.yPos.TabIndex = 18
        Me.yPos.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(15, 59)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 13)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Y Position"
        '
        'xPos
        '
        Me.xPos.Location = New System.Drawing.Point(18, 34)
        Me.xPos.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.xPos.Name = "xPos"
        Me.xPos.Size = New System.Drawing.Size(64, 20)
        Me.xPos.TabIndex = 16
        Me.xPos.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(15, 19)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(54, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "X Position"
        '
        'CancelButton1
        '
        Me.CancelButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CancelButton1.Location = New System.Drawing.Point(191, 291)
        Me.CancelButton1.Name = "CancelButton1"
        Me.CancelButton1.Size = New System.Drawing.Size(83, 27)
        Me.CancelButton1.TabIndex = 13
        Me.CancelButton1.Text = "Cancel"
        Me.CancelButton1.UseVisualStyleBackColor = True
        '
        'SaveButton1
        '
        Me.SaveButton1.Location = New System.Drawing.Point(102, 291)
        Me.SaveButton1.Name = "SaveButton1"
        Me.SaveButton1.Size = New System.Drawing.Size(83, 27)
        Me.SaveButton1.TabIndex = 14
        Me.SaveButton1.Text = "Save"
        Me.SaveButton1.UseVisualStyleBackColor = True
        '
        'NewDisplayForm
        '
        Me.AcceptButton = Me.SaveButton1
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.CancelButton1
        Me.ClientSize = New System.Drawing.Size(286, 327)
        Me.Controls.Add(Me.SaveButton1)
        Me.Controls.Add(Me.CancelButton1)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.DisplayAddress)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.BaudRate)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ComPort)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DisplayName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "NewDisplayForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "New Display"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.DisplayAddress, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.ColumnCount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RowCount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.yPos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.xPos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DisplayName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ComPort As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents BaudRate As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TriColorMode As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents RadioButton3 As RadioButton
    Friend WithEvents NativeFlash As RadioButton
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents RadioButton5 As RadioButton
    Friend WithEvents NativeBeep As RadioButton
    Friend WithEvents DisplayAddress As NumericUpDown
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents ColumnCount As NumericUpDown
    Friend WithEvents Label6 As Label
    Friend WithEvents RowCount As NumericUpDown
    Friend WithEvents Label5 As Label
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents yPos As NumericUpDown
    Friend WithEvents Label7 As Label
    Friend WithEvents xPos As NumericUpDown
    Friend WithEvents Label8 As Label
    Friend WithEvents CancelButton1 As Button
    Friend WithEvents SaveButton1 As Button
End Class

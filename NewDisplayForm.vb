Public Class NewDisplayForm

    Private Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Shared Function NewDisplay() As Display
        Dim form As New NewDisplayForm
        form.ShowDialog()
        If form.DialogResult = DialogResult.OK Then
            Dim display As New Display
            display.Name = form.DisplayName.Text
            display.Port = form.ComPort.Text
            display.BaudRate = form.BaudRate.Text
            display.Address = form.DisplayAddress.Value.ToString.PadLeft(3, "0")
            display.Rows = form.RowCount.Value
            display.Columns = form.ColumnCount.Value
            display.ColorType = If(form.TriColorMode.Checked, DisplayColorType.Tri, DisplayColorType.Mono)
            display.XPos = form.xPos.Value
            display.yPos = form.yPos.Value
            Return display
        Else
            Return Nothing
        End If

    End Function

    Public Shared Function EditDisplay(D As Display) As Display
        Dim form As New NewDisplayForm
        form.Text = "Edit Display"

        form.DisplayName.Text = D.Name
        form.ComPort.Text = D.Port
        form.BaudRate.Text = D.BaudRate
        form.DisplayAddress.Value = D.Address
        form.RowCount.Value = D.Rows
        form.ColumnCount.Value = D.Columns
        form.TriColorMode.Checked = D.ColorType = DisplayColorType.Tri
        form.NativeFlash.Checked = D.CanFlash
        form.xPos.Value = D.xPos
        form.yPos.Value = D.yPos

        form.ShowDialog()
        If form.DialogResult = DialogResult.OK Then
            D.Name = form.DisplayName.Text
            D.Port = form.ComPort.Text
            D.BaudRate = form.BaudRate.Text
            D.Address = form.DisplayAddress.Value.ToString.PadLeft(3, "0")
            D.Rows = form.RowCount.Value
            D.Columns = form.ColumnCount.Value
            D.ColorType = If(form.TriColorMode.Checked, DisplayColorType.Tri, DisplayColorType.Mono)
            D.CanFlash = form.NativeFlash.Checked
            D.xPos = form.xPos.Value
            D.yPos = form.yPos.Value
            Return D
        Else
            Return D
        End If

    End Function

    Private Sub NewDisplayForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'add com ports to combobox1
        For Each sp As String In My.Computer.Ports.SerialPortNames
            ComPort.Items.Add(sp)
        Next
    End Sub

    Private Sub NumericUpDown_mousewheel(sender As Object, e As HandledMouseEventArgs) Handles DisplayAddress.MouseWheel, RowCount.MouseWheel, ColumnCount.MouseWheel, yPos.MouseWheel, xPos.MouseWheel
        e.Handled = True
        If e.Delta > 0 Then
            sender.UpButton()
        Else
            sender.DownButton()
        End If
    End Sub


    Private Sub SaveButton1_Click(sender As Object, e As EventArgs) Handles SaveButton1.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub CancelButton1_Click(sender As Object, e As EventArgs) Handles CancelButton1.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class
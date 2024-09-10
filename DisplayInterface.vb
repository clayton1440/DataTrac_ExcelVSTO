

Imports Microsoft.Office.Interop.Excel

Public Class DisplayInterface

    Public Sub New()
        InitializeComponent()


        ToolStrip1.ImageScalingSize = NewSizeFromScale(New Size(18, 18))
        Me.Size = NewSizeFromScale(New Size(850, 500))
        SplitContainer1.Panel1MinSize = Math.Round(100 * DisplayScale())

    End Sub

    Private Function DisplayScale() As Double
        Dim scale As Double = 1.0
        Dim graphics As Graphics = Me.CreateGraphics()
        Dim DpiX As Single = graphics.DpiX
        Dim ScaleX As Double = DpiX / 96

        Return ScaleX
    End Function

    Private Function NewSizeFromScale(SizeInput As Size) As Size
        Return New Size(Math.Round(SizeInput.Width * DisplayScale()), Math.Round(SizeInput.Height * DisplayScale()))
    End Function


    Private ThisWorkbook As Excel.Workbook = Globals.ThisAddIn.Application.ActiveWorkbook
    Public DisplayTable As Excel.ListObject
    Public MessageTable As Excel.ListObject
    Public FieldTable As Excel.ListObject

    Public XPosColumn As New DataGridViewTextBoxColumn
    Public YPosColumn As New DataGridViewTextBoxColumn
    Public JustifColumn As New DataGridViewComboBoxColumn
    Public MessageTextColumn As New DataGridViewTextBoxColumn
    Public FlashColumn As New DataGridViewCheckBoxColumn
    Public ColorColumn As New DataGridViewComboBoxColumn

    Public Displays As New Dictionary(Of String, Display)


    Private Sub InterfaceForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load



        XPosColumn.Name = "Row"
        XPosColumn.ValueType = GetType(Integer)
        XPosColumn.FillWeight = 50


        YPosColumn.Name = "Column"
        YPosColumn.ValueType = GetType(Integer)
        YPosColumn.FillWeight = 50


        JustifColumn.Name = "L/C/R"
        JustifColumn.Items.Add("Left")
        JustifColumn.Items.Add("Center")
        JustifColumn.Items.Add("Right")
        JustifColumn.FillWeight = 58
        JustifColumn.DefaultCellStyle.NullValue = "Left"


        MessageTextColumn.Name = "Message"
        MessageTextColumn.ValueType = GetType(String)
        MessageTextColumn.FillWeight = 450


        FlashColumn.Name = "Flash"
        FlashColumn.FillWeight = 45


        ColorColumn.Name = "Color"
        ColorColumn.FillWeight = 60
        ColorColumn.Items.Add("RED")
        ColorColumn.Items.Add("GRN")
        ColorColumn.Items.Add("AMB")
        ColorColumn.DefaultCellStyle.NullValue = "RED"


        DGVMessageEditor.Columns.Add(XPosColumn)
        DGVMessageEditor.Columns.Add(YPosColumn)
        DGVMessageEditor.Columns.Add(JustifColumn)
        DGVMessageEditor.Columns.Add(MessageTextColumn)
        DGVMessageEditor.Columns.Add(FlashColumn)
        DGVMessageEditor.Columns.Add(ColorColumn)

        If ThisWorkbook IsNot Nothing Then
            DisplayTable = ThisWorkbook.Sheets("Datatrac_Display").ListObjects("Datatrac_Display")
            MessageTable = ThisWorkbook.Sheets("Datatrac_Message").ListObjects("Datatrac_Message")
            FieldTable = ThisWorkbook.Sheets("Datatrac_Fields").ListObjects("Datatrac_Fields")
        Else
            MsgBox("No workbook is open.  Please open a workbook and try again.")
            Me.Close()
        End If

        If DisplayTable.ListRows.Count > 0 Then
            Dim NodeIndex As Integer
            For Each row As Excel.ListRow In DisplayTable.ListRows
                If row.Range(1).Value Is Nothing OrElse row.Range(1).Value = "" Then Continue For
                Dim newDisplay As New Display
                newDisplay.Name = row.Range(1).Value
                newDisplay.Address = row.Range(2).Value
                newDisplay.Port = row.Range(3).Value
                newDisplay.BaudRate = row.Range(4).Value
                newDisplay.Columns = row.Range(5).Value
                newDisplay.Rows = row.Range(6).Value
                newDisplay.ColorType = row.Range(7).Value
                newDisplay.ID = row.Range(8).Value
                newDisplay.xPos = row.Range(9).Value
                newDisplay.yPos = row.Range(10).Value

                NodeIndex = TreeView1.Nodes(0).Nodes.Add(newDisplay.Name).Index

                'TreeView1.Nodes(0).Nodes(newDisplay.Name).Tag = TreeView1.Nodes(0).Nodes.Count - 1

                If MessageTable.ListRows.Count > 0 Then
                    For Each mrow As Excel.ListRow In MessageTable.ListRows
                        If mrow.Range(5).Value = newDisplay.ID Then
                            Dim newMessage As New Message
                            newMessage.ID = mrow.Range(1).Value
                            newMessage.Name = mrow.Range(2).Value
                            newMessage.CreationDate = mrow.Range(3).Value
                            newMessage.ModifiedDate = mrow.Range(4).Value

                            TreeView1.Nodes(0).Nodes(NodeIndex).Nodes.Add(newMessage.Name)

                            If FieldTable.ListRows.Count > 0 Then
                                For Each frow As ListRow In FieldTable.ListRows
                                    If frow.Range(1).Value = newMessage.ID Then
                                        Dim newField As New MessageField
                                        newField.Name = frow.Range(2).Value
                                        newField.Type = frow.Range(3).Value
                                        newField.Value = frow.Range(4).Value
                                        newField.Color = frow.Range(5).Value
                                        newField.Flashing = frow.Range(6).Value
                                        newField.Visible = frow.Range(7).Value
                                        newField.xPos = frow.Range(8).Value
                                        newField.yPos = frow.Range(9).Value
                                        newField.Justification = frow.Range(10).Value

                                        newMessage.Fields.Add(newField.Name, newField)
                                    End If
                                Next
                            End If

                            newDisplay.Messages.Add(newMessage.Name, newMessage)

                        End If
                    Next
                End If

                Displays.Add(newDisplay.Name, newDisplay)

            Next
        End If


        'Try
        '    If ThisWorkbook.Sheets("Datatrac_Display") IsNot Nothing AndAlso ThisWorkbook.Sheets("Datatrac_Message") IsNot Nothing AndAlso ThisWorkbook.Sheets("Datatrac_Fields") IsNot Nothing Then
        '        


        '        If DisplayTable.ListRows.Count > 0 Then
        '            Dim NodeIndex As Integer
        '            For Each row As Excel.ListRow In DisplayTable.ListRows
        '                If row.Range(1).Value Is Nothing OrElse row.Range(1).Value = "" Then Continue For
        '                Dim newDisplay As New Display
        '                newDisplay.Name = row.Range(1).Value
        '                newDisplay.Address = row.Range(2).Value
        '                newDisplay.Port = row.Range(3).Value
        '                newDisplay.BaudRate = row.Range(4).Value
        '                newDisplay.Columns = row.Range(5).Value
        '                newDisplay.Rows = row.Range(6).Value
        '                newDisplay.ColorType = row.Range(7).Value
        '                newDisplay.ID = row.Range(8).Value
        '                newDisplay.xPos = row.Range(9).Value
        '                newDisplay.yPos = row.Range(10).Value

        '                NodeIndex = TreeView1.Nodes(0).Nodes.Add(newDisplay.Name).Index

        '                'TreeView1.Nodes(0).Nodes(newDisplay.Name).Tag = TreeView1.Nodes(0).Nodes.Count - 1

        '                If MessageTable.ListRows.Count > 0 Then
        '                    For Each mrow As Excel.ListRow In MessageTable.ListRows
        '                        If mrow.Range(5).Value = newDisplay.ID Then
        '                            Dim newMessage As New Message
        '                            newMessage.ID = mrow.Range(1).Value
        '                            newMessage.Name = mrow.Range(2).Value
        '                            newMessage.CreationDate = mrow.Range(3).Value
        '                            newMessage.ModifiedDate = mrow.Range(4).Value

        '                            TreeView1.Nodes(0).Nodes(NodeIndex).Nodes.Add(newMessage.Name)

        '                            If FieldTable.ListRows.Count > 0 Then
        '                                For Each frow As ListRow In FieldTable.ListRows
        '                                    If frow.Range(1).Value = newMessage.ID Then
        '                                        Dim newField As New MessageField
        '                                        newField.Name = frow.Range(2).Value
        '                                        newField.Type = frow.Range(3).Value
        '                                        newField.Value = frow.Range(4).Value
        '                                        newField.Color = frow.Range(5).Value
        '                                        newField.Flashing = frow.Range(6).Value
        '                                        newField.Visible = frow.Range(7).Value
        '                                        newField.xPos = frow.Range(8).Value
        '                                        newField.yPos = frow.Range(9).Value
        '                                        newField.Justification = frow.Range(10).Value

        '                                        newMessage.Fields.Add(newField.Name, newField)
        '                                    End If
        '                                Next
        '                            End If

        '                            newDisplay.Messages.Add(newMessage.Name, newMessage)

        '                        End If
        '                    Next
        '                End If

        '                Displays.Add(newDisplay.Name, newDisplay)

        '            Next
        '        End If
        '    End If
        'Catch ex As Exception
        '    Try
        '        ThisWorkbook.Sheets("Datatrac_Display").Delete()
        '    Catch
        '    End Try
        '    Try
        '        ThisWorkbook.Sheets("Datatrac_Message").Delete()
        '    Catch
        '    End Try
        '    Try
        '        ThisWorkbook.Sheets("Datatrac_Fields").Delete()
        '    Catch
        '    End Try


        '    Dim DisplaySheet As Excel.Worksheet = ThisWorkbook.Sheets.Add()
        '    DisplaySheet.Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVeryHidden
        '    DisplaySheet.Name = "Datatrac_Display"

        '    Dim MessageSheet As Excel.Worksheet = ThisWorkbook.Sheets.Add()
        '    MessageSheet.Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVeryHidden
        '    MessageSheet.Name = "Datatrac_Message"

        '    Dim FieldSheet As Excel.Worksheet = ThisWorkbook.Sheets.Add()
        '    FieldSheet.Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVeryHidden
        '    FieldSheet.Name = "Datatrac_Fields"

        '    'add tables to each sheet (ListObject)
        '    DisplayTable = DisplaySheet.ListObjects.Add(Excel.XlListObjectSourceType.xlSrcRange, DisplaySheet.Range("A1:J1"), , Excel.XlYesNoGuess.xlYes)
        '    MessageTable = MessageSheet.ListObjects.Add(Excel.XlListObjectSourceType.xlSrcRange, MessageSheet.Range("A1:E1"), , Excel.XlYesNoGuess.xlYes)
        '    FieldTable = FieldSheet.ListObjects.Add(Excel.XlListObjectSourceType.xlSrcRange, FieldSheet.Range("A1:J1"), , Excel.XlYesNoGuess.xlYes)

        '    'set the tables
        '    DisplayTable.Name = "Datatrac_Display"
        '    MessageTable.Name = "Datatrac_Message"
        '    FieldTable.Name = "Datatrac_Fields"

        '    'add column headers
        '    DisplayTable.HeaderRowRange(1).Value = {"Name"}
        '    DisplayTable.HeaderRowRange(2).value = {"Address"}
        '    DisplayTable.HeaderRowRange(3).value = {"Port"}
        '    DisplayTable.HeaderRowRange(4).value = {"BaudRate"}
        '    DisplayTable.HeaderRowRange(5).value = {"Columns"}
        '    DisplayTable.HeaderRowRange(6).value = {"Rows"}
        '    DisplayTable.HeaderRowRange(7).value = {"ColorType"}
        '    DisplayTable.HeaderRowRange(8).Value = {"ID"}
        '    DisplayTable.HeaderRowRange(9).Value = {"XPos"}
        '    DisplayTable.HeaderRowRange(10).Value = {"YPos"}

        '    MessageTable.HeaderRowRange(1).Value = {"ID"}
        '    MessageTable.HeaderRowRange(2).value = {"MessageName"}
        '    MessageTable.HeaderRowRange(3).value = {"CreationDate"}
        '    MessageTable.HeaderRowRange(4).value = {"ModifiedDate"}
        '    MessageTable.HeaderRowRange(5).value = {"DisplayID"}

        '    FieldTable.HeaderRowRange(1).Value = {"MessageID"}
        '    FieldTable.HeaderRowRange(2).value = {"FieldName"}
        '    FieldTable.HeaderRowRange(3).value = {"Type"}
        '    FieldTable.HeaderRowRange(4).value = {"Value"}
        '    FieldTable.HeaderRowRange(5).value = {"Color"}
        '    FieldTable.HeaderRowRange(6).value = {"Flashing"}
        '    FieldTable.HeaderRowRange(7).value = {"Visible"}
        '    FieldTable.HeaderRowRange(8).value = {"XPos"}
        '    FieldTable.HeaderRowRange(9).value = {"YPos"}
        '    FieldTable.HeaderRowRange(10).value = {"Justification"}

        'End Try


    End Sub

    Private Sub NewDisplayButton_Click(sender As Object, e As EventArgs) Handles NewDisplayToolStripMenuItem.Click
        Dim newDisplay As Display = NewDisplayForm.NewDisplay
        If newDisplay IsNot Nothing Then
            TreeView1.Nodes(0).Nodes.Add(newDisplay.Name)
            Displays.Add(newDisplay.Name, newDisplay)

            Dim newRow As Excel.ListRow = DisplayTable.ListRows.Add
            newRow.Range(1).Value = newDisplay.Name
            newRow.Range(2).Value = newDisplay.Address
            newRow.Range(3).Value = newDisplay.Port
            newRow.Range(4).Value = newDisplay.BaudRate
            newRow.Range(5).Value = newDisplay.Columns
            newRow.Range(6).Value = newDisplay.Rows
            newRow.Range(7).Value = newDisplay.ColorType
            newRow.Range(8).Value = newDisplay.Name.GetHashCode
            newRow.Range(9).Value = newDisplay.xPos
            newRow.Range(10).Value = newDisplay.yPos
        End If
    End Sub

    Private Sub TreeView1_ContextMenu(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseClick
        'check if right mouse button was clicked, and specifically only on a display node.
        If e.Button = MouseButtons.Right Then
            'show the context menu
            If e.Node.Level = 0 Then
                'set the selected node to the right clicked node
                TreeView1.SelectedNode = e.Node
                Node0CM.Show(TreeView1, e.Location)

            ElseIf e.Node.Level = 1 Then
                TreeView1.SelectedNode = e.Node
                Node1CM.Show(TreeView1, e.Location)

            ElseIf e.Node.Level = 2 Then
                TreeView1.SelectedNode = e.Node
                Node2CM.Show(TreeView1, e.Location)

            End If
        End If
    End Sub

    Private Sub TreeView1_MouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseClick
        If e.Node.Level = 2 Then 'message was selected
            Try
                Dim thisDisplay As Display = Displays(TreeView1.SelectedNode.Parent.Text)
                Dim thisMessage As Message = thisDisplay.Messages(TreeView1.SelectedNode.Text)
                ToolStrip1.Enabled = True
                MessagePreview.Image = DisplayPreview.CreateDisplayBitmap(thisDisplay)

                ToolStrip1.Enabled = True
                DGVMessageEditor.Rows.Clear()

                If thisMessage IsNot Nothing Then
                    For Each field In thisMessage.Fields
                        Dim newRow As New DataGridViewRow
                        newRow.CreateCells(DGVMessageEditor, field.Value.yPos, field.Value.xPos, field.Value.Justification.ToString, field.Value.Value, field.Value.Flashing, ColorToDGVColor(field.Value.Color))
                        DGVMessageEditor.Rows.Add(newRow)
                    Next
                End If

            Catch ex As Exception

            End Try
        Else
            ToolStrip1.Enabled = False
            DGVMessageEditor.Rows.Clear()
        End If
    End Sub

    Private Function ColorToDGVColor(c As DisplayColor) As String
        Select Case c
            Case DisplayColor.Red
                Return "RED"
            Case DisplayColor.Green
                Return "GRN"
            Case DisplayColor.Amber
                Return "AMB"
            Case Else
                Return "RED"
        End Select
    End Function

    Private Sub AddFieldButton_Click(sender As Object, e As EventArgs) Handles AddFieldButton.Click
        DGVMessageEditor.Rows.Add(1, 1, "Left", "", False, "RED")
    End Sub

    Private Sub RemoveFieldButton_Click(sender As Object, e As EventArgs) Handles RemoveFieldButton.Click
        DGVMessageEditor.Rows.RemoveAt(DGVMessageEditor.SelectedRows(0).Index)
    End Sub

    Private Sub CopyFieldButton_Click(sender As Object, e As EventArgs) Handles CopyFieldButton.Click
        DGVMessageEditor.Rows.AddCopy(DGVMessageEditor.SelectedRows(0).Index)
    End Sub

    Private Sub AddMessageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddMessageToolStripMenuItem.Click
        Dim MessageName As String = InputBox("Enter the name of the new message", "New Message", "")
        If MessageName <> "" Then
            Dim newMessage As New Message
            newMessage.Name = MessageName
            newMessage.ID = MessageName.GetHashCode
            newMessage.CreationDate = Date.Today
            newMessage.ModifiedDate = Date.Today
            TreeView1.Nodes(0).Nodes(TreeView1.SelectedNode.Index).Nodes.Add(newMessage.Name)
            Displays(TreeView1.SelectedNode.Text).Messages.Add(newMessage.Name, newMessage)

        End If
    End Sub
    Private Sub DeleteMessageToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DeleteMessageToolStripMenuItem1.Click
        'remove the message from the display table
        For Each row As ListRow In MessageTable.ListRows
            If row.Range(1).Value = Displays(TreeView1.SelectedNode.Parent.Text).Messages(TreeView1.SelectedNode.Text).ID Then
                row.Delete()
                Exit For
            End If
        Next

        Displays(TreeView1.SelectedNode.Parent.Text).Messages.Remove(TreeView1.SelectedNode.Text)
        TreeView1.SelectedNode.Remove()
    End Sub

    Private Sub SaveMessageButton_Click(sender As Object, e As EventArgs) Handles SaveMessageButton.Click
        DGVMessageEditor.EndEdit()

        Displays(TreeView1.SelectedNode.Parent.Text).Messages(TreeView1.SelectedNode.Text).Fields.Clear()
        For i = 0 To DGVMessageEditor.Rows.Count - 1
            If DGVMessageEditor.Rows(i).IsNewRow Then Continue For

            Dim newField As New MessageField
            newField.xPos = DGVMessageEditor.Rows(i).Cells(1).Value
            newField.yPos = DGVMessageEditor.Rows(i).Cells(0).Value
            newField.Justification = MessageField.JustificationFromString(DGVMessageEditor.Rows(i).Cells(2).Value)
            newField.Value = DGVMessageEditor.Rows(i).Cells(3).Value
            newField.Flashing = DGVMessageEditor.Rows(i).Cells(4).Value
            newField.Color = MessageField.ColorFromString(DGVMessageEditor.Rows(i).Cells(5).Value)
            newField.Visible = True
            newField.Name = $"{newField.xPos}_{newField.yPos}_{newField.Color}_{newField.Value.Replace(" "c, "_"c)}"

            Displays(TreeView1.SelectedNode.Parent.Text).Messages(TreeView1.SelectedNode.Text).Fields.Add(newField.Name, newField)
        Next

        MessagePreview.Image = DisplayPreview.CreateDisplayBitmap(Displays(TreeView1.SelectedNode.Parent.Text))


        'save the message and fields to excel tables
        Dim MessageRow As Integer = Nothing
        For Each row As ListRow In MessageTable.ListRows
            If row.Range(1).Value = Displays(TreeView1.SelectedNode.Parent.Text).Messages(TreeView1.SelectedNode.Text).ID Then
                MessageRow = row.Index
                Exit For
            End If
        Next
        If MessageRow = Nothing Then
            MessageRow = MessageTable.ListRows.Add.Index
        End If

        MessageTable.ListRows(MessageRow).Range(1).Value = Displays(TreeView1.SelectedNode.Parent.Text).Messages(TreeView1.SelectedNode.Text).ID
        MessageTable.ListRows(MessageRow).Range(2).Value = Displays(TreeView1.SelectedNode.Parent.Text).Messages(TreeView1.SelectedNode.Text).Name
        MessageTable.ListRows(MessageRow).Range(3).Value = Displays(TreeView1.SelectedNode.Parent.Text).Messages(TreeView1.SelectedNode.Text).CreationDate
        MessageTable.ListRows(MessageRow).Range(4).Value = Date.Today
        MessageTable.ListRows(MessageRow).Range(5).Value = Displays(TreeView1.SelectedNode.Parent.Text).ID

        Dim thisMessage As Message = Displays(TreeView1.SelectedNode.Parent.Text).Messages(TreeView1.SelectedNode.Text)
        For i = FieldTable.ListRows.Count To 1 Step -1
            If FieldTable.ListRows(i).Range(1).Value = thisMessage.ID Then
                FieldTable.ListRows(i).Delete()
            End If
        Next

        For Each field In thisMessage.Fields.Values
            Dim FieldRow As Integer = Nothing
            FieldRow = FieldTable.ListRows.Add.Index

            FieldTable.ListRows(FieldRow).Range(1).Value = thisMessage.ID
            FieldTable.ListRows(FieldRow).Range(2).Value = field.Name
            FieldTable.ListRows(FieldRow).Range(3).Value = field.Type
            FieldTable.ListRows(FieldRow).Range(4).Value = field.Value
            FieldTable.ListRows(FieldRow).Range(5).Value = field.Color
            FieldTable.ListRows(FieldRow).Range(6).Value = field.Flashing
            FieldTable.ListRows(FieldRow).Range(7).Value = field.Visible
            FieldTable.ListRows(FieldRow).Range(8).Value = field.xPos
            FieldTable.ListRows(FieldRow).Range(9).Value = field.yPos
            FieldTable.ListRows(FieldRow).Range(10).Value = field.Justification

        Next



    End Sub


    Private Sub EditDisplayToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditDisplayToolStripMenuItem.Click
        Displays(TreeView1.SelectedNode.Text) = NewDisplayForm.EditDisplay(Displays(TreeView1.SelectedNode.Text))

        'update the display table
        Dim thisDisplay As Display = Displays(TreeView1.SelectedNode.Text)

        For Each row As ListRow In DisplayTable.ListRows
            If row.Range(1).Value = thisDisplay.Name Then
                row.Range(2).Value = thisDisplay.Address
                row.Range(3).Value = thisDisplay.Port
                row.Range(4).Value = thisDisplay.BaudRate
                row.Range(5).Value = thisDisplay.Columns
                row.Range(6).Value = thisDisplay.Rows
                row.Range(7).Value = thisDisplay.ColorType
                row.Range(8).Value = thisDisplay.ID
                row.Range(9).Value = thisDisplay.xPos
                row.Range(10).Value = thisDisplay.yPos
            End If
        Next

    End Sub

End Class
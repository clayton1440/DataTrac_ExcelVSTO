Imports Microsoft.Office.Interop.Excel
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Microsoft.Office.Tools.Ribbon

Public Class DataTracRibbon


    Private ThisWorkbook As Excel.Workbook
    Public OptionsSheet As Excel.Worksheet
    Public DisplayTable As Excel.ListObject
    Public MessageTable As Excel.ListObject
    Public FieldTable As Excel.ListObject

    Private SentMessage As Boolean = False


    Private Sub DataTracRibbon_Load(ByVal sender As System.Object, ByVal e As RibbonUIEventArgs) Handles MyBase.Load

        AddHandler Globals.ThisAddIn.Application.WorkbookActivate, AddressOf WorkbookOpen
        AddHandler Globals.ThisAddIn.Application.WorkbookBeforeClose, AddressOf WorkbookClose
    End Sub

    Private Sub WorkbookOpen()
        WorkbookIsDatatracSourceButton.Enabled = True
        If WorkbookIsDataTracSource() Then
            WorkbookIsDatatracSourceButton.Checked = True
            DisplayGroup.Visible = True
            OptionsGroup.Visible = True

            CheckOptionsSheetExists()
            CheckDisplayTablesExist()



            ClearDisplayOnExit.Checked = OptionsSheet.Range("A1").Value
            RefreshDisplayOnRefreshAll.Checked = OptionsSheet.Range("A2").Value
            RefreshDisplayOnFileOpen.Checked = OptionsSheet.Range("A4").Value

            If RefreshDisplayOnFileOpen.Checked Then
                SendMessages()
            Else
                CheckAutoRefresh()
            End If
        Else
            WorkbookIsDatatracSourceButton.Checked = False
            DisplayGroup.Visible = False
            OptionsGroup.Visible = False
        End If


    End Sub

    Private Function WorkbookIsDataTracSource() As Boolean
        Dim isDataTrac As Boolean = False
        Try

            ThisWorkbook = Globals.ThisAddIn.Application.ActiveWorkbook
            If ThisWorkbook Is Nothing Then Return False
            For i = 1 To ThisWorkbook.Sheets.Count
                If ThisWorkbook.Sheets(i).Name = "Datatrac_Options" Then
                    isDataTrac = True
                    Exit For
                End If
            Next
        Catch ex As Exception

        End Try
        Return isDataTrac
    End Function

    Private Sub WorkbookIsDatatracSourceButton_Click(sender As Object, e As RibbonControlEventArgs) Handles WorkbookIsDatatracSourceButton.Click
        If WorkbookIsDatatracSourceButton.Checked Then
            Try
                'unchecked to checked
                WorkbookIsDatatracSourceButton.Checked = True
                DisplayGroup.Visible = True
                OptionsGroup.Visible = True

                CheckOptionsSheetExists()
                CheckDisplayTablesExist()

                ClearDisplayOnExit.Checked = OptionsSheet.Range("A1").Value
                RefreshDisplayOnRefreshAll.Checked = OptionsSheet.Range("A2").Value
                RefreshDisplayOnFileOpen.Checked = OptionsSheet.Range("A4").Value

            Catch ex As Exception

            End Try

        Else
            'disabled source
            Dim dr As DialogResult = MessageBox.Show("This action will permanently delete any saved Displays, Messages, and Fields for this workbook. Continue?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If dr = DialogResult.Yes Then
                Try
                    ThisWorkbook.Sheets("Datatrac_Options").Delete
                Catch ex As Exception
                End Try
                Try
                    ThisWorkbook.Sheets("Datatrac_Display").Delete
                Catch ex As Exception
                End Try
                Try
                    ThisWorkbook.Sheets("Datatrac_Message").Delete
                Catch ex As Exception
                End Try
                Try
                    ThisWorkbook.Sheets("Datatrac_Fields").Delete
                Catch ex As Exception
                End Try

                WorkbookIsDatatracSourceButton.Checked = False
                DisplayGroup.Visible = False
                OptionsGroup.Visible = False
            Else
                WorkbookIsDatatracSourceButton.Checked = True
            End If
        End If
    End Sub

    Private Sub WorkbookClose()
        WorkbookIsDatatracSourceButton.Enabled = False
        WorkbookIsDatatracSourceButton.Checked = False
        WorkbookIsDatatracSourceButton.Checked = False
        DisplayGroup.Visible = False
        OptionsGroup.Visible = False
        If WorkbookIsDataTracSource() Then ClearDisplays()
    End Sub

    Private Sub Workbook_RefreshAll()

    End Sub

    Private Sub CheckAutoRefresh()
        Dim int As Integer = OptionsSheet.Range("A3").Value

        RefreshManuallyButton.Checked = False
        Refresh15Mins.Checked = False
        Refresh30Mins.Checked = False
        Refresh1Hour.Checked = False
        Refresh1DayButton.Checked = False

        If int < 0 Then int = 0
        If int = 15 Then
            Refresh15Mins.Checked = True
        ElseIf int = 30 Then
            Refresh30Mins.Checked = True
        ElseIf int = 60 Then
            Refresh1Hour.Checked = True
        ElseIf int = 1440 Then
            Refresh1DayButton.Checked = True
        ElseIf int = 0 Then
            RefreshManuallyButton.Checked = True
        End If


        refreshTimer.Stop()
        refreshTimer.Dispose()
        If int > 0 Then
            refreshTimer.Interval = int * 60000
            If SentMessage Then refreshTimer.Start()
        End If
    End Sub
    Private Sub CheckOptionsSheetExists()
        Try
            'If OptionsSheet IsNot Nothing Then Exit Sub

            ThisWorkbook = Globals.ThisAddIn.Application.ActiveWorkbook
            OptionsSheet = Nothing

            If ThisWorkbook Is Nothing Then Exit Sub
            'check for options sheet
            For i = 1 To ThisWorkbook.Sheets.Count
                If ThisWorkbook.Sheets(i).Name = "Datatrac_Options" Then
                    OptionsSheet = ThisWorkbook.Sheets(i)
                    Exit For
                End If
            Next


            If OptionsSheet Is Nothing Then
                OptionsSheet = ThisWorkbook.Sheets.Add()
                OptionsSheet.Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVeryHidden
                OptionsSheet.Name = "Datatrac_Options"
                OptionsSheet.Range("A1").Value = True 'clear when excel closes
                OptionsSheet.Range("A2").Value = False ' refresh on refresh-all
                OptionsSheet.Range("A3").Value = 0  'refresh interval minutes
                OptionsSheet.Range("A4").Value = False ' refresh on file open
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub CheckDisplayTablesExist()
        Try
            'If DisplayTable IsNot Nothing Then Exit Sub
            If ThisWorkbook Is Nothing Then Exit Sub

            DisplayTable = Nothing
            MessageTable = Nothing
            FieldTable = Nothing

            'check for display, message, and field tables
            For i = 1 To ThisWorkbook.Sheets.Count
                If ThisWorkbook.Sheets(i).Name = "Datatrac_Display" Then
                    DisplayTable = ThisWorkbook.Sheets(i).ListObjects(1)
                ElseIf ThisWorkbook.Sheets(i).Name = "Datatrac_Message" Then
                    MessageTable = ThisWorkbook.Sheets(i).ListObjects(1)
                ElseIf ThisWorkbook.Sheets(i).Name = "Datatrac_Fields" Then
                    FieldTable = ThisWorkbook.Sheets(i).ListObjects(1)
                End If
            Next


            If DisplayTable Is Nothing Then
                Dim DisplaySheet As Excel.Worksheet = ThisWorkbook.Sheets.Add()
                DisplaySheet.Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVeryHidden
                DisplaySheet.Name = "Datatrac_Display"

                DisplayTable = DisplaySheet.ListObjects.Add(Excel.XlListObjectSourceType.xlSrcRange, DisplaySheet.Range("A1:J1"), , Excel.XlYesNoGuess.xlYes)

                'add column headers
                DisplayTable.HeaderRowRange(1).Value = {"Name"}
                DisplayTable.HeaderRowRange(2).value = {"Address"}
                DisplayTable.HeaderRowRange(3).value = {"Port"}
                DisplayTable.HeaderRowRange(4).value = {"BaudRate"}
                DisplayTable.HeaderRowRange(5).value = {"Columns"}
                DisplayTable.HeaderRowRange(6).value = {"Rows"}
                DisplayTable.HeaderRowRange(7).value = {"ColorType"}
                DisplayTable.HeaderRowRange(8).Value = {"ID"}
                DisplayTable.HeaderRowRange(9).Value = {"XPos"}
                DisplayTable.HeaderRowRange(10).Value = {"YPos"}

                DisplayTable.Name = "Datatrac_Display"
            End If

            If MessageTable Is Nothing Then
                Dim MessageSheet As Excel.Worksheet = ThisWorkbook.Sheets.Add()
                MessageSheet.Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVeryHidden
                MessageSheet.Name = "Datatrac_Message"

                MessageTable = MessageSheet.ListObjects.Add(Excel.XlListObjectSourceType.xlSrcRange, MessageSheet.Range("A1:E1"), , Excel.XlYesNoGuess.xlYes)

                'add column headers
                MessageTable.HeaderRowRange(1).Value = {"ID"}
                MessageTable.HeaderRowRange(2).value = {"MessageName"}
                MessageTable.HeaderRowRange(3).value = {"CreationDate"}
                MessageTable.HeaderRowRange(4).value = {"ModifiedDate"}
                MessageTable.HeaderRowRange(5).value = {"DisplayID"}

                MessageTable.Name = "Datatrac_Message"
            End If

            If FieldTable Is Nothing Then
                Dim FieldSheet As Excel.Worksheet = ThisWorkbook.Sheets.Add()
                FieldSheet.Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVeryHidden
                FieldSheet.Name = "Datatrac_Fields"

                'add tables to each sheet (ListObject)
                FieldTable = FieldSheet.ListObjects.Add(Excel.XlListObjectSourceType.xlSrcRange, FieldSheet.Range("A1:J1"), , Excel.XlYesNoGuess.xlYes)

                'set the tables
                FieldTable.Name = "Datatrac_Fields"


                FieldTable.HeaderRowRange(1).Value = {"MessageID"}
                FieldTable.HeaderRowRange(2).value = {"FieldName"}
                FieldTable.HeaderRowRange(3).value = {"Type"}
                FieldTable.HeaderRowRange(4).value = {"Value"}
                FieldTable.HeaderRowRange(5).value = {"Color"}
                FieldTable.HeaderRowRange(6).value = {"Flashing"}
                FieldTable.HeaderRowRange(7).value = {"Visible"}
                FieldTable.HeaderRowRange(8).value = {"XPos"}
                FieldTable.HeaderRowRange(9).value = {"YPos"}
                FieldTable.HeaderRowRange(10).value = {"Justification"}
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub BuildMessageButton_Click(sender As Object, e As RibbonControlEventArgs) Handles BuildMessageButton.Click
        CheckOptionsSheetExists()
        CheckDisplayTablesExist()
        Dim MsgWindow As New DisplayInterface
        MsgWindow.Show()
    End Sub

    Private Displays As New Dictionary(Of String, Display)

    Private Sub GetDisplays()
        CheckOptionsSheetExists()
        CheckDisplayTablesExist()

        Displays.Clear()

        If DisplayTable.ListRows.Count > 0 Then
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

                If newDisplay.Address = "" Then
                    MessageBox.Show("Display " & newDisplay.Name & " is missing an address. Please correct this before sending messages.")
                    If newDisplay.Port = "" Or newDisplay.BaudRate = "" Then
                        MessageBox.Show("Display " & newDisplay.Name & " is missing a COM Port or Baud Rate. Please correct this before sending messages.")
                        Exit Sub
                    End If
                    Exit Sub
                End If

                'TreeView1.Nodes(0).Nodes(newDisplay.Name).Tag = TreeView1.Nodes(0).Nodes.Count - 1

                If MessageTable.ListRows.Count > 0 Then
                    For Each mrow As Excel.ListRow In MessageTable.ListRows
                        If mrow.Range(5).Value = newDisplay.ID Then
                            Dim newMessage As New Message
                            newMessage.ID = mrow.Range(1).Value
                            newMessage.Name = mrow.Range(2).Value
                            newMessage.CreationDate = mrow.Range(3).Value
                            newMessage.ModifiedDate = mrow.Range(4).Value


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
    End Sub
    Private Sub SendMessages() Handles RefreshDisplayButton.Click, refreshTimer.Tick
        GetDisplays()

        SentMessage = True
        CheckAutoRefresh()

        For Each display As Display In Displays.Values
            display.Send()
        Next

    End Sub

    Private Sub ClearDisplays() Handles ClearDisplayButton.Click
        GetDisplays()

        For Each display As Display In Displays.Values
            display.Clear()
        Next
    End Sub

    Private Sub ResetDisplays() Handles ResetDisplayButton.Click
        GetDisplays()

        For Each display As Display In Displays.Values
            display.Reset()
        Next
    End Sub

    Private Sub ShowPreviewButton_Click(sender As Object, e As RibbonControlEventArgs) Handles ShowPreviewButton.Click
        GetDisplays()

        For Each display As Display In Displays.Values
            DisplayPreviewWindow.Preview(display)
        Next
    End Sub

    Private Sub Refresh15Mins_Click(sender As Object, e As RibbonControlEventArgs) Handles Refresh15Mins.Click
        CheckOptionsSheetExists()
        SendMessages()

        RefreshManuallyButton.Checked = False
        Refresh15Mins.Checked = True
        Refresh30Mins.Checked = False
        Refresh1Hour.Checked = False
        Refresh1DayButton.Checked = False

        OptionsSheet.Range("A3").Value = 15
    End Sub

    Private Sub Refresh30Mins_Click(sender As Object, e As RibbonControlEventArgs) Handles Refresh30Mins.Click
        CheckOptionsSheetExists()
        SendMessages()

        RefreshManuallyButton.Checked = False
        Refresh15Mins.Checked = False
        Refresh30Mins.Checked = True
        Refresh1Hour.Checked = False
        Refresh1DayButton.Checked = False

        OptionsSheet.Range("A3").Value = 30
    End Sub

    Private Sub Refresh1Hour_Click(sender As Object, e As RibbonControlEventArgs) Handles Refresh1Hour.Click
        CheckOptionsSheetExists()
        SendMessages()

        RefreshManuallyButton.Checked = False
        Refresh15Mins.Checked = False
        Refresh30Mins.Checked = False
        Refresh1Hour.Checked = True
        Refresh1DayButton.Checked = False

        OptionsSheet.Range("A3").Value = 60
    End Sub

    Private Sub Refresh1Day_Click(sender As Object, e As RibbonControlEventArgs) Handles Refresh1DayButton.Click
        CheckOptionsSheetExists()
        SendMessages()

        RefreshManuallyButton.Checked = False
        Refresh15Mins.Checked = False
        Refresh30Mins.Checked = False
        Refresh1Hour.Checked = False
        Refresh1DayButton.Checked = True

        OptionsSheet.Range("A3").Value = 1440
    End Sub

    Private Sub RefreshManuallyButton_Click(sender As Object, e As RibbonControlEventArgs) Handles RefreshManuallyButton.Click
        CheckOptionsSheetExists()
        CheckAutoRefresh()

        RefreshManuallyButton.Checked = True
        Refresh15Mins.Checked = False
        Refresh30Mins.Checked = False
        Refresh1Hour.Checked = False
        Refresh1DayButton.Checked = False

        OptionsSheet.Range("A3").Value = 0
    End Sub

    Private Sub ClearDisplaysOnExit_Click() Handles ClearDisplayOnExit.Click
        CheckOptionsSheetExists()
        OptionsSheet.Range("A1").Value = ClearDisplayOnExit.Checked
    End Sub

    Private Sub RefreshDisplayOnRefreshAll_Click() Handles RefreshDisplayOnRefreshAll.Click
        CheckOptionsSheetExists()
        OptionsSheet.Range("A2").Value = RefreshDisplayOnRefreshAll.Checked
    End Sub
    Private Sub RefreshDisplayOnFileOpen_Click(sender As Object, e As RibbonControlEventArgs) Handles RefreshDisplayOnFileOpen.Click
        CheckOptionsSheetExists()
        OptionsSheet.Range("A4").Value = RefreshDisplayOnFileOpen.Checked
    End Sub


End Class

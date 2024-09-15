Imports System.IO.Ports

Public Class Display
    Public Property Name As String
    Public Property ID As Integer
    Public Property Messages As New Dictionary(Of String, Message)
    Public Property Address As String
    Public Property Port As String
    Public Property BaudRate As Integer
    Public Property Columns As Integer
    Public Property Rows As Integer
    Public Property CanFlash As Boolean
    Public Property ColorType As DisplayColorType
    Public Property xPos As Integer
    Public Property yPos As Integer

    Public Shared Function GetDisplays(lo As Excel.ListObject) As List(Of Display)
        Dim displays As New List(Of Display)
        ' Get displays from Excel
        ' For each row in the display table
        ' Create a new display object
        ' Add the display object to the list

        ' Iterate through each row in the table
        For Each row As Excel.ListRow In lo.ListRows
            Dim display As New Display
            display.Name = row.Range(1).Value
            display.Address = row.Range(2).Value
            display.Port = row.Range(3).Value
            display.BaudRate = row.Range(4).Value
            display.Columns = row.Range(5).Value
            display.Rows = row.Range(6).Value
            display.ColorType = row.Range(7).Value
            display.ID = row.Range(8).Value
            display.xPos = row.Range(9).Value
            display.yPos = row.Range(10).Value
            displays.Add(display)
        Next

        Return displays
    End Function

    Public Shared Function ColorToDispCmd(c As DisplayColor) As String
        Select Case c
            Case DisplayColor.Red
                Return "CORED"
            Case DisplayColor.Green
                Return "COGRN"
            Case DisplayColor.Amber
                Return "COAMB"
            Case Else
                Return "CORED"
        End Select
    End Function

    Public Sub Clear()
        Dim cmd As String = $"{Address.ToString.PadLeft(3, "0"c)}CD"
        ComPort.SendString(cmd, Port, BaudRate)
    End Sub

    Public Sub Reset()
        Dim cmd As String = $"{Address.ToString.PadLeft(3, "0"c)}RS"
        ComPort.SendString(cmd, Port, BaudRate)
    End Sub

    Public Sub Send()
        Clear()

        For Each message As Message In Messages.Values
            Dim commandString As String = ""
            For Each field As MessageField In message.Fields.Values
                Dim value As String = CheckValue(field.Value.Trim)

                If field.Justification = FieldJustification.Center Then
                    field.xPos = field.xPos - (Math.Floor(value.Length / 2) - 1)
                ElseIf field.Justification = FieldJustification.Right Then
                    field.xPos = field.xPos - (value.Length - 1)
                End If

                commandString &= $"{Address.ToString.PadLeft(3, "0"c)}{ColorToDispCmd(field.Color)}{If(field.Flashing, $"{Address.ToString.PadLeft(3, "0"c)}FL", "")}{Address.ToString.PadLeft(3, "0"c)}WR{field.yPos.ToString.PadLeft(2, "0"c)}{field.xPos.ToString.PadLeft(3, "0"c)}{value}{If(field.Flashing, $"{Address.ToString.PadLeft(3, "0"c)}FL", "")}"
            Next
            ComPort.SendString(commandString, Port, BaudRate)
        Next

    End Sub

    Public Function CheckValue(s As String) As String
        If s.Contains("{=") AndAlso s.Contains("}") Then
            ' This is an excel formula we need to evaluate
            Dim formulaBlock As String = s.Substring(s.IndexOf("{="), s.IndexOf("}") - s.IndexOf("{=") + 1)
            Dim formula As String = formulaBlock.Substring(2, formulaBlock.Length - 3)
            Dim eval As Object = Globals.ThisAddIn.Application.Evaluate(formula)

            If TypeOf eval Is Excel.Range Then
                Try
                    s = s.Replace(formulaBlock, CType(eval, Excel.Range).Value.ToString)
                Catch ex As Exception
                    s = s.Replace(formulaBlock, 0.ToString)
                End Try
            Else
                s = s.Replace(formulaBlock, eval.ToString)
            End If
        End If
        Return s
    End Function


    Class ComPort
        Public Shared Sub SendString(data As String, port As String, baud As Integer)
            Dim serialPort As New SerialPort(port, baud)
            serialPort.Open()
            serialPort.Write(data)
            serialPort.Close()
        End Sub
    End Class

End Class

Public Class Message
    Public Property Fields As New Dictionary(Of String, MessageField)
    Public Property ID As Integer
    Public Property Name As String
    Public Property CreationDate As Date
    Public Property ModifiedDate As Date

    Public Shared Function GetMessages(lo As Excel.ListObject, disp As Display) As List(Of Message)
        Dim messages As New List(Of Message)
        ' Get messages from Excel
        ' For each row in the message table
        ' Create a new message object
        ' Add the message object to the list


        ' Iterate through each row in the table
        For Each row As Excel.ListRow In lo.ListRows
            If row.Range(5).Value = disp.ID Then
                Dim message As New Message
                message.ID = row.Range(1).Value
                message.Name = row.Range(2).Value
                message.CreationDate = row.Range(3).Value
                message.ModifiedDate = row.Range(4).Value
                messages.Add(message)
            End If
        Next

        Return messages
    End Function
    Public Shared Function GetMessages(lo As Excel.ListObject) As List(Of Message)
        Dim messages As New List(Of Message)
        ' Get messages from Excel
        ' For each row in the message table
        ' Create a new message object
        ' Add the message object to the list

        ' Iterate through each row in the table
        For Each row As Excel.ListRow In lo.ListRows
            Dim message As New Message
            message.ID = row.Range(1).Value
            message.Name = row.Range(2).Value
            message.CreationDate = row.Range(3).Value
            message.ModifiedDate = row.Range(4).Value
            messages.Add(message)
        Next

        Return messages
    End Function

End Class

Public Class MessageField
    Public Property Name As String
    Public Property Type As String
    Public ReadOnly Property Length As Integer
    Public Property Value As String
    Public Property Color As DisplayColor
    Public Property Flashing As Boolean
    Public Property Visible As Boolean
    Public Property xPos As Integer
    Public Property yPos As Integer
    Public Property Justification As FieldJustification

    Public Shared Function GetFields(lo As Excel.ListObject, msg As Message) As List(Of MessageField)
        Dim fields As New List(Of MessageField)
        ' Get fields from Excel
        ' For each row in the field table
        ' Create a new field object
        ' Add the field object to the list

        ' Iterate through each row in the table
        For Each row As Excel.ListRow In lo.ListRows
            If row.Range(1).Value = msg.ID Then
                Dim field As New MessageField
                field.Name = row.Range(2).Value
                field.Type = row.Range(3).Value
                field.Value = row.Range(4).Value
                field.Color = row.Range(5).Value
                field.Flashing = row.Range(6).Value
                field.Visible = row.Range(7).Value
                field.xPos = row.Range(8).Value
                field.yPos = row.Range(9).Value
                field.Justification = row.Range(10).Value
                fields.Add(field)
            End If
        Next

        Return fields
    End Function
    Public Shared Function GetFields(lo As Excel.ListObject) As List(Of MessageField)
        Dim fields As New List(Of MessageField)
        ' Get fields from Excel
        ' For each row in the field table
        ' Create a new field object
        ' Add the field object to the list

        ' Iterate through each row in the table
        For Each row As Excel.ListRow In lo.ListRows
            Dim field As New MessageField
            field.Name = row.Range(2).Value
            field.Type = row.Range(3).Value
            field.Value = row.Range(4).Value
            field.Color = row.Range(5).Value
            field.Flashing = row.Range(6).Value
            field.Visible = row.Range(7).Value
            field.xPos = row.Range(8).Value
            field.yPos = row.Range(9).Value
            field.Justification = row.Range(10).Value
            fields.Add(field)
        Next

        Return fields
    End Function

    Public Shared Function ColorFromString(s As String) As DisplayColor
        If s Is Nothing Then Return DisplayColor.Red
        s = s.ToLower
        If s = "red" Or s = "cored" Then
            Return DisplayColor.Red
        ElseIf s = "green" Or s = "grn" Or s = "cogrn" Then
            Return DisplayColor.Green
        ElseIf s = "amber" Or s = "amb" Or s = "coamb" Then
            Return DisplayColor.Amber
        Else
            Return DisplayColor.Red
        End If
    End Function

    Public Shared Function JustificationFromString(s As String) As FieldJustification
        If s Is Nothing Then Return FieldJustification.Left
        s = s.ToString.ToLower
        If s = "left" Or s = "l" Then
            Return FieldJustification.Left
        ElseIf s = "center" Or s = "c" Then
            Return FieldJustification.Center
        ElseIf s = "right" Or s = "r" Then
            Return FieldJustification.Right
        Else
            Return FieldJustification.Left
        End If
    End Function



End Class

Public Enum FieldJustification
    Left = 0
    Center = 1
    Right = 2
End Enum

Public Enum DisplayColor
    Red = 0
    Green = 1
    Amber = 2
End Enum

Public Enum DisplayColorType
    Mono = 0
    Tri = 1
End Enum

Module DisplayPreview

    Public Function CreateDisplayBitmap(display As Display) As Bitmap
        ' Set up font
        Dim font As Font = eFont.LoadEmbeddedFont(My.Resources.CGMono_Regular, 16) ' Monospace font


        ' Measure the size of a single character to determine pixel size per character
        Using graphics As Graphics = Graphics.FromHwnd(IntPtr.Zero)
            Dim charSize As Size = TextRenderer.MeasureText(graphics, "W", font, New Size(36, 42), TextFormatFlags.NoPadding)
            Dim charWidth As Integer = charSize.Width
            Dim charHeight As Integer = charSize.Height

            ' Calculate the size of the bitmap based on display dimensions
            Dim bmpWidth As Integer = display.Columns * charWidth
            Dim bmpHeight As Integer = display.Rows * charHeight + 8

            ' Create a new bitmap
            Dim bmp As New Bitmap(bmpWidth, bmpHeight)
            Using g As Graphics = Graphics.FromImage(bmp)
                g.Clear(Color.Black) ' Black background


                ' Iterate through each message
                For Each msg In display.Messages
                    For Each field In msg.Value.Fields.Values
                        If field.Visible Then
                            ' Determine color
                            Dim textColor As Color
                            If display.ColorType = DisplayColorType.Tri Then
                                textColor = GetColorFromDisplayColor(field.Color)
                            Else
                                textColor = Color.Red ' Default to red for mono
                            End If

                            ' Prepare text
                            Dim text As String = Display.CheckValue(field.Value)


                            ' Calculate position
                            Dim x As Integer = (field.xPos - 1) * charWidth
                            Dim y As Integer = (field.yPos - 1) * charHeight + 4

                            If field.Justification = FieldJustification.Center Then
                                x -= (Math.Floor(text.Length / 2) - 1) * charWidth
                            ElseIf field.Justification = FieldJustification.Right Then
                                x -= (text.Length - 1) * charWidth
                            End If

                            ' Draw the text
                            TextRenderer.DrawText(g, text, font, New Point(x, y), textColor, Color.Black, TextFormatFlags.NoPadding)
                        End If
                    Next
                Next

                g.Save()
            End Using

            Return bmp
        End Using
    End Function

    Private Function GetColorFromDisplayColor(c As DisplayColor) As Color
        Select Case c
            Case DisplayColor.Red
                Return Color.Red
            Case DisplayColor.Green
                Return Color.Green
            Case DisplayColor.Amber
                Return Color.FromArgb(255, 215, 0) ' Amber color
            Case Else
                Return Color.Red ' Default to red if unknown color
        End Select
    End Function

End Module
Module Utilities

    Function ExcelDateToDateTime(excelDate As Double) As DateTime

        ' Excel uses 1/1/1900 as day 1. .NET uses 1/1/1900 as day 0.

        ' So, subtract 1 from the Excel date to get the correct .NET date.

        Dim dateValue As DateTime = DateTime.FromOADate(excelDate - 1)

        Return dateValue

    End Function

    Function ExcelDateToDate(excelDate As Double) As Date

        ' Excel uses 1/1/1900 as day 1. .NET uses 1/1/1900 as day 0.

        ' So, subtract 1 from the Excel date to get the correct .NET date.

        Dim dateValue As DateTime = DateTime.FromOADate(excelDate - 1)

        Return dateValue.Date

    End Function
End Module

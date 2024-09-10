Imports System.Drawing.Text
Imports System.Runtime.InteropServices

Public Class eFont

    Private Shared privateFonts As PrivateFontCollection = New PrivateFontCollection()
    Public Shared Function LoadEmbeddedFont(FontResource As Byte(), Optional FontSize As Single = 9) As Font
        ' Get the byte array of the font from the resources

        ' Allocate memory and copy the font data
        Dim fontPtr As IntPtr = Marshal.AllocCoTaskMem(FontResource.Length)
        Marshal.Copy(FontResource, 0, fontPtr, FontResource.Length)

        ' Add the font to the private font collection
        privateFonts.AddMemoryFont(fontPtr, FontResource.Length)

        ' Free the allocated memory
        Marshal.FreeCoTaskMem(fontPtr)

        ' Create a Font object with the desired size
        Return New Font(privateFonts.Families(0), FontSize) ' Adjust the size as needed
    End Function
End Class
Public Class DisplayPreviewWindow

    Private Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private _display As Display
    Public Shared Sub Preview(disp As Display)
        Dim form As New DisplayPreviewWindow
        form._display = disp
        form.Text = form.Text & $" - {disp.Name}"
        form.PictureBox1.Image = DisplayPreview.CreateDisplayBitmap(disp)
        form.Width = form.PictureBox1.Image.Width
        form.Show()
    End Sub

    Private Sub RefreshPreviewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshPreviewToolStripMenuItem.Click
        PictureBox1.Image = DisplayPreview.CreateDisplayBitmap(_display)
    End Sub
End Class
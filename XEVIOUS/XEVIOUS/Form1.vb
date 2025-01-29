' XEVIOUS LIKE STG EDIT BY KYOSUKE MIYAZAWA COPYRIGHT SINCE 2025
Public Class Form1
    Private bmp As Bitmap
    Private fgt As Bitmap
    Private sx = 0
    Private sx2 = 0
    Private sy = 0
    Private _g As Graphics

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim canvas As Bitmap = New Bitmap(PictureBox1.Width, PictureBox1.Height)
        _g = Graphics.FromImage(canvas)
        sy = sy + 4
        If sy = bmp.Height Then
            sy = 0
            sx = sx + canvas.Width
            If sx + canvas.Width > bmp.Width Then
                sx = canvas.Width / 2
            End If
        End If
        Dim y = bmp.Height - PictureBox1.Height - sy
        Dim src1 = New Rectangle(sx, y, PictureBox1.Width, PictureBox1.Height)
        Dim dst = New Rectangle(0, 0, PictureBox1.Width, PictureBox1.Height)
        _g.DrawImage(bmp, dst, src1, GraphicsUnit.Pixel)
        If y < PictureBox1.Height Then
            sx2 = sx + canvas.Width
            If sx2 + canvas.Width > bmp.Width Then
                sx2 = canvas.Width / 2
            End If
            Dim y2 = y + bmp.Height
            Dim src2 = New Rectangle(sx2, y2, PictureBox1.Width, PictureBox1.Height)
            _g.DrawImage(bmp, dst, src2, GraphicsUnit.Pixel)
        End If
        _g.DrawImage(bmp, dst, src1, GraphicsUnit.Pixel)
        Dim fx As Integer = (PictureBox1.Width / 2) - 24
        Dim fy As Integer = PictureBox1.Height - 100
        _g.DrawImage(fgt, fx, fy)
        _g.Dispose()
        PictureBox1.Image = canvas
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bmp = New Bitmap("STG_MAP.png")
        fgt = New Bitmap("STG_SOL.png")
        Timer1.Start()
    End Sub
End Class

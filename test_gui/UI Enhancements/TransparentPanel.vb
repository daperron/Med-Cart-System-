Public Class TransparentPanel
    Inherits Panel
    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or &H20 ''#WS_EX_TRANSPARENT
            Return cp
        End Get
    End Property
    Protected Overrides Sub OnPaintBackground(ByVal e As System.Windows.Forms.PaintEventArgs)
        ''#MyBase.OnPaintBackground(e)
    End Sub

End Class

Public Class frmSplash

    Private Sub frmLoad(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strProjectName As String = System.Reflection.Assembly.GetExecutingAssembly.GetName.Name.ToString
        lblApplicationName.Text = strProjectName
        Dim Version As Version = System.Reflection.Assembly.GetExecutingAssembly.GetName.Version
        Console.WriteLine("Trying to set the version number")
        lblVersionNumber.Text = "Version " & Version.Major & "." & Version.Minor & " (build " & Version.Build & ")"
    End Sub

End Class
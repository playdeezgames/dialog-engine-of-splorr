Imports GMN.Presentation
Imports GMN.Processing
Imports TGGD.Platform

Public Class GMNDisplay
    Inherits Display
    Private Sub New()

    End Sub

    Public Overrides Sub Start()
        UpdateDialog(TitleDialog.Launch(Me, WorldModel.Create(), Function() Nothing).Invoke())
    End Sub

    Public Shared Function Create() As IDisplay
        Dim result = New GMNDisplay
        result.Start()
        Return result
    End Function
End Class

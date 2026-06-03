Imports GMN.Presentation
Imports GMN.Processing
Imports TGGD.Platform

Friend Class GMNDisplay
    Inherits Display

    Public Overrides Sub Start()
        UpdateDialog(TitleDialog.Launch(Me, WorldModel.Create(), Function() Nothing).Invoke())
    End Sub

    Friend Shared Function Create() As IDisplay
        Dim result = New GMNDisplay
        result.Start()
        Return result
    End Function
End Class

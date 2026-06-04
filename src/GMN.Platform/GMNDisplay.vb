Imports GMN.Presentation
Imports GMN.Processing
Imports TGGD.Platform

Public Class GMNDisplay
    Inherits Display

    Private ReadOnly quittable As Boolean

    Private Sub New(quittable As Boolean)
        Me.quittable = quittable
    End Sub

    Public Overrides Sub Start()
        UpdateDialog(TitleDialog.Launch(Me, WorldModel.Create(quittable), Function() Nothing).Invoke())
    End Sub

    Public Shared Function Create(quittable As Boolean) As IDisplay
        Dim result = New GMNDisplay(quittable)
        result.Start()
        Return result
    End Function
End Class

Imports GMN.Presentation
Imports GMN.Processing
Imports TGGD.Persistence
Imports TGGD.Platform

Public Class GMNDisplay
    Inherits Display

    Private ReadOnly quittable As Boolean
    Private ReadOnly persister As IPersister

    Private Sub New(quittable As Boolean, persister As IPersister)
        Me.quittable = quittable
        Me.persister = persister
    End Sub

    Public Overrides Sub Start()
        UpdateDialog(TitleDialog.Launch(Me, WorldModel.Create(quittable, persister), Function() Nothing).Invoke())
    End Sub

    Public Shared Function Create(quittable As Boolean, persister As IPersister) As IDisplay
        Dim result = New GMNDisplay(quittable, persister)
        result.Start()
        Return result
    End Function
End Class

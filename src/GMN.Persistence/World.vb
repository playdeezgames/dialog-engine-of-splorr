Imports System.Text.Json
Imports GMN.Provision
Imports TGGD.Persistence

Public Class World
    Inherits Entity(Of GMNData)
    Implements IWorld
    Private Sub New(data As GMNData, persister As IPersister)
        Me.Data = data
        Me.persister = persister
    End Sub

    Protected Overrides ReadOnly Property Data As GMNData
    Private ReadOnly persister As IPersister

    Public Sub Save(filename As String) Implements IWorld.Save
        persister.SaveAsync(filename, JsonSerializer.Serialize(Data))
    End Sub

    Public Shared Function Create(data As GMNData, persister As IPersister) As IWorld
        Return New World(data, persister)
    End Function

    Public Shared Async Function Load(filename As String, persister As IPersister) As Task(Of IWorld)
        Return New World(JsonSerializer.Deserialize(Of GMNData)(Await persister.LoadAsync(filename)), persister)
    End Function
End Class

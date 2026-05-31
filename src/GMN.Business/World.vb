Imports System.IO
Imports System.Text.Json
Imports GMN.Data
Imports TGGD.Business

Public Class World
    Inherits Entity(Of GMNData)
    Implements IWorld
    Private Sub New(data As GMNData)
        Me.EntityData = data
    End Sub

    Protected Overrides ReadOnly Property EntityData As GMNData

    Public Sub Save(filename As String) Implements IWorld.Save
        File.WriteAllText(filename, JsonSerializer.Serialize(EntityData))
    End Sub

    Public Shared Function Create(data As GMNData) As IWorld
        Return New World(data)
    End Function

    Public Shared Function Load(filename As String) As IWorld
        Return New World(JsonSerializer.Deserialize(Of GMNData)(File.ReadAllText(filename)))
    End Function
End Class

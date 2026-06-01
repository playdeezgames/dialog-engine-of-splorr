Imports System.IO
Imports System.Text.Json
Imports DS.Data
Imports TGGD.Business

Public Class World
    Inherits Entity(Of DSData)
    Implements IWorld

    Private Sub New(data As DSData)
        EntityData = data
    End Sub

    Protected Overrides ReadOnly Property EntityData As DSData

    Public Shared Function Create(data As DSData) As IWorld
        Return New World(data)
    End Function

    Public Shared Function Load(filename As String) As IWorld
        Return New World(JsonSerializer.Deserialize(Of DSData)(File.ReadAllText(filename)))
    End Function
End Class

Imports DS.Business
Imports TGGD.Model

Public Class WorldModel
    Inherits BaseModel(Of IWorld)
    Implements IWorldModel

    Protected Sub New(entity As IWorld)
        MyBase.New(entity)
    End Sub

    Public Sub Reset() Implements IWorldModel.Reset
        Entity.Clear()
        Entity.SetCounter(Counters.SC, 215)

    End Sub

    Public Shared Function Create() As IWorldModel
        Dim world As IWorld
        Try
            world = DS.Business.World.Load(SAVE_FILE_NAME)
        Catch ex As Exception
            world = DS.Business.World.Create(New Data.DSData)
        End Try
        Return New WorldModel(world)
    End Function
End Class

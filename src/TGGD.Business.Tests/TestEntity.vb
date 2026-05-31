Imports TGGD.Data

Friend Class TestEntity
    Inherits Entity(Of EntityData)

    Private Sub New(entityData As EntityData)
        Me.EntityData = entityData
    End Sub

    Protected Overrides ReadOnly Property EntityData As EntityData

    Friend Shared Function Create(entityData As EntityData) As IEntity
        Return New TestEntity(entityData)
    End Function
End Class

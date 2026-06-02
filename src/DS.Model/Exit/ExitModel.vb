Imports DS.Business

Friend Class ExitModel
    Implements IExitModel
    Private ReadOnly location As IDSObject
    Private ReadOnly directionId As Integer

    Private Sub New(location As IDSObject, directionId As Integer)
        Me.location = location
        Me.directionId = directionId
    End Sub

    Public ReadOnly Property DirectionName As String Implements IExitModel.DirectionName
        Get
            Return Directions.DIRECTION_NAMES(directionId)
        End Get
    End Property

    Public ReadOnly Property Exists As Boolean Implements IExitModel.Exists
        Get
            Return location.DS(directionId) <> LOCATION_0
        End Get
    End Property

    Friend Shared Function Create(location As IDSObject, directionId As Integer) As IExitModel
        Return New ExitModel(location, directionId)
    End Function
End Class

Imports DS.Business

Friend Class ObjectModel
    Implements IObjectModel

    Private ReadOnly obj As IOBObject

    Private Sub New(obj As IOBObject)
        Me.obj = obj
    End Sub

    Public ReadOnly Property Name As String Implements IObjectModel.Name
        Get
            Return obj.OBs
        End Get
    End Property

    Friend Shared Function Create(obj As IOBObject) As IObjectModel
        Return New ObjectModel(obj)
    End Function
End Class

Imports DS.Data

Friend Class OBObject
    Implements IOBObject

    Private Sub New(data As WorldData, identifier As Integer)
        Me.data = data
        Me.Identifier = identifier
    End Sub

    Friend Shared Function Create(data As WorldData, identifier As Integer) As IOBObject
        Return New OBObject(data, identifier)
    End Function

    Private ReadOnly data As WorldData
    Public ReadOnly Property Identifier As Integer Implements IOBObject.Identifier
    Private ReadOnly Property EntityData As OBData
        Get
            Return data.OB(Identifier)
        End Get
    End Property

    Public ReadOnly Property OBs As String Implements IOBObject.OBs
        Get
            Return EntityData.OBs
        End Get
    End Property

    Public ReadOnly Property OB(key As Integer) As Integer Implements IOBObject.OB
        Get
            Return EntityData.OB(key)
        End Get
    End Property
End Class

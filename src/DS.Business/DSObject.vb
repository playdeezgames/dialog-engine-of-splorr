Imports DS.Data

Public Class DSObject
    Implements IDSObject
    Private Sub New(data As WorldData, identifier As Integer)
        Me.data = data
        Me.Identifier = identifier
    End Sub

    Private data As WorldData
    Public ReadOnly Property Identifier As Integer Implements IDSObject.Identifier
    Private ReadOnly Property EntityData As DSData
        Get
            Return data.DS(Identifier)
        End Get
    End Property

    Public ReadOnly Property DSs As String Implements IDSObject.DSs
        Get
            Return EntityData.DSs
        End Get
    End Property

    Public ReadOnly Property DS(key As Integer) As Integer Implements IDSObject.DS
        Get
            Return EntityData.DS(key)
        End Get
    End Property

    Friend Shared Function Create(data As WorldData, identifier As Integer) As IDSObject
        Return New DSObject(data, identifier)
    End Function
End Class

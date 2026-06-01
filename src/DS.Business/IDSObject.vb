Public Interface IDSObject
    ReadOnly Property Identifier As Integer
    ReadOnly Property DSs As String
    ReadOnly Property DS(key As Integer) As Integer
End Interface

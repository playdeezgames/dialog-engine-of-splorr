Public Interface IPersister
    Sub Save(filename As String, content As String)
    Function Load(filename As String) As String
End Interface

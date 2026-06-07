Imports System.IO
Imports TGGD.Persistence

Friend Class Persister
    Implements IPersister

    Public Sub Save(filename As String, content As String) Implements IPersister.Save
        File.WriteAllText(filename, content)
    End Sub

    Public Function Load(filename As String) As String Implements IPersister.Load
        Return File.ReadAllText(filename)
    End Function
End Class

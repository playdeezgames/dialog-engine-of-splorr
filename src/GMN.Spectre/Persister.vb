Imports System.IO
Imports TGGD.Persistence

Friend Class Persister
    Implements IPersister

    Public Function SaveAsync(filename As String, content As String) As Task Implements IPersister.SaveAsync
        Return Task.Run(Sub()
                            File.WriteAllText(filename, content)
                        End Sub)
    End Function

    Public Function LoadAsync(filename As String) As Task(Of String) Implements IPersister.LoadAsync
        Return Task.Run(Of String)(Function()
                                       Return File.ReadAllText(filename)
                                   End Function)
    End Function
End Class

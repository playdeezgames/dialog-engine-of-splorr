Public Class EntityData
    Public Property Metadatas As New Dictionary(Of String, String)
    Public Property Counters As New Dictionary(Of String, Integer)
    Public Property CounterMaximums As New Dictionary(Of String, Integer)
    Public Property CounterMinimums As New Dictionary(Of String, Integer)
    Public Property Tags As New HashSet(Of String)
End Class

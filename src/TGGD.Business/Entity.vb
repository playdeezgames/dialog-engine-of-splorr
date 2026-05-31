Imports TGGD.Data

Public MustInherit Class Entity(Of TEntityData As EntityData)
    Implements IEntity

    Protected MustOverride ReadOnly Property EntityData As TEntityData

    Public Sub Clear() Implements IEntity.Clear
        EntityData.Metadatas.Clear()
    End Sub

    Public Sub SetMetadata(metadataId As String, metadataValue As String) Implements IEntity.SetMetadata
        EntityData.Metadatas(metadataId) = metadataValue
    End Sub

    Public Sub SetCounter(counterId As String, counterValue As Integer) Implements IEntity.SetCounter
        EntityData.Counters(counterId) = counterValue
    End Sub

    Public Sub SetTag(tagId As String, tagValue As Boolean) Implements IEntity.SetTag
        If tagValue Then
            EntityData.Tags.Add(tagId)
        Else
            EntityData.Tags.Remove(tagId)
        End If
    End Sub

    Public Sub SetCounterMaximum(counterId As String, counterMaximum As Integer) Implements IEntity.SetCounterMaximum
        EntityData.CounterMaximums(counterId) = counterMaximum
    End Sub

    Public Sub SetCounterMinimum(counterId As String, counterMinimum As Integer) Implements IEntity.SetCounterMinimum
        EntityData.CounterMinimums(counterId) = counterMinimum
    End Sub

    Public Sub DefaultCounter(counterId As String, defaultValue As Integer) Implements IEntity.DefaultCounter
        SetCounter(
            counterId,
            If(
                TryGetCounter(counterId),
                defaultValue))
    End Sub

    Public Function GetMetadata(metadataId As String) As String Implements IEntity.GetMetadata
        Return EntityData.Metadatas(metadataId)
    End Function

    Public Function GetCounter(counterId As String) As Integer Implements IEntity.GetCounter
        Return Math.Clamp(
            EntityData.Counters(counterId),
            GetCounterMinimum(counterId),
            GetCounterMaximum(counterId))
    End Function

    Public Function HasTag(tagId As String) As Boolean Implements IEntity.HasTag
        Return EntityData.Tags.Contains(tagId)
    End Function

    Public Function GetCounterMaximum(counterId As String) As Integer Implements IEntity.GetCounterMaximum
        Dim result As Integer
        If EntityData.CounterMaximums.TryGetValue(counterId, result) Then
            Return result
        End If
        Return Integer.MaxValue
    End Function

    Public Function GetCounterMinimum(counterId As String) As Integer Implements IEntity.GetCounterMinimum
        Dim result As Integer
        If EntityData.CounterMinimums.TryGetValue(counterId, result) Then
            Return result
        End If
        Return Integer.MinValue
    End Function

    Public Function TryGetCounter(counterId As String) As Integer? Implements IEntity.TryGetCounter
        Dim result As Integer
        If EntityData.Counters.TryGetValue(counterId, result) Then
            Return result
        End If
        Return Nothing
    End Function

    Public Function ChangeCounter(counterId As String, delta As Integer) As Integer Implements IEntity.ChangeCounter
        SetCounter(counterId, GetCounter(counterId) + delta)
        Return GetCounter(counterId)
    End Function
End Class

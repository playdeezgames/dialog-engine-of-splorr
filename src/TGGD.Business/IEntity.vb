Public Interface IEntity
    Sub Clear()
    Function GetMetadata(metadataId As String) As String
    Sub SetMetadata(metadataId As String, metadataValue As String)
    Sub SetCounter(counterId As String, counterValue As Integer)
    Function GetCounter(counterId As String) As Integer
    Function HasTag(tagId As String) As Boolean
    Sub SetTag(tagId As String, tagValue As Boolean)
    Function GetCounterMaximum(counterId As String) As Integer
    Sub SetCounterMaximum(counterId As String, counterMaximum As Integer)
    Function GetCounterMinimum(counterId As String) As Integer
    Sub SetCounterMinimum(counterId As String, counterMinimum As Integer)
    Function TryGetCounter(counterId As String) As Integer?
    Function ChangeCounter(counterId As String, delta As Integer) As Integer
    Sub DefaultCounter(counterId As String, defaultValue As Integer)
End Interface

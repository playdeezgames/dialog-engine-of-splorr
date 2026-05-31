Public Module RNG
    Private random As New Random
    Public Function FromRange(inclusiveLower As Integer, inclusiveUpper As Integer, Optional random As Random = Nothing) As Integer
        random = If(random, RNG.random)
        Return random.Next(inclusiveUpper - inclusiveLower + 1) + inclusiveLower
    End Function
End Module

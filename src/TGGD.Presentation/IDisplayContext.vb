Public Interface IDisplayContext
    Sub Render(
                   Optional text As String = Nothing,
                   Optional mood As String = Nothing,
                   Optional newLine As Boolean = False)
End Interface

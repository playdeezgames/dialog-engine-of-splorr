Public Interface IDialogPrompt
    ReadOnly Property PromptType As DialogPromptType
    ReadOnly Property Choices As String()
    ReadOnly Property Title As String
    Function Respond(
               Optional text As String = Nothing,
               Optional counter As Integer? = Nothing,
               Optional dimension As Double? = Nothing) As IDialog
End Interface

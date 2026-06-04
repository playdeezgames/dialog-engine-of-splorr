Public Class DialogPrompt
    Implements IDialogPrompt

    Private Sub New(
                   promptType As DialogPromptType,
                   title As String,
                   Optional choices As IDialogChoice() = Nothing,
                   Optional fromString As Func(Of String, IDialog) = Nothing,
                   Optional fromInteger As Func(Of Integer, IDialog) = Nothing,
                   Optional fromDouble As Func(Of Double, IDialog) = Nothing)
        Me.PromptType = promptType
        Me.Title = title
        Me._choices = If(choices IsNot Nothing, choices.Where(Function(x) x.Enabled).ToArray, Nothing)
        Me.fromString = fromString
        Me.fromInteger = fromInteger
        Me.fromDouble = fromDouble
    End Sub


    Public ReadOnly Property PromptType As DialogPromptType Implements IDialogPrompt.PromptType

    Public ReadOnly Property Choices As String() Implements IDialogPrompt.Choices
        Get
            Return _choices.Select(Function(x) x.Text).ToArray
        End Get
    End Property

    Public ReadOnly Property Title As String Implements IDialogPrompt.Title
    Private ReadOnly _choices As IDialogChoice()
    Private ReadOnly fromString As Func(Of String, IDialog)
    Private ReadOnly fromInteger As Func(Of Integer, IDialog)
    Private ReadOnly fromDouble As Func(Of Double, IDialog)

    Public Function Respond(
                           Optional text As String = Nothing,
                           Optional counter As Integer? = Nothing,
                           Optional dimension As Double? = Nothing) As IDialog Implements IDialogPrompt.Respond
        Select Case PromptType
            Case DialogPromptType.PROMPT_CHOOSE
                Return _choices(counter.Value).NextDialog()
            Case DialogPromptType.PROMPT_DOUBLE
                Return fromDouble(dimension.Value)
            Case DialogPromptType.PROMPT_INTEGER
                Return fromInteger(counter.Value)
            Case DialogPromptType.PROMPT_STRING
                Return fromString(text)
            Case Else
                Throw New NotImplementedException
        End Select
    End Function

    Public Shared Function CreateChoicePrompt(
                                             title As String,
                                             ParamArray choices As IDialogChoice()) As IDialogPrompt
        Return New DialogPrompt(DialogPromptType.PROMPT_CHOOSE, title, choices:=choices)
    End Function

    Public Shared Function CreateIntegerPrompt(title As String, fromInteger As Func(Of Integer, IDialog)) As IDialogPrompt
        Return New DialogPrompt(DialogPromptType.PROMPT_INTEGER, title, fromInteger:=fromInteger)
    End Function

    Public Shared Function CreateDoublePrompt(title As String, fromDouble As Func(Of Double, IDialog)) As IDialogPrompt
        Return New DialogPrompt(DialogPromptType.PROMPT_DOUBLE, title, fromDouble:=fromDouble)
    End Function

    Public Shared Function CreateStringPrompt(title As String, fromString As Func(Of String, IDialog)) As IDialogPrompt
        Return New DialogPrompt(DialogPromptType.PROMPT_STRING, title, fromString:=fromString)
    End Function
End Class

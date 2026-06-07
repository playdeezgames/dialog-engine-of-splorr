Imports GMN.Platform
Imports Spectre.Console
Imports TGGD.Platform
Imports TGGD.Presentation

Module Program
    Sub Main(args As String())
        Console.Title = "Guess My Number"
        Dim display As IDisplay = GMNDisplay.Create(True, New Persister).Result
        While display.Running
            AnsiConsole.Clear()
            For Each element In display.Elements
                RenderElement(element)
            Next
            ReadPrompt(display.Prompt)
        End While
    End Sub

    Private Sub ReadPrompt(prompt As IDialogPrompt)
        Select Case prompt.PromptType
            Case DialogPromptType.PROMPT_CHOOSE
                ReadChoosePrompt(prompt)
            Case DialogPromptType.PROMPT_DOUBLE
                ReadDoublePrompt(prompt)
            Case DialogPromptType.PROMPT_INTEGER
                ReadIntegerPrompt(prompt)
            Case DialogPromptType.PROMPT_STRING
                ReadStringPrompt(prompt)
            Case Else
                Throw New NotImplementedException
        End Select
    End Sub

    Private Sub ReadStringPrompt(prompt As IDialogPrompt)
        prompt.Respond(text:=AnsiConsole.Ask(Of String)($"[olive]{Markup.Escape(prompt.Title)}[/]"))
    End Sub

    Private Sub ReadIntegerPrompt(prompt As IDialogPrompt)
        prompt.Respond(counter:=AnsiConsole.Ask(Of Integer)($"[olive]{Markup.Escape(prompt.Title)}[/]"))
    End Sub

    Private Sub ReadDoublePrompt(prompt As IDialogPrompt)
        prompt.Respond(dimension:=AnsiConsole.Ask(Of Double)($"[olive]{Markup.Escape(prompt.Title)}[/]"))
    End Sub

    Private Sub ReadChoosePrompt(prompt As IDialogPrompt)
        Dim selectionPrompt As New SelectionPrompt(Of Integer) With
            {
                .Title = $"[olive]{Markup.Escape(prompt.Title)}[/]",
                .Converter = Function(x) prompt.Choices(x)
            }
        selectionPrompt.AddChoices(Enumerable.Range(0, prompt.Choices.Length))
        prompt.Respond(counter:=AnsiConsole.Prompt(selectionPrompt))
    End Sub

    Private ReadOnly moodColors As IReadOnlyDictionary(Of String, String) =
        New Dictionary(Of String, String) From {}

    Private Sub RenderElement(element As IDisplayElement)
        Dim colorName As String = Nothing
        If element.Mood IsNot Nothing AndAlso moodColors.TryGetValue(element.Mood, colorName) Then
            AnsiConsole.Write($"[{colorName}]{Markup.Escape(element.Text)}[/]")
        Else
            AnsiConsole.Write(Markup.Escape(element.Text))
        End If
        If element.NewLine Then
            AnsiConsole.WriteLine()
        End If
    End Sub
End Module

Imports Spectre.Console
Imports TGGD.UI

Friend Class GMNHostContext
    Implements IHostContext

    Public Sub WriteLine(text As String, Optional color As String = Nothing) Implements IHostContext.WriteLine
        AnsiConsole.MarkupLine($"{If(color IsNot Nothing, $"[{color}]", String.Empty)}{text}{If(color IsNot Nothing, $"[/]", String.Empty)}")
    End Sub

    Public Sub Pause() Implements IHostContext.Pause
        Dim prompt As New SelectionPrompt(Of String) With
            {
                .Title = String.Empty
            }
        prompt.AddChoice("Ok")
        AnsiConsole.Prompt(prompt)
    End Sub

    Public Sub Clear() Implements IHostContext.Clear
        AnsiConsole.Clear()
    End Sub

    Public Sub WriteString(text As String, Optional color As String = Nothing) Implements IHostContext.WriteString
        AnsiConsole.Markup($"{If(color IsNot Nothing, $"[{color}]", String.Empty)}{text}{If(color IsNot Nothing, $"[/]", String.Empty)}")
    End Sub

    Public Sub WriteFiglet(text As String, Optional color As String = Nothing) Implements IHostContext.WriteFiglet
        Dim figlet = New FigletText(text)
        If color IsNot Nothing Then
            figlet.Color = Spectre.Console.Color.FromName(color)
        End If
        AnsiConsole.Write(figlet)
    End Sub

    Public Function Choose(title As String, ParamArray choices As IDialogChoice()) As IDialog Implements IHostContext.Choose
        Dim prompt As New SelectionPrompt(Of IDialogChoice) With
            {
                .title = $"[olive]{title}[/]",
                .Converter = Function(x) x.Text
            }
        prompt.AddChoices(choices.Where(Function(x) x.Enabled))
        Return AnsiConsole.Prompt(prompt).NextDialog
    End Function

    Public Function ReadString(text As String, Optional defaultValue As String = Nothing) As String Implements IHostContext.ReadString
        If defaultValue IsNot Nothing Then
            Return AnsiConsole.Ask(Of String)(text, defaultValue)
        End If
        Return AnsiConsole.Ask(Of String)(text)
    End Function

    Public Function ReadKey() As String Implements IHostContext.ReadKey
        Return Console.ReadKey(True).Key.ToString
    End Function

    Public Function ReadInteger(text As String, Optional defaultValue As Integer? = Nothing) As Integer Implements IHostContext.ReadInteger
        If defaultValue.HasValue Then
            Return AnsiConsole.Ask(Of Integer)(text, defaultValue.Value)
        Else
            Return AnsiConsole.Ask(Of Integer)(text)
        End If
    End Function
End Class

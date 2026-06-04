Imports GMN.Processing
Imports TGGD.Presentation

Friend Class EvaluateGuessDialog
    Inherits ExitableModelDialog(Of IDisplayContext, IWorldModel)

    Private Sub New(context As IDisplayContext, model As IWorldModel, exitDialog As Func(Of IDialog))
        MyBase.New(context, model, exitDialog)
    End Sub

    Public Overrides Function Run() As IDialogPrompt
        Context.Render($"Yer guess: {Model.Guess}", newLine:=True)
        If Model.IsGuessHigh Then
            Context.Render($"That guess is too high!", newLine:=True)
            Return NewRoundDialog.Launch(Context, Model, ExitDialog).Invoke.Run()
        ElseIf Model.IsGuessLow Then
            Context.Render($"That guess is too low!", newLine:=True)
            Return NewRoundDialog.Launch(Context, Model, ExitDialog).Invoke.Run()
        Else
            Context.Render($"Yer right!", newLine:=True)
            Return EndGameDialog.Launch(Context, Model, ExitDialog).Invoke.Run()
        End If
    End Function

    Protected Overrides Function Relaunch() As IDialog
        Return Launch(Context, Model, ExitDialog).Invoke
    End Function

    Friend Shared Function Launch(context As IDisplayContext, model As IWorldModel, exitDialog As Func(Of IDialog)) As Func(Of IDialog)
        Return Function() New EvaluateGuessDialog(context, model, exitDialog)
    End Function
End Class

Imports GMN.Processing
Imports TGGD.Presentation

Friend Class EndGameDialog
    Inherits ExitableModelDialog(Of IDisplayContext, IWorldModel)

    Private Sub New(context As IDisplayContext, model As IWorldModel, exitDialog As Func(Of IDialog))
        MyBase.New(context, model, exitDialog)
    End Sub

    Public Overrides Function Run() As IDialogPrompt
        Context.Render($"It took you {Model.GuessCount} guesses!", newLine:=True)
        Model.FinishGame()
        Return ExitDialog.Invoke.Run
    End Function

    Protected Overrides Function Relaunch() As IDialog
        Return Launch(Context, Model, ExitDialog).Invoke
    End Function

    Friend Shared Function Launch(context As IDisplayContext, model As IWorldModel, exitDialog As Func(Of IDialog)) As Func(Of IDialog)
        Return Function() New EndGameDialog(context, model, exitDialog)
    End Function
End Class

Imports GMN.Processing
Imports TGGD.Presentation

Friend Class NewRoundDialog
    Inherits ExitableModelDialog(Of IDisplayContext, IWorldModel)

    Private Sub New(context As IDisplayContext, model As IWorldModel, exitDialog As Func(Of IDialog))
        MyBase.New(context, model, exitDialog)
    End Sub

    Public Overrides Function Run() As IDialogPrompt
        Context.Render($"Guess my number {Model.MinimumTarget} thru {Model.MaximumTarget}!", newLine:=True)
        Return DialogPrompt.CreateIntegerPrompt($"Guess #{Model.CurrentGuessNumber}: ", AddressOf MakeGuess)
    End Function

    Private Function MakeGuess(guess As Integer) As IDialog
        Model.MakeGuess(guess)
        Return EvaluateGuessDialog.Launch(Context, Model, ExitDialog).Invoke
    End Function

    Protected Overrides Function Relaunch() As IDialog
        Return Launch(Context, Model, ExitDialog).Invoke
    End Function

    Friend Shared Function Launch(
                                 context As IDisplayContext,
                                 model As IWorldModel,
                                 exitDialog As Func(Of IDialog)) As Func(Of IDialog)
        Return Function() New NewRoundDialog(context, model, exitDialog)
    End Function
End Class

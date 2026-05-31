Imports GMN.Model
Imports TGGD.UI

Friend Class NewRoundDialog
    Inherits ExitableModelDialog(Of IHostContext, IWorldModel)

    Private Sub New(context As IHostContext, model As IWorldModel, exitDialog As Func(Of IDialog))
        MyBase.New(context, model, exitDialog)
    End Sub

    Public Overrides Function Run() As IDialog
        Context.WriteLine($"Guess my number {Model.MinimumTarget} thru {Model.MaximumTarget}!")
        Model.MakeGuess(Context.ReadInteger($"Guess #{Model.CurrentGuessNumber}: "))
        Return EvaluateGuessDialog.Launch(Context, Model, ExitDialog).Invoke
    End Function

    Protected Overrides Function Relaunch() As IDialog
        Return Launch(Context, Model, ExitDialog).Invoke
    End Function

    Friend Shared Function Launch(context As IHostContext, model As IWorldModel, exitDialog As Func(Of IDialog)) As Func(Of IDialog)
        Return Function() New NewRoundDialog(context, model, exitDialog)
    End Function
End Class

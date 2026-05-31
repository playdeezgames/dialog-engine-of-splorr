Imports GMN.Model
Imports TGGD.UI

Friend Class EndGameDialog
    Inherits ExitableModelDialog(Of IHostContext, IWorldModel)

    Private Sub New(context As IHostContext, model As IWorldModel, exitDialog As Func(Of IDialog))
        MyBase.New(context, model, exitDialog)
    End Sub

    Public Overrides Function Run() As IDialog
        Context.WriteLine($"It took you {Model.GuessCount} guesses!")
        Model.FinishGame()
        Return ExitDialog.Invoke
    End Function

    Protected Overrides Function Relaunch() As IDialog
        Return Launch(Context, Model, ExitDialog).Invoke
    End Function

    Friend Shared Function Launch(context As IHostContext, model As IWorldModel, exitDialog As Func(Of IDialog)) As Func(Of IDialog)
        Return Function() New EndGameDialog(context, model, exitDialog)
    End Function
End Class

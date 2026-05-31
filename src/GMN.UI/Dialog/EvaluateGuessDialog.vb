Imports GMN.Model
Imports TGGD.UI

Friend Class EvaluateGuessDialog
    Inherits ExitableModelDialog(Of IHostContext, IWorldModel)

    Private Sub New(context As IHostContext, model As IWorldModel, exitDialog As Func(Of IDialog))
        MyBase.New(context, model, exitDialog)
    End Sub

    Public Overrides Function Run() As IDialog
        If Model.IsGuessHigh Then
            Context.WriteLine($"That guess is too high!")
            Return NewRoundDialog.Launch(Context, Model, ExitDialog).Invoke
        ElseIf Model.IsGuessLow Then
            Context.WriteLine($"That guess is too low!")
            Return NewRoundDialog.Launch(Context, Model, ExitDialog).Invoke
        Else
            Context.WriteLine($"Yer right!")
            Return EndGameDialog.Launch(Context, Model, ExitDialog).Invoke
        End If
    End Function

    Protected Overrides Function Relaunch() As IDialog
        Return Launch(Context, Model, ExitDialog).Invoke
    End Function

    Friend Shared Function Launch(context As IHostContext, model As IWorldModel, exitDialog As Func(Of IDialog)) As Func(Of IDialog)
        Return Function() New EvaluateGuessDialog(context, model, exitDialog)
    End Function
End Class

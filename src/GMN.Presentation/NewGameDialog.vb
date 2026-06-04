Imports GMN.Processing
Imports TGGD.Presentation

Friend Class NewGameDialog
    Inherits ExitableModelDialog(Of IDisplayContext, IWorldModel)

    Private Sub New(context As IDisplayContext, model As IWorldModel, exitDialog As Func(Of IDialog))
        MyBase.New(context, model, exitDialog)
    End Sub

    Public Overrides Function Run() As IDialogPrompt
        Model.StartGame()
        Return NewRoundDialog.Launch(Context, Model, ExitDialog).Invoke().Run()
    End Function

    Protected Overrides Function Relaunch() As IDialog
        Return Launch(Context, Model, ExitDialog).Invoke()
    End Function

    Friend Shared Function Launch(context As IDisplayContext, model As IWorldModel, exitDialog As Func(Of IDialog)) As Func(Of IDialog)
        Return Function() New NewGameDialog(context, model, exitDialog)
    End Function
End Class

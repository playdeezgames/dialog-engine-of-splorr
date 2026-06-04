Imports GMN.Processing
Imports TGGD.Presentation

Friend Class ResetStatisticsDialog
    Inherits ExitableModelDialog(Of IDisplayContext, IWorldModel)

    Private Sub New(context As IDisplayContext, model As IWorldModel, exitDialog As Func(Of IDialog))
        MyBase.New(context, model, exitDialog)
    End Sub

    Public Overrides Function Run() As IDialogPrompt
        Context.Render("Statistics reset!", newLine:=True)
        Model.ResetStatistics()
        Return ExitDialog.Invoke.Run()
    End Function

    Protected Overrides Function Relaunch() As IDialog
        Return Launch(Context, Model, ExitDialog).Invoke()
    End Function

    Friend Shared Function Launch(context As IDisplayContext, model As IWorldModel, exitDialog As Func(Of IDialog)) As Func(Of IDialog)
        Return Function() New ResetStatisticsDialog(context, model, exitDialog)
    End Function
End Class

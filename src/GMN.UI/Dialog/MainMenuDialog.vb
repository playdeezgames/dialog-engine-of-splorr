Imports GMN.Model
Imports TGGD.UI

Friend Class MainMenuDialog
    Inherits ExitableModelDialog(Of IHostContext, IWorldModel)

    Private Sub New(context As IHostContext, model As IWorldModel, exitDialog As Func(Of IDialog))
        MyBase.New(context, model, exitDialog)
    End Sub

    Public Overrides Function Run() As IDialog
        Context.WriteLine($"Games Played: {Model.GamesPlayed}")
        Dim averageScore = Model.AverageScore
        If averageScore.HasValue Then
            Context.WriteLine($"Average Score: {averageScore.Value}")
        End If
        Return Context.Choose(
            "Main Menu:",
            DialogChoice.CreateEnabled(
                "New Game!",
                NewGameDialog.Launch(
                    Context,
                    Model,
                    AddressOf Relaunch)),
            DialogChoice.CreateEnabled(
                "Reset Statistics",
                ConfirmDialog(Of IHostContext).
                    Launch(
                        Context,
                        "[red]Are you sure you want to reset statistics?[/]",
                        ResetStatisticsDialog.Launch(
                            Context,
                            Model,
                            AddressOf Relaunch),
                        AddressOf Relaunch)),
            DialogChoice.CreateEnabled(
                "Quit",
                ConfirmDialog(Of IHostContext).
                    Launch(
                        Context,
                        "[red]Are you sure you want to quit?[/]",
                        ExitDialog,
                        AddressOf Relaunch)))
    End Function

    Protected Overrides Function Relaunch() As IDialog
        Return Launch(Context, Model, ExitDialog).Invoke
    End Function

    Friend Shared Function Launch(context As IHostContext, model As IWorldModel, exitDialog As Func(Of IDialog)) As Func(Of IDialog)
        Return Function() New MainMenuDialog(context, model, exitDialog)
    End Function
End Class

Imports GMN.Processing
Imports TGGD.Presentation

Friend Class MainMenuDialog
    Inherits ExitableModelDialog(Of IDisplayContext, IWorldModel)

    Private Sub New(context As IDisplayContext, model As IWorldModel, exitDialog As Func(Of IDialog))
        MyBase.New(context, model, exitDialog)
    End Sub

    Public Overrides Function Run() As IDialogPrompt
        Context.Render($"Games Played: {Model.GamesPlayed}", newLine:=True)
        Dim averageScore = Model.AverageScore
        If averageScore.HasValue Then
            Context.Render($"Average Score: {averageScore.Value}", newLine:=True)
        End If
        Return DialogPrompt.CreateChoicePrompt(
            "Main Menu:",
            DialogChoice.Create(
                True,
                "New Game!",
                NewGameDialog.Launch(
                    Context,
                    Model,
                    AddressOf Relaunch)),
            DialogChoice.Create(
                True,
                "Reset Statistics",
                ConfirmDialog(Of IDisplayContext).
                    Launch(
                        Context,
                        "Are you sure you want to reset statistics?",
                        ResetStatisticsDialog.Launch(
                            Context,
                            Model,
                            AddressOf Relaunch),
                        AddressOf Relaunch)),
            DialogChoice.Create(
                Model.IsQuittable,
                "Quit",
                ConfirmDialog(Of IDisplayContext).Launch(
                    Context,
                    "Are you sure you want to quit?",
                    ExitDialog,
                    AddressOf Relaunch)))
    End Function

    Protected Overrides Function Relaunch() As IDialog
        Return Launch(Context, Model, ExitDialog).Invoke
    End Function

    Friend Shared Function Launch(context As IDisplayContext, model As IWorldModel, exitDialog As Func(Of IDialog)) As Func(Of IDialog)
        Return Function() New MainMenuDialog(context, model, exitDialog)
    End Function
End Class

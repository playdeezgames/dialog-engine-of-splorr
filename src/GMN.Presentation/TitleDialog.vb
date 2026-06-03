Imports GMN.Processing
Imports TGGD.Presentation

Public Class TitleDialog
    Inherits ExitableModelDialog(Of IDisplayContext, IWorldModel)
    Implements IDialog

    Private Sub New(context As IDisplayContext, model As IWorldModel, exitDialog As Func(Of IDialog))
        MyBase.New(context, model, exitDialog)
    End Sub

    Public Overrides Function Run() As IDialogPrompt
        Context.Render("Guess My Number(1-100)", newLine:=True)
        Return DialogPrompt.CreateChoicePrompt("", DialogChoice.Create(True, "OK", MainMenuDialog.Launch(Context, Model, ExitDialog)))
    End Function

    Protected Overrides Function Relaunch() As IDialog
        Throw New NotImplementedException()
    End Function

    Public Shared Function Launch(context As IDisplayContext, model As IWorldModel, exitDialog As Func(Of IDialog)) As Func(Of IDialog)
        Return Function() New TitleDialog(context, model, exitDialog)
    End Function
End Class

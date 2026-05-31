Imports TGGD.Model

Public MustInherit Class ExitableModelDialog(Of TContext As IHostContext, TModel As IModel)
    Inherits BaseModelDialog(Of TContext, TModel)

    Protected ReadOnly ExitDialog As Func(Of IDialog)

    Protected Sub New(
                     context As TContext,
                     model As TModel,
                     exitDialog As Func(Of IDialog))
        MyBase.New(context, model)
        Me.ExitDialog = exitDialog
    End Sub
    Protected ReadOnly Property ExitChoice As IDialogChoice
        Get
            Return DialogChoice.Create(ExitDialog IsNot Nothing, GetExitText(), ExitDialog)
        End Get
    End Property

    Protected Overridable Function GetExitText() As String
        Return "Never Mind"
    End Function
End Class

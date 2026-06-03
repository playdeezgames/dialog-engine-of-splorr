Imports TGGD.Processing

Public MustInherit Class ExitableModelDialog(Of TContext As IDisplayContext, TModel As IModel)
    Inherits BaseModelDialog(Of TContext, TModel)

    Protected ReadOnly ExitDialog As Func(Of IDialog)

    Protected Sub New(
                     context As TContext,
                     model As TModel,
                     exitDialog As Func(Of IDialog))
        MyBase.New(context, model)
        Me.ExitDialog = exitDialog
    End Sub
End Class

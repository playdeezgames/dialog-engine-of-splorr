Public MustInherit Class BaseDialog(Of TContext As IHostContext)
    Implements IDialog
    Protected ReadOnly Context As TContext
    Protected Sub New(context As TContext)
        Me.Context = context
    End Sub
    Public MustOverride Function Run() As IDialog Implements IDialog.Run
    Protected MustOverride Function Relaunch() As IDialog
End Class

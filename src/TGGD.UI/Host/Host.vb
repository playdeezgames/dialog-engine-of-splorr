Public MustInherit Class Host
    Implements IHost

    Protected ReadOnly Context As IHostContext

    Protected Sub New(context As IHostContext)
        Me.Context = context
    End Sub

    Public MustOverride Function Run() As IDialog Implements IDialog.Run
End Class

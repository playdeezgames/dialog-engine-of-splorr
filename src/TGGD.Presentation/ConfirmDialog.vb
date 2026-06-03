Public Class ConfirmDialog(Of TContext As IDisplayContext)
    Inherits BaseDialog(Of TContext)

    Public ReadOnly Property Text As String
    Public ReadOnly Property OnConfirmDialog As Func(Of IDialog)
    Public ReadOnly Property OnCancelDialog As Func(Of IDialog)

    Private Sub New(
                   context As TContext,
                   text As String,
                   onConfirmDialog As Func(Of IDialog),
                   onCancelDialog As Func(Of IDialog))
        MyBase.New(context)
        Me.Text = text
        Me.OnConfirmDialog = onConfirmDialog
        Me.OnCancelDialog = onCancelDialog
    End Sub

    Public Shared Function Launch(
                                 context As TContext,
                                 text As String,
                                 onConfirmDialog As Func(Of IDialog),
                                 onCancelDialog As Func(Of IDialog)) As Func(Of IDialog)
        Return Function() New ConfirmDialog(Of TContext)(context, text, onConfirmDialog, onCancelDialog)
    End Function

    Protected Overrides Function Relaunch() As IDialog
        Return Launch(
            Context,
            Text,
            OnConfirmDialog,
            OnCancelDialog).Invoke
    End Function

    Public Overrides Function Run() As IDialogPrompt
        Return DialogPrompt.CreateChoicePrompt(
            Text,
            DialogChoice.CreateEnabled("No", OnCancelDialog),
            DialogChoice.CreateEnabled("Yes", OnConfirmDialog))
    End Function
End Class

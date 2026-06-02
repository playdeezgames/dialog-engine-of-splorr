Imports DS.Model
Imports TGGD.UI

Friend Class Line2225Dialog
    Inherits ExitableModelDialog(Of IHostContext, IWorldModel)

    Private Sub New(context As IHostContext, model As IWorldModel, exitDialog As Func(Of IDialog))
        MyBase.New(context, model, exitDialog)
    End Sub

    Friend Shared Function Launch(context As IHostContext, model As IWorldModel, exitDialog As Func(Of IDialog)) As Func(Of IDialog)
        Return Function() New Line2225Dialog(context, model, exitDialog)
    End Function

    Public Overrides Function Run() As IDialog
        Throw New NotImplementedException()
    End Function

    Protected Overrides Function Relaunch() As IDialog
        Throw New NotImplementedException()
    End Function
End Class

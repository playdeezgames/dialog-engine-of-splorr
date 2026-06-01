Imports DS.Model
Imports TGGD.UI

Public Class DSHost
    Inherits Host

    Private Sub New(context As IHostContext)
        MyBase.New(context)
    End Sub
    Public Shared Sub Execute(context As IHostContext)
        Dim host As New DSHost(context)
        host.Run()
    End Sub

    Public Overrides Function Run() As IDialog
        Dim model As IWorldModel = WorldModel.Create()
        Dim dialog As IDialog = Line100Dialog.Launch(Context, model, Function() Nothing).Invoke()
        Do While dialog IsNot Nothing
            dialog = dialog.Run()
        Loop
        Return dialog
    End Function
End Class

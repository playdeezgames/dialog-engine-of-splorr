Imports DS.Model
Imports TGGD.UI

Friend Class Line100Dialog
    Inherits ExitableModelDialog(Of IHostContext, IWorldModel)

    Private Sub New(context As IHostContext, model As IWorldModel, exitDialog As Func(Of IDialog))
        MyBase.New(context, model, exitDialog)
    End Sub

    Public Overrides Function Run() As IDialog
        Context.WriteFiglet("DOG STAR", "fuchsia")
        Context.WriteLine("By Lance Micklus")
        Context.WriteLine("Winooski, VT. 05404")
        Context.WriteLine("Copyright 1979")
        Context.WriteLine("A Re-Production of TheGrumpyGameDev")
        Context.WriteLine("Mount Pleasant, WI. 53406")
        Model.Reset()
        Context.Pause()
        Return ExitDialog.Invoke
    End Function

    Protected Overrides Function Relaunch() As IDialog
        Return Launch(Context, Model, ExitDialog).Invoke
    End Function

    Friend Shared Function Launch(context As IHostContext, model As IWorldModel, exitDialog As Func(Of IDialog)) As Func(Of IDialog)
        Return Function() New Line100Dialog(context, model, exitDialog)
    End Function
End Class

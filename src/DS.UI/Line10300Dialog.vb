Imports DS.Model
Imports TGGD.UI

Friend Class Line10300Dialog
    Inherits ExitableModelDialog(Of IHostContext, IWorldModel)

    Private Sub New(context As IHostContext, model As IWorldModel, exitDialog As Func(Of IDialog))
        MyBase.New(context, model, exitDialog)
    End Sub

    Public Overrides Function Run() As IDialog
        Context.Clear()
        Context.WriteLine(Model.LocationName)
        Model.UpdateGF()
        If Not Model.IsInSupplyDepot AndAlso Model.HasLocationObjects Then
            Context.WriteLine("around me I see:")
            Context.WriteLine(String.Join(", ", Model.LocationObjects.Select(Function(x) x.Name)))
        End If
        Context.WriteString("
Obvious directions are ")
        Dim exits = Model.LocationExits.Where(Function(x) x.Exists)
        If Not exits.any Then
            Context.WriteString("unknown")
        Else
            Context.WriteString(String.Join(", ", exits.Select(Function(x) x.DirectionName)))
        End If
        Context.WriteLine(".")
        Return Line2125Dialog.Launch(Context, Model, ExitDialog).Invoke()
    End Function

    Protected Overrides Function Relaunch() As IDialog
        Return Launch(Context, Model, ExitDialog).Invoke
    End Function

    Friend Shared Function Launch(context As IHostContext, model As IWorldModel, exitDialog As Func(Of IDialog)) As Func(Of IDialog)
        Return Function() New Line10300Dialog(context, model, exitDialog)
    End Function
End Class

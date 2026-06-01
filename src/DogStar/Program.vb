Imports DS.UI

Module Program
    Sub Main(args As String())
        Console.Title = "Guess My Number"
        DSHost.Execute(New DSHostContext())
    End Sub
End Module

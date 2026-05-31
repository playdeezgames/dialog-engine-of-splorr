Imports GMN.UI

Module Program
    Sub Main(args As String())
        Console.Title = "Guess My Number"
        GMNHost.Execute(New GMNHostContext())
    End Sub
End Module

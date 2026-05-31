Public Interface IHostContext
    Sub WriteLine(text As String, Optional color As String = Nothing)
    Sub WriteString(text As String, Optional color As String = Nothing)
    Sub Pause()
    Sub Clear()
    Function Choose(title As String, ParamArray choices As IDialogChoice()) As IDialog
    Function ReadString(text As String, Optional defaultValue As String = Nothing) As String
    Function ReadKey() As String
    Sub WriteFiglet(text As String, Optional color As String = Nothing)
    Function ReadInteger(text As String, Optional defaultValue As Integer? = Nothing) As Integer
End Interface

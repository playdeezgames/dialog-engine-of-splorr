Public Class DisplayElement
    Implements IDisplayElement

    Private Sub New(text As String, mood As String, newLine As Boolean)
        Me.Mood = mood
        Me.Text = text
        Me.NewLine = newLine
    End Sub

    Public ReadOnly Property Mood As String Implements IDisplayElement.Mood

    Public ReadOnly Property Text As String Implements IDisplayElement.Text

    Public ReadOnly Property NewLine As Boolean Implements IDisplayElement.NewLine

    Public Shared Function Create(text As String, mood As String, newLine As Boolean) As IDisplayElement
        Return New DisplayElement(text, mood, newLine)
    End Function
End Class

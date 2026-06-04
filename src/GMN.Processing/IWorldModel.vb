Imports TGGD.Processing

Public Interface IWorldModel
    Inherits IModel
    ReadOnly Property GamesPlayed As Integer
    ReadOnly Property AverageScore As Integer?
    Sub StartGame()
    ReadOnly Property MinimumTarget As Integer
    ReadOnly Property MaximumTarget As Integer
    ReadOnly Property CurrentGuessNumber As Integer
    ReadOnly Property IsGuessHigh As Boolean
    ReadOnly Property IsGuessLow As Boolean
    Sub MakeGuess(guess As Integer)
    Sub FinishGame()
    Sub ResetStatistics()
    ReadOnly Property GuessCount As Integer
    ReadOnly Property Guess As Integer
    ReadOnly Property IsQuittable As Boolean
End Interface

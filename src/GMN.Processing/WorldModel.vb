Imports GMN.Persistence
Imports TGGD.Persistence
Imports TGGD.Processing

Public Class WorldModel
    Inherits BaseModel(Of IWorld)
    Implements IWorldModel

    Protected Sub New(entity As IWorld)
        MyBase.New(entity)
    End Sub

    Public ReadOnly Property GamesPlayed As Integer Implements IWorldModel.GamesPlayed
        Get
            Return If(Entity.TryGetCounter(Counters.GAMES_PLAYED), 0)
        End Get
    End Property

    Public ReadOnly Property AverageScore As Integer? Implements IWorldModel.AverageScore
        Get
            Dim totalScore = Entity.TryGetCounter(Counters.TOTAL_SCORE)
            If GamesPlayed = 0 OrElse Not totalScore.HasValue Then
                Return Nothing
            End If
            Return totalScore.Value \ GamesPlayed
        End Get
    End Property

    Public ReadOnly Property MinimumTarget As Integer Implements IWorldModel.MinimumTarget
        Get
            Return Grimoire.MINIMUM_TARGET
        End Get
    End Property

    Public ReadOnly Property MaximumTarget As Integer Implements IWorldModel.MaximumTarget
        Get
            Return Grimoire.MAXIMUM_TARGET
        End Get
    End Property

    Public ReadOnly Property CurrentGuessNumber As Integer Implements IWorldModel.CurrentGuessNumber
        Get
            Return If(Entity.TryGetCounter(Counters.GUESS_COUNT), 0) + 1
        End Get
    End Property

    Public ReadOnly Property IsGuessHigh As Boolean Implements IWorldModel.IsGuessHigh
        Get
            Return Entity.HasTag(Tags.TOO_HIGH)
        End Get
    End Property

    Public ReadOnly Property IsGuessLow As Boolean Implements IWorldModel.IsGuessLow
        Get
            Return Entity.HasTag(Tags.TOO_LOW)
        End Get
    End Property

    Public ReadOnly Property GuessCount As Integer Implements IWorldModel.GuessCount
        Get
            Return Entity.GetCounter(Counters.GUESS_COUNT)
        End Get
    End Property

    Public ReadOnly Property Guess As Integer Implements IWorldModel.Guess
        Get
            Return Entity.GetCounter(Counters.GUESS)
        End Get
    End Property

    Public ReadOnly Property IsQuittable As Boolean Implements IWorldModel.IsQuittable
        Get
            Return Entity.HasTag(Tags.QUITTABLE)
        End Get
    End Property

    Public Sub StartGame() Implements IWorldModel.StartGame
        Entity.SetCounter(Counters.GUESS_COUNT, 0)
        Entity.SetCounter(Counters.TARGET_NUMBER, RNG.FromRange(Grimoire.MINIMUM_TARGET, Grimoire.MAXIMUM_TARGET))
    End Sub

    Public Sub MakeGuess(guess As Integer) Implements IWorldModel.MakeGuess
        Entity.SetCounter(Counters.GUESS, guess)
        Entity.ChangeCounter(Counters.GUESS_COUNT, 1)
        Entity.AssignTag(Tags.TOO_HIGH, guess > Entity.GetCounter(Counters.TARGET_NUMBER))
        Entity.AssignTag(Tags.TOO_LOW, guess < Entity.GetCounter(Counters.TARGET_NUMBER))
    End Sub

    Public Sub FinishGame() Implements IWorldModel.FinishGame
        Entity.DefaultCounter(Counters.GAMES_PLAYED, 0)
        Entity.DefaultCounter(Counters.TOTAL_SCORE, 0)
        Entity.ChangeCounter(Counters.GAMES_PLAYED, 1)
        Entity.ChangeCounter(Counters.TOTAL_SCORE, GuessCount)
        Entity.Save(Grimoire.SAVE_FILE_NAME)
    End Sub

    Public Sub ResetStatistics() Implements IWorldModel.ResetStatistics
        Entity.SetCounter(Counters.GAMES_PLAYED, 0)
        Entity.SetCounter(Counters.TOTAL_SCORE, 0)
        Entity.Save(Grimoire.SAVE_FILE_NAME)
    End Sub

    Public Shared Async Function Create(quittable As Boolean, persister As IPersister) As Task(Of IWorldModel)
        Dim world As IWorld
        Try
            world = Await GMN.Persistence.World.Load(SAVE_FILE_NAME, persister)
        Catch ex As Exception
            world = GMN.Persistence.World.Create(New Provision.GMNData, persister)
        End Try
        If quittable Then
            world.SetTag(Tags.QUITTABLE)
        End If
        Return New WorldModel(world)
    End Function

End Class

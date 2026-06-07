Imports TGGD.Persistence

Public Interface IWorld
    Inherits IEntity

    Function Save(filename As String) As Task
End Interface
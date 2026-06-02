Imports TGGD.Model

Public Interface IWorldModel
    Inherits IModel

    ReadOnly Property LocationName As String
    Sub Reset()
    Sub UpdateGF()
    ReadOnly Property IsInSupplyDepot As Boolean
    ReadOnly Property HasLocationObjects As Boolean
    ReadOnly Property LocationObjects As IEnumerable(Of IObjectModel)
    ReadOnly Property LocationExits As IEnumerable(Of IExitModel)
    Function CheckGuardSpawn() As Boolean
End Interface

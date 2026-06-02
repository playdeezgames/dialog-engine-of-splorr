Imports DS.Business
Imports TGGD.Business
Imports TGGD.Model

Public Class WorldModel
    Inherits BaseModel(Of IWorld)
    Implements IWorldModel

    Protected Sub New(entity As IWorld)
        MyBase.New(entity)
    End Sub

    Public ReadOnly Property LocationName As String Implements IWorldModel.LocationName
        Get
            Return Entity.GetDS(Entity.GetCounter(Counters.LC)).DSs
        End Get
    End Property

    Public ReadOnly Property IsInSupplyDepot As Boolean Implements IWorldModel.IsInSupplyDepot
        Get
            Return Entity.GetCounter(Counters.LC) = LOCATION_7
        End Get
    End Property

    Public ReadOnly Property HasLocationObjects As Boolean Implements IWorldModel.HasLocationObjects
        Get
            Dim locationId = Entity.GetCounter(Counters.LC)
            Return Entity.GetOBs().Any(Function(x) x.OB(1) = locationId)
        End Get
    End Property

    Public ReadOnly Property LocationObjects As IEnumerable(Of IObjectModel) Implements IWorldModel.LocationObjects
        Get
            Dim locationId = Entity.GetCounter(Counters.LC)
            Return Entity.GetOBs().Where(Function(x) x.OB(1) = locationId).Select(Function(x) ObjectModel.Create(x))
        End Get
    End Property

    Public ReadOnly Property LocationExits As IEnumerable(Of IExitModel) Implements IWorldModel.LocationExits
        Get
            Dim locationObject = Entity.GetDS(Entity.GetCounter(Counters.LC))
            Return DIRECTION_IDS.Select(Function(x) ExitModel.Create(locationObject, x))
        End Get
    End Property

    Public Sub Reset() Implements IWorldModel.Reset
        Entity.Clear()
        Entity.SetCounter(Counters.SC, 215)
        CreateLocations()
        CreateObjects()
        Entity.SetCounter(Counters.LC, LOCATION_2)
        Entity.SetCounter(Counters.BL, 4)
        Entity.SetCounter(Counters.GF, 50)
        Entity.SetCounter(Counters.RV, 16396)
        Entity.SetCounter(Counters.TC, 0) 'some sort of timer?!?
        Entity.SetCounter(Counters.MD, 0) 'when the burger gets cold?
    End Sub

    Public Sub UpdateGF() Implements IWorldModel.UpdateGF
        If Entity.GetCounter(Counters.LC) = LOCATION_35 Then
            Entity.SetCounter(Counters.GF, 10)
        End If
    End Sub

    Private Sub CreateObjects()
        Entity.CreateOB(1, "a tag which says: >> NEEDS TURBO <<", 11, 5, 0)
        Entity.CreateOB(LOCATION_2, "anti-matter fuel", 12, 5, 5)
        Entity.CreateOB(3, "blaster", 13, 7, 0)
        Entity.CreateOB(4, "communicator", 14, 9, 0)
        Entity.CreateOB(5, "a very surprised guard", 15, 9, 0)
        Entity.CreateOB(6, "map of the ship", 16, 29, 20)
        Entity.CreateOB(7, "some keys", 17, 9, 0)
        Entity.CreateOB(8, "a shinestone necklace", 18, 10, 20)
        Entity.CreateOB(9, "Princess Leya's cape", 21, 14, 5)
        Entity.CreateOB(10, "McDonald's hamburger", 22, 15, 0)
        Entity.CreateOB(11, "a cassette tape", 23, 7, 0)
        Entity.CreateOB(12, "a turboencabulator", 24, 17, 5)
        Entity.CreateOB(13, "an evil looking scientist", 25, 17, 0)
        Entity.CreateOB(14, "secret attack plans", 26, 0, 20)
        Entity.CreateOB(15, "death ray schematic", 27, 9, 20)
        Entity.CreateOB(16, "cloaking device", 28, 17, 20)
        Entity.CreateOB(17, "micro laser gun", 29, 24, 20)
        Entity.CreateOB(18, "I.D. card", 31, 17, 0)
        Entity.CreateOB(19, "malidium crystals (the treasury!)", 32, 26, 30)
        Entity.CreateOB(20, "a sign which says: >> OUT OF ORDER <<", 33, 3, 0)
        Entity.CreateOB(21, "attack robot", 34, 35, 0)
        Entity.CreateOB(22, "Princess Leya", 35, 34, 50)
        Entity.CreateOB(23, "ammunition", 37, 7, 0)
    End Sub

    Private Sub CreateLocations()
        Entity.CreateDS(LOCATION_1, "I'm in the passenger & storage compartment of my space ship.
There's an exit here to leave the ship.", LOCATION_2, LOCATION_0, LOCATION_0, LOCATION_0, LOCATION_0, LOCATION_3)
        Entity.CreateDS(LOCATION_2, "I'm in the cockpit of my space ship. A large red button says >> PRESS TO BLAST OFF <<", LOCATION_0, LOCATION_0, LOCATION_1, LOCATION_0, LOCATION_0, LOCATION_0)
        Entity.CreateDS(LOCATION_3, "I'm standing next to my space ship which is locate on a huge flight deck.", LOCATION_18, LOCATION_0, LOCATION_4, LOCATION_0, LOCATION_1, LOCATION_0)
        Entity.CreateDS(LOCATION_4, "I'm out on the flight deck of General Doom's Battle Cruiser.", LOCATION_3, LOCATION_5, LOCATION_4, LOCATION_4, LOCATION_0, LOCATION_0)
        Entity.CreateDS(LOCATION_5, "I'm out on the flight deck of General Doom's Battle Cruiser.", LOCATION_4, LOCATION_6, LOCATION_5, LOCATION_4, LOCATION_0, LOCATION_0)
        Entity.CreateDS(LOCATION_6, "I'm in a hallway. There are doors on all sides. The door to the north says: >> CLOSED FOR THE DAY <<", LOCATION_7, LOCATION_0, LOCATION_8, LOCATION_5, LOCATION_0, LOCATION_0)
        Entity.CreateDS(LOCATION_7, "I'm in the supply depot.
Around me I see:
All kinds of things", LOCATION_0, LOCATION_0, LOCATION_6, LOCATION_0, LOCATION_0, LOCATION_0)
        Entity.CreateDS(LOCATION_8, "I'm at the end of one of the hallways.
I can hear voices nearby. Sounds like guards.", LOCATION_6, LOCATION_10, LOCATION_0, LOCATION_9, LOCATION_0, LOCATION_12)
        Entity.CreateDS(LOCATION_9, "I'm in the strategy planning room.", LOCATION_11, LOCATION_8, LOCATION_0, LOCATION_0, LOCATION_0, LOCATION_0)
        Entity.CreateDS(LOCATION_10, "I'm in the decontamination area.", LOCATION_0, LOCATION_14, LOCATION_0, LOCATION_8, LOCATION_0, LOCATION_0)
        Entity.CreateDS(LOCATION_11, "This area is the tractor beam control room.
A large sign warns: >> DO NOT PRESS ANY BUTTONS <<", LOCATION_0, LOCATION_0, LOCATION_9, LOCATION_0, LOCATION_0, LOCATION_0)
        Entity.CreateDS(LOCATION_12, "I'm in another hallway. To the east is a restroom.", LOCATION_15, LOCATION_13, LOCATION_0, LOCATION_0, LOCATION_8, LOCATION_0)
        Entity.CreateDS(LOCATION_13, "This is what is commonly called on Earth, the bathroom.
There's graffiti written all over the wall.
Pipes lean up through the ceiling.", LOCATION_15, LOCATION_0, LOCATION_0, LOCATION_12, LOCATION_27, LOCATION_0)
        Entity.CreateDS(LOCATION_14, "This appears to be an interrogation room.", LOCATION_0, LOCATION_0, LOCATION_0, LOCATION_10, LOCATION_0, LOCATION_0)
        Entity.CreateDS(LOCATION_15, "I'm in a lounge.", LOCATION_0, LOCATION_0, LOCATION_13, LOCATION_12, LOCATION_0, LOCATION_0)
        Entity.CreateDS(LOCATION_16, "This is a computer room. There's a TRS-80 in here.
On the screen it says: >> CSAVE TAPE <<", LOCATION_17, LOCATION_0, LOCATION_18, LOCATION_0, LOCATION_0, LOCATION_0)
        Entity.CreateDS(LOCATION_17, "I'm in a testing laboratory.", LOCATION_0, LOCATION_0, LOCATION_16, LOCATION_0, LOCATION_0, LOCATION_0)
        Entity.CreateDS(LOCATION_18, "I'm in a hallway.
A large arrow points east and says: >> TO THE VAULT <<", LOCATION_16, LOCATION_25, LOCATION_3, LOCATION_19, LOCATION_0, LOCATION_0)
        Entity.CreateDS(LOCATION_19, "This is the entrance to the development lab section.", LOCATION_20, LOCATION_18, LOCATION_21, LOCATION_20, LOCATION_22, LOCATION_0)
        Entity.CreateDS(LOCATION_20, "I'm in a long corridor. There are laboratories all around me.", LOCATION_19, LOCATION_23, LOCATION_21, LOCATION_20, LOCATION_22, LOCATION_24)
        Entity.CreateDS(LOCATION_21, "I'm in a research lab.", LOCATION_20, LOCATION_0, LOCATION_0, LOCATION_0, LOCATION_0, LOCATION_0)
        Entity.CreateDS(LOCATION_22, "I'm lost!", LOCATION_22, LOCATION_22, LOCATION_22, LOCATION_22, LOCATION_22, LOCATION_20)
        Entity.CreateDS(LOCATION_23, "I'm in a research lab.", LOCATION_0, LOCATION_0, LOCATION_0, LOCATION_20, LOCATION_0, LOCATION_0)
        Entity.CreateDS(LOCATION_24, "I'm in a research lab.", LOCATION_0, LOCATION_0, LOCATION_0, LOCATION_0, LOCATION_20, LOCATION_0)
        Entity.CreateDS(LOCATION_25, "I'm near the entrance to the vault.
A sign here says: >> AUTHORIZED PERSONNEL ONLY <<", LOCATION_0, LOCATION_26, LOCATION_0, LOCATION_18, LOCATION_0, LOCATION_0)
        Entity.CreateDS(LOCATION_26, "I'm in the vault.", LOCATION_0, LOCATION_0, LOCATION_0, LOCATION_25, LOCATION_0, LOCATION_0)
        Entity.CreateDS(LOCATION_27, "I'm in a pipe tunnel which leads in every direction.", LOCATION_28, LOCATION_27, LOCATION_27, LOCATION_27, LOCATION_27, LOCATION_13)
        Entity.CreateDS(LOCATION_28, "I'm in a pipe tunnel which leads in every direction.", LOCATION_29, LOCATION_29, LOCATION_29, LOCATION_29, LOCATION_30, LOCATION_29)
        Entity.CreateDS(LOCATION_29, "I'm lost in a maze of pipes.", LOCATION_28, LOCATION_29, LOCATION_29, LOCATION_29, LOCATION_29, LOCATION_27)
        Entity.CreateDS(LOCATION_30, "I'm in the pipe maze.
Below me I think I can see the jail.", LOCATION_29, LOCATION_29, LOCATION_28, LOCATION_29, LOCATION_29, LOCATION_31)
        Entity.CreateDS(LOCATION_31, "I'm in the jail.", LOCATION_32, LOCATION_33, LOCATION_34, LOCATION_35, LOCATION_0, LOCATION_0)
        Entity.CreateDS(LOCATION_32, "I'm in a jail cell.", LOCATION_0, LOCATION_0, LOCATION_31, LOCATION_0, LOCATION_0, LOCATION_0)
        Entity.CreateDS(LOCATION_33, "I'm in a jail cell.", LOCATION_0, LOCATION_0, LOCATION_0, LOCATION_31, LOCATION_0, LOCATION_0)
        Entity.CreateDS(LOCATION_34, "I'm in a jail cell.", LOCATION_31, LOCATION_0, LOCATION_0, LOCATION_0, LOCATION_0, LOCATION_0)
        Entity.CreateDS(LOCATION_35, "I'm at the security desk.
To the north an elevator.", LOCATION_36, LOCATION_31, LOCATION_0, LOCATION_0, LOCATION_0, LOCATION_0)
        Entity.CreateDS(LOCATION_36, "I'm in the elevator.", LOCATION_0, LOCATION_0, LOCATION_35, LOCATION_0, LOCATION_37, LOCATION_0)
        Entity.CreateDS(LOCATION_37, "I'm in the elevator.", LOCATION_0, LOCATION_0, LOCATION_14, LOCATION_0, LOCATION_0, LOCATION_36)
    End Sub

    Public Shared Function Create() As IWorldModel
        Dim world As IWorld
        Try
            world = DS.Business.World.Load(SAVE_FILE_NAME)
        Catch ex As Exception
            world = DS.Business.World.Create(New Data.WorldData)
        End Try
        Return New WorldModel(world)
    End Function

    Public Function CheckGuardSpawn() As Boolean Implements IWorldModel.CheckGuardSpawn
        If Entity.GetCounter(Counters.TC) < 25 Then
            Return False
        End If
        If RNG.FromRange(1, Entity.GetCounter(Counters.GF)) <> 1 Then
            Return False
        End If
        If Entity.GetCounter(Counters.TC) = 300 Then
            Entity.SetCounter(Counters.GF, 20)
        End If
        Dim locationId = Entity.GetCounter(Counters.LC)
        If locationId < LOCATION_3 OrElse locationId = LOCATION_9 OrElse locationId = LOCATION_26 OrElse locationId = LOCATION_37 Then
            Return False
        End If
        If locationId > LOCATION_26 And locationId < LOCATION_31 Then
            Return False
        End If
        Return True
    End Function
End Class

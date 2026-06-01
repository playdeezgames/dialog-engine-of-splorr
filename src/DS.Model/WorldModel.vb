Imports DS.Business
Imports TGGD.Model

Public Class WorldModel
    Inherits BaseModel(Of IWorld)
    Implements IWorldModel

    Protected Sub New(entity As IWorld)
        MyBase.New(entity)
    End Sub

    Public Sub Reset() Implements IWorldModel.Reset
        Entity.Clear()
        Entity.SetCounter(Counters.SC, 215)
        CreateLocations()
        CreateObjects()
    End Sub

    Private Sub CreateObjects()
        Entity.CreateOB(1, "a tag which says: >> NEEDS TURBO <<", 11, 5, 0)
        Entity.CreateOB(2, "anti-matter fuel", 12, 5, 5)
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
        Entity.CreateDS(1, "I'm in the passenger & storage compartment of my space ship.
There's an exit here to leave the ship.", 2, 0, 0, 0, 0, 3)
        Entity.CreateDS(2, "I'm in the cockpit of my space ship. A large red button says >> PRESS TO BLAST OFF <<", 0, 0, 1, 0, 0, 0)
        Entity.CreateDS(3, "I'm standing next to my space ship which is locate on a huge flight deck.", 18, 0, 4, 0, 1, 0)
        Entity.CreateDS(4, "I'm out on the flight deck of General Doom's Battle Cruiser.", 3, 5, 4, 4, 0, 0)
        Entity.CreateDS(5, "I'm out on the flight deck of General Doom's Battle Cruiser.", 4, 6, 5, 4, 0, 0)
        Entity.CreateDS(6, "I'm in a hallway. There are doors on all sides. The door to the north says: >> CLOSED FOR THE DAY <<", 7, 0, 8, 5, 0, 0)
        Entity.CreateDS(7, "I'm in the supply depot.
Around me I see:
All kinds of things", 0, 0, 6, 0, 0, 0)
        Entity.CreateDS(8, "I'm at the end of one of the hallways.
I can hear voices nearby. Sounds like guards.", 6, 10, 0, 9, 0, 12)
        Entity.CreateDS(9, "I'm in the strategy planning room.", 11, 8, 0, 0, 0, 0)
        Entity.CreateDS(10, "I'm in the decontamination area.", 0, 14, 0, 8, 0, 0)
        Entity.CreateDS(11, "This area is the tractor beam control room.
A large sign warns: >> DO NOT PRESS ANY BUTTONS <<", 0, 0, 9, 0, 0, 0)
        Entity.CreateDS(12, "I'm in another hallway. To the east is a restroom.", 15, 13, 0, 0, 8, 0)
        Entity.CreateDS(13, "This is what is commonly called on Earth, the bathroom.
There's graffiti written all over the wall.
Pipes lean up through the ceiling.", 15, 0, 0, 12, 27, 0)
        Entity.CreateDS(14, "This appears to be an interrogation room.", 0, 0, 0, 10, 0, 0)
        Entity.CreateDS(15, "I'm in a lounge.", 0, 0, 13, 12, 0, 0)
        Entity.CreateDS(16, "This is a computer room. There's a TRS-80 in here.
On the screen it says: >> CSAVE TAPE <<", 17, 0, 18, 0, 0, 0)
        Entity.CreateDS(17, "I'm in a testing laboratory.", 0, 0, 16, 0, 0, 0)
        Entity.CreateDS(18, "I'm in a hallway.
A large arrow points east and says: >> TO THE VAULT <<", 16, 25, 3, 19, 0, 0)
        Entity.CreateDS(19, "This is the entrance to the development lab section.", 20, 18, 21, 20, 22, 0)
        Entity.CreateDS(20, "I'm in a long corridor. There are laboratories all around me.", 19, 23, 21, 20, 22, 24)
        Entity.CreateDS(21, "I'm in a research lab.", 20, 0, 0, 0, 0, 0)
        Entity.CreateDS(22, "I'm lost!", 22, 22, 22, 22, 22, 20)
        Entity.CreateDS(23, "I'm in a research lab.", 0, 0, 0, 20, 0, 0)
        Entity.CreateDS(24, "I'm in a research lab.", 0, 0, 0, 0, 20, 0)
        Entity.CreateDS(25, "I'm near the entrance to the vault.
A sign here says: >> AUTHORIZED PERSONNEL ONLY <<", 0, 26, 0, 18, 0, 0)
        Entity.CreateDS(26, "I'm in the vault.", 0, 0, 0, 25, 0, 0)
        Entity.CreateDS(27, "I'm in a pipe tunnel which leads in every direction.", 28, 27, 27, 27, 27, 13)
        Entity.CreateDS(28, "I'm in a pipe tunnel which leads in every direction.", 29, 29, 29, 29, 30, 29)
        Entity.CreateDS(29, "I'm lost in a maze of pipes.", 28, 29, 29, 29, 29, 27)
        Entity.CreateDS(30, "I'm in the pipe maze.
Below me I think I can see the jail.", 29, 29, 28, 29, 29, 31)
        Entity.CreateDS(31, "I'm in the jail.", 32, 33, 34, 35, 0, 0)
        Entity.CreateDS(32, "I'm in a jail cell.", 0, 0, 31, 0, 0, 0)
        Entity.CreateDS(33, "I'm in a jail cell.", 0, 0, 0, 31, 0, 0)
        Entity.CreateDS(34, "I'm in a jail cell.", 31, 0, 0, 0, 0, 0)
        Entity.CreateDS(35, "I'm at the security desk.
To the north an elevator.", 36, 31, 0, 0, 0, 0)
        Entity.CreateDS(36, "I'm in the elevator.", 0, 0, 35, 0, 37, 0)
        Entity.CreateDS(37, "I'm in the elevator.", 0, 0, 14, 0, 0, 36)
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
End Class

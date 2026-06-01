Imports System.IO
Imports System.Text.Json
Imports DS.Data
Imports TGGD.Business

Public Class World
    Inherits Entity(Of WorldData)
    Implements IWorld

    Private Sub New(data As WorldData)
        EntityData = data
    End Sub

    Public Overrides Sub Clear()
        MyBase.Clear()
        EntityData.DS.Clear()
        EntityData.OB.Clear()
    End Sub

    Protected Overrides ReadOnly Property EntityData As WorldData

    Public Shared Function Create(data As WorldData) As IWorld
        Return New World(data)
    End Function

    Public Shared Function Load(filename As String) As IWorld
        Return New World(JsonSerializer.Deserialize(Of WorldData)(File.ReadAllText(filename)))
    End Function

    Public Function CreateDS(dsId As Integer, dss As String, ds1 As Integer, ds2 As Integer, ds3 As Integer, ds4 As Integer, ds5 As Integer, ds6 As Integer) As IDSObject Implements IWorld.CreateDS
        EntityData.DS(dsId) = New DSData With
            {
                .DSs = dss,
                .DS = New Dictionary(Of Integer, Integer) From
                {
                    {1, ds1},
                    {2, ds2},
                    {3, ds3},
                    {4, ds4},
                    {5, ds5},
                    {6, ds6}
                }
            }
        Return DSObject.Create(EntityData, dsId)
    End Function

    Public Function CreateOB(obId As Integer, obs As String, ob1 As Integer, ob2 As Integer, ob3 As Integer) As IOBObject Implements IWorld.CreateOB
        EntityData.OB(obId) = New OBData With
            {
                .OBs = obs,
                .OB = New Dictionary(Of Integer, Integer) From
                {
                    {1, ob1},
                    {2, ob2},
                    {3, ob3}
                }
            }
        Return OBObject.Create(EntityData, obId)
    End Function
End Class

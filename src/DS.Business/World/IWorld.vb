Imports TGGD.Business

Public Interface IWorld
    Inherits IEntity
    Function CreateDS(dsId As Integer, dss As String, ds1 As Integer, ds2 As Integer, ds3 As Integer, ds4 As Integer, ds5 As Integer, ds6 As Integer) As IDSObject
    Function CreateOB(obId As Integer, obs As String, ob1 As Integer, ob2 As Integer, ob3 As Integer) As IOBObject
    Function GetDS(dsId As Integer) As IDSObject
    Function GetOBs() As IEnumerable(Of IOBObject)
End Interface

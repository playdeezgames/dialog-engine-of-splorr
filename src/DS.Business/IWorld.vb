Imports TGGD.Business

Public Interface IWorld
    Inherits IEntity
    Function CreateDS(dsId As Integer, dss As String, ds1 As Integer, ds2 As Integer, ds3 As Integer, ds4 As Integer, ds5 As Integer, ds6 As Integer) As IDSObject
End Interface

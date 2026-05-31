Imports Shouldly
Imports TGGD.Data
Imports Xunit

Namespace TGGD.Business.Tests
    Public Class TestEntity_metadata_should
        <Fact>
        Sub throw_exception_when_reading_null_entity_data()
            Dim sut = TestEntity.Create(Nothing)
            Should.Throw(Of NullReferenceException)(Sub() sut.GetMetadata(Keys.ONE))
        End Sub
        <Fact>
        Sub throw_exception_when_reading_invalid_key()
            Dim entityData As New EntityData
            Dim sut = TestEntity.Create(entityData)
            Should.Throw(Of KeyNotFoundException)(Sub() sut.GetMetadata(Keys.ONE))
        End Sub
        Const METADATA_VALUE = "metadata value"
        <Fact>
        Sub set_metadata()
            Dim entityData As New EntityData
            Dim sut = TestEntity.Create(entityData)
            sut.SetMetadata(Keys.ONE, METADATA_VALUE)
            entityData.Metadatas.Count.ShouldBe(1)
            entityData.Metadatas.Single.Key.ShouldBe(Keys.ONE)
            entityData.Metadatas.Single.Value.ShouldBe(METADATA_VALUE)
        End Sub
        <Fact>
        Sub get_metadata()
            Dim entityData As New EntityData
            With entityData
                .Metadatas(Keys.ONE) = METADATA_VALUE
            End With
            Dim sut = TestEntity.Create(entityData)
            Dim actual = sut.GetMetadata(Keys.ONE)
            actual.ShouldBe(METADATA_VALUE)
        End Sub
    End Class
End Namespace


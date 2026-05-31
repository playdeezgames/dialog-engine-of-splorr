Imports Shouldly
Imports TGGD.Data
Imports Xunit

Public Class TestEntity_tag_should
    <Fact>
    Sub throw_exception_when_reading_null_entity_data()
        Dim sut = TestEntity.Create(Nothing)
        Should.Throw(Of NullReferenceException)(Sub() sut.HasTag(Keys.ONE))
    End Sub
    <Fact>
    Sub return_false_when_seeking_nonexistent_tag()
        Dim entityData As New EntityData
        Dim sut = TestEntity.Create(entityData)
        Dim actual = sut.HasTag(Keys.ONE)
        actual.ShouldBeFalse
    End Sub
    <Fact>
    Sub set_tag()
        Dim entityData As New EntityData
        Dim sut = TestEntity.Create(entityData)
        sut.SetTag(Keys.ONE, True)
        entityData.Tags.Count.ShouldBe(1)
        entityData.Tags.Single.ShouldBe(Keys.ONE)
    End Sub
    <Fact>
    Sub clear_tag()
        Dim entityData As New EntityData
        Dim sut = TestEntity.Create(entityData)
        sut.SetTag(Keys.ONE, False)
        entityData.Tags.ShouldBeEmpty
    End Sub
End Class

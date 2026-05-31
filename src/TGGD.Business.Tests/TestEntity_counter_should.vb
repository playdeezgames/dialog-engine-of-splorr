Imports Shouldly
Imports TGGD.Data
Imports Xunit

Public Class TestEntity_counter_should
    <Fact>
    Sub throw_exception_when_reading_null_entity_data()
        Dim sut = TestEntity.Create(Nothing)
        Should.Throw(Of NullReferenceException)(Sub() sut.GetCounter(Keys.ONE))
    End Sub
    <Fact>
    Sub throw_exception_when_reading_invalid_key()
        Dim entityData As New EntityData
        Dim sut = TestEntity.Create(entityData)
        Should.Throw(Of KeyNotFoundException)(Sub() sut.GetCounter(Keys.ONE))
    End Sub
    Const COUNTER_VALUE = 69
    <Fact>
    Sub set_counter()
        Dim entityData As New EntityData
        Dim sut = TestEntity.Create(entityData)
        sut.SetCounter(Keys.ONE, COUNTER_VALUE)
        entityData.Counters.Count.ShouldBe(1)
        entityData.Counters.Single.Key.ShouldBe(Keys.ONE)
        entityData.Counters.Single.Value.ShouldBe(COUNTER_VALUE)
    End Sub
    <Fact>
    Sub get_counter()
        Dim entityData As New EntityData
        With entityData
            .Counters(Keys.ONE) = COUNTER_VALUE
        End With
        Dim sut = TestEntity.Create(entityData)
        Dim actual = sut.GetCounter(Keys.ONE)
        actual.ShouldBe(COUNTER_VALUE)
    End Sub
    <Fact>
    Sub try_get_counter_returns_nothing_when_not_set()
        Dim entityData As New EntityData
        Dim sut = TestEntity.Create(entityData)
        Dim actual = sut.TryGetCounter(Keys.ONE)
        actual.ShouldBeNull
    End Sub
    <Fact>
    Sub try_get_counter_returns_value_when_set()
        Dim entityData As New EntityData
        Dim sut = TestEntity.Create(entityData)
        sut.SetCounter(Keys.ONE, COUNTER_VALUE)
        Dim actual = sut.TryGetCounter(Keys.ONE)
        actual.ShouldBe(COUNTER_VALUE)
    End Sub
    <Fact>
    Sub change_counter_throws_when_invalid_key()
        Dim entityData As New EntityData
        Dim sut = TestEntity.Create(entityData)
        Should.Throw(Of KeyNotFoundException)(Sub() sut.ChangeCounter(Keys.ONE, COUNTER_VALUE))
    End Sub
    <Fact>
    Sub change_counter_adds_to_current_counter_value()
        Dim entityData As New EntityData
        Dim sut = TestEntity.Create(entityData)
        sut.SetCounter(Keys.ONE, 0)
        Dim actual = sut.ChangeCounter(Keys.ONE, COUNTER_VALUE)
        actual.ShouldBe(COUNTER_VALUE)
    End Sub
    <Fact>
    Sub default_counter_sets_value_for_invalid_key()
        Dim entityData As New EntityData
        Dim sut = TestEntity.Create(entityData)
        sut.DefaultCounter(Keys.ONE, COUNTER_VALUE)
        Dim actual = sut.GetCounter(Keys.ONE)
        actual.ShouldBe(COUNTER_VALUE)
    End Sub
End Class

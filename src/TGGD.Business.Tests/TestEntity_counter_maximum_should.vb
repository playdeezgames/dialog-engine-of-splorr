Imports Shouldly
Imports TGGD.Data
Imports Xunit

Public Class TestEntity_counter_maximum_should
    <Fact>
    Sub throw_exception_when_reading_null_entity_data()
        Dim sut = TestEntity.Create(Nothing)
        Should.Throw(Of NullReferenceException)(Sub() sut.GetCounterMaximum(Keys.ONE))
    End Sub
    <Fact>
    Sub throw_exception_when_writing_to_null_entity_data()
        Dim sut = TestEntity.Create(Nothing)
        Should.Throw(Of NullReferenceException)(Sub() sut.SetCounterMaximum(Keys.ONE, COUNTER_MAXIMUM))
    End Sub
    <Fact>
    Sub return_maximum_integer_when_reading_invalid_key()
        Dim sut = TestEntity.Create(New Data.EntityData)
        Dim actual = sut.GetCounterMaximum(Keys.ONE)
        actual.ShouldBe(Integer.MaxValue)
    End Sub
    Const COUNTER_MAXIMUM = 69
    <Fact>
    Sub set_counter_maximum()
        Dim entityData As New Data.EntityData
        Dim sut = TestEntity.Create(entityData)
        sut.SetCounterMaximum(Keys.ONE, COUNTER_MAXIMUM)
        entityData.CounterMaximums.Count.ShouldBe(1)
        entityData.CounterMaximums.Single.Key.ShouldBe(Keys.ONE)
        entityData.CounterMaximums.Single.Value.ShouldBe(COUNTER_MAXIMUM)
    End Sub
    <Fact>
    Sub get_counter_maximum()
        Dim entityData As New Data.EntityData
        entityData.CounterMaximums(Keys.ONE) = COUNTER_MAXIMUM
        Dim sut = TestEntity.Create(entityData)
        Dim actual = sut.GetCounterMaximum(Keys.ONE)
        actual.ShouldBe(COUNTER_MAXIMUM)
    End Sub
    <Fact>
    Sub affect_counter_value()
        Dim sut = TestEntity.Create(New Data.EntityData)
        sut.SetCounter(Keys.ONE, COUNTER_MAXIMUM + 1)
        sut.SetCounterMaximum(Keys.ONE, COUNTER_MAXIMUM)
        Dim actual = sut.GetCounter(Keys.ONE)
        actual.ShouldBe(COUNTER_MAXIMUM)
    End Sub
End Class

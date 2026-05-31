Imports Shouldly
Imports Xunit

Public Class TestEntity_counter_minimum_should
    <Fact>
    Sub throw_exception_when_reading_null_entity_data()
        Dim sut = TestEntity.Create(Nothing)
        Should.Throw(Of NullReferenceException)(Sub() sut.GetCounterMinimum(Keys.ONE))
    End Sub
    <Fact>
    Sub throw_exception_when_writing_to_null_entity_data()
        Dim sut = TestEntity.Create(Nothing)
        Should.Throw(Of NullReferenceException)(Sub() sut.SetCounterMinimum(Keys.ONE, COUNTER_MINIMUM))
    End Sub
    <Fact>
    Sub return_minimum_integer_when_reading_invalid_key()
        Dim sut = TestEntity.Create(New Data.EntityData)
        Dim actual = sut.GetCounterMinimum(Keys.ONE)
        actual.ShouldBe(Integer.MinValue)
    End Sub
    Const COUNTER_MINIMUM = 69
    <Fact>
    Sub set_counter_minimum()
        Dim entityData As New Data.EntityData
        Dim sut = TestEntity.Create(entityData)
        sut.SetCounterMinimum(Keys.ONE, COUNTER_MINIMUM)
        entityData.CounterMinimums.Count.ShouldBe(1)
        entityData.CounterMinimums.Single.Key.ShouldBe(Keys.ONE)
        entityData.CounterMinimums.Single.Value.ShouldBe(COUNTER_MINIMUM)
    End Sub
    <Fact>
    Sub get_counter_minimum()
        Dim entityData As New Data.EntityData
        entityData.CounterMinimums(Keys.ONE) = COUNTER_MINIMUM
        Dim sut = TestEntity.Create(entityData)
        Dim actual = sut.GetCounterMinimum(Keys.ONE)
        actual.ShouldBe(COUNTER_MINIMUM)
    End Sub
    <Fact>
    Sub affect_counter_value()
        Dim sut = TestEntity.Create(New Data.EntityData)
        sut.SetCounter(Keys.ONE, COUNTER_MINIMUM - 1)
        sut.SetCounterMinimum(Keys.ONE, COUNTER_MINIMUM)
        Dim actual = sut.GetCounter(Keys.ONE)
        actual.ShouldBe(COUNTER_MINIMUM)
    End Sub
End Class

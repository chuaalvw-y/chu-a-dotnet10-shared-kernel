// Copyright (c) 2026 Alvin Wilsen Chan Chua
// GitHub: chuaalvw-y
// Licensed under the Alvin Wilsen Chan Chua Proprietary Use-Only License.
// See LICENSE.txt in the project root for full license information.

using ChuA.SharedKernel.Models;

namespace ChuA.SharedKernel.Tests.Models;

public sealed class EntityAndValueObjectTests
{
    [Fact]
    public void Entities_are_equal_when_type_and_id_match()
    {
        Assert.Equal(new TestEntity(1), new TestEntity(1));
        Assert.NotEqual(new TestEntity(1), new TestEntity(2));
    }

    [Fact]
    public void Value_objects_are_equal_when_components_match()
    {
        Assert.Equal(new Money("USD", 10), new Money("USD", 10));
        Assert.NotEqual(new Money("USD", 10), new Money("EUR", 10));
    }

    private sealed class TestEntity(int id) : Entity<int>(id);

    private sealed class Money(string currency, decimal amount) : ValueObject
    {
        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return currency;
            yield return amount;
        }
    }
}

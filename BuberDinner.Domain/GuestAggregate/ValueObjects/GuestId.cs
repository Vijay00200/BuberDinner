using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.GuestAggregate.ValueObjects;

public sealed class GuestId : ValueObject
{
    public Guid Value { get; }

    private GuestId(Guid guid)
    {
        Value = guid;
    }

    public static GuestId CreateUnique()
    {
        return new GuestId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
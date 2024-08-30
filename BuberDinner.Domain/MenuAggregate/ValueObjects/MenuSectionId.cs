using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.MenuAggregate.ValueObjects;

public sealed class MenuSectionId : ValueObject
{
    public MenuSectionId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static MenuSectionId CreateUnique()
    {
        // TODO: enforce invariants
        return new MenuSectionId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
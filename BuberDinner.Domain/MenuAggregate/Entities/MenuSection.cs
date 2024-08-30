using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.MenuAggregate.ValueObjects;

namespace BuberDinner.Domain.MenuAggregate.Entities;

public sealed class MenuSection : Entity<MenuSectionId>
{
    private readonly List<MenuItem> _items;
    public string Name { get; }
    public string Description { get; }

    public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

    private MenuSection(string name, string description, List<MenuItem> items, MenuSectionId? id = null)
        : base(id ?? MenuSectionId.CreateUnique())
    {
        Name = name;
        Description = description;
        _items = items;
    }

    public static MenuSection Create(
        string name,
        string description,
        List<MenuItem>? items = null)
    {
        // TODO: enforce invariants
        return new MenuSection(name, description, items ?? new());
    }
}
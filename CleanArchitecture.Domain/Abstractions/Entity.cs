namespace CleanArchitecture.Domain.Abstractions;

public abstract class Entity<TEntityId>
{
    protected Entity(
        DateTime utcNow)
    {
        CreatedOn = utcNow;
        UpdatedOn = utcNow;
        RegDel = GetZeroValue();
    }

    protected Entity(
        TEntityId id,
        DateTime utcNow)
    {
        Id = id;
        CreatedOn = utcNow;
        UpdatedOn = utcNow;
        RegDel = GetZeroValue();
    }

    protected Entity() { }

    public TEntityId Id { get; init; } = default!;

    public DateTime CreatedOn { get; init; } = default!;

    public DateTime UpdatedOn { get; private set; } = default!;

    public TEntityId RegDel { get; private set; } = default!;

    public bool IsDeleted => !RegDel!.Equals(GetZeroValue());

    protected void Update(DateTime utcNow)
    {
        UpdatedOn = utcNow;
    }

    protected void Delete(DateTime utcNow)
    {
        RegDel = Id;
        UpdatedOn = utcNow;
    }

    protected abstract TEntityId GetZeroValue();
}

namespace Housing.Domain.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; protected set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; } 
    public bool IsDeleted { get; private set; }
    public DateTime? DeletedAt { get; private set; }
    
    public void SoftDelete()
    {
        if (IsDeleted)
            return;

        IsDeleted = true;
        DeletedAt = DateTime.UtcNow;
    }
    public void Restore()
    {
        IsDeleted = false;
        DeletedAt = null;
    }

}

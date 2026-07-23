namespace ConvenienceStore.Domain.Abstraction
{
    public abstract class AuditableEntity : Entity
    {
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public void MarkCreated(DateTime now)
        {
            CreatedAt = now;
            UpdatedAt = now;
        }

        public void MarkUpdated(DateTime now)
        {
            UpdatedAt = now;
        }
    }
}

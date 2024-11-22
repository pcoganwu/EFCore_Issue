namespace EFCore_Issue.Lib.Models
{
    public class BaseObject
    {
        protected BaseObject()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            UpdatedAt  = CreatedAt;
        }
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public Guid? RootId { get; set; }
    }
}

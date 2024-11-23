namespace EFCore_Issue.Lib.Models
{
    public class BaseObject
    {
        protected BaseObject()
        {
            Id = Guid.NewGuid();
            CreatedAt = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc);
            UpdatedAt  = CreatedAt;
        }
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public Guid? RootId { get; set; }
    }
}

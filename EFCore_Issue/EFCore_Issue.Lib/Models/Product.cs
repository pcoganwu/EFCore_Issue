namespace EFCore_Issue.Lib.Models;

public partial class Product
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Supplier { get; set; } = null!;

    public string Description { get; set; } = null!;

    public Guid? TypeId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public Guid? RootId { get; set; }

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();

    public virtual ProductType? Type { get; set; }
}

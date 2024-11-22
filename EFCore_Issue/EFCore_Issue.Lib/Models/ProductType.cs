namespace EFCore_Issue.Lib.Models;
public partial class ProductType
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public Guid? RootId { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}

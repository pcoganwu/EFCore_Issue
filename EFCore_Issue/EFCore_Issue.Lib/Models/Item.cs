namespace EFCore_Issue.Lib.Models;

public partial class Item
{
    public Guid Id { get; set; }

    public int Size { get; set; }

    public string Color { get; set; } = null!;

    public string Picture { get; set; } = null!;

    public decimal Price { get; set; }

    public Guid? ProductId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public Guid? RootId { get; set; }

    public virtual Product? Product { get; set; }

    public virtual ICollection<SalesItem> SalesItems { get; set; } = new List<SalesItem>();
}

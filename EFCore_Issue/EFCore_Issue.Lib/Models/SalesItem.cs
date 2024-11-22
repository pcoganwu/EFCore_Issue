namespace EFCore_Issue.Lib.Models;

public partial class SalesItem
{
    public Guid Id { get; set; }

    public int Quantity { get; set; }

    public decimal Discount { get; set; }

    public bool Taxable { get; set; }

    public decimal SalesTaxRate { get; set; }

    public Guid? ItemId { get; set; }

    public Guid? SalesOrderId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public Guid? RootId { get; set; }

    public virtual Item? Item { get; set; }

    public virtual SalesOrder? SalesOrder { get; set; }
}

namespace EFCore_Issue.Lib.Models;

public partial class SalesOrder
{
    public Guid Id { get; set; }

    public DateTime TimeOrderTaken { get; set; }

    public int PurchaseOrderNumber { get; set; }

    public string CreditCardNumber { get; set; } = null!;

    public short CreditCardExpireMonth { get; set; }

    public short CreditCardExpireDay { get; set; }

    public short CreditCardExpireSecretCode { get; set; }

    public string NameOnCard { get; set; } = null!;

    public Guid? CustId { get; set; }

    public Guid? SalesPersonId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public Guid? RootId { get; set; }

    public virtual Customer? Cust { get; set; }

    public virtual ICollection<SalesItem> SalesItems { get; set; } = new List<SalesItem>();

    public virtual SalesPerson? SalesPerson { get; set; }
}

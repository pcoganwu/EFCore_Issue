namespace EFCore_Issue.Lib.Models;

public partial class Customer : PeopleBase
{
    public string Company { get; set; } = null!;

    public DateTime DateEntered { get; set; }
    public virtual ICollection<SalesOrder> SalesOrders { get; set; } = new List<SalesOrder>();
}

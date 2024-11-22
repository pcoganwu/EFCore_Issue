using EFCore_Issue.Lib.Models;
public partial class SalesPerson : PeopleBase
{
    public DateTime DateHired { get; set; }
    public virtual ICollection<SalesOrder> SalesOrders { get; set; } = new List<SalesOrder>();
}


namespace EFCore_Issue.Lib.Models
{
    public abstract class PeopleBase : BaseObject
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Street { get; set; } = null!;

        public string Sex { get; set; } = null!;

        public string City { get; set; } = null!;

        public string State { get; set; } = null!;

        public int ZipCode { get; set; }

        public string Phone { get; set; } = null!;

        public DateOnly? BirthOfDate { get; set; }
    }
}

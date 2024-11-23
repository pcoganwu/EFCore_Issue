using EFCore_Issue.Lib.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore_Issue.Lib.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<SalesOrder> SalesOrders { get; set; } = null!;
        public DbSet<SalesItem> SalesItems { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<SalesPerson> SalesPersons { get; set; } = null!;
        public DbSet<Item> Items { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<ProductType> ProductTypes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            IList<Customer> customers = [
                new Customer { Id = Guid.Parse("6875C4A1-7668-BC3E-7FA3-F711CD6C5962"), FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", Company = "Company A", Street = "123 Main St", City = "Anytown", State = "CA", ZipCode = 12345, Phone = "555-1234", BirthOfDate = new DateOnly(1980, 1, 1), DateEntered = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="M" },
               new Customer { Id = Guid.Parse("11E3E16E-3BE1-C27B-21CE-D051FC580215"), FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", Company = "Company B", Street = "456 Elm St", City = "Othertown", State = "NY", ZipCode = 67890, Phone = "555-5678", BirthOfDate = new DateOnly(1990, 2, 2),  DateEntered =new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="F" },
               new Customer { Id = Guid.Parse("4D62D555-FAB2-C918-A87B-2417C26A4700"), FirstName = "Alice", LastName = "Johnson", Email = "alice.johnson@example.com", Company = "Company C", Street = "789 Oak St", City = "Sometown", State = "TX", ZipCode = 11223, Phone = "555-9012", BirthOfDate = new DateOnly(1985, 3, 3),  DateEntered = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="" },
               new Customer { Id = Guid.Parse("BFD26780-499E-A591-8F34-A4363A8F96A9"), FirstName = "Bob", LastName = "Brown", Email = "bob.brown@example.com", Company = "Company D", Street = "101 Pine St", City = "Anycity", State = "FL", ZipCode = 44556, Phone = "555-3456", BirthOfDate = new DateOnly(1975, 4, 4),  DateEntered = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="M" },
               new Customer { Id = Guid.Parse("1398C92D-B203-C189-D517-7EF0324B513A"), FirstName = "Charlie", LastName = "Davis", Email = "charlie.davis@example.com", Company = "Company E", Street = "202 Maple St", City = "Othercity", State = "IL", ZipCode = 77889, Phone = "555-7890", BirthOfDate = new DateOnly(2000, 5, 5),  DateEntered = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="M" },
               new Customer { Id = Guid.Parse("576E15E6-9645-FE95-84EF-CD7066816FB4"), FirstName = "Daniel", LastName = "Evans", Email = "daniel.evans@example.com", Company = "Company F", Street = "303 Birch St", City = "Newtown", State = "CA", ZipCode = 12345, Phone = "555-2345", BirthOfDate = new DateOnly(1980, 6, 6), DateEntered = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="M" },
                new Customer { Id = Guid.Parse("005D6E01-18A0-3360-36BC-2A94472C4B0C"), FirstName = "Emma", LastName = "Taylor", Email = "emma.taylor@example.com", Company = "Company G", Street = "404 Cedar St", City = "Oldtown", State = "NY", ZipCode = 67890, Phone = "555-6789", BirthOfDate = new DateOnly(1990, 7, 7), DateEntered = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="F" },
                new Customer { Id = Guid.Parse("4D1BB398-57B4-3BDD-7972-EA11858FA895"), FirstName = "Frank", LastName = "Anderson", Email = "frank.anderson@example.com", Company = "Company H", Street = "505 Spruce St", City = "Smalltown", State = "TX", ZipCode = 11223, Phone = "555-0123", BirthOfDate = new DateOnly(1985, 8, 8), DateEntered = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="M" },
                new Customer { Id = Guid.Parse("95C21C78-E3AE-C1B6-4300-B8F7B111DA9D"), FirstName = "Grace", LastName = "Thomas", Email = "grace.thomas@example.com", Company = "Company I", Street = "606 Walnut St", City = "Bigcity", State = "FL", ZipCode = 44556, Phone = "555-4567", BirthOfDate = new DateOnly(1975, 9, 9), DateEntered = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="F" },
                new Customer { Id = Guid.Parse("C94A5687-CF7A-829A-D83B-73C18C8E163A"), FirstName = "Henry", LastName = "Jackson", Email = "henry.jackson@example.com", Company = "Company J", Street = "707 Chestnut St", City = "Middletown", State = "IL", ZipCode = 77889, Phone = "555-8901", BirthOfDate = new DateOnly(2000, 10, 10), DateEntered = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="M" },
                new Customer { Id = Guid.Parse("65E65EAC-4903-B788-2B4B-A15B639CEFD8"), FirstName = "Ivy", LastName = "White", Email = "ivy.white@example.com", Company = "Company K", Street = "808 Maple St", City = "Anyville", State = "CA", ZipCode = 12345, Phone = "555-2346", BirthOfDate = new DateOnly(1981, 11, 11), DateEntered = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="F" },
                new Customer { Id = Guid.Parse("8D005410-229C-8FE3-1CAF-FBEB8C156EAA"), FirstName = "Jack", LastName = "Harris", Email = "jack.harris@example.com", Company = "Company L", Street = "909 Oak St", City = "Otherville", State = "NY", ZipCode = 67891, Phone = "555-6780", BirthOfDate = new DateOnly(1991, 12, 12), DateEntered = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="M" },
                new Customer { Id = Guid.Parse("9212C492-F508-AA2F-5585-92A24D5A295D"), FirstName = "Karen", LastName = "Martin", Email = "karen.martin@example.com", Company = "Company M", Street = "1010 Pine St", City = "Sometown", State = "TX", ZipCode = 11224, Phone = "555-0124", BirthOfDate = new DateOnly(1986, 1, 13), DateEntered = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="F" },
                new Customer { Id = Guid.Parse("0E438039-45A2-6B29-E6ED-4EC4FC6BC87B"), FirstName = "Leo", LastName = "Clark", Email = "leo.clark@example.com", Company = "Company N", Street = "1111 Birch St", City = "Anycity", State = "FL", ZipCode = 44557, Phone = "555-3457", BirthOfDate = new DateOnly(1976, 2, 14), DateEntered = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="M" },
                new Customer { Id = Guid.Parse("302FAB80-4112-BEF2-6AF1-EECEB19C9D12"), FirstName = "Mia", LastName = "Lewis", Email = "mia.lewis@example.com", Company = "Company O", Street = "1212 Cedar St", City = "Othercity", State = "IL", ZipCode = 77890, Phone = "555-7891", BirthOfDate = new DateOnly(2001, 3, 15), DateEntered = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="F" },
                new Customer { Id = Guid.Parse("2A3320F2-1220-D70C-71E9-C4B634FE7057"), FirstName = "Noah", LastName = "Walker", Email = "noah.walker@example.com", Company = "Company P", Street = "1313 Spruce St", City = "Newtown", State = "CA", ZipCode = 12346, Phone = "555-2347", BirthOfDate = new DateOnly(1982, 4, 16), DateEntered = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="M" },
                new Customer { Id = Guid.Parse("E5C85334-A0C2-B8F6-17BF-B5C993A01245"), FirstName = "Olivia", LastName = "Hall", Email = "olivia.hall@example.com", Company = "Company Q", Street = "1414 Walnut St", City = "Oldtown", State = "NY", ZipCode = 67892, Phone = "555-6782", BirthOfDate = new DateOnly(1992, 5, 17), DateEntered = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="F" },
                new Customer { Id = Guid.Parse("0079C294-B859-4935-35A8-0C5F00334D63"), FirstName = "Paul", LastName = "Young", Email = "paul.young@example.com", Company = "Company R", Street = "1515 Chestnut St", City = "Smalltown", State = "TX", ZipCode = 11225, Phone = "555-0125", BirthOfDate = new DateOnly(1987, 6, 18), DateEntered = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="M" },
                new Customer { Id = Guid.Parse("21728FF2-4758-E644-B938-93F4E3F0E20F"), FirstName = "Quinn", LastName = "King", Email = "quinn.king@example.com", Company = "Company S", Street = "1616 Maple St", City = "Bigcity", State = "FL", ZipCode = 44558, Phone = "555-4568", BirthOfDate = new DateOnly(1977, 7, 19), DateEntered = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="F" },
                new Customer { Id = Guid.Parse("109B27C9-107A-9284-93A2-D851FE2DB21C"), FirstName = "Ryan", LastName = "Scott", Email = "ryan.scott@example.com", Company = "Company T", Street = "1717 Oak St", City = "Middletown", State = "IL", ZipCode = 77891, Phone = "555-8902", BirthOfDate = new DateOnly(2002, 8, 20), DateEntered = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="M" },
                new Customer { Id = Guid.Parse("FE1FFA4F-6CB7-B9C4-ACF1-82DAE3F45719"), FirstName = "Sophia", LastName = "Green", Email = "sophia.green@example.com", Company = "Company U", Street = "1818 Pine St", City = "Anyville", State = "CA", ZipCode = 12347, Phone = "555-2348", BirthOfDate = new DateOnly(1983, 9, 21), DateEntered = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="F" },
                new Customer { Id = Guid.Parse("4EAD9930-32CC-AA72-C53F-B1307695CEAF"), FirstName = "Thomas", LastName = "Baker", Email = "thomas.baker@example.com", Company = "Company V", Street = "1919 Birch St", City = "Otherville", State = "NY", ZipCode = 67893, Phone = "555-6783", BirthOfDate = new DateOnly(1993, 10, 22), DateEntered = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="M" },
                new Customer { Id = Guid.Parse("71A81584-08DE-66F5-65A8-52FA67F4FAB6"), FirstName = "Uma", LastName = "Adams", Email = "uma.adams@example.com", Company = "Company W", Street = "2020 Cedar St", City = "Sometown", State = "TX", ZipCode = 11226, Phone = "555-0126", BirthOfDate = new DateOnly(1988, 11, 23), DateEntered = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="F" },
                new Customer { Id = Guid.Parse("C0C38089-531F-952E-373C-6BC22A5005EF"), FirstName = "Victor", LastName = "Nelson", Email = "victor.nelson@example.com", Company = "Company X", Street = "2121 Spruce St", City = "Anycity", State = "FL", ZipCode = 44559, Phone = "555-3459", BirthOfDate = new DateOnly(1978, 12, 24), DateEntered = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="M" },
                new Customer { Id = Guid.Parse("5684C9B3-7BF0-E2F6-4F7E-F444168CDE76"), FirstName = "Wendy", LastName = "Carter", Email = "wendy.carter@example.com", Company = "Company Y", Street = "2222 Walnut St", City = "Othercity", State = "IL", ZipCode = 77892, Phone = "555-7893", BirthOfDate = new DateOnly(2003, 1, 25), DateEntered = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="F" },
                new Customer { Id = Guid.Parse("D12FD11C-A9D6-A205-2D1B-98CB710402E4"), FirstName = "Xander", LastName = "Mitchell", Email = "xander.mitchell@example.com", Company = "Company Z", Street = "2323 Chestnut St", City = "Newtown", State = "CA", ZipCode = 12348, Phone = "555-2349", BirthOfDate = new DateOnly(1984, 2, 26), DateEntered =new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="M" },
                new Customer { Id = Guid.Parse("6C7035A6-D5B1-9731-AB08-79E604055C63"), FirstName = "Yara", LastName = "Perez", Email = "yara.perez@example.com", Company = "Company AA", Street = "2424 Maple St", City = "Oldtown", State = "NY", ZipCode = 67894, Phone = "555-6784", BirthOfDate = new DateOnly(1994, 3, 27), DateEntered = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="F" },
                new Customer { Id = Guid.Parse("B9CC87A4-18B7-9F51-D742-F988FE64BCB1"), FirstName = "Zane", LastName = "Roberts", Email = "zane.roberts@example.com", Company = "Company BB", Street = "2525 Oak St", City = "Smalltown", State = "TX", ZipCode = 11227, Phone = "555-0127", BirthOfDate = new DateOnly(1989, 4, 28), DateEntered = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="M" },
                new Customer { Id = Guid.Parse("5066B859-A9AE-3268-3C47-F637B48DE1F9"), FirstName = "Amy", LastName = "Turner", Email = "amy.turner@example.com", Company = "Company CC", Street = "2626 Pine St", City = "Bigcity", State = "FL", ZipCode = 44560, Phone = "555-4569", BirthOfDate = new DateOnly(1979, 5, 29), DateEntered = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="F" },
                new Customer { Id = Guid.Parse("06C9A8A5-71EF-779A-A34B-B62574B5CC58"), FirstName = "Brian", LastName = "Phillips", Email = "brian.phillips@example.com", Company = "Company DD", Street = "2727 Birch St", City = "Middletown", State = "IL", ZipCode = 77893, Phone = "555-8903", BirthOfDate = new DateOnly(2004, 6, 30), DateEntered =new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="M" },
                new Customer { Id = Guid.Parse("81FB0083-E5EE-CCBB-AB07-579DAB9D0FFC"), FirstName = "Chloe", LastName = "Campbell", Email = "chloe.campbell@example.com", Company = "Company EE", Street = "2828 Cedar St", City = "Anyville", State = "CA", ZipCode = 12349, Phone = "555-2350", BirthOfDate = new DateOnly(1985, 7, 31), DateEntered = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="F" },
                new Customer { Id = Guid.Parse("74C965F4-D428-7258-ED70-5BDF08BDAD76"), FirstName = "David", LastName = "Parker", Email = "david.parker@example.com", Company = "Company FF", Street = "2929 Spruce St", City = "Otherville", State = "NY", ZipCode = 67895, Phone = "555-6785", BirthOfDate = new DateOnly(1995, 8, 1), DateEntered = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="M" },
                new Customer { Id = Guid.Parse("6421B880-3699-D244-4F23-DFE791B9CAE7"), FirstName = "Ella", LastName = "Evans", Email = "ella.evans@example.com", Company = "Company GG", Street = "3030 Walnut St", City = "Sometown", State = "TX", ZipCode = 11228, Phone = "555-0128", BirthOfDate = new DateOnly(1990, 9, 2), DateEntered = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="F" }
                ];
            modelBuilder.Entity<Customer>().HasData(customers);

            IList<ProductType> productTypes =
            [
                new ProductType { Id = Guid.Parse("A4E61AC2-216B-F970-1E1F-72B77372AEFE"), Name = "Running" },
                new ProductType { Id = Guid.Parse("F1605D4E-42D2-0770-C464-4B790AD05852"), Name = "Casual" },
                new ProductType { Id = Guid.Parse("9627DB3A-1CB3-BB94-A9F1-C8A178C7198D"), Name = "Formal" },
                new ProductType { Id = Guid.Parse("D56250D0-CF45-01EF-C894-F16B51CF64B2"), Name = "Sports" },
                new ProductType { Id = Guid.Parse("D496FA08-6E15-BCF2-5729-83B84631A083"), Name = "Boots" }
            ];
            modelBuilder.Entity<ProductType>().HasData(productTypes);

            IList<Product> products =
            [
                new Product { Id = Guid.Parse("4A2010E7-25D5-5F0E-7B79-30EAE97BB30C"), Name = "Nike Air Max", Supplier = "Nike", Description = "Comfortable running shoes", TypeId = productTypes[0].Id },
                new Product { Id = Guid.Parse("7EA840A5-58D8-85C4-70FB-78E31286FB69"), Name = "Adidas Superstar", Supplier = "Adidas", Description = "Classic casual shoes", TypeId = productTypes[1].Id },
                new Product { Id = Guid.Parse("52B9D002-0DD5-F216-06F4-AEA901755001"), Name = "Clarks Oxford", Supplier = "Clarks", Description = "Elegant formal shoes", TypeId = productTypes[2].Id },
                new Product { Id = Guid.Parse("A5141648-1260-5664-96C7-F878112BAAC5"), Name = "Puma Soccer Cleats", Supplier = "Puma", Description = "High-performance soccer cleats", TypeId = productTypes[3].Id },
                new Product { Id = Guid.Parse("CBF2DEE0-45D3-E682-511A-EF2B9947CC81"), Name = "Timberland Boots", Supplier = "Timberland", Description = "Durable outdoor boots", TypeId = productTypes[4].Id },
                 new Product { Id = Guid.Parse("0093D67A-66AA-F6BC-C2B1-BA61E3DD54BD"), Name = "Reebok Classic", Supplier = "Reebok", Description = "Timeless casual shoes", TypeId = productTypes[1].Id },
                 new Product { Id = Guid.Parse("7163D1C2-B1A9-E66A-D71A-FD236CDC9FD3"), Name = "Asics Gel-Kayano", Supplier = "Asics", Description = "Stability running shoes", TypeId = productTypes[0].Id },
                 new Product { Id = Guid.Parse("B40245E4-085A-39E6-AC26-3A855E475F0F"), Name = "New Balance 990", Supplier = "New Balance", Description = "Premium running shoes", TypeId = productTypes[0].Id },
                 new Product { Id = Guid.Parse("235CF756-B2F2-1405-6FB2-271805E43552"), Name = "Vans Old Skool", Supplier = "Vans", Description = "Classic skate shoes", TypeId = productTypes[1].Id },
                 new Product { Id = Guid.Parse("86DB3BE3-D641-8B59-78AC-A700E590F414"), Name = "Converse Chuck Taylor", Supplier = "Converse", Description = "Iconic casual shoes", TypeId = productTypes[1].Id },
                 new Product { Id = Guid.Parse("2EDD5B84-377B-2CD7-E681-0482139C3D62"), Name = "Dr. Martens 1460", Supplier = "Dr. Martens", Description = "Classic boots", TypeId = productTypes[4].Id },
                 new Product { Id = Guid.Parse("34DD818F-77EC-6953-1DFB-A9DF69FAE86F"), Name = "Under Armour Curry", Supplier = "Under Armour", Description = "Basketball shoes", TypeId = productTypes[3].Id },
                 new Product { Id = Guid.Parse("A1A2BA33-B704-08AB-FBA8-5E29CE6F008C"), Name = "Mizuno Wave Rider", Supplier = "Mizuno", Description = "Cushioned running shoes", TypeId = productTypes[0].Id },
                 new Product { Id = Guid.Parse("AEBBDA26-90E8-D5D3-95CF-A95525E38FB0"), Name = "Saucony Kinvara", Supplier = "Saucony", Description = "Lightweight running shoes", TypeId = productTypes[0].Id },
                 new Product { Id = Guid.Parse("3E830FE0-36D6-41E8-3FC5-CC2388319E7A"), Name = "Brooks Ghost", Supplier = "Brooks", Description = "Neutral running shoes", TypeId = productTypes[0].Id },
                 new Product { Id = Guid.Parse("D2593EE6-D6D2-188A-F8EF-6977B2647A57"), Name = "Hoka One One Clifton", Supplier = "Hoka One One", Description = "Maximalist running shoes", TypeId = productTypes[0].Id },
                 new Product { Id = Guid.Parse("C99E80F5-C2CF-53AB-9928-651606009D92"), Name = "Salomon Speedcross", Supplier = "Salomon", Description = "Trail running shoes", TypeId = productTypes[0].Id },
                 new Product { Id = Guid.Parse("48D3AEED-F71C-9133-5077-9D166E47B171"), Name = "Merrell Moab", Supplier = "Merrell", Description = "Hiking boots", TypeId = productTypes[4].Id },
                 new Product { Id = Guid.Parse("DBBE2061-29C5-7299-2686-575121021590"), Name = "Columbia Newton Ridge", Supplier = "Columbia", Description = "Waterproof hiking boots", TypeId = productTypes[4].Id },
                 new Product { Id = Guid.Parse("5AB05728-75E8-FCCF-CD8D-B06CA4527493"), Name = "Keen Targhee", Supplier = "Keen", Description = "All-terrain hiking boots", TypeId = productTypes[4].Id },
                 new Product { Id = Guid.Parse("1120B244-D042-6CFB-B59D-5543ABEDC94F"), Name = "La Sportiva Bushido", Supplier = "La Sportiva", Description = "Technical trail running shoes", TypeId = productTypes[0].Id },
                 new Product { Id = Guid.Parse("2E568493-9D71-C288-DD7A-49532EB42353"), Name = "Scarpa Mojito", Supplier = "Scarpa", Description = "Approach shoes", TypeId = productTypes[1].Id },
                 new Product { Id = Guid.Parse("3079793C-AF6D-8E1A-F9D5-D6DB4BEF52F4"), Name = "Arc'teryx Norvan", Supplier = "Arc'teryx", Description = "Trail running shoes", TypeId = productTypes[0].Id },
                 new Product { Id = Guid.Parse("FC6206C5-B87E-D216-1C12-8B8E9AB06BB1"), Name = "Altra Lone Peak", Supplier = "Altra", Description = "Zero-drop trail running shoes", TypeId = productTypes[0].Id },
                 new Product { Id = Guid.Parse("C4E228DB-291F-AD06-636C-5BC1F6109D0C"), Name = "Inov-8 Roclite", Supplier = "Inov-8", Description = "Versatile trail running shoes", TypeId = productTypes[0].Id },
                 new Product { Id = Guid.Parse("83E9FE64-D98D-BF4F-09A4-AFEE10EB9944"), Name = "The North Face Ultra", Supplier = "The North Face", Description = "Trail running shoes", TypeId = productTypes[0].Id },
                 new Product { Id = Guid.Parse("CCCD4FA8-C51B-9D89-3A3D-107648B8D21D"), Name = "Patagonia Drifter", Supplier = "Patagonia", Description = "Eco-friendly hiking shoes", TypeId = productTypes[4].Id },
                 new Product { Id = Guid.Parse("259667D1-5408-B3FA-8395-C09C7C78902E"), Name = "Lowa Renegade", Supplier = "Lowa", Description = "Sturdy hiking boots", TypeId = productTypes[4].Id },
                 new Product { Id = Guid.Parse("34EE2B5C-112C-67E8-634E-1F36CA5BDBFC"), Name = "Oboz Bridger", Supplier = "Oboz", Description = "Waterproof hiking boots", TypeId = productTypes[4].Id },
                 new Product { Id = Guid.Parse("81856369-E2CF-76F5-EC7A-38AFE7948309"), Name = "Danner Mountain", Supplier = "Danner", Description = "Heritage hiking boots", TypeId = productTypes[4].Id }
            ];
            modelBuilder.Entity<Product>().HasData(products);

            IList<Item> items = [
                new Item { Id = Guid.Parse("670FA168-297B-248B-D3FD-E7BB33FC2441"), Color = "Black", Picture = "nike_air_max.jpg", Price = 120.00m, ProductId = products[0].Id, Size = 10 },
                new Item { Id = Guid.Parse("63D7437E-2893-C36E-DCE8-F6AD857E550A"), Color = "White", Picture = "adidas_superstar.jpg", Price = 80.00m, ProductId = products[1].Id, Size = 9 },
                new Item { Id = Guid.Parse("5E473CD8-2804-E263-6763-E8F804B98AF8"), Color = "Brown", Picture = "clarks_oxford.jpg", Price = 150.00m, ProductId = products[2].Id, Size = 11 },
                new Item { Id = Guid.Parse("BEAB39F3-158E-E429-3AED-6D434C10B71B"), Color = "Red", Picture = "puma_soccer_cleats.jpg", Price = 100.00m, ProductId = products[3].Id, Size = 8 },
                new Item { Id = Guid.Parse("7CFF0680-1D4B-D8D3-5954-0697FE010202"), Color = "Tan", Picture = "timberland_boots.jpg", Price = 200.00m, ProductId = products[4].Id, Size = 12 },
                 new Item { Id = Guid.Parse("C75C6B0F-3E2B-87ED-88BF-DF79D8BD1BFF"), Color = "Blue", Picture = "reebok_classic.jpg", Price = 90.00m, ProductId = products[5].Id, Size = 10 },
                new Item { Id = Guid.Parse("C15296AB-2BE9-BCC8-A872-90C3E488F1C2"), Color = "Green", Picture = "asics_gel_kayano.jpg", Price = 130.00m, ProductId = products[6].Id, Size = 9 },
                new Item { Id = Guid.Parse("5110ABF1-3DA6-DE61-E49E-54E924855D5C"), Color = "Gray", Picture = "new_balance_990.jpg", Price = 160.00m, ProductId = products[7].Id, Size = 11 },
                new Item { Id = Guid.Parse("C4E86DF1-4C83-01DB-B271-829D693EE04C"), Color = "Black", Picture = "vans_old_skool.jpg", Price = 70.00m, ProductId = products[8].Id, Size = 8 },
                new Item { Id = Guid.Parse("CA3E4208-7723-31AF-135F-E4E5F077964A"), Color = "White", Picture = "converse_chuck_taylor.jpg", Price = 60.00m, ProductId = products[9].Id, Size = 9 },
                new Item { Id = Guid.Parse("BB5EEAAD-9EB1-7AAA-C6CB-61F07F7611FC"), Color = "Brown", Picture = "dr_martens_1460.jpg", Price = 140.00m, ProductId = products[10].Id, Size = 10 },
                new Item { Id = Guid.Parse("D1A23498-E2F8-6949-B644-7BD399AA3AE5"), Color = "Black", Picture = "under_armour_curry.jpg", Price = 110.00m, ProductId = products[11].Id, Size = 12 },
                new Item { Id = Guid.Parse("6A673ED2-E049-1F63-DC09-E8E97ED5B748"), Color = "Blue", Picture = "mizuno_wave_rider.jpg", Price = 120.00m, ProductId = products[12].Id, Size = 11 },
                new Item { Id = Guid.Parse("FB64D4EE-3971-A8CD-DF3F-0B66CC1132B2"), Color = "Green", Picture = "saucony_kinvara.jpg", Price = 100.00m, ProductId = products[13].Id, Size = 9 },
                new Item { Id = Guid.Parse("AB0ED41A-AF6D-8181-112C-23C4D10C19E9"), Color = "Gray", Picture = "brooks_ghost.jpg", Price = 130.00m, ProductId = products[14].Id, Size = 10 },
                new Item { Id = Guid.Parse("15FC68EC-0CDE-D216-4BAC-A5134567AAEB"), Color = "Black", Picture = "hoka_one_one_clifton.jpg", Price = 140.00m, ProductId = products[15].Id, Size = 8 },
                new Item { Id = Guid.Parse("A18C7509-4A13-2E15-0F73-DFBAF261325F"), Color = "Red", Picture = "salomon_speedcross.jpg", Price = 150.00m, ProductId = products[16].Id, Size = 12 },
                new Item { Id = Guid.Parse("49D3EE66-BE17-FDE4-2915-2A45C0EC1AE3"), Color = "Brown", Picture = "merrell_moab.jpg", Price = 160.00m, ProductId = products[17].Id, Size = 11 },
                new Item { Id = Guid.Parse("02AFC0D7-78D9-B37D-A1C9-A664D5E82571"), Color = "Black", Picture = "columbia_newton_ridge.jpg", Price = 170.00m, ProductId = products[18].Id, Size = 10 },
                new Item { Id = Guid.Parse("684EB9BB-D823-35C5-27A3-C71DF5CAC876"), Color = "Tan", Picture = "keen_targhee.jpg", Price = 180.00m, ProductId = products[19].Id, Size = 9 },
                new Item { Id = Guid.Parse("906C2769-3EDF-0E84-7644-475199F4A5FE"), Color = "Blue", Picture = "la_sportiva_bushido.jpg", Price = 190.00m, ProductId = products[20].Id, Size = 8 },
                new Item { Id = Guid.Parse("0EA64811-E4EC-900E-E481-78EB6A7C0F73"), Color = "Green", Picture = "scarpa_mojito.jpg", Price = 200.00m, ProductId = products[21].Id, Size = 12 },
                new Item { Id = Guid.Parse("4E60F021-7093-34BF-67F0-93A7954FE3DC"), Color = "Gray", Picture = "arcteryx_norvan.jpg", Price = 210.00m, ProductId = products[22].Id, Size = 11 },
                new Item { Id = Guid.Parse("2B842EDD-34F3-4ACA-8304-37593311E106"), Color = "Black", Picture = "altra_lone_peak.jpg", Price = 220.00m, ProductId = products[23].Id, Size = 10 },
                new Item { Id = Guid.Parse("2897EAC8-CE11-1D63-2A4F-C3BC40D84C11"), Color = "Red", Picture = "inov8_roclite.jpg", Price = 230.00m, ProductId = products[24].Id, Size = 9 },
                new Item { Id = Guid.Parse("3F7E8A0A-718E-86AC-B31D-6CD09650BE3D"), Color = "Brown", Picture = "the_north_face_ultra.jpg", Price = 240.00m, ProductId = products[25].Id, Size = 8 },
                new Item { Id = Guid.Parse("20E38C5C-697E-E9B8-454D-49DE0D402AD7"), Color = "Black", Picture = "patagonia_drifter.jpg", Price = 250.00m, ProductId = products[26].Id, Size = 12 },
                new Item { Id = Guid.Parse("F18117EC-D1C9-C28B-E60D-65070305E030"), Color = "Blue", Picture = "lowa_renegade.jpg", Price = 260.00m, ProductId = products[27].Id, Size = 11 },
                new Item { Id = Guid.Parse("AD68BD8C-6748-AD8C-22A5-37AF807AE23B"), Color = "Green", Picture = "oboz_bridger.jpg", Price = 270.00m, ProductId = products[28].Id, Size = 10 },
                new Item { Id = Guid.Parse("7BD784A3-CD37-4859-75F6-A6959D88C776"), Color = "Gray", Picture = "danner_mountain.jpg", Price = 280.00m, ProductId = products[29].Id, Size = 9 }
                ];
            modelBuilder.Entity<Item>().HasData(items);

            IList<SalesPerson> salesPersons =
            [
                new SalesPerson { Id = Guid.Parse("5758D99E-2DDD-D22A-BAE2-58BCA85EEA16"), FirstName = "David", LastName = "Wilson", Email = "david.wilson@example.com", Street = "303 Birch St", City = "Newtown", State = "CA", ZipCode = 12345, Phone = "555-2345", BirthOfDate = new DateOnly(1980, 6, 6), DateHired = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="M" },
                new SalesPerson { Id = Guid.Parse("07E792E5-664B-4098-DF0F-382A547D13C4"), FirstName = "Emma", LastName = "Taylor", Email = "emma.taylor@example.com", Street = "404 Cedar St", City = "Oldtown", State = "NY", ZipCode = 67890, Phone = "555-6789", BirthOfDate = new DateOnly(1990, 7, 7),  DateHired = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="M" },
                new SalesPerson { Id = Guid.Parse("940F8DC8-DE5F-D316-C58C-DFFE7F24CF73"), FirstName = "Frank", LastName = "Anderson", Email = "frank.anderson@example.com", Street = "505 Spruce St", City = "Smalltown", State = "TX", ZipCode = 11223, Phone = "555-0123", BirthOfDate = new DateOnly(1985, 8, 8),  DateHired = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="M" },
                new SalesPerson { Id = Guid.Parse("7340AA82-0EC8-5F37-A95D-313D150BAF49"), FirstName = "Grace", LastName = "Thomas", Email = "grace.thomas@example.com", Street = "606 Walnut St", City = "Bigcity", State = "FL", ZipCode = 44556, Phone = "555-4567", BirthOfDate = new DateOnly(1975, 9, 9),  DateHired = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="F" },
                new SalesPerson { Id = Guid.Parse("ECDF557D-4CC2-CD87-5F3B-C5078532CC92"), FirstName = "Henry", LastName = "Jackson", Email = "henry.jackson@example.com", Street = "707 Chestnut St", City = "Middletown", State = "IL", ZipCode = 77889, Phone = "555-8901", BirthOfDate = new DateOnly(2000, 10, 10),  DateHired = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="M" }
                ];
            modelBuilder.Entity<SalesPerson>().HasData(salesPersons);

            IList<SalesOrder> salesOrders = [
                new SalesOrder { Id = Guid.Parse("1BE75F9B-BC26-D99F-68B9-E7AEF05D2B29"), TimeOrderTaken = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), PurchaseOrderNumber = 1001, CreditCardNumber = "1234567812345678", CreditCardExpireMonth = 12, CreditCardExpireDay = 31, CreditCardExpireSecretCode = 123, NameOnCard = "John Doe", CustId = customers[0].Id, SalesPersonId = salesPersons[0].Id },
                new SalesOrder { Id = Guid.Parse("DFB15180-1D22-5EBB-D6A5-4F81431972D3"), TimeOrderTaken = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), PurchaseOrderNumber = 1002, CreditCardNumber = "2345678923456789", CreditCardExpireMonth = 11, CreditCardExpireDay = 30, CreditCardExpireSecretCode = 234, NameOnCard = "Jane Smith", CustId = customers[1].Id, SalesPersonId = salesPersons[1].Id },
                new SalesOrder { Id = Guid.Parse("93D2E010-F843-C1AB-9E78-31B026B4CA3A"), TimeOrderTaken = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), PurchaseOrderNumber = 1003, CreditCardNumber = "3456789034567890", CreditCardExpireMonth = 10, CreditCardExpireDay = 29, CreditCardExpireSecretCode = 345, NameOnCard = "Alice Johnson", CustId = customers[2].Id, SalesPersonId = salesPersons[2].Id },
                new SalesOrder { Id = Guid.Parse("8A4FD003-8672-5F65-D288-9F008718BA90"), TimeOrderTaken = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), PurchaseOrderNumber = 1004, CreditCardNumber = "4567890145678901", CreditCardExpireMonth = 9, CreditCardExpireDay = 28, CreditCardExpireSecretCode = 456, NameOnCard = "Bob Brown", CustId = customers[3].Id, SalesPersonId = salesPersons[3].Id },
                new SalesOrder { Id = Guid.Parse("F810C4F9-172A-5AC8-70A5-5F6572B5056C"), TimeOrderTaken =new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), PurchaseOrderNumber = 1005, CreditCardNumber = "5678901256789012", CreditCardExpireMonth = 8, CreditCardExpireDay = 27, CreditCardExpireSecretCode = 567, NameOnCard = "Charlie Davis", CustId = customers[4].Id, SalesPersonId = salesPersons[4].Id }
                ];
            modelBuilder.Entity<SalesOrder>().HasData(salesOrders);

             modelBuilder.Entity<SalesItem>().HasData(
            new SalesItem
            {
                Id = Guid.Parse("91903FEB-A365-1B66-E8C5-7748450FE2CB"),
                Quantity = 2,
                Discount = 0.10m,
                Taxable = true,
                SalesTaxRate = 0.07m,
                ItemId = items[0].Id, // Replace with actual ItemId
                SalesOrderId = salesOrders[1].Id // Replace with actual SalesOrderId
            },
            new SalesItem
            {
                Id = Guid.Parse("E92C4885-5F78-413F-80EC-79E1D92033F7"),
                Quantity = 1,
                Discount = 0.05m,
                Taxable = true,
                SalesTaxRate = 0.07m,
                ItemId = items[1].Id, // Replace with actual ItemId
                SalesOrderId = salesOrders[2].Id // Replace with actual SalesOrderId
            },
            new SalesItem
            {
                Id = Guid.Parse("17314D75-064E-71F3-23AB-1CF7AF54F047"),
                Quantity = 3,
                Discount = 0.15m,
                Taxable = false,
                SalesTaxRate = 0.00m,
                ItemId = items[3].Id, // Replace with actual ItemId
                SalesOrderId = salesOrders[4].Id // Replace with actual SalesOrderId
            },
            new SalesItem
            {
                Id = Guid.Parse("5DD6CCA7-F3BA-F664-DF7E-83C3193D3A0F"),
                Quantity = 4,
                Discount = 0.20m,
                Taxable = true,
                SalesTaxRate = 0.07m,
                ItemId = items[2].Id, // Replace with actual ItemId
                SalesOrderId = salesOrders[3].Id // Replace with actual SalesOrderId
            },
            new SalesItem
            {
                Id = Guid.Parse("E9A8BB0B-3E5A-CB5A-ED10-AE5070B7813D"),
                Quantity = 2,
                Discount = 0.10m,
                Taxable = true,
                SalesTaxRate = 0.07m,
                ItemId = items[3].Id, // Replace with actual ItemId
                SalesOrderId = salesOrders[4].Id // Replace with actual SalesOrderId
            }
        );


            base.OnModelCreating(modelBuilder);
        }
    }
}

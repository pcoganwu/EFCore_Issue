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
                new Customer { Id = Guid.NewGuid(), FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", Company = "Company A", Street = "123 Main St", City = "Anytown", State = "CA", ZipCode = 12345, Phone = "555-1234", BirthOfDate = new DateOnly(1980, 1, 1), DateEntered = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="M" },
               new Customer { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", Company = "Company B", Street = "456 Elm St", City = "Othertown", State = "NY", ZipCode = 67890, Phone = "555-5678", BirthOfDate = new DateOnly(1990, 2, 2),  DateEntered =new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="F" },
               new Customer { Id = Guid.NewGuid(), FirstName = "Alice", LastName = "Johnson", Email = "alice.johnson@example.com", Company = "Company C", Street = "789 Oak St", City = "Sometown", State = "TX", ZipCode = 11223, Phone = "555-9012", BirthOfDate = new DateOnly(1985, 3, 3),  DateEntered = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="" },
               new Customer { Id = Guid.NewGuid(), FirstName = "Bob", LastName = "Brown", Email = "bob.brown@example.com", Company = "Company D", Street = "101 Pine St", City = "Anycity", State = "FL", ZipCode = 44556, Phone = "555-3456", BirthOfDate = new DateOnly(1975, 4, 4),  DateEntered = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="M" },
               new Customer { Id = Guid.NewGuid(), FirstName = "Charlie", LastName = "Davis", Email = "charlie.davis@example.com", Company = "Company E", Street = "202 Maple St", City = "Othercity", State = "IL", ZipCode = 77889, Phone = "555-7890", BirthOfDate = new DateOnly(2000, 5, 5),  DateEntered = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="M" },
               new Customer { Id = Guid.NewGuid(), FirstName = "Daniel", LastName = "Evans", Email = "daniel.evans@example.com", Company = "Company F", Street = "303 Birch St", City = "Newtown", State = "CA", ZipCode = 12345, Phone = "555-2345", BirthOfDate = new DateOnly(1980, 6, 6), DateEntered = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="M" },
                new Customer { Id = Guid.NewGuid(), FirstName = "Emma", LastName = "Taylor", Email = "emma.taylor@example.com", Company = "Company G", Street = "404 Cedar St", City = "Oldtown", State = "NY", ZipCode = 67890, Phone = "555-6789", BirthOfDate = new DateOnly(1990, 7, 7), DateEntered = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="F" },
                new Customer { Id = Guid.NewGuid(), FirstName = "Frank", LastName = "Anderson", Email = "frank.anderson@example.com", Company = "Company H", Street = "505 Spruce St", City = "Smalltown", State = "TX", ZipCode = 11223, Phone = "555-0123", BirthOfDate = new DateOnly(1985, 8, 8), DateEntered = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="M" },
                new Customer { Id = Guid.NewGuid(), FirstName = "Grace", LastName = "Thomas", Email = "grace.thomas@example.com", Company = "Company I", Street = "606 Walnut St", City = "Bigcity", State = "FL", ZipCode = 44556, Phone = "555-4567", BirthOfDate = new DateOnly(1975, 9, 9), DateEntered = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="F" },
                new Customer { Id = Guid.NewGuid(), FirstName = "Henry", LastName = "Jackson", Email = "henry.jackson@example.com", Company = "Company J", Street = "707 Chestnut St", City = "Middletown", State = "IL", ZipCode = 77889, Phone = "555-8901", BirthOfDate = new DateOnly(2000, 10, 10), DateEntered = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="M" },
                new Customer { Id = Guid.NewGuid(), FirstName = "Ivy", LastName = "White", Email = "ivy.white@example.com", Company = "Company K", Street = "808 Maple St", City = "Anyville", State = "CA", ZipCode = 12345, Phone = "555-2346", BirthOfDate = new DateOnly(1981, 11, 11), DateEntered = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="F" },
                new Customer { Id = Guid.NewGuid(), FirstName = "Jack", LastName = "Harris", Email = "jack.harris@example.com", Company = "Company L", Street = "909 Oak St", City = "Otherville", State = "NY", ZipCode = 67891, Phone = "555-6780", BirthOfDate = new DateOnly(1991, 12, 12), DateEntered = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="M" },
                new Customer { Id = Guid.NewGuid(), FirstName = "Karen", LastName = "Martin", Email = "karen.martin@example.com", Company = "Company M", Street = "1010 Pine St", City = "Sometown", State = "TX", ZipCode = 11224, Phone = "555-0124", BirthOfDate = new DateOnly(1986, 1, 13), DateEntered = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="F" },
                new Customer { Id = Guid.NewGuid(), FirstName = "Leo", LastName = "Clark", Email = "leo.clark@example.com", Company = "Company N", Street = "1111 Birch St", City = "Anycity", State = "FL", ZipCode = 44557, Phone = "555-3457", BirthOfDate = new DateOnly(1976, 2, 14), DateEntered = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="M" },
                new Customer { Id = Guid.NewGuid(), FirstName = "Mia", LastName = "Lewis", Email = "mia.lewis@example.com", Company = "Company O", Street = "1212 Cedar St", City = "Othercity", State = "IL", ZipCode = 77890, Phone = "555-7891", BirthOfDate = new DateOnly(2001, 3, 15), DateEntered = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="F" },
                new Customer { Id = Guid.NewGuid(), FirstName = "Noah", LastName = "Walker", Email = "noah.walker@example.com", Company = "Company P", Street = "1313 Spruce St", City = "Newtown", State = "CA", ZipCode = 12346, Phone = "555-2347", BirthOfDate = new DateOnly(1982, 4, 16), DateEntered = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="M" },
                new Customer { Id = Guid.NewGuid(), FirstName = "Olivia", LastName = "Hall", Email = "olivia.hall@example.com", Company = "Company Q", Street = "1414 Walnut St", City = "Oldtown", State = "NY", ZipCode = 67892, Phone = "555-6782", BirthOfDate = new DateOnly(1992, 5, 17), DateEntered = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="F" },
                new Customer { Id = Guid.NewGuid(), FirstName = "Paul", LastName = "Young", Email = "paul.young@example.com", Company = "Company R", Street = "1515 Chestnut St", City = "Smalltown", State = "TX", ZipCode = 11225, Phone = "555-0125", BirthOfDate = new DateOnly(1987, 6, 18), DateEntered = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="M" },
                new Customer { Id = Guid.NewGuid(), FirstName = "Quinn", LastName = "King", Email = "quinn.king@example.com", Company = "Company S", Street = "1616 Maple St", City = "Bigcity", State = "FL", ZipCode = 44558, Phone = "555-4568", BirthOfDate = new DateOnly(1977, 7, 19), DateEntered = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="F" },
                new Customer { Id = Guid.NewGuid(), FirstName = "Ryan", LastName = "Scott", Email = "ryan.scott@example.com", Company = "Company T", Street = "1717 Oak St", City = "Middletown", State = "IL", ZipCode = 77891, Phone = "555-8902", BirthOfDate = new DateOnly(2002, 8, 20), DateEntered = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="M" },
                new Customer { Id = Guid.NewGuid(), FirstName = "Sophia", LastName = "Green", Email = "sophia.green@example.com", Company = "Company U", Street = "1818 Pine St", City = "Anyville", State = "CA", ZipCode = 12347, Phone = "555-2348", BirthOfDate = new DateOnly(1983, 9, 21), DateEntered = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="F" },
                new Customer { Id = Guid.NewGuid(), FirstName = "Thomas", LastName = "Baker", Email = "thomas.baker@example.com", Company = "Company V", Street = "1919 Birch St", City = "Otherville", State = "NY", ZipCode = 67893, Phone = "555-6783", BirthOfDate = new DateOnly(1993, 10, 22), DateEntered = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="M" },
                new Customer { Id = Guid.NewGuid(), FirstName = "Uma", LastName = "Adams", Email = "uma.adams@example.com", Company = "Company W", Street = "2020 Cedar St", City = "Sometown", State = "TX", ZipCode = 11226, Phone = "555-0126", BirthOfDate = new DateOnly(1988, 11, 23), DateEntered = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="F" },
                new Customer { Id = Guid.NewGuid(), FirstName = "Victor", LastName = "Nelson", Email = "victor.nelson@example.com", Company = "Company X", Street = "2121 Spruce St", City = "Anycity", State = "FL", ZipCode = 44559, Phone = "555-3459", BirthOfDate = new DateOnly(1978, 12, 24), DateEntered = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="M" },
                new Customer { Id = Guid.NewGuid(), FirstName = "Wendy", LastName = "Carter", Email = "wendy.carter@example.com", Company = "Company Y", Street = "2222 Walnut St", City = "Othercity", State = "IL", ZipCode = 77892, Phone = "555-7893", BirthOfDate = new DateOnly(2003, 1, 25), DateEntered = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="F" },
                new Customer { Id = Guid.NewGuid(), FirstName = "Xander", LastName = "Mitchell", Email = "xander.mitchell@example.com", Company = "Company Z", Street = "2323 Chestnut St", City = "Newtown", State = "CA", ZipCode = 12348, Phone = "555-2349", BirthOfDate = new DateOnly(1984, 2, 26), DateEntered =new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="M" },
                new Customer { Id = Guid.NewGuid(), FirstName = "Yara", LastName = "Perez", Email = "yara.perez@example.com", Company = "Company AA", Street = "2424 Maple St", City = "Oldtown", State = "NY", ZipCode = 67894, Phone = "555-6784", BirthOfDate = new DateOnly(1994, 3, 27), DateEntered = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="F" },
                new Customer { Id = Guid.NewGuid(), FirstName = "Zane", LastName = "Roberts", Email = "zane.roberts@example.com", Company = "Company BB", Street = "2525 Oak St", City = "Smalltown", State = "TX", ZipCode = 11227, Phone = "555-0127", BirthOfDate = new DateOnly(1989, 4, 28), DateEntered = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="M" },
                new Customer { Id = Guid.NewGuid(), FirstName = "Amy", LastName = "Turner", Email = "amy.turner@example.com", Company = "Company CC", Street = "2626 Pine St", City = "Bigcity", State = "FL", ZipCode = 44560, Phone = "555-4569", BirthOfDate = new DateOnly(1979, 5, 29), DateEntered = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="F" },
                new Customer { Id = Guid.NewGuid(), FirstName = "Brian", LastName = "Phillips", Email = "brian.phillips@example.com", Company = "Company DD", Street = "2727 Birch St", City = "Middletown", State = "IL", ZipCode = 77893, Phone = "555-8903", BirthOfDate = new DateOnly(2004, 6, 30), DateEntered =new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="M" },
                new Customer { Id = Guid.NewGuid(), FirstName = "Chloe", LastName = "Campbell", Email = "chloe.campbell@example.com", Company = "Company EE", Street = "2828 Cedar St", City = "Anyville", State = "CA", ZipCode = 12349, Phone = "555-2350", BirthOfDate = new DateOnly(1985, 7, 31), DateEntered = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="F" },
                new Customer { Id = Guid.NewGuid(), FirstName = "David", LastName = "Parker", Email = "david.parker@example.com", Company = "Company FF", Street = "2929 Spruce St", City = "Otherville", State = "NY", ZipCode = 67895, Phone = "555-6785", BirthOfDate = new DateOnly(1995, 8, 1), DateEntered = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="M" },
                new Customer { Id = Guid.NewGuid(), FirstName = "Ella", LastName = "Evans", Email = "ella.evans@example.com", Company = "Company GG", Street = "3030 Walnut St", City = "Sometown", State = "TX", ZipCode = 11228, Phone = "555-0128", BirthOfDate = new DateOnly(1990, 9, 2), DateEntered = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="F" }
                ];
            modelBuilder.Entity<Customer>().HasData(customers);

            IList<ProductType> productTypes =
            [
                new ProductType { Id = Guid.NewGuid(), Name = "Running" },
                new ProductType { Id = Guid.NewGuid(), Name = "Casual" },
                new ProductType { Id = Guid.NewGuid(), Name = "Formal" },
                new ProductType { Id = Guid.NewGuid(), Name = "Sports" },
                new ProductType { Id = Guid.NewGuid(), Name = "Boots" }
            ];
            modelBuilder.Entity<ProductType>().HasData(productTypes);

            IList<Product> products =
            [
                new Product { Id = Guid.NewGuid(), Name = "Nike Air Max", Supplier = "Nike", Description = "Comfortable running shoes", TypeId = productTypes[0].Id },
                new Product { Id = Guid.NewGuid(), Name = "Adidas Superstar", Supplier = "Adidas", Description = "Classic casual shoes", TypeId = productTypes[1].Id },
                new Product { Id = Guid.NewGuid(), Name = "Clarks Oxford", Supplier = "Clarks", Description = "Elegant formal shoes", TypeId = productTypes[2].Id },
                new Product { Id = Guid.NewGuid(), Name = "Puma Soccer Cleats", Supplier = "Puma", Description = "High-performance soccer cleats", TypeId = productTypes[3].Id },
                new Product { Id = Guid.NewGuid(), Name = "Timberland Boots", Supplier = "Timberland", Description = "Durable outdoor boots", TypeId = productTypes[4].Id },
                 new Product { Id = Guid.NewGuid(), Name = "Reebok Classic", Supplier = "Reebok", Description = "Timeless casual shoes", TypeId = productTypes[1].Id },
                 new Product { Id = Guid.NewGuid(), Name = "Asics Gel-Kayano", Supplier = "Asics", Description = "Stability running shoes", TypeId = productTypes[0].Id },
                 new Product { Id = Guid.NewGuid(), Name = "New Balance 990", Supplier = "New Balance", Description = "Premium running shoes", TypeId = productTypes[0].Id },
                 new Product { Id = Guid.NewGuid(), Name = "Vans Old Skool", Supplier = "Vans", Description = "Classic skate shoes", TypeId = productTypes[1].Id },
                 new Product { Id = Guid.NewGuid(), Name = "Converse Chuck Taylor", Supplier = "Converse", Description = "Iconic casual shoes", TypeId = productTypes[1].Id },
                 new Product { Id = Guid.NewGuid(), Name = "Dr. Martens 1460", Supplier = "Dr. Martens", Description = "Classic boots", TypeId = productTypes[4].Id },
                 new Product { Id = Guid.NewGuid(), Name = "Under Armour Curry", Supplier = "Under Armour", Description = "Basketball shoes", TypeId = productTypes[3].Id },
                 new Product { Id = Guid.NewGuid(), Name = "Mizuno Wave Rider", Supplier = "Mizuno", Description = "Cushioned running shoes", TypeId = productTypes[0].Id },
                 new Product { Id = Guid.NewGuid(), Name = "Saucony Kinvara", Supplier = "Saucony", Description = "Lightweight running shoes", TypeId = productTypes[0].Id },
                 new Product { Id = Guid.NewGuid(), Name = "Brooks Ghost", Supplier = "Brooks", Description = "Neutral running shoes", TypeId = productTypes[0].Id },
                 new Product { Id = Guid.NewGuid(), Name = "Hoka One One Clifton", Supplier = "Hoka One One", Description = "Maximalist running shoes", TypeId = productTypes[0].Id },
                 new Product { Id = Guid.NewGuid(), Name = "Salomon Speedcross", Supplier = "Salomon", Description = "Trail running shoes", TypeId = productTypes[0].Id },
                 new Product { Id = Guid.NewGuid(), Name = "Merrell Moab", Supplier = "Merrell", Description = "Hiking boots", TypeId = productTypes[4].Id },
                 new Product { Id = Guid.NewGuid(), Name = "Columbia Newton Ridge", Supplier = "Columbia", Description = "Waterproof hiking boots", TypeId = productTypes[4].Id },
                 new Product { Id = Guid.NewGuid(), Name = "Keen Targhee", Supplier = "Keen", Description = "All-terrain hiking boots", TypeId = productTypes[4].Id },
                 new Product { Id = Guid.NewGuid(), Name = "La Sportiva Bushido", Supplier = "La Sportiva", Description = "Technical trail running shoes", TypeId = productTypes[0].Id },
                 new Product { Id = Guid.NewGuid(), Name = "Scarpa Mojito", Supplier = "Scarpa", Description = "Approach shoes", TypeId = productTypes[1].Id },
                 new Product { Id = Guid.NewGuid(), Name = "Arc'teryx Norvan", Supplier = "Arc'teryx", Description = "Trail running shoes", TypeId = productTypes[0].Id },
                 new Product { Id = Guid.NewGuid(), Name = "Altra Lone Peak", Supplier = "Altra", Description = "Zero-drop trail running shoes", TypeId = productTypes[0].Id },
                 new Product { Id = Guid.NewGuid(), Name = "Inov-8 Roclite", Supplier = "Inov-8", Description = "Versatile trail running shoes", TypeId = productTypes[0].Id },
                 new Product { Id = Guid.NewGuid(), Name = "The North Face Ultra", Supplier = "The North Face", Description = "Trail running shoes", TypeId = productTypes[0].Id },
                 new Product { Id = Guid.NewGuid(), Name = "Patagonia Drifter", Supplier = "Patagonia", Description = "Eco-friendly hiking shoes", TypeId = productTypes[4].Id },
                 new Product { Id = Guid.NewGuid(), Name = "Lowa Renegade", Supplier = "Lowa", Description = "Sturdy hiking boots", TypeId = productTypes[4].Id },
                 new Product { Id = Guid.NewGuid(), Name = "Oboz Bridger", Supplier = "Oboz", Description = "Waterproof hiking boots", TypeId = productTypes[4].Id },
                 new Product { Id = Guid.NewGuid(), Name = "Danner Mountain", Supplier = "Danner", Description = "Heritage hiking boots", TypeId = productTypes[4].Id }
            ];
            modelBuilder.Entity<Product>().HasData(products);

            IList<Item> items = [
                new Item { Id = Guid.NewGuid(), Color = "Black", Picture = "nike_air_max.jpg", Price = 120.00m, ProductId = products[0].Id, Size = 10 },
                new Item { Id = Guid.NewGuid(), Color = "White", Picture = "adidas_superstar.jpg", Price = 80.00m, ProductId = products[1].Id, Size = 9 },
                new Item { Id = Guid.NewGuid(), Color = "Brown", Picture = "clarks_oxford.jpg", Price = 150.00m, ProductId = products[2].Id, Size = 11 },
                new Item { Id = Guid.NewGuid(), Color = "Red", Picture = "puma_soccer_cleats.jpg", Price = 100.00m, ProductId = products[3].Id, Size = 8 },
                new Item { Id = Guid.NewGuid(), Color = "Tan", Picture = "timberland_boots.jpg", Price = 200.00m, ProductId = products[4].Id, Size = 12 },
                 new Item { Id = Guid.NewGuid(), Color = "Blue", Picture = "reebok_classic.jpg", Price = 90.00m, ProductId = products[5].Id, Size = 10 },
                new Item { Id = Guid.NewGuid(), Color = "Green", Picture = "asics_gel_kayano.jpg", Price = 130.00m, ProductId = products[6].Id, Size = 9 },
                new Item { Id = Guid.NewGuid(), Color = "Gray", Picture = "new_balance_990.jpg", Price = 160.00m, ProductId = products[7].Id, Size = 11 },
                new Item { Id = Guid.NewGuid(), Color = "Black", Picture = "vans_old_skool.jpg", Price = 70.00m, ProductId = products[8].Id, Size = 8 },
                new Item { Id = Guid.NewGuid(), Color = "White", Picture = "converse_chuck_taylor.jpg", Price = 60.00m, ProductId = products[9].Id, Size = 9 },
                new Item { Id = Guid.NewGuid(), Color = "Brown", Picture = "dr_martens_1460.jpg", Price = 140.00m, ProductId = products[10].Id, Size = 10 },
                new Item { Id = Guid.NewGuid(), Color = "Black", Picture = "under_armour_curry.jpg", Price = 110.00m, ProductId = products[11].Id, Size = 12 },
                new Item { Id = Guid.NewGuid(), Color = "Blue", Picture = "mizuno_wave_rider.jpg", Price = 120.00m, ProductId = products[12].Id, Size = 11 },
                new Item { Id = Guid.NewGuid(), Color = "Green", Picture = "saucony_kinvara.jpg", Price = 100.00m, ProductId = products[13].Id, Size = 9 },
                new Item { Id = Guid.NewGuid(), Color = "Gray", Picture = "brooks_ghost.jpg", Price = 130.00m, ProductId = products[14].Id, Size = 10 },
                new Item { Id = Guid.NewGuid(), Color = "Black", Picture = "hoka_one_one_clifton.jpg", Price = 140.00m, ProductId = products[15].Id, Size = 8 },
                new Item { Id = Guid.NewGuid(), Color = "Red", Picture = "salomon_speedcross.jpg", Price = 150.00m, ProductId = products[16].Id, Size = 12 },
                new Item { Id = Guid.NewGuid(), Color = "Brown", Picture = "merrell_moab.jpg", Price = 160.00m, ProductId = products[17].Id, Size = 11 },
                new Item { Id = Guid.NewGuid(), Color = "Black", Picture = "columbia_newton_ridge.jpg", Price = 170.00m, ProductId = products[18].Id, Size = 10 },
                new Item { Id = Guid.NewGuid(), Color = "Tan", Picture = "keen_targhee.jpg", Price = 180.00m, ProductId = products[19].Id, Size = 9 },
                new Item { Id = Guid.NewGuid(), Color = "Blue", Picture = "la_sportiva_bushido.jpg", Price = 190.00m, ProductId = products[20].Id, Size = 8 },
                new Item { Id = Guid.NewGuid(), Color = "Green", Picture = "scarpa_mojito.jpg", Price = 200.00m, ProductId = products[21].Id, Size = 12 },
                new Item { Id = Guid.NewGuid(), Color = "Gray", Picture = "arcteryx_norvan.jpg", Price = 210.00m, ProductId = products[22].Id, Size = 11 },
                new Item { Id = Guid.NewGuid(), Color = "Black", Picture = "altra_lone_peak.jpg", Price = 220.00m, ProductId = products[23].Id, Size = 10 },
                new Item { Id = Guid.NewGuid(), Color = "Red", Picture = "inov8_roclite.jpg", Price = 230.00m, ProductId = products[24].Id, Size = 9 },
                new Item { Id = Guid.NewGuid(), Color = "Brown", Picture = "the_north_face_ultra.jpg", Price = 240.00m, ProductId = products[25].Id, Size = 8 },
                new Item { Id = Guid.NewGuid(), Color = "Black", Picture = "patagonia_drifter.jpg", Price = 250.00m, ProductId = products[26].Id, Size = 12 },
                new Item { Id = Guid.NewGuid(), Color = "Blue", Picture = "lowa_renegade.jpg", Price = 260.00m, ProductId = products[27].Id, Size = 11 },
                new Item { Id = Guid.NewGuid(), Color = "Green", Picture = "oboz_bridger.jpg", Price = 270.00m, ProductId = products[28].Id, Size = 10 },
                new Item { Id = Guid.NewGuid(), Color = "Gray", Picture = "danner_mountain.jpg", Price = 280.00m, ProductId = products[29].Id, Size = 9 }
                ];
            modelBuilder.Entity<Item>().HasData(items);

            IList<SalesPerson> salesPersons =
            [
                new SalesPerson { Id = Guid.NewGuid(), FirstName = "David", LastName = "Wilson", Email = "david.wilson@example.com", Street = "303 Birch St", City = "Newtown", State = "CA", ZipCode = 12345, Phone = "555-2345", BirthOfDate = new DateOnly(1980, 6, 6), DateHired = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="M" },
                new SalesPerson { Id = Guid.NewGuid(), FirstName = "Emma", LastName = "Taylor", Email = "emma.taylor@example.com", Street = "404 Cedar St", City = "Oldtown", State = "NY", ZipCode = 67890, Phone = "555-6789", BirthOfDate = new DateOnly(1990, 7, 7),  DateHired = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="M" },
                new SalesPerson { Id = Guid.NewGuid(), FirstName = "Frank", LastName = "Anderson", Email = "frank.anderson@example.com", Street = "505 Spruce St", City = "Smalltown", State = "TX", ZipCode = 11223, Phone = "555-0123", BirthOfDate = new DateOnly(1985, 8, 8),  DateHired = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="M" },
                new SalesPerson { Id = Guid.NewGuid(), FirstName = "Grace", LastName = "Thomas", Email = "grace.thomas@example.com", Street = "606 Walnut St", City = "Bigcity", State = "FL", ZipCode = 44556, Phone = "555-4567", BirthOfDate = new DateOnly(1975, 9, 9),  DateHired = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="F" },
                new SalesPerson { Id = Guid.NewGuid(), FirstName = "Henry", LastName = "Jackson", Email = "henry.jackson@example.com", Street = "707 Chestnut St", City = "Middletown", State = "IL", ZipCode = 77889, Phone = "555-8901", BirthOfDate = new DateOnly(2000, 10, 10),  DateHired = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), Sex="M" }
                ];
            modelBuilder.Entity<SalesPerson>().HasData(salesPersons);

            IList<SalesOrder> salesOrders = [
                new SalesOrder { Id = Guid.NewGuid(), TimeOrderTaken = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), PurchaseOrderNumber = 1001, CreditCardNumber = "1234567812345678", CreditCardExpireMonth = 12, CreditCardExpireDay = 31, CreditCardExpireSecretCode = 123, NameOnCard = "John Doe", CustId = customers[0].Id, SalesPersonId = salesPersons[0].Id },
                new SalesOrder { Id = Guid.NewGuid(), TimeOrderTaken = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), PurchaseOrderNumber = 1002, CreditCardNumber = "2345678923456789", CreditCardExpireMonth = 11, CreditCardExpireDay = 30, CreditCardExpireSecretCode = 234, NameOnCard = "Jane Smith", CustId = customers[1].Id, SalesPersonId = salesPersons[1].Id },
                new SalesOrder { Id = Guid.NewGuid(), TimeOrderTaken = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), PurchaseOrderNumber = 1003, CreditCardNumber = "3456789034567890", CreditCardExpireMonth = 10, CreditCardExpireDay = 29, CreditCardExpireSecretCode = 345, NameOnCard = "Alice Johnson", CustId = customers[2].Id, SalesPersonId = salesPersons[2].Id },
                new SalesOrder { Id = Guid.NewGuid(), TimeOrderTaken = new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), PurchaseOrderNumber = 1004, CreditCardNumber = "4567890145678901", CreditCardExpireMonth = 9, CreditCardExpireDay = 28, CreditCardExpireSecretCode = 456, NameOnCard = "Bob Brown", CustId = customers[3].Id, SalesPersonId = salesPersons[3].Id },
                new SalesOrder { Id = Guid.NewGuid(), TimeOrderTaken =new DateTime(new DateOnly(2024, 11, 22), new TimeOnly(0, 0, 0), DateTimeKind.Utc), PurchaseOrderNumber = 1005, CreditCardNumber = "5678901256789012", CreditCardExpireMonth = 8, CreditCardExpireDay = 27, CreditCardExpireSecretCode = 567, NameOnCard = "Charlie Davis", CustId = customers[4].Id, SalesPersonId = salesPersons[4].Id }
                ];
            modelBuilder.Entity<SalesOrder>().HasData(salesOrders);

             modelBuilder.Entity<SalesItem>().HasData(
            new SalesItem
            {
                Id = Guid.NewGuid(),
                Quantity = 2,
                Discount = 0.10m,
                Taxable = true,
                SalesTaxRate = 0.07m,
                ItemId = items[0].Id, // Replace with actual ItemId
                SalesOrderId = salesOrders[1].Id // Replace with actual SalesOrderId
            },
            new SalesItem
            {
                Id = Guid.NewGuid(),
                Quantity = 1,
                Discount = 0.05m,
                Taxable = true,
                SalesTaxRate = 0.07m,
                ItemId = items[1].Id, // Replace with actual ItemId
                SalesOrderId = salesOrders[2].Id // Replace with actual SalesOrderId
            },
            new SalesItem
            {
                Id = Guid.NewGuid(),
                Quantity = 3,
                Discount = 0.15m,
                Taxable = false,
                SalesTaxRate = 0.00m,
                ItemId = items[3].Id, // Replace with actual ItemId
                SalesOrderId = salesOrders[4].Id // Replace with actual SalesOrderId
            },
            new SalesItem
            {
                Id = Guid.NewGuid(),
                Quantity = 4,
                Discount = 0.20m,
                Taxable = true,
                SalesTaxRate = 0.07m,
                ItemId = items[2].Id, // Replace with actual ItemId
                SalesOrderId = salesOrders[3].Id // Replace with actual SalesOrderId
            },
            new SalesItem
            {
                Id = Guid.NewGuid(),
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

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCore_Issue.Lib.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Company = table.Column<string>(type: "text", nullable: false),
                    DateEntered = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RootId = table.Column<Guid>(type: "uuid", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Street = table.Column<string>(type: "text", nullable: false),
                    Sex = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    State = table.Column<string>(type: "text", nullable: false),
                    ZipCode = table.Column<int>(type: "integer", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    BirthOfDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RootId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesPersons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DateHired = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RootId = table.Column<Guid>(type: "uuid", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Street = table.Column<string>(type: "text", nullable: false),
                    Sex = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    State = table.Column<string>(type: "text", nullable: false),
                    ZipCode = table.Column<int>(type: "integer", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    BirthOfDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesPersons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Supplier = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    TypeId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RootId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SalesOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TimeOrderTaken = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PurchaseOrderNumber = table.Column<int>(type: "integer", nullable: false),
                    CreditCardNumber = table.Column<string>(type: "text", nullable: false),
                    CreditCardExpireMonth = table.Column<short>(type: "smallint", nullable: false),
                    CreditCardExpireDay = table.Column<short>(type: "smallint", nullable: false),
                    CreditCardExpireSecretCode = table.Column<short>(type: "smallint", nullable: false),
                    NameOnCard = table.Column<string>(type: "text", nullable: false),
                    CustId = table.Column<Guid>(type: "uuid", nullable: true),
                    SalesPersonId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RootId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesOrders_Customers_CustId",
                        column: x => x.CustId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SalesOrders_SalesPersons_SalesPersonId",
                        column: x => x.SalesPersonId,
                        principalTable: "SalesPersons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Size = table.Column<int>(type: "integer", nullable: false),
                    Color = table.Column<string>(type: "text", nullable: false),
                    Picture = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RootId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SalesItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Discount = table.Column<decimal>(type: "numeric", nullable: false),
                    Taxable = table.Column<bool>(type: "boolean", nullable: false),
                    SalesTaxRate = table.Column<decimal>(type: "numeric", nullable: false),
                    ItemId = table.Column<Guid>(type: "uuid", nullable: true),
                    SalesOrderId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RootId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SalesItems_SalesOrders_SalesOrderId",
                        column: x => x.SalesOrderId,
                        principalTable: "SalesOrders",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "BirthOfDate", "City", "Company", "CreatedAt", "DateEntered", "DeletedAt", "Email", "FirstName", "LastName", "Phone", "RootId", "Sex", "State", "Street", "UpdatedAt", "ZipCode" },
                values: new object[,]
                {
                    { new Guid("00eae958-82c3-4784-b145-75e802699062"), new DateOnly(1991, 12, 12), "Otherville", "Company L", new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5058), new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5062), null, "jack.harris@example.com", "Jack", "Harris", "555-6780", null, "M", "NY", "909 Oak St", new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5058), 67891 },
                    { new Guid("09a83477-f893-4c20-a84e-ddce9ba5e7e4"), new DateOnly(1983, 9, 21), "Anyville", "Company U", new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5128), new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5133), null, "sophia.green@example.com", "Sophia", "Green", "555-2348", null, "F", "CA", "1818 Pine St", new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5128), 12347 },
                    { new Guid("0c4e305d-d975-4c91-976a-8d121e22defb"), new DateOnly(1993, 10, 22), "Otherville", "Company V", new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5135), new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5138), null, "thomas.baker@example.com", "Thomas", "Baker", "555-6783", null, "M", "NY", "1919 Birch St", new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5135), 67893 },
                    { new Guid("1b4465e7-508f-44b3-b9da-c75153c37de7"), new DateOnly(1982, 4, 16), "Newtown", "Company P", new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5082), new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5085), null, "noah.walker@example.com", "Noah", "Walker", "555-2347", null, "M", "CA", "1313 Spruce St", new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5082), 12346 },
                    { new Guid("20c29c60-58bb-40b6-9161-f3448a853773"), new DateOnly(1980, 1, 1), "Anytown", "Company A", new DateTime(2024, 11, 22, 17, 2, 11, 971, DateTimeKind.Utc).AddTicks(4635), new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(4231), null, "john.doe@example.com", "John", "Doe", "555-1234", null, "M", "CA", "123 Main St", new DateTime(2024, 11, 22, 17, 2, 11, 971, DateTimeKind.Utc).AddTicks(4635), 12345 },
                    { new Guid("240e7c8d-8506-48f4-bbcc-4798f637338c"), new DateOnly(2003, 1, 25), "Othercity", "Company Y", new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5150), new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5155), null, "wendy.carter@example.com", "Wendy", "Carter", "555-7893", null, "F", "IL", "2222 Walnut St", new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5150), 77892 },
                    { new Guid("3b99ace2-3811-4d3a-a0e7-22081b40b5f1"), new DateOnly(1978, 12, 24), "Anycity", "Company X", new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5145), new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5148), null, "victor.nelson@example.com", "Victor", "Nelson", "555-3459", null, "M", "FL", "2121 Spruce St", new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5145), 44559 },
                    { new Guid("3faa44bd-a372-4af2-997f-e6745e253d56"), new DateOnly(2000, 10, 10), "Middletown", "Company J", new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5026), new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5029), null, "henry.jackson@example.com", "Henry", "Jackson", "555-8901", null, "M", "IL", "707 Chestnut St", new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5026), 77889 },
                    { new Guid("41e5c39d-22f5-486e-a392-a85abc44de39"), new DateOnly(1990, 7, 7), "Oldtown", "Company G", new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5007), new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5010), null, "emma.taylor@example.com", "Emma", "Taylor", "555-6789", null, "F", "NY", "404 Cedar St", new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5007), 67890 },
                    { new Guid("42845aa7-ff5f-4023-9cc4-651942d65b04"), new DateOnly(1986, 1, 13), "Sometown", "Company M", new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5064), new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5069), null, "karen.martin@example.com", "Karen", "Martin", "555-0124", null, "F", "TX", "1010 Pine St", new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5064), 11224 },
                    { new Guid("4eb6c3e3-79cf-4e0a-badd-2ea402d9f22a"), new DateOnly(1975, 9, 9), "Bigcity", "Company I", new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5018), new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5024), null, "grace.thomas@example.com", "Grace", "Thomas", "555-4567", null, "F", "FL", "606 Walnut St", new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5018), 44556 },
                    { new Guid("4ff53848-daee-4e0d-ad5a-ea8598f67353"), new DateOnly(1980, 6, 6), "Newtown", "Company F", new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5002), new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5006), null, "daniel.evans@example.com", "Daniel", "Evans", "555-2345", null, "M", "CA", "303 Birch St", new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5002), 12345 },
                    { new Guid("5b6fc6e8-2324-4819-b30c-25f9e08cf79c"), new DateOnly(1988, 11, 23), "Sometown", "Company W", new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5140), new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5143), null, "uma.adams@example.com", "Uma", "Adams", "555-0126", null, "F", "TX", "2020 Cedar St", new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5140), 11226 },
                    { new Guid("61694930-2d2b-428f-999c-535979dbae93"), new DateOnly(1975, 4, 4), "Anycity", "Company D", new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(4935), new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(4983), null, "bob.brown@example.com", "Bob", "Brown", "555-3456", null, "M", "FL", "101 Pine St", new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(4935), 44556 },
                    { new Guid("645f0647-96f4-45e9-8c8a-06f057878aa2"), new DateOnly(1985, 7, 31), "Anyville", "Company EE", new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5203), new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5206), null, "chloe.campbell@example.com", "Chloe", "Campbell", "555-2350", null, "F", "CA", "2828 Cedar St", new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5203), 12349 },
                    { new Guid("80bf335e-c3bf-4883-ab57-b587099c1cef"), new DateOnly(1990, 2, 2), "Othertown", "Company B", new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(4911), new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(4925), null, "jane.smith@example.com", "Jane", "Smith", "555-5678", null, "F", "NY", "456 Elm St", new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(4911), 67890 },
                    { new Guid("8e69d52b-1cac-4551-a9db-bf9b54502f39"), new DateOnly(1995, 8, 1), "Otherville", "Company FF", new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5208), new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5211), null, "david.parker@example.com", "David", "Parker", "555-6785", null, "M", "NY", "2929 Spruce St", new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5208), 67895 },
                    { new Guid("9882e8cb-32ab-4a0d-8b52-7622727f876e"), new DateOnly(1984, 2, 26), "Newtown", "Company Z", new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5157), new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5160), null, "xander.mitchell@example.com", "Xander", "Mitchell", "555-2349", null, "M", "CA", "2323 Chestnut St", new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5157), 12348 },
                    { new Guid("9d6c80c7-b434-4fe2-8597-4535750d8711"), new DateOnly(1981, 11, 11), "Anyville", "Company K", new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5031), new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5036), null, "ivy.white@example.com", "Ivy", "White", "555-2346", null, "F", "CA", "808 Maple St", new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5031), 12345 },
                    { new Guid("b9f36de2-e4c4-4a00-9f0f-e944609ffbd3"), new DateOnly(2002, 8, 20), "Middletown", "Company T", new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5123), new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5126), null, "ryan.scott@example.com", "Ryan", "Scott", "555-8902", null, "M", "IL", "1717 Oak St", new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5123), 77891 },
                    { new Guid("ba6265f7-c40c-4c86-bb7f-300668f20cba"), new DateOnly(2001, 3, 15), "Othercity", "Company O", new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5076), new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5079), null, "mia.lewis@example.com", "Mia", "Lewis", "555-7891", null, "F", "IL", "1212 Cedar St", new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5076), 77890 },
                    { new Guid("bade424e-4f45-42d8-a553-78217ad0171a"), new DateOnly(1992, 5, 17), "Oldtown", "Company Q", new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5087), new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5092), null, "olivia.hall@example.com", "Olivia", "Hall", "555-6782", null, "F", "NY", "1414 Walnut St", new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5087), 67892 },
                    { new Guid("bce2b42d-cce2-4907-afb0-dd15bffc06fa"), new DateOnly(2000, 5, 5), "Othercity", "Company E", new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(4985), new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5000), null, "charlie.davis@example.com", "Charlie", "Davis", "555-7890", null, "M", "IL", "202 Maple St", new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(4985), 77889 },
                    { new Guid("bd5b435a-4a82-4021-a88b-142c5204ffc3"), new DateOnly(1977, 7, 19), "Bigcity", "Company S", new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5099), new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5121), null, "quinn.king@example.com", "Quinn", "King", "555-4568", null, "F", "FL", "1616 Maple St", new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5099), 44558 },
                    { new Guid("bd73e583-65f5-4b79-9c9c-7fc6bc9d5afc"), new DateOnly(1989, 4, 28), "Smalltown", "Company BB", new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5186), new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5189), null, "zane.roberts@example.com", "Zane", "Roberts", "555-0127", null, "M", "TX", "2525 Oak St", new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5186), 11227 },
                    { new Guid("c25d7269-5770-4326-95c0-9d09ec5c652c"), new DateOnly(1985, 3, 3), "Sometown", "Company C", new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(4929), new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(4933), null, "alice.johnson@example.com", "Alice", "Johnson", "555-9012", null, "", "TX", "789 Oak St", new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(4929), 11223 },
                    { new Guid("d0f36bf4-4b55-49b1-a04a-c5b36a9866b3"), new DateOnly(1979, 5, 29), "Bigcity", "Company CC", new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5191), new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5196), null, "amy.turner@example.com", "Amy", "Turner", "555-4569", null, "F", "FL", "2626 Pine St", new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5191), 44560 },
                    { new Guid("d10a77c7-8c92-4a1d-a6bd-39cfa8b2bbba"), new DateOnly(1976, 2, 14), "Anycity", "Company N", new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5071), new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5074), null, "leo.clark@example.com", "Leo", "Clark", "555-3457", null, "M", "FL", "1111 Birch St", new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5071), 44557 },
                    { new Guid("d4594763-4409-42d8-9435-6ac5e3c8a63d"), new DateOnly(1994, 3, 27), "Oldtown", "Company AA", new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5162), new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5184), null, "yara.perez@example.com", "Yara", "Perez", "555-6784", null, "F", "NY", "2424 Maple St", new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5162), 67894 },
                    { new Guid("dab9e161-07ed-4e6a-824a-a98f20d6de0b"), new DateOnly(1990, 9, 2), "Sometown", "Company GG", new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5212), new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5218), null, "ella.evans@example.com", "Ella", "Evans", "555-0128", null, "F", "TX", "3030 Walnut St", new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5212), 11228 },
                    { new Guid("dce0c11e-94d7-4955-aed9-ef1c6d3d675e"), new DateOnly(1987, 6, 18), "Smalltown", "Company R", new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5094), new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5097), null, "paul.young@example.com", "Paul", "Young", "555-0125", null, "M", "TX", "1515 Chestnut St", new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5094), 11225 },
                    { new Guid("de93a9b4-8922-466c-aff7-ae52768fef45"), new DateOnly(2004, 6, 30), "Middletown", "Company DD", new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5198), new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5201), null, "brian.phillips@example.com", "Brian", "Phillips", "555-8903", null, "M", "IL", "2727 Birch St", new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5198), 77893 },
                    { new Guid("f100cf0c-35fd-466d-9adf-a1935c83fcb3"), new DateOnly(1985, 8, 8), "Smalltown", "Company H", new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5013), new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5016), null, "frank.anderson@example.com", "Frank", "Anderson", "555-0123", null, "M", "TX", "505 Spruce St", new DateTime(2024, 11, 22, 17, 2, 11, 972, DateTimeKind.Utc).AddTicks(5013), 11223 }
                });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Name", "RootId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("095fb67f-a5a1-4623-a6c8-8d206ae2c511"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sports", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("884ea087-837a-4f6d-8651-638f866c24b3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Running", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9021334b-010b-4d1e-8fa7-33949791cfe1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Boots", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c6a25c64-e472-42ba-8520-de4be57c6bf5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Formal", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fdb2acf1-cefe-4527-bdb7-6084b4182537"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Casual", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "SalesPersons",
                columns: new[] { "Id", "BirthOfDate", "City", "CreatedAt", "DateHired", "DeletedAt", "Email", "FirstName", "LastName", "Phone", "RootId", "Sex", "State", "Street", "UpdatedAt", "ZipCode" },
                values: new object[,]
                {
                    { new Guid("19a4c551-4bb6-4eea-b4ba-0a52db445743"), new DateOnly(1985, 8, 8), "Smalltown", new DateTime(2024, 11, 22, 17, 2, 11, 975, DateTimeKind.Utc).AddTicks(4253), new DateTime(2024, 11, 22, 17, 2, 11, 975, DateTimeKind.Utc).AddTicks(4256), null, "frank.anderson@example.com", "Frank", "Anderson", "555-0123", null, "M", "TX", "505 Spruce St", new DateTime(2024, 11, 22, 17, 2, 11, 975, DateTimeKind.Utc).AddTicks(4253), 11223 },
                    { new Guid("acf0a47e-87a9-4ac3-908a-6986ddef4852"), new DateOnly(1990, 7, 7), "Oldtown", new DateTime(2024, 11, 22, 17, 2, 11, 975, DateTimeKind.Utc).AddTicks(4244), new DateTime(2024, 11, 22, 17, 2, 11, 975, DateTimeKind.Utc).AddTicks(4251), null, "emma.taylor@example.com", "Emma", "Taylor", "555-6789", null, "M", "NY", "404 Cedar St", new DateTime(2024, 11, 22, 17, 2, 11, 975, DateTimeKind.Utc).AddTicks(4244), 67890 },
                    { new Guid("b7383c69-1d3e-4672-9e7a-291338dc3bea"), new DateOnly(1980, 6, 6), "Newtown", new DateTime(2024, 11, 22, 17, 2, 11, 975, DateTimeKind.Utc).AddTicks(3729), new DateTime(2024, 11, 22, 17, 2, 11, 975, DateTimeKind.Utc).AddTicks(3736), null, "david.wilson@example.com", "David", "Wilson", "555-2345", null, "M", "CA", "303 Birch St", new DateTime(2024, 11, 22, 17, 2, 11, 975, DateTimeKind.Utc).AddTicks(3729), 12345 },
                    { new Guid("b8a495ae-115f-48f4-a47a-f0e380491686"), new DateOnly(1975, 9, 9), "Bigcity", new DateTime(2024, 11, 22, 17, 2, 11, 975, DateTimeKind.Utc).AddTicks(4263), new DateTime(2024, 11, 22, 17, 2, 11, 975, DateTimeKind.Utc).AddTicks(4266), null, "grace.thomas@example.com", "Grace", "Thomas", "555-4567", null, "F", "FL", "606 Walnut St", new DateTime(2024, 11, 22, 17, 2, 11, 975, DateTimeKind.Utc).AddTicks(4263), 44556 },
                    { new Guid("ecdeb0a8-d342-45e6-8acc-8aebd76520eb"), new DateOnly(2000, 10, 10), "Middletown", new DateTime(2024, 11, 22, 17, 2, 11, 975, DateTimeKind.Utc).AddTicks(4268), new DateTime(2024, 11, 22, 17, 2, 11, 975, DateTimeKind.Utc).AddTicks(4291), null, "henry.jackson@example.com", "Henry", "Jackson", "555-8901", null, "M", "IL", "707 Chestnut St", new DateTime(2024, 11, 22, 17, 2, 11, 975, DateTimeKind.Utc).AddTicks(4268), 77889 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Description", "Name", "RootId", "Supplier", "TypeId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0889e36a-30db-4157-ab8e-b1add6c7cf55"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Stability running shoes", "Asics Gel-Kayano", null, "Asics", new Guid("884ea087-837a-4f6d-8651-638f866c24b3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1178c6f3-cd59-4e50-b07e-fed9063368a1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Iconic casual shoes", "Converse Chuck Taylor", null, "Converse", new Guid("fdb2acf1-cefe-4527-bdb7-6084b4182537"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("13c34d79-b410-4472-8b7f-e2a0dd1b2f2a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Versatile trail running shoes", "Inov-8 Roclite", null, "Inov-8", new Guid("884ea087-837a-4f6d-8651-638f866c24b3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("148806b8-de39-44c2-936e-b2b4bbc9abdd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Zero-drop trail running shoes", "Altra Lone Peak", null, "Altra", new Guid("884ea087-837a-4f6d-8651-638f866c24b3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1ba2835b-0a4e-48c4-b14a-03740d3e4eb2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Heritage hiking boots", "Danner Mountain", null, "Danner", new Guid("9021334b-010b-4d1e-8fa7-33949791cfe1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("25f71bfc-ac31-4f8f-a27a-59f0708508d4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sturdy hiking boots", "Lowa Renegade", null, "Lowa", new Guid("9021334b-010b-4d1e-8fa7-33949791cfe1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("37abab4e-2411-4369-8e31-b0bcbc6d448a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Elegant formal shoes", "Clarks Oxford", null, "Clarks", new Guid("c6a25c64-e472-42ba-8520-de4be57c6bf5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3cdcf161-593d-436c-8c71-7895e7f37860"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Waterproof hiking boots", "Columbia Newton Ridge", null, "Columbia", new Guid("9021334b-010b-4d1e-8fa7-33949791cfe1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3d2cb0cc-27a3-4051-b444-d37b8df80562"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Premium running shoes", "New Balance 990", null, "New Balance", new Guid("884ea087-837a-4f6d-8651-638f866c24b3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("68ef86b0-f903-4a6d-9c59-38c20063e62b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Durable outdoor boots", "Timberland Boots", null, "Timberland", new Guid("9021334b-010b-4d1e-8fa7-33949791cfe1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6a74adc6-a620-404a-8f4e-ae152e0c2c9d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "High-performance soccer cleats", "Puma Soccer Cleats", null, "Puma", new Guid("095fb67f-a5a1-4623-a6c8-8d206ae2c511"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("89b34a77-a831-47b4-8a99-91f0da61e8b5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Classic skate shoes", "Vans Old Skool", null, "Vans", new Guid("fdb2acf1-cefe-4527-bdb7-6084b4182537"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("977c55a4-8dce-4643-b8ee-5209d63697c6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Classic casual shoes", "Adidas Superstar", null, "Adidas", new Guid("fdb2acf1-cefe-4527-bdb7-6084b4182537"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ada01666-7aaa-4cc8-8c80-b329dfdbe031"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Waterproof hiking boots", "Oboz Bridger", null, "Oboz", new Guid("9021334b-010b-4d1e-8fa7-33949791cfe1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("af4713c6-3b0c-4f4d-97ad-1c89c842be2d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Technical trail running shoes", "La Sportiva Bushido", null, "La Sportiva", new Guid("884ea087-837a-4f6d-8651-638f866c24b3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b34836f7-8f7a-465d-b319-10c2b25b6c9d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Timeless casual shoes", "Reebok Classic", null, "Reebok", new Guid("fdb2acf1-cefe-4527-bdb7-6084b4182537"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b496ae99-136a-4d5a-8ddf-fc3b0b4e08d4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Trail running shoes", "Salomon Speedcross", null, "Salomon", new Guid("884ea087-837a-4f6d-8651-638f866c24b3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bbefbdbe-5470-4368-bf4e-f8f071e06942"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Classic boots", "Dr. Martens 1460", null, "Dr. Martens", new Guid("9021334b-010b-4d1e-8fa7-33949791cfe1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bc00fd6f-6c3f-4940-88a3-3cd5e27a4c36"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Approach shoes", "Scarpa Mojito", null, "Scarpa", new Guid("fdb2acf1-cefe-4527-bdb7-6084b4182537"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c9f36766-27bd-45cb-9d7d-e962a012441f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Eco-friendly hiking shoes", "Patagonia Drifter", null, "Patagonia", new Guid("9021334b-010b-4d1e-8fa7-33949791cfe1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d4aac052-55f6-4812-b41d-a2b4b4adfdb6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Neutral running shoes", "Brooks Ghost", null, "Brooks", new Guid("884ea087-837a-4f6d-8651-638f866c24b3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d66e3366-92dc-4c04-924d-114512f5edb5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Trail running shoes", "The North Face Ultra", null, "The North Face", new Guid("884ea087-837a-4f6d-8651-638f866c24b3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e1800387-b973-47b9-a089-0ea174025a24"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Trail running shoes", "Arc'teryx Norvan", null, "Arc'teryx", new Guid("884ea087-837a-4f6d-8651-638f866c24b3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f2f61bd7-0f96-4682-a3e3-f6ac55362efc"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Hiking boots", "Merrell Moab", null, "Merrell", new Guid("9021334b-010b-4d1e-8fa7-33949791cfe1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f3b3ecca-20f8-4cb4-87f8-438ebbec999d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Cushioned running shoes", "Mizuno Wave Rider", null, "Mizuno", new Guid("884ea087-837a-4f6d-8651-638f866c24b3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f96ffd5e-5d22-4380-93c9-54b7583bc727"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "All-terrain hiking boots", "Keen Targhee", null, "Keen", new Guid("9021334b-010b-4d1e-8fa7-33949791cfe1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f9c87948-02d4-4b37-97bd-639a3b4d8bd9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Basketball shoes", "Under Armour Curry", null, "Under Armour", new Guid("095fb67f-a5a1-4623-a6c8-8d206ae2c511"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fa5ff7ac-5069-49f9-8934-de5ea47edaf3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Comfortable running shoes", "Nike Air Max", null, "Nike", new Guid("884ea087-837a-4f6d-8651-638f866c24b3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fae2e970-70fe-460f-a8d1-390210ba55ed"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Maximalist running shoes", "Hoka One One Clifton", null, "Hoka One One", new Guid("884ea087-837a-4f6d-8651-638f866c24b3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fd49f027-ccd4-447f-bb86-6be5d7727479"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lightweight running shoes", "Saucony Kinvara", null, "Saucony", new Guid("884ea087-837a-4f6d-8651-638f866c24b3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "SalesOrders",
                columns: new[] { "Id", "CreatedAt", "CreditCardExpireDay", "CreditCardExpireMonth", "CreditCardExpireSecretCode", "CreditCardNumber", "CustId", "DeletedAt", "NameOnCard", "PurchaseOrderNumber", "RootId", "SalesPersonId", "TimeOrderTaken", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0a1a25c2-78dc-4f48-9628-5c91c8c99e9a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)31, (short)12, (short)123, "1234567812345678", new Guid("20c29c60-58bb-40b6-9161-f3448a853773"), null, "John Doe", 1001, null, new Guid("b7383c69-1d3e-4672-9e7a-291338dc3bea"), new DateTime(2024, 11, 22, 17, 2, 11, 975, DateTimeKind.Utc).AddTicks(5790), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0c894f99-632a-408b-90ec-8f8dccb5945d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)29, (short)10, (short)345, "3456789034567890", new Guid("c25d7269-5770-4326-95c0-9d09ec5c652c"), null, "Alice Johnson", 1003, null, new Guid("19a4c551-4bb6-4eea-b4ba-0a52db445743"), new DateTime(2024, 11, 22, 17, 2, 11, 975, DateTimeKind.Utc).AddTicks(8781), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e9f8941b-9a65-4f74-a180-6524bc170435"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)28, (short)9, (short)456, "4567890145678901", new Guid("61694930-2d2b-428f-999c-535979dbae93"), null, "Bob Brown", 1004, null, new Guid("b8a495ae-115f-48f4-a47a-f0e380491686"), new DateTime(2024, 11, 22, 17, 2, 11, 975, DateTimeKind.Utc).AddTicks(8793), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ed015542-7c6f-480a-bf31-e6eb3a335c21"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)30, (short)11, (short)234, "2345678923456789", new Guid("80bf335e-c3bf-4883-ab57-b587099c1cef"), null, "Jane Smith", 1002, null, new Guid("acf0a47e-87a9-4ac3-908a-6986ddef4852"), new DateTime(2024, 11, 22, 17, 2, 11, 975, DateTimeKind.Utc).AddTicks(8759), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fce6a71d-685a-4a83-ba6a-d0afe0089efd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)27, (short)8, (short)567, "5678901256789012", new Guid("bce2b42d-cce2-4907-afb0-dd15bffc06fa"), null, "Charlie Davis", 1005, null, new Guid("ecdeb0a8-d342-45e6-8acc-8aebd76520eb"), new DateTime(2024, 11, 22, 17, 2, 11, 975, DateTimeKind.Utc).AddTicks(8810), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Color", "CreatedAt", "DeletedAt", "Picture", "Price", "ProductId", "RootId", "Size", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("04e19b61-b800-403b-b1a3-9599a4d62433"), "Green", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "oboz_bridger.jpg", 270.00m, new Guid("ada01666-7aaa-4cc8-8c80-b329dfdbe031"), null, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2f5eddfd-8b16-456e-a6cd-f324b149e389"), "Black", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "vans_old_skool.jpg", 70.00m, new Guid("89b34a77-a831-47b4-8a99-91f0da61e8b5"), null, 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2fb184b9-710d-4ff0-a9cd-7e1ac9b0be22"), "Gray", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "arcteryx_norvan.jpg", 210.00m, new Guid("e1800387-b973-47b9-a089-0ea174025a24"), null, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("36d8d4e2-1534-447e-b5cd-4a6aa97b4147"), "Black", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "altra_lone_peak.jpg", 220.00m, new Guid("148806b8-de39-44c2-936e-b2b4bbc9abdd"), null, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("39e23fe7-9a1e-4740-a9f9-ab9323238e17"), "Blue", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "la_sportiva_bushido.jpg", 190.00m, new Guid("af4713c6-3b0c-4f4d-97ad-1c89c842be2d"), null, 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3d52844d-059f-44c0-83ca-074973bbe4e4"), "Tan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "keen_targhee.jpg", 180.00m, new Guid("f96ffd5e-5d22-4380-93c9-54b7583bc727"), null, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3e0e7881-adf2-4ca4-a2c3-13215be781f1"), "White", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "adidas_superstar.jpg", 80.00m, new Guid("977c55a4-8dce-4643-b8ee-5209d63697c6"), null, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4dcfbbca-913a-4dff-a47c-67a6b27e4f6e"), "Brown", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "the_north_face_ultra.jpg", 240.00m, new Guid("d66e3366-92dc-4c04-924d-114512f5edb5"), null, 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("50f39d8e-9a5f-4469-ae9f-954adbe9d29a"), "Tan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "timberland_boots.jpg", 200.00m, new Guid("68ef86b0-f903-4a6d-9c59-38c20063e62b"), null, 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6439bd46-3c16-4a2d-9670-25d582003571"), "Blue", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "lowa_renegade.jpg", 260.00m, new Guid("25f71bfc-ac31-4f8f-a27a-59f0708508d4"), null, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6de00272-8b1f-4f2d-9045-973b2090663f"), "Red", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "salomon_speedcross.jpg", 150.00m, new Guid("b496ae99-136a-4d5a-8ddf-fc3b0b4e08d4"), null, 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7d6d3ca4-481f-4be0-8364-9cc0eccfb464"), "Black", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "columbia_newton_ridge.jpg", 170.00m, new Guid("3cdcf161-593d-436c-8c71-7895e7f37860"), null, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("819b4b0c-4daa-4391-8a43-6aa79fb2dc14"), "Black", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "hoka_one_one_clifton.jpg", 140.00m, new Guid("fae2e970-70fe-460f-a8d1-390210ba55ed"), null, 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("823693d0-8039-486a-89d3-cd5b93c0c79c"), "Gray", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "brooks_ghost.jpg", 130.00m, new Guid("d4aac052-55f6-4812-b41d-a2b4b4adfdb6"), null, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("87f99ca1-4899-4e9b-8e64-2d6e6ca4e295"), "Gray", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "new_balance_990.jpg", 160.00m, new Guid("3d2cb0cc-27a3-4051-b444-d37b8df80562"), null, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("89bbdcb4-01bb-4d8e-8f2d-6421f7ec56d2"), "Black", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "under_armour_curry.jpg", 110.00m, new Guid("f9c87948-02d4-4b37-97bd-639a3b4d8bd9"), null, 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8d1df8f2-c4e8-46ce-bcca-6996698df657"), "Green", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "saucony_kinvara.jpg", 100.00m, new Guid("fd49f027-ccd4-447f-bb86-6be5d7727479"), null, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("94a25609-c19d-4b61-a089-bd06c1a0ae12"), "Brown", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "merrell_moab.jpg", 160.00m, new Guid("f2f61bd7-0f96-4682-a3e3-f6ac55362efc"), null, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("94c23d34-28d4-4c26-af03-41059d32ebbd"), "Brown", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "clarks_oxford.jpg", 150.00m, new Guid("37abab4e-2411-4369-8e31-b0bcbc6d448a"), null, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("95706b11-01ee-45f7-9fb6-ce6c5332b7d8"), "Black", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nike_air_max.jpg", 120.00m, new Guid("fa5ff7ac-5069-49f9-8934-de5ea47edaf3"), null, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9beb65f5-34b6-4325-bddd-5e0a996d890b"), "Brown", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "dr_martens_1460.jpg", 140.00m, new Guid("bbefbdbe-5470-4368-bf4e-f8f071e06942"), null, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9f167384-870e-433b-ad70-a596c90da663"), "Red", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "puma_soccer_cleats.jpg", 100.00m, new Guid("6a74adc6-a620-404a-8f4e-ae152e0c2c9d"), null, 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b1e9b439-a8eb-40df-919b-c9e57a3d57e3"), "Green", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "asics_gel_kayano.jpg", 130.00m, new Guid("0889e36a-30db-4157-ab8e-b1add6c7cf55"), null, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b60b7476-1b82-48e9-8aec-9274c75aa617"), "Blue", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "mizuno_wave_rider.jpg", 120.00m, new Guid("f3b3ecca-20f8-4cb4-87f8-438ebbec999d"), null, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cfaced75-a0b7-4896-b172-d584e66f063a"), "Green", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "scarpa_mojito.jpg", 200.00m, new Guid("bc00fd6f-6c3f-4940-88a3-3cd5e27a4c36"), null, 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e70dde15-82d2-4234-b440-6b828a58c6e3"), "Red", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "inov8_roclite.jpg", 230.00m, new Guid("13c34d79-b410-4472-8b7f-e2a0dd1b2f2a"), null, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("eee8ac01-fe13-496a-a0a8-0ae827ee6934"), "Black", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "patagonia_drifter.jpg", 250.00m, new Guid("c9f36766-27bd-45cb-9d7d-e962a012441f"), null, 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f2b99d1c-c364-4033-96ca-8af4240e3b42"), "Blue", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "reebok_classic.jpg", 90.00m, new Guid("b34836f7-8f7a-465d-b319-10c2b25b6c9d"), null, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f2cdb91b-57a7-4558-99e9-e0c6202cf45e"), "Gray", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "danner_mountain.jpg", 280.00m, new Guid("1ba2835b-0a4e-48c4-b14a-03740d3e4eb2"), null, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f46567cb-dfe1-4622-9791-e98318d93975"), "White", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "converse_chuck_taylor.jpg", 60.00m, new Guid("1178c6f3-cd59-4e50-b07e-fed9063368a1"), null, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "SalesItems",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Discount", "ItemId", "Quantity", "RootId", "SalesOrderId", "SalesTaxRate", "Taxable", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("3ad2c6ea-2e98-433a-accf-5e26416a6793"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0.10m, new Guid("9f167384-870e-433b-ad70-a596c90da663"), 2, null, new Guid("fce6a71d-685a-4a83-ba6a-d0afe0089efd"), 0.07m, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("659974cf-e2e0-43f5-9c6e-aeb44653b68b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0.20m, new Guid("94c23d34-28d4-4c26-af03-41059d32ebbd"), 4, null, new Guid("e9f8941b-9a65-4f74-a180-6524bc170435"), 0.07m, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7cbf4832-8091-4e85-b843-d4f5d37b3472"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0.15m, new Guid("9f167384-870e-433b-ad70-a596c90da663"), 3, null, new Guid("fce6a71d-685a-4a83-ba6a-d0afe0089efd"), 0.00m, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d331275f-ffec-45d5-9a5f-86d0c51539ed"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0.10m, new Guid("95706b11-01ee-45f7-9fb6-ce6c5332b7d8"), 2, null, new Guid("ed015542-7c6f-480a-bf31-e6eb3a335c21"), 0.07m, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e0aeffb5-f08c-429e-a519-cbe18861d2ed"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0.05m, new Guid("3e0e7881-adf2-4ca4-a2c3-13215be781f1"), 1, null, new Guid("0c894f99-632a-408b-90ec-8f8dccb5945d"), 0.07m, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_ProductId",
                table: "Items",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_TypeId",
                table: "Products",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesItems_ItemId",
                table: "SalesItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesItems_SalesOrderId",
                table: "SalesItems",
                column: "SalesOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrders_CustId",
                table: "SalesOrders",
                column: "CustId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrders_SalesPersonId",
                table: "SalesOrders",
                column: "SalesPersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalesItems");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "SalesOrders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "SalesPersons");

            migrationBuilder.DropTable(
                name: "ProductTypes");
        }
    }
}

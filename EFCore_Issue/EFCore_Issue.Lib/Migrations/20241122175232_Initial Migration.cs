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
                    { new Guid("03add296-9c05-4612-bed3-732df7460d40"), new DateOnly(1993, 10, 22), "Otherville", "Company V", new DateTime(2024, 11, 22, 17, 52, 31, 212, DateTimeKind.Utc).AddTicks(1371), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "thomas.baker@example.com", "Thomas", "Baker", "555-6783", null, "M", "NY", "1919 Birch St", new DateTime(2024, 11, 22, 17, 52, 31, 212, DateTimeKind.Utc).AddTicks(1371), 67893 },
                    { new Guid("06553a5b-daf5-4f54-b034-bb982d1e2316"), new DateOnly(2002, 8, 20), "Middletown", "Company T", new DateTime(2024, 11, 22, 17, 52, 31, 212, DateTimeKind.Utc).AddTicks(1344), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "ryan.scott@example.com", "Ryan", "Scott", "555-8902", null, "M", "IL", "1717 Oak St", new DateTime(2024, 11, 22, 17, 52, 31, 212, DateTimeKind.Utc).AddTicks(1344), 77891 },
                    { new Guid("0a07daf8-eefc-4c94-b5e9-f18125282f18"), new DateOnly(2001, 3, 15), "Othercity", "Company O", new DateTime(2024, 11, 22, 17, 52, 31, 212, DateTimeKind.Utc).AddTicks(1293), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "mia.lewis@example.com", "Mia", "Lewis", "555-7891", null, "F", "IL", "1212 Cedar St", new DateTime(2024, 11, 22, 17, 52, 31, 212, DateTimeKind.Utc).AddTicks(1293), 77890 },
                    { new Guid("0e0d69d8-830d-4059-a4b8-3e550fe2b8bb"), new DateOnly(1989, 4, 28), "Smalltown", "Company BB", new DateTime(2024, 11, 22, 17, 52, 31, 212, DateTimeKind.Utc).AddTicks(1414), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "zane.roberts@example.com", "Zane", "Roberts", "555-0127", null, "M", "TX", "2525 Oak St", new DateTime(2024, 11, 22, 17, 52, 31, 212, DateTimeKind.Utc).AddTicks(1414), 11227 },
                    { new Guid("16ce39b4-3ebd-4f85-a871-5240e9c5f067"), new DateOnly(1991, 12, 12), "Otherville", "Company L", new DateTime(2024, 11, 22, 17, 52, 31, 212, DateTimeKind.Utc).AddTicks(1262), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "jack.harris@example.com", "Jack", "Harris", "555-6780", null, "M", "NY", "909 Oak St", new DateTime(2024, 11, 22, 17, 52, 31, 212, DateTimeKind.Utc).AddTicks(1262), 67891 },
                    { new Guid("177144c8-dcf7-4d7f-b472-5a3248be39dd"), new DateOnly(2000, 10, 10), "Middletown", "Company J", new DateTime(2024, 11, 22, 17, 52, 31, 212, DateTimeKind.Utc).AddTicks(1254), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "henry.jackson@example.com", "Henry", "Jackson", "555-8901", null, "M", "IL", "707 Chestnut St", new DateTime(2024, 11, 22, 17, 52, 31, 212, DateTimeKind.Utc).AddTicks(1254), 77889 },
                    { new Guid("29bbed5e-8596-41ce-9f38-8b1b259475d6"), new DateOnly(1980, 1, 1), "Anytown", "Company A", new DateTime(2024, 11, 22, 17, 52, 31, 211, DateTimeKind.Utc).AddTicks(7232), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "john.doe@example.com", "John", "Doe", "555-1234", null, "M", "CA", "123 Main St", new DateTime(2024, 11, 22, 17, 52, 31, 211, DateTimeKind.Utc).AddTicks(7232), 12345 },
                    { new Guid("2f207703-1576-4f6b-a9fb-e7e2d9cdc081"), new DateOnly(1990, 2, 2), "Othertown", "Company B", new DateTime(2024, 11, 22, 17, 52, 31, 212, DateTimeKind.Utc).AddTicks(1174), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "jane.smith@example.com", "Jane", "Smith", "555-5678", null, "F", "NY", "456 Elm St", new DateTime(2024, 11, 22, 17, 52, 31, 212, DateTimeKind.Utc).AddTicks(1174), 67890 },
                    { new Guid("32c3abf8-b864-4791-a8a7-bd980f7a400a"), new DateOnly(1990, 7, 7), "Oldtown", "Company G", new DateTime(2024, 11, 22, 17, 52, 31, 212, DateTimeKind.Utc).AddTicks(1206), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "emma.taylor@example.com", "Emma", "Taylor", "555-6789", null, "F", "NY", "404 Cedar St", new DateTime(2024, 11, 22, 17, 52, 31, 212, DateTimeKind.Utc).AddTicks(1206), 67890 },
                    { new Guid("362f9053-6edd-4e45-acbf-d648e79065c4"), new DateOnly(2004, 6, 30), "Middletown", "Company DD", new DateTime(2024, 11, 22, 17, 52, 31, 212, DateTimeKind.Utc).AddTicks(1424), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "brian.phillips@example.com", "Brian", "Phillips", "555-8903", null, "M", "IL", "2727 Birch St", new DateTime(2024, 11, 22, 17, 52, 31, 212, DateTimeKind.Utc).AddTicks(1424), 77893 },
                    { new Guid("3735c6ca-d646-41b7-9fdf-cfb92ea9b0ac"), new DateOnly(1986, 1, 13), "Sometown", "Company M", new DateTime(2024, 11, 22, 17, 52, 31, 212, DateTimeKind.Utc).AddTicks(1268), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "karen.martin@example.com", "Karen", "Martin", "555-0124", null, "F", "TX", "1010 Pine St", new DateTime(2024, 11, 22, 17, 52, 31, 212, DateTimeKind.Utc).AddTicks(1268), 11224 },
                    { new Guid("3b42d385-8a03-475c-aaf7-d0d666cd8ef8"), new DateOnly(1990, 9, 2), "Sometown", "Company GG", new DateTime(2024, 11, 22, 17, 52, 31, 212, DateTimeKind.Utc).AddTicks(1439), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "ella.evans@example.com", "Ella", "Evans", "555-0128", null, "F", "TX", "3030 Walnut St", new DateTime(2024, 11, 22, 17, 52, 31, 212, DateTimeKind.Utc).AddTicks(1439), 11228 },
                    { new Guid("3d0d27f6-69a3-4aa9-88e9-e20dd5452a71"), new DateOnly(1985, 7, 31), "Anyville", "Company EE", new DateTime(2024, 11, 22, 17, 52, 31, 212, DateTimeKind.Utc).AddTicks(1428), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "chloe.campbell@example.com", "Chloe", "Campbell", "555-2350", null, "F", "CA", "2828 Cedar St", new DateTime(2024, 11, 22, 17, 52, 31, 212, DateTimeKind.Utc).AddTicks(1428), 12349 },
                    { new Guid("4501ef7d-ff1a-4366-a12d-f6fcfc835003"), new DateOnly(1987, 6, 18), "Smalltown", "Company R", new DateTime(2024, 11, 22, 17, 52, 31, 212, DateTimeKind.Utc).AddTicks(1336), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "paul.young@example.com", "Paul", "Young", "555-0125", null, "M", "TX", "1515 Chestnut St", new DateTime(2024, 11, 22, 17, 52, 31, 212, DateTimeKind.Utc).AddTicks(1336), 11225 },
                    { new Guid("4c365ee5-4f6f-4ec5-8950-7649a27f0c81"), new DateOnly(1981, 11, 11), "Anyville", "Company K", new DateTime(2024, 11, 22, 17, 52, 31, 212, DateTimeKind.Utc).AddTicks(1258), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "ivy.white@example.com", "Ivy", "White", "555-2346", null, "F", "CA", "808 Maple St", new DateTime(2024, 11, 22, 17, 52, 31, 212, DateTimeKind.Utc).AddTicks(1258), 12345 },
                    { new Guid("63f14b2b-b6d9-4601-9664-d47a08481630"), new DateOnly(1985, 3, 3), "Sometown", "Company C", new DateTime(2024, 11, 22, 17, 52, 31, 212, DateTimeKind.Utc).AddTicks(1184), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "alice.johnson@example.com", "Alice", "Johnson", "555-9012", null, "", "TX", "789 Oak St", new DateTime(2024, 11, 22, 17, 52, 31, 212, DateTimeKind.Utc).AddTicks(1184), 11223 },
                    { new Guid("6e10a197-83e0-4cb7-9bc6-08a224defac4"), new DateOnly(1978, 12, 24), "Anycity", "Company X", new DateTime(2024, 11, 22, 17, 52, 31, 212, DateTimeKind.Utc).AddTicks(1380), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "victor.nelson@example.com", "Victor", "Nelson", "555-3459", null, "M", "FL", "2121 Spruce St", new DateTime(2024, 11, 22, 17, 52, 31, 212, DateTimeKind.Utc).AddTicks(1380), 44559 },
                    { new Guid("7028bb9d-fd60-4438-bee3-4b9401be9fb5"), new DateOnly(1976, 2, 14), "Anycity", "Company N", new DateTime(2024, 11, 22, 17, 52, 31, 212, DateTimeKind.Utc).AddTicks(1289), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "leo.clark@example.com", "Leo", "Clark", "555-3457", null, "M", "FL", "1111 Birch St", new DateTime(2024, 11, 22, 17, 52, 31, 212, DateTimeKind.Utc).AddTicks(1289), 44557 },
                    { new Guid("821b129d-2ee9-45da-9407-917a2ca1e911"), new DateOnly(1977, 7, 19), "Bigcity", "Company S", new DateTime(2024, 11, 22, 17, 52, 31, 212, DateTimeKind.Utc).AddTicks(1340), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "quinn.king@example.com", "Quinn", "King", "555-4568", null, "F", "FL", "1616 Maple St", new DateTime(2024, 11, 22, 17, 52, 31, 212, DateTimeKind.Utc).AddTicks(1340), 44558 },
                    { new Guid("88093ef5-b325-4429-a9b0-c438ed4115a2"), new DateOnly(1982, 4, 16), "Newtown", "Company P", new DateTime(2024, 11, 22, 17, 52, 31, 212, DateTimeKind.Utc).AddTicks(1325), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "noah.walker@example.com", "Noah", "Walker", "555-2347", null, "M", "CA", "1313 Spruce St", new DateTime(2024, 11, 22, 17, 52, 31, 212, DateTimeKind.Utc).AddTicks(1325), 12346 },
                    { new Guid("966c155b-5eaa-4887-bc5b-02624c3664f6"), new DateOnly(2000, 5, 5), "Othercity", "Company E", new DateTime(2024, 11, 22, 17, 52, 31, 212, DateTimeKind.Utc).AddTicks(1198), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "charlie.davis@example.com", "Charlie", "Davis", "555-7890", null, "M", "IL", "202 Maple St", new DateTime(2024, 11, 22, 17, 52, 31, 212, DateTimeKind.Utc).AddTicks(1198), 77889 },
                    { new Guid("98d376be-633d-452d-8db9-2e7363b7d014"), new DateOnly(1975, 9, 9), "Bigcity", "Company I", new DateTime(2024, 11, 22, 17, 52, 31, 212, DateTimeKind.Utc).AddTicks(1249), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "grace.thomas@example.com", "Grace", "Thomas", "555-4567", null, "F", "FL", "606 Walnut St", new DateTime(2024, 11, 22, 17, 52, 31, 212, DateTimeKind.Utc).AddTicks(1249), 44556 },
                    { new Guid("993e091b-bebf-40c9-b125-3aa8259b698b"), new DateOnly(1984, 2, 26), "Newtown", "Company Z", new DateTime(2024, 11, 22, 17, 52, 31, 212, DateTimeKind.Utc).AddTicks(1390), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "xander.mitchell@example.com", "Xander", "Mitchell", "555-2349", null, "M", "CA", "2323 Chestnut St", new DateTime(2024, 11, 22, 17, 52, 31, 212, DateTimeKind.Utc).AddTicks(1390), 12348 },
                    { new Guid("a825098b-fbe0-4d7e-a7d3-8ed555941450"), new DateOnly(1985, 8, 8), "Smalltown", "Company H", new DateTime(2024, 11, 22, 17, 52, 31, 212, DateTimeKind.Utc).AddTicks(1243), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "frank.anderson@example.com", "Frank", "Anderson", "555-0123", null, "M", "TX", "505 Spruce St", new DateTime(2024, 11, 22, 17, 52, 31, 212, DateTimeKind.Utc).AddTicks(1243), 11223 },
                    { new Guid("c1edfd77-6731-42b3-9fc5-7475be190b46"), new DateOnly(1983, 9, 21), "Anyville", "Company U", new DateTime(2024, 11, 22, 17, 52, 31, 212, DateTimeKind.Utc).AddTicks(1367), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "sophia.green@example.com", "Sophia", "Green", "555-2348", null, "F", "CA", "1818 Pine St", new DateTime(2024, 11, 22, 17, 52, 31, 212, DateTimeKind.Utc).AddTicks(1367), 12347 },
                    { new Guid("c2d065cc-fa8a-46aa-aa26-9fa745838260"), new DateOnly(1988, 11, 23), "Sometown", "Company W", new DateTime(2024, 11, 22, 17, 52, 31, 212, DateTimeKind.Utc).AddTicks(1376), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "uma.adams@example.com", "Uma", "Adams", "555-0126", null, "F", "TX", "2020 Cedar St", new DateTime(2024, 11, 22, 17, 52, 31, 212, DateTimeKind.Utc).AddTicks(1376), 11226 },
                    { new Guid("cbca9f78-8bdb-4fee-b3ff-87376ba42203"), new DateOnly(1992, 5, 17), "Oldtown", "Company Q", new DateTime(2024, 11, 22, 17, 52, 31, 212, DateTimeKind.Utc).AddTicks(1332), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "olivia.hall@example.com", "Olivia", "Hall", "555-6782", null, "F", "NY", "1414 Walnut St", new DateTime(2024, 11, 22, 17, 52, 31, 212, DateTimeKind.Utc).AddTicks(1332), 67892 },
                    { new Guid("db642a10-c134-4f12-b767-b23dca99ec82"), new DateOnly(1979, 5, 29), "Bigcity", "Company CC", new DateTime(2024, 11, 22, 17, 52, 31, 212, DateTimeKind.Utc).AddTicks(1420), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "amy.turner@example.com", "Amy", "Turner", "555-4569", null, "F", "FL", "2626 Pine St", new DateTime(2024, 11, 22, 17, 52, 31, 212, DateTimeKind.Utc).AddTicks(1420), 44560 },
                    { new Guid("e28634e1-5fb3-4dac-afba-9cb02ba55f65"), new DateOnly(1975, 4, 4), "Anycity", "Company D", new DateTime(2024, 11, 22, 17, 52, 31, 212, DateTimeKind.Utc).AddTicks(1188), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "bob.brown@example.com", "Bob", "Brown", "555-3456", null, "M", "FL", "101 Pine St", new DateTime(2024, 11, 22, 17, 52, 31, 212, DateTimeKind.Utc).AddTicks(1188), 44556 },
                    { new Guid("e9deca52-1e1d-4708-9e31-f234162f2121"), new DateOnly(1994, 3, 27), "Oldtown", "Company AA", new DateTime(2024, 11, 22, 17, 52, 31, 212, DateTimeKind.Utc).AddTicks(1410), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "yara.perez@example.com", "Yara", "Perez", "555-6784", null, "F", "NY", "2424 Maple St", new DateTime(2024, 11, 22, 17, 52, 31, 212, DateTimeKind.Utc).AddTicks(1410), 67894 },
                    { new Guid("e9e9ff88-8738-49cb-a9a3-2afcbf1d342f"), new DateOnly(1995, 8, 1), "Otherville", "Company FF", new DateTime(2024, 11, 22, 17, 52, 31, 212, DateTimeKind.Utc).AddTicks(1433), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "david.parker@example.com", "David", "Parker", "555-6785", null, "M", "NY", "2929 Spruce St", new DateTime(2024, 11, 22, 17, 52, 31, 212, DateTimeKind.Utc).AddTicks(1433), 67895 },
                    { new Guid("fcaf4ccd-385e-4109-b0d0-e1bac542cb9e"), new DateOnly(2003, 1, 25), "Othercity", "Company Y", new DateTime(2024, 11, 22, 17, 52, 31, 212, DateTimeKind.Utc).AddTicks(1386), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "wendy.carter@example.com", "Wendy", "Carter", "555-7893", null, "F", "IL", "2222 Walnut St", new DateTime(2024, 11, 22, 17, 52, 31, 212, DateTimeKind.Utc).AddTicks(1386), 77892 },
                    { new Guid("fe1aeaf5-23f8-42e0-a4d2-d58c5a19d437"), new DateOnly(1980, 6, 6), "Newtown", "Company F", new DateTime(2024, 11, 22, 17, 52, 31, 212, DateTimeKind.Utc).AddTicks(1202), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "daniel.evans@example.com", "Daniel", "Evans", "555-2345", null, "M", "CA", "303 Birch St", new DateTime(2024, 11, 22, 17, 52, 31, 212, DateTimeKind.Utc).AddTicks(1202), 12345 }
                });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Name", "RootId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("1840141f-cda3-48f5-a510-fe0e635131f4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Running", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5c62932a-9c16-4d4e-857a-b26dfd1156ff"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Boots", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6bb9844b-9b67-4b98-ad76-9f9af8e70d8c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Formal", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8e2645f2-8966-4df6-9e3b-5ee63f7259f3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Casual", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d74484b1-376f-42b7-9af2-0b1ec6296a27"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sports", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "SalesPersons",
                columns: new[] { "Id", "BirthOfDate", "City", "CreatedAt", "DateHired", "DeletedAt", "Email", "FirstName", "LastName", "Phone", "RootId", "Sex", "State", "Street", "UpdatedAt", "ZipCode" },
                values: new object[,]
                {
                    { new Guid("350ccb22-39f3-4680-bbfe-919ae81e230c"), new DateOnly(1980, 6, 6), "Newtown", new DateTime(2024, 11, 22, 17, 52, 31, 214, DateTimeKind.Utc).AddTicks(9064), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "david.wilson@example.com", "David", "Wilson", "555-2345", null, "M", "CA", "303 Birch St", new DateTime(2024, 11, 22, 17, 52, 31, 214, DateTimeKind.Utc).AddTicks(9064), 12345 },
                    { new Guid("98fd068c-8219-4c46-aee5-6011d5faf71a"), new DateOnly(1990, 7, 7), "Oldtown", new DateTime(2024, 11, 22, 17, 52, 31, 214, DateTimeKind.Utc).AddTicks(9363), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "emma.taylor@example.com", "Emma", "Taylor", "555-6789", null, "M", "NY", "404 Cedar St", new DateTime(2024, 11, 22, 17, 52, 31, 214, DateTimeKind.Utc).AddTicks(9363), 67890 },
                    { new Guid("9b8fc7d2-70e0-4a76-95da-260e36dad1cc"), new DateOnly(2000, 10, 10), "Middletown", new DateTime(2024, 11, 22, 17, 52, 31, 214, DateTimeKind.Utc).AddTicks(9413), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "henry.jackson@example.com", "Henry", "Jackson", "555-8901", null, "M", "IL", "707 Chestnut St", new DateTime(2024, 11, 22, 17, 52, 31, 214, DateTimeKind.Utc).AddTicks(9413), 77889 },
                    { new Guid("a849261a-dab2-44b0-ac94-85f1c7d51861"), new DateOnly(1975, 9, 9), "Bigcity", new DateTime(2024, 11, 22, 17, 52, 31, 214, DateTimeKind.Utc).AddTicks(9409), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "grace.thomas@example.com", "Grace", "Thomas", "555-4567", null, "F", "FL", "606 Walnut St", new DateTime(2024, 11, 22, 17, 52, 31, 214, DateTimeKind.Utc).AddTicks(9409), 44556 },
                    { new Guid("f8ea5c3e-38e0-468a-a133-cd873827967a"), new DateOnly(1985, 8, 8), "Smalltown", new DateTime(2024, 11, 22, 17, 52, 31, 214, DateTimeKind.Utc).AddTicks(9400), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "frank.anderson@example.com", "Frank", "Anderson", "555-0123", null, "M", "TX", "505 Spruce St", new DateTime(2024, 11, 22, 17, 52, 31, 214, DateTimeKind.Utc).AddTicks(9400), 11223 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Description", "Name", "RootId", "Supplier", "TypeId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("110563f5-1f3f-4c71-be79-87d724802b35"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Classic casual shoes", "Adidas Superstar", null, "Adidas", new Guid("8e2645f2-8966-4df6-9e3b-5ee63f7259f3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("128c2b16-6f0c-4257-9a23-f5fbb97b2fd9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lightweight running shoes", "Saucony Kinvara", null, "Saucony", new Guid("1840141f-cda3-48f5-a510-fe0e635131f4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1b079f8f-f63c-4029-b31e-f1ec46e064db"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "All-terrain hiking boots", "Keen Targhee", null, "Keen", new Guid("5c62932a-9c16-4d4e-857a-b26dfd1156ff"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2161ca43-ad8e-415f-893a-42cd2d7f9d8d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Trail running shoes", "Arc'teryx Norvan", null, "Arc'teryx", new Guid("1840141f-cda3-48f5-a510-fe0e635131f4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5ee7ef4c-25e7-4107-9b6b-5703d5336afd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Waterproof hiking boots", "Columbia Newton Ridge", null, "Columbia", new Guid("5c62932a-9c16-4d4e-857a-b26dfd1156ff"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6311d8c0-6375-4702-ba51-22fb625981ce"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Technical trail running shoes", "La Sportiva Bushido", null, "La Sportiva", new Guid("1840141f-cda3-48f5-a510-fe0e635131f4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("65461a27-1da3-42c3-88db-0bfcb3cda912"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Iconic casual shoes", "Converse Chuck Taylor", null, "Converse", new Guid("8e2645f2-8966-4df6-9e3b-5ee63f7259f3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6550ed7c-c25a-46f5-b38a-a2e49d535c5e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Stability running shoes", "Asics Gel-Kayano", null, "Asics", new Guid("1840141f-cda3-48f5-a510-fe0e635131f4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("661ed21e-a18a-4355-966f-37b67fe7ec56"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Trail running shoes", "The North Face Ultra", null, "The North Face", new Guid("1840141f-cda3-48f5-a510-fe0e635131f4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("75dc5abd-828e-4925-9d47-76c4779e500f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Classic skate shoes", "Vans Old Skool", null, "Vans", new Guid("8e2645f2-8966-4df6-9e3b-5ee63f7259f3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("766e9937-5096-4a02-aa1e-da1b898ff561"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Classic boots", "Dr. Martens 1460", null, "Dr. Martens", new Guid("5c62932a-9c16-4d4e-857a-b26dfd1156ff"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("79088a35-0558-4180-b093-7d9fb23401f1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Maximalist running shoes", "Hoka One One Clifton", null, "Hoka One One", new Guid("1840141f-cda3-48f5-a510-fe0e635131f4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7bdb8dd7-c05e-4cb4-9ecf-f2d0e8e3f6c4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Versatile trail running shoes", "Inov-8 Roclite", null, "Inov-8", new Guid("1840141f-cda3-48f5-a510-fe0e635131f4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7fc748f2-334a-40fc-8ec0-4e5a9e8851ee"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Eco-friendly hiking shoes", "Patagonia Drifter", null, "Patagonia", new Guid("5c62932a-9c16-4d4e-857a-b26dfd1156ff"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8a7ecc7c-57e2-499b-97cc-a42fc074ae7f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Cushioned running shoes", "Mizuno Wave Rider", null, "Mizuno", new Guid("1840141f-cda3-48f5-a510-fe0e635131f4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a6cbf6e4-d0bc-4591-af91-3f9f98188cb4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sturdy hiking boots", "Lowa Renegade", null, "Lowa", new Guid("5c62932a-9c16-4d4e-857a-b26dfd1156ff"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("aa63de5e-c6e4-41a7-a595-3eaaf4a87bbc"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Premium running shoes", "New Balance 990", null, "New Balance", new Guid("1840141f-cda3-48f5-a510-fe0e635131f4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ac3a2543-2065-4524-bb80-7f07ca8e4b70"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Comfortable running shoes", "Nike Air Max", null, "Nike", new Guid("1840141f-cda3-48f5-a510-fe0e635131f4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b1e0c82d-28ca-4d12-a18a-af5d4a332b38"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Elegant formal shoes", "Clarks Oxford", null, "Clarks", new Guid("6bb9844b-9b67-4b98-ad76-9f9af8e70d8c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b2a651aa-7f84-4447-881a-99fcc154267a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Basketball shoes", "Under Armour Curry", null, "Under Armour", new Guid("d74484b1-376f-42b7-9af2-0b1ec6296a27"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c82b35ac-958d-42d9-be84-c70501fea9a6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "High-performance soccer cleats", "Puma Soccer Cleats", null, "Puma", new Guid("d74484b1-376f-42b7-9af2-0b1ec6296a27"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d3cc497d-a4e8-4fc7-8852-ba33443b101f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Hiking boots", "Merrell Moab", null, "Merrell", new Guid("5c62932a-9c16-4d4e-857a-b26dfd1156ff"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d657bf4b-2f8e-4007-8671-1f36d5b2d182"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Neutral running shoes", "Brooks Ghost", null, "Brooks", new Guid("1840141f-cda3-48f5-a510-fe0e635131f4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("dc3d27fc-7223-45dd-8bde-cbfa3cbe0706"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Approach shoes", "Scarpa Mojito", null, "Scarpa", new Guid("8e2645f2-8966-4df6-9e3b-5ee63f7259f3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e183a966-3d03-4ee6-ba0d-71737c75c123"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Zero-drop trail running shoes", "Altra Lone Peak", null, "Altra", new Guid("1840141f-cda3-48f5-a510-fe0e635131f4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e3ad5f61-091d-4b60-9e67-acb76bec8975"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Timeless casual shoes", "Reebok Classic", null, "Reebok", new Guid("8e2645f2-8966-4df6-9e3b-5ee63f7259f3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e4288647-4145-43db-923f-3107f02a53e6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Heritage hiking boots", "Danner Mountain", null, "Danner", new Guid("5c62932a-9c16-4d4e-857a-b26dfd1156ff"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e4c11fe2-4d1f-4d3a-93ce-ca93fd4c32a6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Trail running shoes", "Salomon Speedcross", null, "Salomon", new Guid("1840141f-cda3-48f5-a510-fe0e635131f4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ec413a41-1d7f-4bd3-929e-21822a7305c1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Durable outdoor boots", "Timberland Boots", null, "Timberland", new Guid("5c62932a-9c16-4d4e-857a-b26dfd1156ff"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ff86d84a-b37c-4412-99c6-29d9d944f8cc"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Waterproof hiking boots", "Oboz Bridger", null, "Oboz", new Guid("5c62932a-9c16-4d4e-857a-b26dfd1156ff"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "SalesOrders",
                columns: new[] { "Id", "CreatedAt", "CreditCardExpireDay", "CreditCardExpireMonth", "CreditCardExpireSecretCode", "CreditCardNumber", "CustId", "DeletedAt", "NameOnCard", "PurchaseOrderNumber", "RootId", "SalesPersonId", "TimeOrderTaken", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("3666591f-12cd-4582-a85e-ed23f0322656"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)27, (short)8, (short)567, "5678901256789012", new Guid("966c155b-5eaa-4887-bc5b-02624c3664f6"), null, "Charlie Davis", 1005, null, new Guid("9b8fc7d2-70e0-4a76-95da-260e36dad1cc"), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("53acc6e5-6b1b-4630-b4ad-7a6c04ddfdea"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)28, (short)9, (short)456, "4567890145678901", new Guid("e28634e1-5fb3-4dac-afba-9cb02ba55f65"), null, "Bob Brown", 1004, null, new Guid("a849261a-dab2-44b0-ac94-85f1c7d51861"), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6836da2a-c977-43d8-82b3-ba69d80e1681"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)30, (short)11, (short)234, "2345678923456789", new Guid("2f207703-1576-4f6b-a9fb-e7e2d9cdc081"), null, "Jane Smith", 1002, null, new Guid("98fd068c-8219-4c46-aee5-6011d5faf71a"), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("76c7df6f-4edb-44ed-bf35-f0cd9befedc6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)31, (short)12, (short)123, "1234567812345678", new Guid("29bbed5e-8596-41ce-9f38-8b1b259475d6"), null, "John Doe", 1001, null, new Guid("350ccb22-39f3-4680-bbfe-919ae81e230c"), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a68a0dc1-0a84-4198-bdf7-8657af3e230d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)29, (short)10, (short)345, "3456789034567890", new Guid("63f14b2b-b6d9-4601-9664-d47a08481630"), null, "Alice Johnson", 1003, null, new Guid("f8ea5c3e-38e0-468a-a133-cd873827967a"), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Color", "CreatedAt", "DeletedAt", "Picture", "Price", "ProductId", "RootId", "Size", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("07cdcaa3-b614-42bd-9aba-c60ddd67c612"), "Black", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "hoka_one_one_clifton.jpg", 140.00m, new Guid("79088a35-0558-4180-b093-7d9fb23401f1"), null, 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("13c7c423-3764-4d3d-9d5c-0483a1f51c15"), "Black", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nike_air_max.jpg", 120.00m, new Guid("ac3a2543-2065-4524-bb80-7f07ca8e4b70"), null, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2420a82f-75a0-4491-9a81-59a6f509e250"), "Red", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "puma_soccer_cleats.jpg", 100.00m, new Guid("c82b35ac-958d-42d9-be84-c70501fea9a6"), null, 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2977b23d-5ca0-49c1-84fd-2a9ce8116bab"), "Black", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "vans_old_skool.jpg", 70.00m, new Guid("75dc5abd-828e-4925-9d47-76c4779e500f"), null, 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("41eb5286-cd2c-4396-bb0e-5f5a44f2ff4e"), "White", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "adidas_superstar.jpg", 80.00m, new Guid("110563f5-1f3f-4c71-be79-87d724802b35"), null, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4b509e9b-f3fc-489c-8e76-6f76573adc6e"), "Blue", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "lowa_renegade.jpg", 260.00m, new Guid("a6cbf6e4-d0bc-4591-af91-3f9f98188cb4"), null, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4dd9ff35-6583-4312-a2fb-035316e82c4e"), "Tan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "keen_targhee.jpg", 180.00m, new Guid("1b079f8f-f63c-4029-b31e-f1ec46e064db"), null, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5189e301-fc78-4c99-a88c-5cd89cb916c9"), "Brown", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "clarks_oxford.jpg", 150.00m, new Guid("b1e0c82d-28ca-4d12-a18a-af5d4a332b38"), null, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("64f72c28-49fa-4ba7-82db-16386e705795"), "Gray", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "new_balance_990.jpg", 160.00m, new Guid("aa63de5e-c6e4-41a7-a595-3eaaf4a87bbc"), null, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("67070561-1499-46e1-9da1-f9e4a7398406"), "Gray", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "danner_mountain.jpg", 280.00m, new Guid("e4288647-4145-43db-923f-3107f02a53e6"), null, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7e23eb3c-d473-4a6a-9e47-8bf0b126bcca"), "Red", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "salomon_speedcross.jpg", 150.00m, new Guid("e4c11fe2-4d1f-4d3a-93ce-ca93fd4c32a6"), null, 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8032970a-896a-4e54-ace7-4e5ab42f640e"), "Black", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "columbia_newton_ridge.jpg", 170.00m, new Guid("5ee7ef4c-25e7-4107-9b6b-5703d5336afd"), null, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9977f592-43ce-403b-8c25-899c9d46d3bf"), "Green", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "asics_gel_kayano.jpg", 130.00m, new Guid("6550ed7c-c25a-46f5-b38a-a2e49d535c5e"), null, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a5e11ef7-1adf-4cc8-8b5c-d8b49c1fd2d0"), "Red", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "inov8_roclite.jpg", 230.00m, new Guid("7bdb8dd7-c05e-4cb4-9ecf-f2d0e8e3f6c4"), null, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a79eb62e-e27f-4e06-9f2a-1b6db7876bcf"), "Black", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "under_armour_curry.jpg", 110.00m, new Guid("b2a651aa-7f84-4447-881a-99fcc154267a"), null, 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b0bacfbb-b8c8-4678-9188-1a009c786733"), "Tan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "timberland_boots.jpg", 200.00m, new Guid("ec413a41-1d7f-4bd3-929e-21822a7305c1"), null, 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bad14e5d-f1c1-43d1-aab7-a2e3ac6721da"), "Gray", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "brooks_ghost.jpg", 130.00m, new Guid("d657bf4b-2f8e-4007-8671-1f36d5b2d182"), null, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("be63dbbc-262c-4997-8de6-752467345861"), "Black", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "altra_lone_peak.jpg", 220.00m, new Guid("e183a966-3d03-4ee6-ba0d-71737c75c123"), null, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("be9acedf-887b-4305-8dc1-8d69eaf7b507"), "Brown", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "the_north_face_ultra.jpg", 240.00m, new Guid("661ed21e-a18a-4355-966f-37b67fe7ec56"), null, 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c45e15cc-88b9-4eb6-8279-d4b5a01f5d30"), "Green", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "saucony_kinvara.jpg", 100.00m, new Guid("128c2b16-6f0c-4257-9a23-f5fbb97b2fd9"), null, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c671a820-d698-4ecb-b43c-d1cd6ad1e8d4"), "Black", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "patagonia_drifter.jpg", 250.00m, new Guid("7fc748f2-334a-40fc-8ec0-4e5a9e8851ee"), null, 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c7e4052a-0bbc-4793-aaf2-ea0a70fea9b5"), "Blue", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "mizuno_wave_rider.jpg", 120.00m, new Guid("8a7ecc7c-57e2-499b-97cc-a42fc074ae7f"), null, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c8d60aca-d493-437c-8053-0f314e1c5525"), "Brown", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "merrell_moab.jpg", 160.00m, new Guid("d3cc497d-a4e8-4fc7-8852-ba33443b101f"), null, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cd094cf6-7253-4775-9fd3-edc7f7be6bb8"), "Green", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "scarpa_mojito.jpg", 200.00m, new Guid("dc3d27fc-7223-45dd-8bde-cbfa3cbe0706"), null, 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d674ca00-8691-46d1-8836-c3510dde2221"), "White", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "converse_chuck_taylor.jpg", 60.00m, new Guid("65461a27-1da3-42c3-88db-0bfcb3cda912"), null, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e89ab2e6-0781-4b04-b7d0-8272cf041bda"), "Blue", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "la_sportiva_bushido.jpg", 190.00m, new Guid("6311d8c0-6375-4702-ba51-22fb625981ce"), null, 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ed615c2c-865a-4f28-bbad-ce5fdb8daab3"), "Brown", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "dr_martens_1460.jpg", 140.00m, new Guid("766e9937-5096-4a02-aa1e-da1b898ff561"), null, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fdf3a9c9-03b1-4860-a19f-6bec8262c8ea"), "Blue", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "reebok_classic.jpg", 90.00m, new Guid("e3ad5f61-091d-4b60-9e67-acb76bec8975"), null, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ffcf26f4-2b06-4805-8327-341c25585a55"), "Gray", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "arcteryx_norvan.jpg", 210.00m, new Guid("2161ca43-ad8e-415f-893a-42cd2d7f9d8d"), null, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ffe30c34-8e28-474b-baf0-aafd3cdec931"), "Green", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "oboz_bridger.jpg", 270.00m, new Guid("ff86d84a-b37c-4412-99c6-29d9d944f8cc"), null, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "SalesItems",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Discount", "ItemId", "Quantity", "RootId", "SalesOrderId", "SalesTaxRate", "Taxable", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("4cd55ab6-823a-4b8b-949c-b18af7b126de"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0.05m, new Guid("41eb5286-cd2c-4396-bb0e-5f5a44f2ff4e"), 1, null, new Guid("a68a0dc1-0a84-4198-bdf7-8657af3e230d"), 0.07m, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("646a1571-8b71-4137-bb79-b20951760b9b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0.10m, new Guid("2420a82f-75a0-4491-9a81-59a6f509e250"), 2, null, new Guid("3666591f-12cd-4582-a85e-ed23f0322656"), 0.07m, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("82523495-ee5c-460c-bafa-2637683e4467"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0.15m, new Guid("2420a82f-75a0-4491-9a81-59a6f509e250"), 3, null, new Guid("3666591f-12cd-4582-a85e-ed23f0322656"), 0.00m, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9d16da36-3494-46b3-85d4-734f39ae337b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0.20m, new Guid("5189e301-fc78-4c99-a88c-5cd89cb916c9"), 4, null, new Guid("53acc6e5-6b1b-4630-b4ad-7a6c04ddfdea"), 0.07m, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c4d32dcb-2485-42e8-9196-475ae226438f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0.10m, new Guid("13c7c423-3764-4d3d-9d5c-0483a1f51c15"), 2, null, new Guid("6836da2a-c977-43d8-82b3-ba69d80e1681"), 0.07m, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
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

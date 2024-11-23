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
                    { new Guid("00647b0b-9ee0-4d95-8f45-c376322e3097"), new DateOnly(1990, 2, 2), "Othertown", "Company B", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "jane.smith@example.com", "Jane", "Smith", "555-5678", null, "F", "NY", "456 Elm St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 67890 },
                    { new Guid("04ce7c1b-2b1d-4f2f-8037-ed1ca2069efd"), new DateOnly(1987, 6, 18), "Smalltown", "Company R", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "paul.young@example.com", "Paul", "Young", "555-0125", null, "M", "TX", "1515 Chestnut St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 11225 },
                    { new Guid("1244ff4f-8268-49ac-956b-6d5d4604f9f3"), new DateOnly(1994, 3, 27), "Oldtown", "Company AA", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "yara.perez@example.com", "Yara", "Perez", "555-6784", null, "F", "NY", "2424 Maple St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 67894 },
                    { new Guid("143cfadd-b96d-444c-bd9d-3aedc36b235b"), new DateOnly(2004, 6, 30), "Middletown", "Company DD", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "brian.phillips@example.com", "Brian", "Phillips", "555-8903", null, "M", "IL", "2727 Birch St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 77893 },
                    { new Guid("1545d11b-177a-4019-8d73-24480a8e639d"), new DateOnly(1977, 7, 19), "Bigcity", "Company S", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "quinn.king@example.com", "Quinn", "King", "555-4568", null, "F", "FL", "1616 Maple St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 44558 },
                    { new Guid("25410355-21c6-4454-963a-47f8f587fcd2"), new DateOnly(1990, 7, 7), "Oldtown", "Company G", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "emma.taylor@example.com", "Emma", "Taylor", "555-6789", null, "F", "NY", "404 Cedar St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 67890 },
                    { new Guid("2e7eabdb-f2f4-409d-ba47-d65912777582"), new DateOnly(2000, 10, 10), "Middletown", "Company J", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "henry.jackson@example.com", "Henry", "Jackson", "555-8901", null, "M", "IL", "707 Chestnut St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 77889 },
                    { new Guid("3dbdd895-8f9f-4f14-aa68-b856825fb365"), new DateOnly(1976, 2, 14), "Anycity", "Company N", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "leo.clark@example.com", "Leo", "Clark", "555-3457", null, "M", "FL", "1111 Birch St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 44557 },
                    { new Guid("42b686ca-aa11-4160-b568-7c17997c0ddf"), new DateOnly(1985, 8, 8), "Smalltown", "Company H", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "frank.anderson@example.com", "Frank", "Anderson", "555-0123", null, "M", "TX", "505 Spruce St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 11223 },
                    { new Guid("46f43253-9a88-4d2d-819f-75f7edb05857"), new DateOnly(1985, 7, 31), "Anyville", "Company EE", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "chloe.campbell@example.com", "Chloe", "Campbell", "555-2350", null, "F", "CA", "2828 Cedar St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 12349 },
                    { new Guid("4ac88820-37e6-4ac7-af3b-922ee04829e8"), new DateOnly(1991, 12, 12), "Otherville", "Company L", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "jack.harris@example.com", "Jack", "Harris", "555-6780", null, "M", "NY", "909 Oak St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 67891 },
                    { new Guid("593f2abf-a8a0-4b0a-8a38-3168cf3ed556"), new DateOnly(1986, 1, 13), "Sometown", "Company M", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "karen.martin@example.com", "Karen", "Martin", "555-0124", null, "F", "TX", "1010 Pine St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 11224 },
                    { new Guid("66ca4a78-4d52-4eb6-86e9-5aec1c1aeb11"), new DateOnly(2001, 3, 15), "Othercity", "Company O", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "mia.lewis@example.com", "Mia", "Lewis", "555-7891", null, "F", "IL", "1212 Cedar St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 77890 },
                    { new Guid("6bf5cb6a-02b0-4f78-a1ed-2ddee461d01c"), new DateOnly(1992, 5, 17), "Oldtown", "Company Q", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "olivia.hall@example.com", "Olivia", "Hall", "555-6782", null, "F", "NY", "1414 Walnut St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 67892 },
                    { new Guid("71c11416-1be3-447b-bc48-9684cac9853b"), new DateOnly(1981, 11, 11), "Anyville", "Company K", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "ivy.white@example.com", "Ivy", "White", "555-2346", null, "F", "CA", "808 Maple St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 12345 },
                    { new Guid("7a6bdf41-1b56-4fd2-81cf-91d64c9205c3"), new DateOnly(2002, 8, 20), "Middletown", "Company T", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "ryan.scott@example.com", "Ryan", "Scott", "555-8902", null, "M", "IL", "1717 Oak St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 77891 },
                    { new Guid("7ac9ea1d-3dd9-4d22-b10c-3582785590d6"), new DateOnly(1988, 11, 23), "Sometown", "Company W", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "uma.adams@example.com", "Uma", "Adams", "555-0126", null, "F", "TX", "2020 Cedar St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 11226 },
                    { new Guid("8db50e99-deac-44d8-bbb3-42ebc2e6b111"), new DateOnly(1980, 6, 6), "Newtown", "Company F", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "daniel.evans@example.com", "Daniel", "Evans", "555-2345", null, "M", "CA", "303 Birch St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 12345 },
                    { new Guid("9ef2868a-43d2-45ac-bd34-e8b9e705dcb1"), new DateOnly(1989, 4, 28), "Smalltown", "Company BB", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "zane.roberts@example.com", "Zane", "Roberts", "555-0127", null, "M", "TX", "2525 Oak St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 11227 },
                    { new Guid("a5a4fd9e-7701-486a-8b21-0ace7f7fb2fa"), new DateOnly(1982, 4, 16), "Newtown", "Company P", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "noah.walker@example.com", "Noah", "Walker", "555-2347", null, "M", "CA", "1313 Spruce St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 12346 },
                    { new Guid("a8afdb99-2c7a-4aa2-9c0f-c53121caa222"), new DateOnly(1978, 12, 24), "Anycity", "Company X", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "victor.nelson@example.com", "Victor", "Nelson", "555-3459", null, "M", "FL", "2121 Spruce St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 44559 },
                    { new Guid("abb29913-84fc-4f17-8ab0-94da274f0a1d"), new DateOnly(1984, 2, 26), "Newtown", "Company Z", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "xander.mitchell@example.com", "Xander", "Mitchell", "555-2349", null, "M", "CA", "2323 Chestnut St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 12348 },
                    { new Guid("b01e5999-b4be-466b-8370-4f5283154cc2"), new DateOnly(1993, 10, 22), "Otherville", "Company V", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "thomas.baker@example.com", "Thomas", "Baker", "555-6783", null, "M", "NY", "1919 Birch St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 67893 },
                    { new Guid("b1862c94-f6b1-4bbd-be50-714d421a40a7"), new DateOnly(1979, 5, 29), "Bigcity", "Company CC", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "amy.turner@example.com", "Amy", "Turner", "555-4569", null, "F", "FL", "2626 Pine St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 44560 },
                    { new Guid("c0a8dc3f-c3ed-4fe0-b663-7632aaf5b402"), new DateOnly(1983, 9, 21), "Anyville", "Company U", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "sophia.green@example.com", "Sophia", "Green", "555-2348", null, "F", "CA", "1818 Pine St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 12347 },
                    { new Guid("c122dc80-e772-48fb-a125-84ea2cab1b2f"), new DateOnly(1985, 3, 3), "Sometown", "Company C", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "alice.johnson@example.com", "Alice", "Johnson", "555-9012", null, "", "TX", "789 Oak St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 11223 },
                    { new Guid("c43cb1fb-f844-4a74-9573-a8de46e5e57c"), new DateOnly(2000, 5, 5), "Othercity", "Company E", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "charlie.davis@example.com", "Charlie", "Davis", "555-7890", null, "M", "IL", "202 Maple St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 77889 },
                    { new Guid("ca20a3d8-8b58-48e0-add5-f60cfbb0d2ff"), new DateOnly(1990, 9, 2), "Sometown", "Company GG", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "ella.evans@example.com", "Ella", "Evans", "555-0128", null, "F", "TX", "3030 Walnut St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 11228 },
                    { new Guid("cc106dc6-2649-490a-a4d8-fa30438992b6"), new DateOnly(2003, 1, 25), "Othercity", "Company Y", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "wendy.carter@example.com", "Wendy", "Carter", "555-7893", null, "F", "IL", "2222 Walnut St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 77892 },
                    { new Guid("cf3c6d17-e638-4a2c-a18b-0e9e81a917ec"), new DateOnly(1980, 1, 1), "Anytown", "Company A", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "john.doe@example.com", "John", "Doe", "555-1234", null, "M", "CA", "123 Main St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 12345 },
                    { new Guid("d7dc43de-fef8-41fd-9d76-0314b433ce04"), new DateOnly(1995, 8, 1), "Otherville", "Company FF", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "david.parker@example.com", "David", "Parker", "555-6785", null, "M", "NY", "2929 Spruce St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 67895 },
                    { new Guid("e6779c8c-6976-4da9-adc6-e510c82f8858"), new DateOnly(1975, 4, 4), "Anycity", "Company D", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "bob.brown@example.com", "Bob", "Brown", "555-3456", null, "M", "FL", "101 Pine St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 44556 },
                    { new Guid("fc5538bd-1d13-4d10-96d7-abb18e751080"), new DateOnly(1975, 9, 9), "Bigcity", "Company I", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "grace.thomas@example.com", "Grace", "Thomas", "555-4567", null, "F", "FL", "606 Walnut St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 44556 }
                });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Name", "RootId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("23bfd419-5695-4fec-ab63-cec6d84b4da1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Boots", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2c066807-374b-4783-92be-9c632f40beca"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Formal", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d772e486-6e9b-4510-b854-d242351db14c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Casual", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e879aaed-1250-4471-81b6-3f1eb6111efa"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Running", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fa10dd62-1a70-4f16-ace2-003dd325be49"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sports", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "SalesPersons",
                columns: new[] { "Id", "BirthOfDate", "City", "CreatedAt", "DateHired", "DeletedAt", "Email", "FirstName", "LastName", "Phone", "RootId", "Sex", "State", "Street", "UpdatedAt", "ZipCode" },
                values: new object[,]
                {
                    { new Guid("0f030a6a-97ac-4d9d-b482-2eb8d064cd1a"), new DateOnly(2000, 10, 10), "Middletown", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "henry.jackson@example.com", "Henry", "Jackson", "555-8901", null, "M", "IL", "707 Chestnut St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 77889 },
                    { new Guid("15ce0fc9-3f20-4259-803b-01cfb1542ffa"), new DateOnly(1980, 6, 6), "Newtown", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "david.wilson@example.com", "David", "Wilson", "555-2345", null, "M", "CA", "303 Birch St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 12345 },
                    { new Guid("2380867f-3642-4e0e-a24f-75c6535adf0a"), new DateOnly(1985, 8, 8), "Smalltown", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "frank.anderson@example.com", "Frank", "Anderson", "555-0123", null, "M", "TX", "505 Spruce St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 11223 },
                    { new Guid("e0713885-674f-435a-b27a-7a32aff46e8e"), new DateOnly(1975, 9, 9), "Bigcity", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "grace.thomas@example.com", "Grace", "Thomas", "555-4567", null, "F", "FL", "606 Walnut St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 44556 },
                    { new Guid("fdb00d75-7378-424b-9570-cbfa1a935bf6"), new DateOnly(1990, 7, 7), "Oldtown", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "emma.taylor@example.com", "Emma", "Taylor", "555-6789", null, "M", "NY", "404 Cedar St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 67890 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Description", "Name", "RootId", "Supplier", "TypeId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("10900223-0636-477d-9142-af6855cb629c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Elegant formal shoes", "Clarks Oxford", null, "Clarks", new Guid("2c066807-374b-4783-92be-9c632f40beca"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("13abc01e-4ebd-4178-8942-9753236d22e5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lightweight running shoes", "Saucony Kinvara", null, "Saucony", new Guid("e879aaed-1250-4471-81b6-3f1eb6111efa"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1d1045b0-54fa-4700-a0f4-cc8f5da3656e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Technical trail running shoes", "La Sportiva Bushido", null, "La Sportiva", new Guid("e879aaed-1250-4471-81b6-3f1eb6111efa"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2bef756f-02bb-45d7-84e6-078e0df290c3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Heritage hiking boots", "Danner Mountain", null, "Danner", new Guid("23bfd419-5695-4fec-ab63-cec6d84b4da1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("352827ef-42a8-4117-8340-1c16711c0400"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Timeless casual shoes", "Reebok Classic", null, "Reebok", new Guid("d772e486-6e9b-4510-b854-d242351db14c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3a0015e7-1a4a-441a-b833-102b2eb6dbff"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Trail running shoes", "Arc'teryx Norvan", null, "Arc'teryx", new Guid("e879aaed-1250-4471-81b6-3f1eb6111efa"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("402e1a8e-0d85-4e2f-a0c1-ab775976d0b3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Trail running shoes", "Salomon Speedcross", null, "Salomon", new Guid("e879aaed-1250-4471-81b6-3f1eb6111efa"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4ce692c1-f6d9-4e69-8f0d-93d1924055b0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Premium running shoes", "New Balance 990", null, "New Balance", new Guid("e879aaed-1250-4471-81b6-3f1eb6111efa"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4f097990-1630-4b53-bcb9-76efaa9f8570"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Hiking boots", "Merrell Moab", null, "Merrell", new Guid("23bfd419-5695-4fec-ab63-cec6d84b4da1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4fa82311-ed2e-4eb9-b567-fa7f3fcc7f1c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Trail running shoes", "The North Face Ultra", null, "The North Face", new Guid("e879aaed-1250-4471-81b6-3f1eb6111efa"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4fe2d2bf-0f1d-4cf8-9d63-a08d32c64fa3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Basketball shoes", "Under Armour Curry", null, "Under Armour", new Guid("fa10dd62-1a70-4f16-ace2-003dd325be49"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("594cb715-6f78-4790-b110-936f9064cc1a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Eco-friendly hiking shoes", "Patagonia Drifter", null, "Patagonia", new Guid("23bfd419-5695-4fec-ab63-cec6d84b4da1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6399e9a2-f983-4710-8a8d-5084bc46f9b3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Versatile trail running shoes", "Inov-8 Roclite", null, "Inov-8", new Guid("e879aaed-1250-4471-81b6-3f1eb6111efa"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("71e3f427-5050-489e-b036-243d9bd04618"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Classic boots", "Dr. Martens 1460", null, "Dr. Martens", new Guid("23bfd419-5695-4fec-ab63-cec6d84b4da1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7ba5ffa5-b3ed-4ae9-bf49-67fdb8572c03"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "High-performance soccer cleats", "Puma Soccer Cleats", null, "Puma", new Guid("fa10dd62-1a70-4f16-ace2-003dd325be49"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8bff8107-6afe-471c-a3a8-5ea48f6362c0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Neutral running shoes", "Brooks Ghost", null, "Brooks", new Guid("e879aaed-1250-4471-81b6-3f1eb6111efa"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8d7277fd-a979-4c28-9b8e-b9146a9634d5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Waterproof hiking boots", "Oboz Bridger", null, "Oboz", new Guid("23bfd419-5695-4fec-ab63-cec6d84b4da1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("923d7c48-1f0b-4826-b937-1c95082c9787"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Maximalist running shoes", "Hoka One One Clifton", null, "Hoka One One", new Guid("e879aaed-1250-4471-81b6-3f1eb6111efa"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("939da1a2-6cb5-4769-b57c-ad4799b5cdb4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Zero-drop trail running shoes", "Altra Lone Peak", null, "Altra", new Guid("e879aaed-1250-4471-81b6-3f1eb6111efa"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9ed9b0f0-ea82-4d43-9861-4c7315f52507"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Durable outdoor boots", "Timberland Boots", null, "Timberland", new Guid("23bfd419-5695-4fec-ab63-cec6d84b4da1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9f6e1d2b-1377-4390-8eae-7be47c38d18e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Iconic casual shoes", "Converse Chuck Taylor", null, "Converse", new Guid("d772e486-6e9b-4510-b854-d242351db14c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a4d791f8-4917-4192-9520-88422514cda3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Waterproof hiking boots", "Columbia Newton Ridge", null, "Columbia", new Guid("23bfd419-5695-4fec-ab63-cec6d84b4da1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a650ae15-1de8-4cbc-98bf-ae15ec18cb7d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "All-terrain hiking boots", "Keen Targhee", null, "Keen", new Guid("23bfd419-5695-4fec-ab63-cec6d84b4da1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a9cc9831-2b17-4591-854e-8bc49163c256"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Comfortable running shoes", "Nike Air Max", null, "Nike", new Guid("e879aaed-1250-4471-81b6-3f1eb6111efa"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b5b3d353-d19d-454c-8b30-2265a88e04fe"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Classic casual shoes", "Adidas Superstar", null, "Adidas", new Guid("d772e486-6e9b-4510-b854-d242351db14c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c0755372-174a-4c67-807e-5bcd98f30356"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Stability running shoes", "Asics Gel-Kayano", null, "Asics", new Guid("e879aaed-1250-4471-81b6-3f1eb6111efa"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d6e9ea19-7587-4f15-a37d-ffcd7d70041c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sturdy hiking boots", "Lowa Renegade", null, "Lowa", new Guid("23bfd419-5695-4fec-ab63-cec6d84b4da1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("dbbf3543-247f-4f9d-9aa7-d7d92f2b1cb1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Approach shoes", "Scarpa Mojito", null, "Scarpa", new Guid("d772e486-6e9b-4510-b854-d242351db14c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("dc93a9d7-e90c-4b90-9f34-2dcda84e43b0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Cushioned running shoes", "Mizuno Wave Rider", null, "Mizuno", new Guid("e879aaed-1250-4471-81b6-3f1eb6111efa"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fa56f732-0dc6-40b5-ad57-ec4fb6dca62a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Classic skate shoes", "Vans Old Skool", null, "Vans", new Guid("d772e486-6e9b-4510-b854-d242351db14c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "SalesOrders",
                columns: new[] { "Id", "CreatedAt", "CreditCardExpireDay", "CreditCardExpireMonth", "CreditCardExpireSecretCode", "CreditCardNumber", "CustId", "DeletedAt", "NameOnCard", "PurchaseOrderNumber", "RootId", "SalesPersonId", "TimeOrderTaken", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("1ee66148-e4ce-4dcb-ac43-965d34ff6318"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)30, (short)11, (short)234, "2345678923456789", new Guid("00647b0b-9ee0-4d95-8f45-c376322e3097"), null, "Jane Smith", 1002, null, new Guid("fdb00d75-7378-424b-9570-cbfa1a935bf6"), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5e678e3b-fddb-47fb-a6a3-6194be83277a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)28, (short)9, (short)456, "4567890145678901", new Guid("e6779c8c-6976-4da9-adc6-e510c82f8858"), null, "Bob Brown", 1004, null, new Guid("e0713885-674f-435a-b27a-7a32aff46e8e"), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7c85eff2-7c76-4c6d-baea-dee41885dc19"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)29, (short)10, (short)345, "3456789034567890", new Guid("c122dc80-e772-48fb-a125-84ea2cab1b2f"), null, "Alice Johnson", 1003, null, new Guid("2380867f-3642-4e0e-a24f-75c6535adf0a"), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c360bb51-6146-4cae-88b5-8d45b5f14149"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)31, (short)12, (short)123, "1234567812345678", new Guid("cf3c6d17-e638-4a2c-a18b-0e9e81a917ec"), null, "John Doe", 1001, null, new Guid("15ce0fc9-3f20-4259-803b-01cfb1542ffa"), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f97f9051-f8e5-4b0b-8e44-6d6a03c1728b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)27, (short)8, (short)567, "5678901256789012", new Guid("c43cb1fb-f844-4a74-9573-a8de46e5e57c"), null, "Charlie Davis", 1005, null, new Guid("0f030a6a-97ac-4d9d-b482-2eb8d064cd1a"), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Color", "CreatedAt", "DeletedAt", "Picture", "Price", "ProductId", "RootId", "Size", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0bd3b942-8352-4679-9c5c-e39a59c41481"), "Brown", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "merrell_moab.jpg", 160.00m, new Guid("4f097990-1630-4b53-bcb9-76efaa9f8570"), null, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1829fc70-927d-434c-8886-a18690b93069"), "Gray", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "new_balance_990.jpg", 160.00m, new Guid("4ce692c1-f6d9-4e69-8f0d-93d1924055b0"), null, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("206d2452-c130-46d5-9e17-7e45b50e90ff"), "Black", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "vans_old_skool.jpg", 70.00m, new Guid("fa56f732-0dc6-40b5-ad57-ec4fb6dca62a"), null, 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("20c9c8a5-5776-409b-9ea4-c5f52d688ca8"), "Green", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "saucony_kinvara.jpg", 100.00m, new Guid("13abc01e-4ebd-4178-8942-9753236d22e5"), null, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("34435aa6-dc8a-42b8-98de-bf78ab4e9877"), "Black", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "columbia_newton_ridge.jpg", 170.00m, new Guid("a4d791f8-4917-4192-9520-88422514cda3"), null, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("40418715-f4f0-4d73-a136-86304eea3dd8"), "White", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "adidas_superstar.jpg", 80.00m, new Guid("b5b3d353-d19d-454c-8b30-2265a88e04fe"), null, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("42248eee-9e02-4b66-9107-10789811cfb7"), "Gray", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "brooks_ghost.jpg", 130.00m, new Guid("8bff8107-6afe-471c-a3a8-5ea48f6362c0"), null, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4ec52ecb-e9c8-4719-af5d-f7aab7e60d08"), "Gray", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "arcteryx_norvan.jpg", 210.00m, new Guid("3a0015e7-1a4a-441a-b833-102b2eb6dbff"), null, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("50e3edae-c80b-4cfc-82cc-cd49360aa9cc"), "Red", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "salomon_speedcross.jpg", 150.00m, new Guid("402e1a8e-0d85-4e2f-a0c1-ab775976d0b3"), null, 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("584d27ef-8d0a-45e3-9653-3a04aa1730f6"), "Tan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "keen_targhee.jpg", 180.00m, new Guid("a650ae15-1de8-4cbc-98bf-ae15ec18cb7d"), null, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("69bc12cc-c9cf-47bf-8314-bc898deca9f0"), "Black", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "hoka_one_one_clifton.jpg", 140.00m, new Guid("923d7c48-1f0b-4826-b937-1c95082c9787"), null, 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6a99cce0-ce87-4965-a5ca-7663946834eb"), "Blue", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "lowa_renegade.jpg", 260.00m, new Guid("d6e9ea19-7587-4f15-a37d-ffcd7d70041c"), null, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6bfd8120-062a-4231-8af0-dc43821ce08f"), "Green", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "oboz_bridger.jpg", 270.00m, new Guid("8d7277fd-a979-4c28-9b8e-b9146a9634d5"), null, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7459ef4c-81b2-46d7-855f-c44c0cb97f8e"), "Tan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "timberland_boots.jpg", 200.00m, new Guid("9ed9b0f0-ea82-4d43-9861-4c7315f52507"), null, 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7b1f26a6-0bd0-45d4-ba72-1ffbfe3a02b5"), "Blue", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "reebok_classic.jpg", 90.00m, new Guid("352827ef-42a8-4117-8340-1c16711c0400"), null, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8834c66a-fe2b-40bb-afd9-f2ec2b494f9e"), "Green", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "asics_gel_kayano.jpg", 130.00m, new Guid("c0755372-174a-4c67-807e-5bcd98f30356"), null, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8b3d6463-7263-4dc1-8647-e096329ba721"), "Black", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "under_armour_curry.jpg", 110.00m, new Guid("4fe2d2bf-0f1d-4cf8-9d63-a08d32c64fa3"), null, 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("95485b9f-5af7-4795-b080-521e0b6bfd36"), "Black", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "patagonia_drifter.jpg", 250.00m, new Guid("594cb715-6f78-4790-b110-936f9064cc1a"), null, 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9a8b7165-6bb9-4482-bef2-6248da2e2f1d"), "Black", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "altra_lone_peak.jpg", 220.00m, new Guid("939da1a2-6cb5-4769-b57c-ad4799b5cdb4"), null, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9eae8b3e-6eb4-4b47-a615-978920501b0b"), "Red", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "inov8_roclite.jpg", 230.00m, new Guid("6399e9a2-f983-4710-8a8d-5084bc46f9b3"), null, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a7b79ca3-70fd-463c-98d9-f29b95fd6124"), "Brown", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "the_north_face_ultra.jpg", 240.00m, new Guid("4fa82311-ed2e-4eb9-b567-fa7f3fcc7f1c"), null, 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c370ecd9-87b1-4860-919d-f78ea998b6b5"), "Blue", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "la_sportiva_bushido.jpg", 190.00m, new Guid("1d1045b0-54fa-4700-a0f4-cc8f5da3656e"), null, 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cb982547-d393-425e-b540-d9341b3f9634"), "Blue", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "mizuno_wave_rider.jpg", 120.00m, new Guid("dc93a9d7-e90c-4b90-9f34-2dcda84e43b0"), null, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("dff1534e-6bc4-471c-97f2-3b2d66437079"), "Brown", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "clarks_oxford.jpg", 150.00m, new Guid("10900223-0636-477d-9142-af6855cb629c"), null, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e3703a3d-d1d0-4b14-b73f-0492c311d375"), "Brown", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "dr_martens_1460.jpg", 140.00m, new Guid("71e3f427-5050-489e-b036-243d9bd04618"), null, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("eb5133e5-30c0-4aa4-93d6-5f98361b91f0"), "Green", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "scarpa_mojito.jpg", 200.00m, new Guid("dbbf3543-247f-4f9d-9aa7-d7d92f2b1cb1"), null, 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("eca686cd-9885-47b9-9da4-3ec7a22e98a4"), "White", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "converse_chuck_taylor.jpg", 60.00m, new Guid("9f6e1d2b-1377-4390-8eae-7be47c38d18e"), null, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ee604982-8476-4c1b-8461-ae0c163c36b4"), "Black", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nike_air_max.jpg", 120.00m, new Guid("a9cc9831-2b17-4591-854e-8bc49163c256"), null, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f85c8134-b20f-4f3f-aeab-858bd08fd4e3"), "Gray", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "danner_mountain.jpg", 280.00m, new Guid("2bef756f-02bb-45d7-84e6-078e0df290c3"), null, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ffb83faa-e3b2-4deb-919c-934d9ad13f07"), "Red", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "puma_soccer_cleats.jpg", 100.00m, new Guid("7ba5ffa5-b3ed-4ae9-bf49-67fdb8572c03"), null, 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "SalesItems",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Discount", "ItemId", "Quantity", "RootId", "SalesOrderId", "SalesTaxRate", "Taxable", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("2cf8418a-e54a-4632-8441-feba803d7b53"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0.10m, new Guid("ffb83faa-e3b2-4deb-919c-934d9ad13f07"), 2, null, new Guid("f97f9051-f8e5-4b0b-8e44-6d6a03c1728b"), 0.07m, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("31697bc0-7d56-476c-b4e6-70010354fb70"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0.05m, new Guid("40418715-f4f0-4d73-a136-86304eea3dd8"), 1, null, new Guid("7c85eff2-7c76-4c6d-baea-dee41885dc19"), 0.07m, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("690d55a4-e4b4-424e-ba2f-9e38dd1bcfeb"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0.15m, new Guid("ffb83faa-e3b2-4deb-919c-934d9ad13f07"), 3, null, new Guid("f97f9051-f8e5-4b0b-8e44-6d6a03c1728b"), 0.00m, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ae9470d4-eaad-40b8-859f-e43c73309169"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0.10m, new Guid("ee604982-8476-4c1b-8461-ae0c163c36b4"), 2, null, new Guid("1ee66148-e4ce-4dcb-ac43-965d34ff6318"), 0.07m, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e9b0a210-40a9-42a7-b214-5edc165a70ea"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0.20m, new Guid("dff1534e-6bc4-471c-97f2-3b2d66437079"), 4, null, new Guid("5e678e3b-fddb-47fb-a6a3-6194be83277a"), 0.07m, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
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

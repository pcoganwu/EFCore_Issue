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
                    { new Guid("005d6e01-18a0-3360-36bc-2a94472c4b0c"), new DateOnly(1990, 7, 7), "Oldtown", "Company G", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "emma.taylor@example.com", "Emma", "Taylor", "555-6789", null, "F", "NY", "404 Cedar St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 67890 },
                    { new Guid("0079c294-b859-4935-35a8-0c5f00334d63"), new DateOnly(1987, 6, 18), "Smalltown", "Company R", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "paul.young@example.com", "Paul", "Young", "555-0125", null, "M", "TX", "1515 Chestnut St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 11225 },
                    { new Guid("06c9a8a5-71ef-779a-a34b-b62574b5cc58"), new DateOnly(2004, 6, 30), "Middletown", "Company DD", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "brian.phillips@example.com", "Brian", "Phillips", "555-8903", null, "M", "IL", "2727 Birch St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 77893 },
                    { new Guid("0e438039-45a2-6b29-e6ed-4ec4fc6bc87b"), new DateOnly(1976, 2, 14), "Anycity", "Company N", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "leo.clark@example.com", "Leo", "Clark", "555-3457", null, "M", "FL", "1111 Birch St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 44557 },
                    { new Guid("109b27c9-107a-9284-93a2-d851fe2db21c"), new DateOnly(2002, 8, 20), "Middletown", "Company T", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "ryan.scott@example.com", "Ryan", "Scott", "555-8902", null, "M", "IL", "1717 Oak St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 77891 },
                    { new Guid("11e3e16e-3be1-c27b-21ce-d051fc580215"), new DateOnly(1990, 2, 2), "Othertown", "Company B", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "jane.smith@example.com", "Jane", "Smith", "555-5678", null, "F", "NY", "456 Elm St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 67890 },
                    { new Guid("1398c92d-b203-c189-d517-7ef0324b513a"), new DateOnly(2000, 5, 5), "Othercity", "Company E", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "charlie.davis@example.com", "Charlie", "Davis", "555-7890", null, "M", "IL", "202 Maple St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 77889 },
                    { new Guid("21728ff2-4758-e644-b938-93f4e3f0e20f"), new DateOnly(1977, 7, 19), "Bigcity", "Company S", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "quinn.king@example.com", "Quinn", "King", "555-4568", null, "F", "FL", "1616 Maple St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 44558 },
                    { new Guid("2a3320f2-1220-d70c-71e9-c4b634fe7057"), new DateOnly(1982, 4, 16), "Newtown", "Company P", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "noah.walker@example.com", "Noah", "Walker", "555-2347", null, "M", "CA", "1313 Spruce St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 12346 },
                    { new Guid("302fab80-4112-bef2-6af1-eeceb19c9d12"), new DateOnly(2001, 3, 15), "Othercity", "Company O", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "mia.lewis@example.com", "Mia", "Lewis", "555-7891", null, "F", "IL", "1212 Cedar St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 77890 },
                    { new Guid("4d1bb398-57b4-3bdd-7972-ea11858fa895"), new DateOnly(1985, 8, 8), "Smalltown", "Company H", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "frank.anderson@example.com", "Frank", "Anderson", "555-0123", null, "M", "TX", "505 Spruce St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 11223 },
                    { new Guid("4d62d555-fab2-c918-a87b-2417c26a4700"), new DateOnly(1985, 3, 3), "Sometown", "Company C", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "alice.johnson@example.com", "Alice", "Johnson", "555-9012", null, "", "TX", "789 Oak St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 11223 },
                    { new Guid("4ead9930-32cc-aa72-c53f-b1307695ceaf"), new DateOnly(1993, 10, 22), "Otherville", "Company V", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "thomas.baker@example.com", "Thomas", "Baker", "555-6783", null, "M", "NY", "1919 Birch St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 67893 },
                    { new Guid("5066b859-a9ae-3268-3c47-f637b48de1f9"), new DateOnly(1979, 5, 29), "Bigcity", "Company CC", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "amy.turner@example.com", "Amy", "Turner", "555-4569", null, "F", "FL", "2626 Pine St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 44560 },
                    { new Guid("5684c9b3-7bf0-e2f6-4f7e-f444168cde76"), new DateOnly(2003, 1, 25), "Othercity", "Company Y", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "wendy.carter@example.com", "Wendy", "Carter", "555-7893", null, "F", "IL", "2222 Walnut St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 77892 },
                    { new Guid("576e15e6-9645-fe95-84ef-cd7066816fb4"), new DateOnly(1980, 6, 6), "Newtown", "Company F", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "daniel.evans@example.com", "Daniel", "Evans", "555-2345", null, "M", "CA", "303 Birch St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 12345 },
                    { new Guid("6421b880-3699-d244-4f23-dfe791b9cae7"), new DateOnly(1990, 9, 2), "Sometown", "Company GG", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "ella.evans@example.com", "Ella", "Evans", "555-0128", null, "F", "TX", "3030 Walnut St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 11228 },
                    { new Guid("65e65eac-4903-b788-2b4b-a15b639cefd8"), new DateOnly(1981, 11, 11), "Anyville", "Company K", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "ivy.white@example.com", "Ivy", "White", "555-2346", null, "F", "CA", "808 Maple St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 12345 },
                    { new Guid("6875c4a1-7668-bc3e-7fa3-f711cd6c5962"), new DateOnly(1980, 1, 1), "Anytown", "Company A", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "john.doe@example.com", "John", "Doe", "555-1234", null, "M", "CA", "123 Main St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 12345 },
                    { new Guid("6c7035a6-d5b1-9731-ab08-79e604055c63"), new DateOnly(1994, 3, 27), "Oldtown", "Company AA", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "yara.perez@example.com", "Yara", "Perez", "555-6784", null, "F", "NY", "2424 Maple St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 67894 },
                    { new Guid("71a81584-08de-66f5-65a8-52fa67f4fab6"), new DateOnly(1988, 11, 23), "Sometown", "Company W", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "uma.adams@example.com", "Uma", "Adams", "555-0126", null, "F", "TX", "2020 Cedar St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 11226 },
                    { new Guid("74c965f4-d428-7258-ed70-5bdf08bdad76"), new DateOnly(1995, 8, 1), "Otherville", "Company FF", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "david.parker@example.com", "David", "Parker", "555-6785", null, "M", "NY", "2929 Spruce St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 67895 },
                    { new Guid("81fb0083-e5ee-ccbb-ab07-579dab9d0ffc"), new DateOnly(1985, 7, 31), "Anyville", "Company EE", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "chloe.campbell@example.com", "Chloe", "Campbell", "555-2350", null, "F", "CA", "2828 Cedar St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 12349 },
                    { new Guid("8d005410-229c-8fe3-1caf-fbeb8c156eaa"), new DateOnly(1991, 12, 12), "Otherville", "Company L", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "jack.harris@example.com", "Jack", "Harris", "555-6780", null, "M", "NY", "909 Oak St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 67891 },
                    { new Guid("9212c492-f508-aa2f-5585-92a24d5a295d"), new DateOnly(1986, 1, 13), "Sometown", "Company M", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "karen.martin@example.com", "Karen", "Martin", "555-0124", null, "F", "TX", "1010 Pine St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 11224 },
                    { new Guid("95c21c78-e3ae-c1b6-4300-b8f7b111da9d"), new DateOnly(1975, 9, 9), "Bigcity", "Company I", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "grace.thomas@example.com", "Grace", "Thomas", "555-4567", null, "F", "FL", "606 Walnut St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 44556 },
                    { new Guid("b9cc87a4-18b7-9f51-d742-f988fe64bcb1"), new DateOnly(1989, 4, 28), "Smalltown", "Company BB", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "zane.roberts@example.com", "Zane", "Roberts", "555-0127", null, "M", "TX", "2525 Oak St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 11227 },
                    { new Guid("bfd26780-499e-a591-8f34-a4363a8f96a9"), new DateOnly(1975, 4, 4), "Anycity", "Company D", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "bob.brown@example.com", "Bob", "Brown", "555-3456", null, "M", "FL", "101 Pine St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 44556 },
                    { new Guid("c0c38089-531f-952e-373c-6bc22a5005ef"), new DateOnly(1978, 12, 24), "Anycity", "Company X", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "victor.nelson@example.com", "Victor", "Nelson", "555-3459", null, "M", "FL", "2121 Spruce St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 44559 },
                    { new Guid("c94a5687-cf7a-829a-d83b-73c18c8e163a"), new DateOnly(2000, 10, 10), "Middletown", "Company J", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "henry.jackson@example.com", "Henry", "Jackson", "555-8901", null, "M", "IL", "707 Chestnut St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 77889 },
                    { new Guid("d12fd11c-a9d6-a205-2d1b-98cb710402e4"), new DateOnly(1984, 2, 26), "Newtown", "Company Z", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "xander.mitchell@example.com", "Xander", "Mitchell", "555-2349", null, "M", "CA", "2323 Chestnut St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 12348 },
                    { new Guid("e5c85334-a0c2-b8f6-17bf-b5c993a01245"), new DateOnly(1992, 5, 17), "Oldtown", "Company Q", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "olivia.hall@example.com", "Olivia", "Hall", "555-6782", null, "F", "NY", "1414 Walnut St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 67892 },
                    { new Guid("fe1ffa4f-6cb7-b9c4-acf1-82dae3f45719"), new DateOnly(1983, 9, 21), "Anyville", "Company U", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "sophia.green@example.com", "Sophia", "Green", "555-2348", null, "F", "CA", "1818 Pine St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 12347 }
                });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Name", "RootId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("9627db3a-1cb3-bb94-a9f1-c8a178c7198d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Formal", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a4e61ac2-216b-f970-1e1f-72b77372aefe"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Running", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d496fa08-6e15-bcf2-5729-83b84631a083"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Boots", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d56250d0-cf45-01ef-c894-f16b51cf64b2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sports", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f1605d4e-42d2-0770-c464-4b790ad05852"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Casual", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "SalesPersons",
                columns: new[] { "Id", "BirthOfDate", "City", "CreatedAt", "DateHired", "DeletedAt", "Email", "FirstName", "LastName", "Phone", "RootId", "Sex", "State", "Street", "UpdatedAt", "ZipCode" },
                values: new object[,]
                {
                    { new Guid("07e792e5-664b-4098-df0f-382a547d13c4"), new DateOnly(1990, 7, 7), "Oldtown", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "emma.taylor@example.com", "Emma", "Taylor", "555-6789", null, "M", "NY", "404 Cedar St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 67890 },
                    { new Guid("5758d99e-2ddd-d22a-bae2-58bca85eea16"), new DateOnly(1980, 6, 6), "Newtown", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "david.wilson@example.com", "David", "Wilson", "555-2345", null, "M", "CA", "303 Birch St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 12345 },
                    { new Guid("7340aa82-0ec8-5f37-a95d-313d150baf49"), new DateOnly(1975, 9, 9), "Bigcity", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "grace.thomas@example.com", "Grace", "Thomas", "555-4567", null, "F", "FL", "606 Walnut St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 44556 },
                    { new Guid("940f8dc8-de5f-d316-c58c-dffe7f24cf73"), new DateOnly(1985, 8, 8), "Smalltown", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "frank.anderson@example.com", "Frank", "Anderson", "555-0123", null, "M", "TX", "505 Spruce St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 11223 },
                    { new Guid("ecdf557d-4cc2-cd87-5f3b-c5078532cc92"), new DateOnly(2000, 10, 10), "Middletown", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "henry.jackson@example.com", "Henry", "Jackson", "555-8901", null, "M", "IL", "707 Chestnut St", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), 77889 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Description", "Name", "RootId", "Supplier", "TypeId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0093d67a-66aa-f6bc-c2b1-ba61e3dd54bd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Timeless casual shoes", "Reebok Classic", null, "Reebok", new Guid("f1605d4e-42d2-0770-c464-4b790ad05852"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1120b244-d042-6cfb-b59d-5543abedc94f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Technical trail running shoes", "La Sportiva Bushido", null, "La Sportiva", new Guid("a4e61ac2-216b-f970-1e1f-72b77372aefe"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("235cf756-b2f2-1405-6fb2-271805e43552"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Classic skate shoes", "Vans Old Skool", null, "Vans", new Guid("f1605d4e-42d2-0770-c464-4b790ad05852"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("259667d1-5408-b3fa-8395-c09c7c78902e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sturdy hiking boots", "Lowa Renegade", null, "Lowa", new Guid("d496fa08-6e15-bcf2-5729-83b84631a083"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2e568493-9d71-c288-dd7a-49532eb42353"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Approach shoes", "Scarpa Mojito", null, "Scarpa", new Guid("f1605d4e-42d2-0770-c464-4b790ad05852"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2edd5b84-377b-2cd7-e681-0482139c3d62"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Classic boots", "Dr. Martens 1460", null, "Dr. Martens", new Guid("d496fa08-6e15-bcf2-5729-83b84631a083"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3079793c-af6d-8e1a-f9d5-d6db4bef52f4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Trail running shoes", "Arc'teryx Norvan", null, "Arc'teryx", new Guid("a4e61ac2-216b-f970-1e1f-72b77372aefe"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("34dd818f-77ec-6953-1dfb-a9df69fae86f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Basketball shoes", "Under Armour Curry", null, "Under Armour", new Guid("d56250d0-cf45-01ef-c894-f16b51cf64b2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("34ee2b5c-112c-67e8-634e-1f36ca5bdbfc"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Waterproof hiking boots", "Oboz Bridger", null, "Oboz", new Guid("d496fa08-6e15-bcf2-5729-83b84631a083"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3e830fe0-36d6-41e8-3fc5-cc2388319e7a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Neutral running shoes", "Brooks Ghost", null, "Brooks", new Guid("a4e61ac2-216b-f970-1e1f-72b77372aefe"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("48d3aeed-f71c-9133-5077-9d166e47b171"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Hiking boots", "Merrell Moab", null, "Merrell", new Guid("d496fa08-6e15-bcf2-5729-83b84631a083"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4a2010e7-25d5-5f0e-7b79-30eae97bb30c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Comfortable running shoes", "Nike Air Max", null, "Nike", new Guid("a4e61ac2-216b-f970-1e1f-72b77372aefe"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("52b9d002-0dd5-f216-06f4-aea901755001"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Elegant formal shoes", "Clarks Oxford", null, "Clarks", new Guid("9627db3a-1cb3-bb94-a9f1-c8a178c7198d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5ab05728-75e8-fccf-cd8d-b06ca4527493"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "All-terrain hiking boots", "Keen Targhee", null, "Keen", new Guid("d496fa08-6e15-bcf2-5729-83b84631a083"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7163d1c2-b1a9-e66a-d71a-fd236cdc9fd3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Stability running shoes", "Asics Gel-Kayano", null, "Asics", new Guid("a4e61ac2-216b-f970-1e1f-72b77372aefe"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7ea840a5-58d8-85c4-70fb-78e31286fb69"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Classic casual shoes", "Adidas Superstar", null, "Adidas", new Guid("f1605d4e-42d2-0770-c464-4b790ad05852"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("81856369-e2cf-76f5-ec7a-38afe7948309"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Heritage hiking boots", "Danner Mountain", null, "Danner", new Guid("d496fa08-6e15-bcf2-5729-83b84631a083"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("83e9fe64-d98d-bf4f-09a4-afee10eb9944"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Trail running shoes", "The North Face Ultra", null, "The North Face", new Guid("a4e61ac2-216b-f970-1e1f-72b77372aefe"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("86db3be3-d641-8b59-78ac-a700e590f414"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Iconic casual shoes", "Converse Chuck Taylor", null, "Converse", new Guid("f1605d4e-42d2-0770-c464-4b790ad05852"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a1a2ba33-b704-08ab-fba8-5e29ce6f008c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Cushioned running shoes", "Mizuno Wave Rider", null, "Mizuno", new Guid("a4e61ac2-216b-f970-1e1f-72b77372aefe"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a5141648-1260-5664-96c7-f878112baac5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "High-performance soccer cleats", "Puma Soccer Cleats", null, "Puma", new Guid("d56250d0-cf45-01ef-c894-f16b51cf64b2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("aebbda26-90e8-d5d3-95cf-a95525e38fb0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lightweight running shoes", "Saucony Kinvara", null, "Saucony", new Guid("a4e61ac2-216b-f970-1e1f-72b77372aefe"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b40245e4-085a-39e6-ac26-3a855e475f0f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Premium running shoes", "New Balance 990", null, "New Balance", new Guid("a4e61ac2-216b-f970-1e1f-72b77372aefe"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c4e228db-291f-ad06-636c-5bc1f6109d0c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Versatile trail running shoes", "Inov-8 Roclite", null, "Inov-8", new Guid("a4e61ac2-216b-f970-1e1f-72b77372aefe"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c99e80f5-c2cf-53ab-9928-651606009d92"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Trail running shoes", "Salomon Speedcross", null, "Salomon", new Guid("a4e61ac2-216b-f970-1e1f-72b77372aefe"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cbf2dee0-45d3-e682-511a-ef2b9947cc81"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Durable outdoor boots", "Timberland Boots", null, "Timberland", new Guid("d496fa08-6e15-bcf2-5729-83b84631a083"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cccd4fa8-c51b-9d89-3a3d-107648b8d21d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Eco-friendly hiking shoes", "Patagonia Drifter", null, "Patagonia", new Guid("d496fa08-6e15-bcf2-5729-83b84631a083"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d2593ee6-d6d2-188a-f8ef-6977b2647a57"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Maximalist running shoes", "Hoka One One Clifton", null, "Hoka One One", new Guid("a4e61ac2-216b-f970-1e1f-72b77372aefe"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("dbbe2061-29c5-7299-2686-575121021590"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Waterproof hiking boots", "Columbia Newton Ridge", null, "Columbia", new Guid("d496fa08-6e15-bcf2-5729-83b84631a083"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fc6206c5-b87e-d216-1c12-8b8e9ab06bb1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Zero-drop trail running shoes", "Altra Lone Peak", null, "Altra", new Guid("a4e61ac2-216b-f970-1e1f-72b77372aefe"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "SalesOrders",
                columns: new[] { "Id", "CreatedAt", "CreditCardExpireDay", "CreditCardExpireMonth", "CreditCardExpireSecretCode", "CreditCardNumber", "CustId", "DeletedAt", "NameOnCard", "PurchaseOrderNumber", "RootId", "SalesPersonId", "TimeOrderTaken", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("1be75f9b-bc26-d99f-68b9-e7aef05d2b29"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)31, (short)12, (short)123, "1234567812345678", new Guid("6875c4a1-7668-bc3e-7fa3-f711cd6c5962"), null, "John Doe", 1001, null, new Guid("5758d99e-2ddd-d22a-bae2-58bca85eea16"), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8a4fd003-8672-5f65-d288-9f008718ba90"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)28, (short)9, (short)456, "4567890145678901", new Guid("bfd26780-499e-a591-8f34-a4363a8f96a9"), null, "Bob Brown", 1004, null, new Guid("7340aa82-0ec8-5f37-a95d-313d150baf49"), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("93d2e010-f843-c1ab-9e78-31b026b4ca3a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)29, (short)10, (short)345, "3456789034567890", new Guid("4d62d555-fab2-c918-a87b-2417c26a4700"), null, "Alice Johnson", 1003, null, new Guid("940f8dc8-de5f-d316-c58c-dffe7f24cf73"), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("dfb15180-1d22-5ebb-d6a5-4f81431972d3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)30, (short)11, (short)234, "2345678923456789", new Guid("11e3e16e-3be1-c27b-21ce-d051fc580215"), null, "Jane Smith", 1002, null, new Guid("07e792e5-664b-4098-df0f-382a547d13c4"), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f810c4f9-172a-5ac8-70a5-5f6572b5056c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)27, (short)8, (short)567, "5678901256789012", new Guid("1398c92d-b203-c189-d517-7ef0324b513a"), null, "Charlie Davis", 1005, null, new Guid("ecdf557d-4cc2-cd87-5f3b-c5078532cc92"), new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Color", "CreatedAt", "DeletedAt", "Picture", "Price", "ProductId", "RootId", "Size", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("02afc0d7-78d9-b37d-a1c9-a664d5e82571"), "Black", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "columbia_newton_ridge.jpg", 170.00m, new Guid("dbbe2061-29c5-7299-2686-575121021590"), null, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0ea64811-e4ec-900e-e481-78eb6a7c0f73"), "Green", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "scarpa_mojito.jpg", 200.00m, new Guid("2e568493-9d71-c288-dd7a-49532eb42353"), null, 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("15fc68ec-0cde-d216-4bac-a5134567aaeb"), "Black", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "hoka_one_one_clifton.jpg", 140.00m, new Guid("d2593ee6-d6d2-188a-f8ef-6977b2647a57"), null, 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("20e38c5c-697e-e9b8-454d-49de0d402ad7"), "Black", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "patagonia_drifter.jpg", 250.00m, new Guid("cccd4fa8-c51b-9d89-3a3d-107648b8d21d"), null, 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2897eac8-ce11-1d63-2a4f-c3bc40d84c11"), "Red", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "inov8_roclite.jpg", 230.00m, new Guid("c4e228db-291f-ad06-636c-5bc1f6109d0c"), null, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2b842edd-34f3-4aca-8304-37593311e106"), "Black", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "altra_lone_peak.jpg", 220.00m, new Guid("fc6206c5-b87e-d216-1c12-8b8e9ab06bb1"), null, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3f7e8a0a-718e-86ac-b31d-6cd09650be3d"), "Brown", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "the_north_face_ultra.jpg", 240.00m, new Guid("83e9fe64-d98d-bf4f-09a4-afee10eb9944"), null, 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("49d3ee66-be17-fde4-2915-2a45c0ec1ae3"), "Brown", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "merrell_moab.jpg", 160.00m, new Guid("48d3aeed-f71c-9133-5077-9d166e47b171"), null, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4e60f021-7093-34bf-67f0-93a7954fe3dc"), "Gray", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "arcteryx_norvan.jpg", 210.00m, new Guid("3079793c-af6d-8e1a-f9d5-d6db4bef52f4"), null, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5110abf1-3da6-de61-e49e-54e924855d5c"), "Gray", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "new_balance_990.jpg", 160.00m, new Guid("b40245e4-085a-39e6-ac26-3a855e475f0f"), null, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5e473cd8-2804-e263-6763-e8f804b98af8"), "Brown", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "clarks_oxford.jpg", 150.00m, new Guid("52b9d002-0dd5-f216-06f4-aea901755001"), null, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("63d7437e-2893-c36e-dce8-f6ad857e550a"), "White", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "adidas_superstar.jpg", 80.00m, new Guid("7ea840a5-58d8-85c4-70fb-78e31286fb69"), null, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("670fa168-297b-248b-d3fd-e7bb33fc2441"), "Black", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nike_air_max.jpg", 120.00m, new Guid("4a2010e7-25d5-5f0e-7b79-30eae97bb30c"), null, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("684eb9bb-d823-35c5-27a3-c71df5cac876"), "Tan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "keen_targhee.jpg", 180.00m, new Guid("5ab05728-75e8-fccf-cd8d-b06ca4527493"), null, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6a673ed2-e049-1f63-dc09-e8e97ed5b748"), "Blue", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "mizuno_wave_rider.jpg", 120.00m, new Guid("a1a2ba33-b704-08ab-fba8-5e29ce6f008c"), null, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7bd784a3-cd37-4859-75f6-a6959d88c776"), "Gray", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "danner_mountain.jpg", 280.00m, new Guid("81856369-e2cf-76f5-ec7a-38afe7948309"), null, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7cff0680-1d4b-d8d3-5954-0697fe010202"), "Tan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "timberland_boots.jpg", 200.00m, new Guid("cbf2dee0-45d3-e682-511a-ef2b9947cc81"), null, 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("906c2769-3edf-0e84-7644-475199f4a5fe"), "Blue", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "la_sportiva_bushido.jpg", 190.00m, new Guid("1120b244-d042-6cfb-b59d-5543abedc94f"), null, 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a18c7509-4a13-2e15-0f73-dfbaf261325f"), "Red", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "salomon_speedcross.jpg", 150.00m, new Guid("c99e80f5-c2cf-53ab-9928-651606009d92"), null, 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ab0ed41a-af6d-8181-112c-23c4d10c19e9"), "Gray", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "brooks_ghost.jpg", 130.00m, new Guid("3e830fe0-36d6-41e8-3fc5-cc2388319e7a"), null, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ad68bd8c-6748-ad8c-22a5-37af807ae23b"), "Green", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "oboz_bridger.jpg", 270.00m, new Guid("34ee2b5c-112c-67e8-634e-1f36ca5bdbfc"), null, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bb5eeaad-9eb1-7aaa-c6cb-61f07f7611fc"), "Brown", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "dr_martens_1460.jpg", 140.00m, new Guid("2edd5b84-377b-2cd7-e681-0482139c3d62"), null, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("beab39f3-158e-e429-3aed-6d434c10b71b"), "Red", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "puma_soccer_cleats.jpg", 100.00m, new Guid("a5141648-1260-5664-96c7-f878112baac5"), null, 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c15296ab-2be9-bcc8-a872-90c3e488f1c2"), "Green", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "asics_gel_kayano.jpg", 130.00m, new Guid("7163d1c2-b1a9-e66a-d71a-fd236cdc9fd3"), null, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c4e86df1-4c83-01db-b271-829d693ee04c"), "Black", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "vans_old_skool.jpg", 70.00m, new Guid("235cf756-b2f2-1405-6fb2-271805e43552"), null, 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c75c6b0f-3e2b-87ed-88bf-df79d8bd1bff"), "Blue", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "reebok_classic.jpg", 90.00m, new Guid("0093d67a-66aa-f6bc-c2b1-ba61e3dd54bd"), null, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ca3e4208-7723-31af-135f-e4e5f077964a"), "White", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "converse_chuck_taylor.jpg", 60.00m, new Guid("86db3be3-d641-8b59-78ac-a700e590f414"), null, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d1a23498-e2f8-6949-b644-7bd399aa3ae5"), "Black", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "under_armour_curry.jpg", 110.00m, new Guid("34dd818f-77ec-6953-1dfb-a9df69fae86f"), null, 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f18117ec-d1c9-c28b-e60d-65070305e030"), "Blue", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "lowa_renegade.jpg", 260.00m, new Guid("259667d1-5408-b3fa-8395-c09c7c78902e"), null, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fb64d4ee-3971-a8cd-df3f-0b66cc1132b2"), "Green", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "saucony_kinvara.jpg", 100.00m, new Guid("aebbda26-90e8-d5d3-95cf-a95525e38fb0"), null, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "SalesItems",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Discount", "ItemId", "Quantity", "RootId", "SalesOrderId", "SalesTaxRate", "Taxable", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("17314d75-064e-71f3-23ab-1cf7af54f047"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0.15m, new Guid("beab39f3-158e-e429-3aed-6d434c10b71b"), 3, null, new Guid("f810c4f9-172a-5ac8-70a5-5f6572b5056c"), 0.00m, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5dd6cca7-f3ba-f664-df7e-83c3193d3a0f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0.20m, new Guid("5e473cd8-2804-e263-6763-e8f804b98af8"), 4, null, new Guid("8a4fd003-8672-5f65-d288-9f008718ba90"), 0.07m, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("91903feb-a365-1b66-e8c5-7748450fe2cb"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0.10m, new Guid("670fa168-297b-248b-d3fd-e7bb33fc2441"), 2, null, new Guid("dfb15180-1d22-5ebb-d6a5-4f81431972d3"), 0.07m, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e92c4885-5f78-413f-80ec-79e1d92033f7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0.05m, new Guid("63d7437e-2893-c36e-dce8-f6ad857e550a"), 1, null, new Guid("93d2e010-f843-c1ab-9e78-31b026b4ca3a"), 0.07m, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e9a8bb0b-3e5a-cb5a-ed10-ae5070b7813d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0.10m, new Guid("beab39f3-158e-e429-3aed-6d434c10b71b"), 2, null, new Guid("f810c4f9-172a-5ac8-70a5-5f6572b5056c"), 0.07m, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
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

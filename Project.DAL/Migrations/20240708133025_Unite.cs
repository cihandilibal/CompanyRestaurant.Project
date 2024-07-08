using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Unite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobilePhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobilePhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OffNumber = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "money", nullable: false),
                    PredictedAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableNo = table.Column<int>(type: "int", nullable: false),
                    OrderTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableNo = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: true),
                    UnitPrice = table.Column<decimal>(type: "money", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Payments_Orders_ID",
                        column: x => x.ID,
                        principalTable: "Orders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeDetails",
                columns: table => new
                {
                    RecipeID = table.Column<int>(type: "int", nullable: false),
                    IngredientID = table.Column<int>(type: "int", nullable: false),
                    Instruction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IngredientQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeDetails", x => new { x.IngredientID, x.RecipeID });
                    table.ForeignKey(
                        name: "FK_RecipeDetails_Ingredients_IngredientID",
                        column: x => x.IngredientID,
                        principalTable: "Ingredients",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeDetails_Recipes_RecipeID",
                        column: x => x.RecipeID,
                        principalTable: "Recipes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "money", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => new { x.OrderID, x.ProductID });
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 1, "d6a3cc96-e943-455e-b756-209fffe2239b", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedDate", "DeletedDate", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "ModifiedDate", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, "2c3839d9-4c9f-45c0-980a-6d1d11db0234", new DateTime(2024, 7, 8, 16, 30, 23, 981, DateTimeKind.Local).AddTicks(6735), null, "dilibalcihan@gmail.com", true, false, null, null, "DILIBALCIHAN@GMAIL.COM", "CIHAN", "AQAAAAIAAYagAAAAEMVvsRgKp11h27k4SbbIV2AJnxgmUVSwukR7ZAX+n1LTAgIS6+LPV94sXA3cJ7QRbQ==", null, false, "59d23f99-fe90-43f7-90e0-84dacedbfe2e", 1, false, "cihan" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "CategoryName", "CreatedDate", "DeletedDate", "Description", "ModifiedDate", "Status" },
                values: new object[,]
                {
                    { 1, "Books", new DateTime(2024, 7, 8, 16, 30, 23, 981, DateTimeKind.Local).AddTicks(2317), null, "Veritatis adipisci accusantium in voluptatem totam quia quam suscipit sit.", null, 1 },
                    { 2, "Outdoors", new DateTime(2024, 7, 8, 16, 30, 23, 981, DateTimeKind.Local).AddTicks(2923), null, "Consequuntur adanaya patlıcan sokaklarda ışık vel in quaerat ipsam voluptatem.", null, 1 },
                    { 3, "Books", new DateTime(2024, 7, 8, 16, 30, 23, 981, DateTimeKind.Local).AddTicks(3082), null, "Blanditiis consequuntur ipsum oldular sed okuma sit ama mıknatıslı şafak.", null, 1 },
                    { 4, "Music", new DateTime(2024, 7, 8, 16, 30, 23, 981, DateTimeKind.Local).AddTicks(3231), null, "Ve layıkıyla minima layıkıyla nemo makinesi magni enim okuma gördüm.", null, 1 },
                    { 5, "Games", new DateTime(2024, 7, 8, 16, 30, 23, 981, DateTimeKind.Local).AddTicks(3381), null, "Qui sayfası laudantium blanditiis quaerat koyun ki quis non dolore.", null, 1 },
                    { 6, "Shoes", new DateTime(2024, 7, 8, 16, 30, 23, 981, DateTimeKind.Local).AddTicks(3579), null, "Quia consequatur sit et ki amet modi quia enim bilgiyasayarı.", null, 1 },
                    { 7, "Books", new DateTime(2024, 7, 8, 16, 30, 23, 981, DateTimeKind.Local).AddTicks(3735), null, "Beğendim sıla modi oldular öyle camisi aut totam kapının consequatur.", null, 1 },
                    { 8, "Books", new DateTime(2024, 7, 8, 16, 30, 23, 981, DateTimeKind.Local).AddTicks(3879), null, "Qui explicabo aperiam beğendim corporis qui eum vitae tv cesurca.", null, 1 },
                    { 9, "Clothing", new DateTime(2024, 7, 8, 16, 30, 23, 981, DateTimeKind.Local).AddTicks(4029), null, "Telefonu masanın ea ea qui veritatis duyulmamış düşünüyor gül voluptatem.", null, 1 },
                    { 10, "Games", new DateTime(2024, 7, 8, 16, 30, 23, 981, DateTimeKind.Local).AddTicks(4298), null, "Aspernatur ducimus exercitationem esse voluptate yapacakmış gül adipisci laudantium sit.", null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "ID", "Address", "CreatedDate", "DeletedDate", "Duty", "FirstName", "LastName", "MobilePhone", "ModifiedDate", "OffNumber", "Status" },
                values: new object[,]
                {
                    { 1, "Uskudar", new DateTime(2024, 7, 8, 16, 30, 24, 90, DateTimeKind.Local).AddTicks(3621), null, "Garson", "Batuhan", "Dilibal", "0435 769 56 93", null, 3, 1 },
                    { 2, "Uskudar", new DateTime(2024, 7, 8, 16, 30, 24, 90, DateTimeKind.Local).AddTicks(3647), null, "Garson", "Batuhan", "Dilibal", "0435 769 56 93", null, 3, 1 },
                    { 3, "Uskudar", new DateTime(2024, 7, 8, 16, 30, 24, 90, DateTimeKind.Local).AddTicks(3649), null, "Garson", "Batuhan", "Dilibal", "0435 769 56 93", null, 3, 1 },
                    { 4, "Uskudar", new DateTime(2024, 7, 8, 16, 30, 24, 90, DateTimeKind.Local).AddTicks(3650), null, "Garson", "Batuhan", "Dilibal", "0435 769 56 93", null, 3, 1 },
                    { 5, "Uskudar", new DateTime(2024, 7, 8, 16, 30, 24, 90, DateTimeKind.Local).AddTicks(3651), null, "Garson", "Batuhan", "Dilibal", "0435 769 56 93", null, 3, 1 },
                    { 6, "Uskudar", new DateTime(2024, 7, 8, 16, 30, 24, 90, DateTimeKind.Local).AddTicks(3662), null, "Garson", "Batuhan", "Dilibal", "0435 769 56 93", null, 3, 1 },
                    { 7, "Uskudar", new DateTime(2024, 7, 8, 16, 30, 24, 90, DateTimeKind.Local).AddTicks(3757), null, "Garson", "Batuhan", "Dilibal", "0435 769 56 93", null, 3, 1 },
                    { 8, "Uskudar", new DateTime(2024, 7, 8, 16, 30, 24, 90, DateTimeKind.Local).AddTicks(3758), null, "Garson", "Batuhan", "Dilibal", "0435 769 56 93", null, 3, 1 },
                    { 9, "Uskudar", new DateTime(2024, 7, 8, 16, 30, 24, 90, DateTimeKind.Local).AddTicks(3760), null, "Garson", "Batuhan", "Dilibal", "0435 769 56 93", null, 3, 1 },
                    { 10, "Uskudar", new DateTime(2024, 7, 8, 16, 30, 24, 90, DateTimeKind.Local).AddTicks(3763), null, "Garson", "Batuhan", "Dilibal", "0435 769 56 93", null, 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "ID", "Amount", "CreatedDate", "DeletedDate", "ModifiedDate", "Name", "PredictedAmount", "Status", "Unit", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 10m, new DateTime(2024, 7, 8, 16, 30, 23, 981, DateTimeKind.Local).AddTicks(6043), null, null, "Patates", 9m, 1, "kg", 15m },
                    { 2, 10m, new DateTime(2024, 7, 8, 16, 30, 23, 981, DateTimeKind.Local).AddTicks(6053), null, null, "Patates", 9m, 1, "kg", 15m },
                    { 3, 10m, new DateTime(2024, 7, 8, 16, 30, 23, 981, DateTimeKind.Local).AddTicks(6055), null, null, "Patates", 9m, 1, "kg", 15m },
                    { 4, 10m, new DateTime(2024, 7, 8, 16, 30, 23, 981, DateTimeKind.Local).AddTicks(6125), null, null, "Patates", 9m, 1, "kg", 15m },
                    { 5, 10m, new DateTime(2024, 7, 8, 16, 30, 23, 981, DateTimeKind.Local).AddTicks(6128), null, null, "Patates", 9m, 1, "kg", 15m },
                    { 6, 10m, new DateTime(2024, 7, 8, 16, 30, 23, 981, DateTimeKind.Local).AddTicks(6132), null, null, "Patates", 9m, 1, "kg", 15m },
                    { 7, 10m, new DateTime(2024, 7, 8, 16, 30, 23, 981, DateTimeKind.Local).AddTicks(6134), null, null, "Patates", 9m, 1, "kg", 15m },
                    { 8, 10m, new DateTime(2024, 7, 8, 16, 30, 23, 981, DateTimeKind.Local).AddTicks(6136), null, null, "Patates", 9m, 1, "kg", 15m },
                    { 9, 10m, new DateTime(2024, 7, 8, 16, 30, 23, 981, DateTimeKind.Local).AddTicks(6138), null, null, "Patates", 9m, 1, "kg", 15m },
                    { 10, 10m, new DateTime(2024, 7, 8, 16, 30, 23, 981, DateTimeKind.Local).AddTicks(6141), null, null, "Patates", 9m, 1, "kg", 15m }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "ID", "CreatedDate", "DeletedDate", "ModifiedDate", "Name", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 8, 16, 30, 23, 981, DateTimeKind.Local).AddTicks(6211), null, null, "Filtre Kahve", 1 },
                    { 2, new DateTime(2024, 7, 8, 16, 30, 23, 981, DateTimeKind.Local).AddTicks(6215), null, null, "Filtre Kahve", 1 },
                    { 3, new DateTime(2024, 7, 8, 16, 30, 23, 981, DateTimeKind.Local).AddTicks(6216), null, null, "Filtre Kahve", 1 },
                    { 4, new DateTime(2024, 7, 8, 16, 30, 23, 981, DateTimeKind.Local).AddTicks(6218), null, null, "Filtre Kahve", 1 },
                    { 5, new DateTime(2024, 7, 8, 16, 30, 23, 981, DateTimeKind.Local).AddTicks(6219), null, null, "Filtre Kahve", 1 },
                    { 6, new DateTime(2024, 7, 8, 16, 30, 23, 981, DateTimeKind.Local).AddTicks(6223), null, null, "Filtre Kahve", 1 },
                    { 7, new DateTime(2024, 7, 8, 16, 30, 23, 981, DateTimeKind.Local).AddTicks(6224), null, null, "Filtre Kahve", 1 },
                    { 8, new DateTime(2024, 7, 8, 16, 30, 23, 981, DateTimeKind.Local).AddTicks(6226), null, null, "Filtre Kahve", 1 },
                    { 9, new DateTime(2024, 7, 8, 16, 30, 23, 981, DateTimeKind.Local).AddTicks(6227), null, null, "Filtre Kahve", 1 },
                    { 10, new DateTime(2024, 7, 8, 16, 30, 23, 981, DateTimeKind.Local).AddTicks(6230), null, null, "Filtre Kahve", 1 }
                });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "ID", "CreatedDate", "DeletedDate", "ModifiedDate", "Status", "TableNo" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 8, 16, 30, 24, 90, DateTimeKind.Local).AddTicks(3851), null, null, "Bos", 1 },
                    { 2, new DateTime(2024, 7, 8, 16, 30, 24, 90, DateTimeKind.Local).AddTicks(3856), null, null, "Bos", 2 },
                    { 3, new DateTime(2024, 7, 8, 16, 30, 24, 90, DateTimeKind.Local).AddTicks(3858), null, null, "Bos", 3 },
                    { 4, new DateTime(2024, 7, 8, 16, 30, 24, 90, DateTimeKind.Local).AddTicks(3859), null, null, "Bos", 4 },
                    { 5, new DateTime(2024, 7, 8, 16, 30, 24, 90, DateTimeKind.Local).AddTicks(3860), null, null, "Bos", 5 },
                    { 6, new DateTime(2024, 7, 8, 16, 30, 24, 90, DateTimeKind.Local).AddTicks(3863), null, null, "Bos", 6 },
                    { 7, new DateTime(2024, 7, 8, 16, 30, 24, 90, DateTimeKind.Local).AddTicks(3864), null, null, "Bos", 7 },
                    { 8, new DateTime(2024, 7, 8, 16, 30, 24, 90, DateTimeKind.Local).AddTicks(3865), null, null, "Bos", 8 },
                    { 9, new DateTime(2024, 7, 8, 16, 30, 24, 90, DateTimeKind.Local).AddTicks(3866), null, null, "Bos", 9 },
                    { 10, new DateTime(2024, 7, 8, 16, 30, 24, 90, DateTimeKind.Local).AddTicks(3868), null, null, "Bos", 10 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "CategoryID", "CreatedDate", "DeletedDate", "ModifiedDate", "ProductName", "Status", "Unit", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 7, 8, 16, 30, 23, 981, DateTimeKind.Local).AddTicks(4598), null, null, "Handmade Steel Shirt", 1, "Porsiyon", 18.50m },
                    { 2, 2, new DateTime(2024, 7, 8, 16, 30, 23, 981, DateTimeKind.Local).AddTicks(4861), null, null, "Gorgeous Rubber Mouse", 1, "Porsiyon", 278.37m },
                    { 3, 3, new DateTime(2024, 7, 8, 16, 30, 23, 981, DateTimeKind.Local).AddTicks(4978), null, null, "Incredible Steel Table", 1, "Porsiyon", 898.89m },
                    { 4, 4, new DateTime(2024, 7, 8, 16, 30, 23, 981, DateTimeKind.Local).AddTicks(5087), null, null, "Small Plastic Salad", 1, "Porsiyon", 801.83m },
                    { 5, 5, new DateTime(2024, 7, 8, 16, 30, 23, 981, DateTimeKind.Local).AddTicks(5196), null, null, "Small Granite Pants", 1, "Porsiyon", 120.50m },
                    { 6, 6, new DateTime(2024, 7, 8, 16, 30, 23, 981, DateTimeKind.Local).AddTicks(5412), null, null, "Unbranded Plastic Gloves", 1, "Porsiyon", 573.88m },
                    { 7, 7, new DateTime(2024, 7, 8, 16, 30, 23, 981, DateTimeKind.Local).AddTicks(5521), null, null, "Tasty Cotton Sausages", 1, "Porsiyon", 605.24m },
                    { 8, 8, new DateTime(2024, 7, 8, 16, 30, 23, 981, DateTimeKind.Local).AddTicks(5630), null, null, "Licensed Fresh Mouse", 1, "Porsiyon", 910.37m },
                    { 9, 9, new DateTime(2024, 7, 8, 16, 30, 23, 981, DateTimeKind.Local).AddTicks(5739), null, null, "Ergonomic Cotton Sausages", 1, "Porsiyon", 810.09m },
                    { 10, 10, new DateTime(2024, 7, 8, 16, 30, 23, 981, DateTimeKind.Local).AddTicks(5848), null, null, "Incredible Fresh Table", 1, "Porsiyon", 381.84m }
                });

            migrationBuilder.InsertData(
                table: "RecipeDetails",
                columns: new[] { "IngredientID", "RecipeID", "CreatedDate", "DeletedDate", "IngredientQuantity", "Instruction", "ModifiedDate", "Status", "Unit" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 7, 8, 16, 30, 23, 981, DateTimeKind.Local).AddTicks(6288), null, 3m, "Karıstır", null, 1, "Adet" },
                    { 2, 2, new DateTime(2024, 7, 8, 16, 30, 23, 981, DateTimeKind.Local).AddTicks(6293), null, 3m, "Karıstır", null, 1, "Adet" },
                    { 3, 3, new DateTime(2024, 7, 8, 16, 30, 23, 981, DateTimeKind.Local).AddTicks(6295), null, 3m, "Karıstır", null, 1, "Adet" },
                    { 4, 4, new DateTime(2024, 7, 8, 16, 30, 23, 981, DateTimeKind.Local).AddTicks(6297), null, 3m, "Karıstır", null, 1, "Adet" },
                    { 5, 5, new DateTime(2024, 7, 8, 16, 30, 23, 981, DateTimeKind.Local).AddTicks(6299), null, 3m, "Karıstır", null, 1, "Adet" },
                    { 6, 6, new DateTime(2024, 7, 8, 16, 30, 23, 981, DateTimeKind.Local).AddTicks(6302), null, 3m, "Karıstır", null, 1, "Adet" },
                    { 7, 7, new DateTime(2024, 7, 8, 16, 30, 23, 981, DateTimeKind.Local).AddTicks(6304), null, 3m, "Karıstır", null, 1, "Adet" },
                    { 8, 8, new DateTime(2024, 7, 8, 16, 30, 23, 981, DateTimeKind.Local).AddTicks(6306), null, 3m, "Karıstır", null, 1, "Adet" },
                    { 9, 9, new DateTime(2024, 7, 8, 16, 30, 23, 981, DateTimeKind.Local).AddTicks(6307), null, 3m, "Karıstır", null, 1, "Adet" },
                    { 10, 10, new DateTime(2024, 7, 8, 16, 30, 23, 981, DateTimeKind.Local).AddTicks(6311), null, 3m, "Karıstır", null, 1, "Adet" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductID",
                table: "OrderDetails",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeDetails_RecipeID",
                table: "RecipeDetails",
                column: "RecipeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "RecipeDetails");

            migrationBuilder.DropTable(
                name: "Tables");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}

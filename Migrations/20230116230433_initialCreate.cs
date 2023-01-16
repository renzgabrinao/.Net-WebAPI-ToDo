using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produces",
                columns: table => new
                {
                    ProduceID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produces", x => x.ProduceID);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SupplierName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierID);
                });

            migrationBuilder.CreateTable(
                name: "ProduceSuppliers",
                columns: table => new
                {
                    ProduceID = table.Column<int>(type: "INTEGER", nullable: false),
                    SupplierID = table.Column<int>(type: "INTEGER", nullable: false),
                    Qty = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProduceSuppliers", x => new { x.ProduceID, x.SupplierID });
                    table.ForeignKey(
                        name: "FK_ProduceSuppliers_Produces_ProduceID",
                        column: x => x.ProduceID,
                        principalTable: "Produces",
                        principalColumn: "ProduceID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProduceSuppliers_Suppliers_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Produces",
                columns: new[] { "ProduceID", "Description" },
                values: new object[] { 1, "Oranges" });

            migrationBuilder.InsertData(
                table: "Produces",
                columns: new[] { "ProduceID", "Description" },
                values: new object[] { 2, "Apples" });

            migrationBuilder.InsertData(
                table: "Produces",
                columns: new[] { "ProduceID", "Description" },
                values: new object[] { 3, "Peaches" });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "SupplierID", "SupplierName" },
                values: new object[] { 1, "Kin's Market" });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "SupplierID", "SupplierName" },
                values: new object[] { 2, "Fresh Street Market" });

            migrationBuilder.InsertData(
                table: "ProduceSuppliers",
                columns: new[] { "ProduceID", "SupplierID", "Qty" },
                values: new object[] { 1, 1, 25 });

            migrationBuilder.InsertData(
                table: "ProduceSuppliers",
                columns: new[] { "ProduceID", "SupplierID", "Qty" },
                values: new object[] { 2, 2, 12 });

            migrationBuilder.InsertData(
                table: "ProduceSuppliers",
                columns: new[] { "ProduceID", "SupplierID", "Qty" },
                values: new object[] { 3, 1, 30 });

            migrationBuilder.CreateIndex(
                name: "IX_ProduceSuppliers_SupplierID",
                table: "ProduceSuppliers",
                column: "SupplierID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProduceSuppliers");

            migrationBuilder.DropTable(
                name: "Produces");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}

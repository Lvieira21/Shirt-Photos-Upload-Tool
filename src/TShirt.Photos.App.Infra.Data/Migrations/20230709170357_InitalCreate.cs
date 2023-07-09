using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TShirt.Photos.App.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitalCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colours", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fabrics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fabrics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shirts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shirts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShirtId = table.Column<int>(type: "int", nullable: false),
                    ColourId = table.Column<int>(type: "int", nullable: false),
                    FabricId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Shirts_ShirtId",
                        column: x => x.ShirtId,
                        principalTable: "Shirts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShirtColour",
                columns: table => new
                {
                    ShirtId = table.Column<int>(type: "int", nullable: false),
                    ColourId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShirtColour", x => new { x.ShirtId, x.ColourId });
                    table.ForeignKey(
                        name: "FK_ShirtColour_Colours_ColourId",
                        column: x => x.ColourId,
                        principalTable: "Colours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShirtColour_Shirts_ShirtId",
                        column: x => x.ShirtId,
                        principalTable: "Shirts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShirtFabric",
                columns: table => new
                {
                    ShirtId = table.Column<int>(type: "int", nullable: false),
                    FabricId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShirtFabric", x => new { x.ShirtId, x.FabricId });
                    table.ForeignKey(
                        name: "FK_ShirtFabric_Fabrics_FabricId",
                        column: x => x.FabricId,
                        principalTable: "Fabrics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShirtFabric_Shirts_ShirtId",
                        column: x => x.ShirtId,
                        principalTable: "Shirts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Colours",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "White" },
                    { 2, "Red" },
                    { 3, "Grey" }
                });

            migrationBuilder.InsertData(
                table: "Fabrics",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Cotton" },
                    { 2, "Linen" },
                    { 3, "Silk" }
                });

            migrationBuilder.InsertData(
                table: "Shirts",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Abstract" },
                    { 2, "Bubbles" },
                    { 3, "Plain" }
                });

            migrationBuilder.InsertData(
                table: "ShirtColour",
                columns: new[] { "ColourId", "ShirtId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 2, 2 },
                    { 3, 2 },
                    { 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "ShirtFabric",
                columns: new[] { "FabricId", "ShirtId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 1, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_ShirtId",
                table: "Images",
                column: "ShirtId");

            migrationBuilder.CreateIndex(
                name: "IX_ShirtColour_ColourId",
                table: "ShirtColour",
                column: "ColourId");

            migrationBuilder.CreateIndex(
                name: "IX_ShirtFabric_FabricId",
                table: "ShirtFabric",
                column: "FabricId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "ShirtColour");

            migrationBuilder.DropTable(
                name: "ShirtFabric");

            migrationBuilder.DropTable(
                name: "Colours");

            migrationBuilder.DropTable(
                name: "Fabrics");

            migrationBuilder.DropTable(
                name: "Shirts");
        }
    }
}

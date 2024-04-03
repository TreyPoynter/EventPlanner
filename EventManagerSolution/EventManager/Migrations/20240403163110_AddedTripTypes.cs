using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventManager.Migrations
{
    /// <inheritdoc />
    public partial class AddedTripTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Type_TypeId",
                table: "Events");

            migrationBuilder.DropTable(
                name: "Type");

            migrationBuilder.CreateTable(
                name: "EventType",
                columns: table => new
                {
                    EventTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventType", x => x.EventTypeId);
                });

            migrationBuilder.InsertData(
                table: "EventType",
                columns: new[] { "EventTypeId", "Name" },
                values: new object[,]
                {
                    { 1, "Wedding" },
                    { 2, "Birthday Party" },
                    { 3, "Conference" },
                    { 4, "Music Concert" },
                    { 5, "Charity Gala" },
                    { 6, "Product Launch" },
                    { 7, "Gathering" },
                    { 8, "Sports Event" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Events_EventType_TypeId",
                table: "Events",
                column: "TypeId",
                principalTable: "EventType",
                principalColumn: "EventTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_EventType_TypeId",
                table: "Events");

            migrationBuilder.DropTable(
                name: "EventType");

            migrationBuilder.CreateTable(
                name: "Type",
                columns: table => new
                {
                    TypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.TypeId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Type_TypeId",
                table: "Events",
                column: "TypeId",
                principalTable: "Type",
                principalColumn: "TypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace HPStore.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tainghes",
                columns: table => new
                {
                    TaingheID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTainghe = table.Column<string>(nullable: true),
                    Gia = table.Column<decimal>(type: "decimal(8, 2)", nullable: false),
                    Hang = table.Column<string>(nullable: true),
                    Mota = table.Column<string>(nullable: true),
                    Loai = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tainghes", x => x.TaingheID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tainghes");
        }
    }
}

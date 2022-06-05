using Microsoft.EntityFrameworkCore.Migrations;
using Oracle.EntityFrameworkCore.Metadata;

namespace MyMusic.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "JOHNMC");

            migrationBuilder.CreateTable(
                name: "ARTISTS",
                schema: "JOHNMC",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ARTISTS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MUSICS",
                schema: "JOHNMC",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(maxLength: 50, nullable: false),
                    ARTISTID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MUSICS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MUSICS_ARTISTS_ARTISTID",
                        column: x => x.ARTISTID,
                        principalSchema: "JOHNMC",
                        principalTable: "ARTISTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MUSICS_ARTISTID",
                schema: "JOHNMC",
                table: "MUSICS",
                column: "ARTISTID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MUSICS",
                schema: "JOHNMC");

            migrationBuilder.DropTable(
                name: "ARTISTS",
                schema: "JOHNMC");
        }
    }
}

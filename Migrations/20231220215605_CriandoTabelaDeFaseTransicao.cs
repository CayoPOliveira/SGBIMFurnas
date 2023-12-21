using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SGBIMFurnas.Migrations
{
    public partial class CriandoTabelaDeFaseTransicao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fases_Etapas_Id_Etapa",
                table: "Fases");

            migrationBuilder.RenameColumn(
                name: "Id_Etapa",
                table: "Fases",
                newName: "EtapaId");

            migrationBuilder.RenameIndex(
                name: "IX_Fases_Id_Etapa",
                table: "Fases",
                newName: "IX_Fases_EtapaId");

            migrationBuilder.CreateTable(
                name: "FaseTransicao",
                columns: table => new
                {
                    FaseAnteriorId = table.Column<int>(type: "int", nullable: false),
                    FaseSeguinteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaseTransicao", x => new { x.FaseAnteriorId, x.FaseSeguinteId });
                    table.ForeignKey(
                        name: "FK_FaseTransicao_Fases_FaseAnteriorId",
                        column: x => x.FaseAnteriorId,
                        principalTable: "Fases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FaseTransicao_Fases_FaseSeguinteId",
                        column: x => x.FaseSeguinteId,
                        principalTable: "Fases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_FaseTransicao_FaseSeguinteId",
                table: "FaseTransicao",
                column: "FaseSeguinteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fases_Etapas_EtapaId",
                table: "Fases",
                column: "EtapaId",
                principalTable: "Etapas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fases_Etapas_EtapaId",
                table: "Fases");

            migrationBuilder.DropTable(
                name: "FaseTransicao");

            migrationBuilder.RenameColumn(
                name: "EtapaId",
                table: "Fases",
                newName: "Id_Etapa");

            migrationBuilder.RenameIndex(
                name: "IX_Fases_EtapaId",
                table: "Fases",
                newName: "IX_Fases_Id_Etapa");

            migrationBuilder.AddForeignKey(
                name: "FK_Fases_Etapas_Id_Etapa",
                table: "Fases",
                column: "Id_Etapa",
                principalTable: "Etapas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

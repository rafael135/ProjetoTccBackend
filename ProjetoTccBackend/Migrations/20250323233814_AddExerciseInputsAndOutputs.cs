using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoTccBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddExerciseInputsAndOutputs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExercisesInCompetions_Competitions_CompetitionId",
                table: "ExercisesInCompetions");

            migrationBuilder.DropForeignKey(
                name: "FK_ExercisesInCompetions_Exercises_ExerciseId",
                table: "ExercisesInCompetions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExercisesInCompetions",
                table: "ExercisesInCompetions");

            migrationBuilder.RenameTable(
                name: "ExercisesInCompetions",
                newName: "ExercisesInCompetitions");

            migrationBuilder.RenameIndex(
                name: "IX_ExercisesInCompetions_ExerciseId",
                table: "ExercisesInCompetitions",
                newName: "IX_ExercisesInCompetitions_ExerciseId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Exercises",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExercisesInCompetitions",
                table: "ExercisesInCompetitions",
                columns: new[] { "CompetitionId", "ExerciseId" });

            migrationBuilder.CreateTable(
                name: "ExerciseInputs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ExerciseId = table.Column<int>(type: "int", nullable: false),
                    Input = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseInputs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseInputs_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ExerciseOutputs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ExerciseId = table.Column<int>(type: "int", nullable: false),
                    ExerciseInputId = table.Column<int>(type: "int", nullable: false),
                    Output = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseOutputs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseOutputs_ExerciseInputs_ExerciseInputId",
                        column: x => x.ExerciseInputId,
                        principalTable: "ExerciseInputs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseOutputs_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseInputs_ExerciseId",
                table: "ExerciseInputs",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseOutputs_ExerciseId",
                table: "ExerciseOutputs",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseOutputs_ExerciseInputId",
                table: "ExerciseOutputs",
                column: "ExerciseInputId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ExercisesInCompetitions_Competitions_CompetitionId",
                table: "ExercisesInCompetitions",
                column: "CompetitionId",
                principalTable: "Competitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExercisesInCompetitions_Exercises_ExerciseId",
                table: "ExercisesInCompetitions",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExercisesInCompetitions_Competitions_CompetitionId",
                table: "ExercisesInCompetitions");

            migrationBuilder.DropForeignKey(
                name: "FK_ExercisesInCompetitions_Exercises_ExerciseId",
                table: "ExercisesInCompetitions");

            migrationBuilder.DropTable(
                name: "ExerciseOutputs");

            migrationBuilder.DropTable(
                name: "ExerciseInputs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExercisesInCompetitions",
                table: "ExercisesInCompetitions");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Exercises");

            migrationBuilder.RenameTable(
                name: "ExercisesInCompetitions",
                newName: "ExercisesInCompetions");

            migrationBuilder.RenameIndex(
                name: "IX_ExercisesInCompetitions_ExerciseId",
                table: "ExercisesInCompetions",
                newName: "IX_ExercisesInCompetions_ExerciseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExercisesInCompetions",
                table: "ExercisesInCompetions",
                columns: new[] { "CompetitionId", "ExerciseId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ExercisesInCompetions_Competitions_CompetitionId",
                table: "ExercisesInCompetions",
                column: "CompetitionId",
                principalTable: "Competitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExercisesInCompetions_Exercises_ExerciseId",
                table: "ExercisesInCompetions",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

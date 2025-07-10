using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoTccBackend.Migrations
{
    /// <inheritdoc />
    public partial class fixUniqueGroupRankingInCompetition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompetitionRankings_Competitions_CompetitionId",
                table: "CompetitionRankings");

            migrationBuilder.DropIndex(
                name: "IX_CompetitionRankings_CompetitionId",
                table: "CompetitionRankings");

            migrationBuilder.AddColumn<DateTime>(
                name: "BlockSubmissions",
                table: "Competitions",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Duration",
                table: "Competitions",
                type: "time(6)",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<DateTime>(
                name: "StopRanking",
                table: "Competitions",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "SubmissionPenalty",
                table: "Competitions",
                type: "time(6)",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionRankings_CompetitionId",
                table: "CompetitionRankings",
                column: "CompetitionId",
                unique: false);

            migrationBuilder.AddForeignKey(
                name: "FK_CompetitionRankings_Competition_CompetitionId",
                table: "CompetitionRankings",
                column: "CompetitionId",
                principalTable: "Competitions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CompetitionRankings_CompetitionId",
                table: "CompetitionRankings");

            migrationBuilder.DropForeignKey(
                name: "FK_CompetitionRankings_Competition_CompetitionId",
                table: "CompetitionRankings");

            migrationBuilder.DropColumn(
                name: "BlockSubmissions",
                table: "Competitions");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Competitions");

            migrationBuilder.DropColumn(
                name: "StopRanking",
                table: "Competitions");

            migrationBuilder.DropColumn(
                name: "SubmissionPenalty",
                table: "Competitions");

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionRankings_CompetitionId",
                table: "CompetitionRankings",
                column: "CompetitionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CompetitionRankings_Competitions_CompetitionId",
                table: "CompetitionRankings",
                column: "CompetitionId",
                principalTable: "Competition",
                principalColumn: "Id");
        }
    }
}

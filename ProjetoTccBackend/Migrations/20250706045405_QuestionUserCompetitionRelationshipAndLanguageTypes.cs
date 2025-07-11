﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoTccBackend.Migrations
{
    /// <inheritdoc />
    public partial class QuestionUserCompetitionRelationshipAndLanguageTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Accepted",
                table: "GroupExerciseAttempts",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "JudgeResponse",
                table: "GroupExerciseAttempts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Language",
                table: "GroupExerciseAttempts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "SubmissionTime",
                table: "GroupExerciseAttempts",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CompetitionId = table.Column<int>(type: "int", nullable: false),
                    TargetQuestionId = table.Column<int>(type: "int", nullable: true),
                    ExerciseId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Content = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    QuestionType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Questions_Competitions_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "Competitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Questions_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Questions_Questions_TargetQuestionId",
                        column: x => x.TargetQuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_CompetitionId",
                table: "Questions",
                column: "CompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_ExerciseId",
                table: "Questions",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_TargetQuestionId",
                table: "Questions",
                column: "TargetQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_UserId",
                table: "Questions",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropColumn(
                name: "Accepted",
                table: "GroupExerciseAttempts");

            migrationBuilder.DropColumn(
                name: "JudgeResponse",
                table: "GroupExerciseAttempts");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "GroupExerciseAttempts");

            migrationBuilder.DropColumn(
                name: "SubmissionTime",
                table: "GroupExerciseAttempts");
        }
    }
}

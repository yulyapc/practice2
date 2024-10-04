using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hackaton.api.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Teams_TeamId",
                table: "Participants");

            migrationBuilder.DropForeignKey(
                name: "FK_Rewards_Hackatons_HackatonId",
                table: "Rewards");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Hackatons_HackatonId",
                table: "Teams");

            migrationBuilder.AlterColumn<int>(
                name: "HackatonId",
                table: "Teams",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "HackatonId",
                table: "Rewards",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TeamId",
                table: "Participants",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Evaluations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Score = table.Column<int>(type: "int", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: true),
                    MentorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Evaluations_Mentors_MentorId",
                        column: x => x.MentorId,
                        principalTable: "Mentors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Evaluations_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_MentorId",
                table: "Evaluations",
                column: "MentorId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_ProjectId",
                table: "Evaluations",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_TeamId",
                table: "Projects",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Teams_TeamId",
                table: "Participants",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rewards_Hackatons_HackatonId",
                table: "Rewards",
                column: "HackatonId",
                principalTable: "Hackatons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Hackatons_HackatonId",
                table: "Teams",
                column: "HackatonId",
                principalTable: "Hackatons",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Teams_TeamId",
                table: "Participants");

            migrationBuilder.DropForeignKey(
                name: "FK_Rewards_Hackatons_HackatonId",
                table: "Rewards");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Hackatons_HackatonId",
                table: "Teams");

            migrationBuilder.DropTable(
                name: "Evaluations");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.AlterColumn<int>(
                name: "HackatonId",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HackatonId",
                table: "Rewards",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TeamId",
                table: "Participants",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Teams_TeamId",
                table: "Participants",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rewards_Hackatons_HackatonId",
                table: "Rewards",
                column: "HackatonId",
                principalTable: "Hackatons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Hackatons_HackatonId",
                table: "Teams",
                column: "HackatonId",
                principalTable: "Hackatons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimesheetAPP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Consomations",
                columns: table => new
                {
                    ConsomationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateDebut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NbHeure = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consomations", x => x.ConsomationId);
                });

            migrationBuilder.CreateTable(
                name: "Solutions",
                columns: table => new
                {
                    SolutionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomSolution = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solutions", x => x.SolutionId);
                });

            migrationBuilder.CreateTable(
                name: "Intervenants",
                columns: table => new
                {
                    IntervenantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateDeNaissnace = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientExistance = table.Column<bool>(type: "bit", nullable: false),
                    ConsomationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intervenants", x => x.IntervenantId);
                    table.ForeignKey(
                        name: "FK_Intervenants_Consomations_ConsomationId",
                        column: x => x.ConsomationId,
                        principalTable: "Consomations",
                        principalColumn: "ConsomationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projets",
                columns: table => new
                {
                    ProjetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomProjet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionProjet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SolutionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projets", x => x.ProjetId);
                    table.ForeignKey(
                        name: "FK_Projets_Solutions_SolutionId",
                        column: x => x.SolutionId,
                        principalTable: "Solutions",
                        principalColumn: "SolutionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projet_Intervenants",
                columns: table => new
                {
                    Projet_IntervenantId = table.Column<int>(type: "int", nullable: false),
                    IntervenantId = table.Column<int>(type: "int", nullable: false),
                    ProjetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projet_Intervenants", x => new { x.ProjetId, x.IntervenantId, x.Projet_IntervenantId });
                    table.ForeignKey(
                        name: "FK_Projet_Intervenants_Intervenants_IntervenantId",
                        column: x => x.IntervenantId,
                        principalTable: "Intervenants",
                        principalColumn: "IntervenantId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projet_Intervenants_Projets_ProjetId",
                        column: x => x.ProjetId,
                        principalTable: "Projets",
                        principalColumn: "ProjetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomTicket = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DecriptionTicket = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Severity = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    ConsomationId = table.Column<int>(type: "int", nullable: false),
                    SolutionId = table.Column<int>(type: "int", nullable: false),
                    ProjetId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Tickets_Consomations_ConsomationId",
                        column: x => x.ConsomationId,
                        principalTable: "Consomations",
                        principalColumn: "ConsomationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Projets_ProjetId",
                        column: x => x.ProjetId,
                        principalTable: "Projets",
                        principalColumn: "ProjetId");
                    table.ForeignKey(
                        name: "FK_Tickets_Solutions_SolutionId",
                        column: x => x.SolutionId,
                        principalTable: "Solutions",
                        principalColumn: "SolutionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Intervenants_ConsomationId",
                table: "Intervenants",
                column: "ConsomationId");

            migrationBuilder.CreateIndex(
                name: "IX_Projet_Intervenants_IntervenantId",
                table: "Projet_Intervenants",
                column: "IntervenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Projets_SolutionId",
                table: "Projets",
                column: "SolutionId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ConsomationId",
                table: "Tickets",
                column: "ConsomationId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ProjetId",
                table: "Tickets",
                column: "ProjetId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_SolutionId",
                table: "Tickets",
                column: "SolutionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projet_Intervenants");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Intervenants");

            migrationBuilder.DropTable(
                name: "Projets");

            migrationBuilder.DropTable(
                name: "Consomations");

            migrationBuilder.DropTable(
                name: "Solutions");
        }
    }
}

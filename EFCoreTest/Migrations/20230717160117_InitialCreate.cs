using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreTest.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "County",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_County", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Defendent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsOrganization = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Defendent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FilerType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilerType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Firm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plaintiff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimId = table.Column<int>(type: "int", nullable: false),
                    IsPatient = table.Column<bool>(type: "bit", nullable: false),
                    IsMinor = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plaintiff", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QueueStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QueueStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Filer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilerTypeId = table.Column<int>(type: "int", nullable: false),
                    FirmId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Filer_FilerType_FilerTypeId",
                        column: x => x.FilerTypeId,
                        principalTable: "FilerType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Filer_Firm_FirmId",
                        column: x => x.FirmId,
                        principalTable: "Firm",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Claim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FilerId = table.Column<int>(type: "int", nullable: false),
                    AttorneyId = table.Column<int>(type: "int", nullable: false),
                    CountyId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Claim_County_CountyId",
                        column: x => x.CountyId,
                        principalTable: "County",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Claim_Filer_FilerId",
                        column: x => x.FilerId,
                        principalTable: "Filer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Claim_QueueStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "QueueStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClaimDefendentLink",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimId = table.Column<int>(type: "int", nullable: false),
                    DefendentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimDefendentLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClaimDefendentLink_Claim_ClaimId",
                        column: x => x.ClaimId,
                        principalTable: "Claim",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClaimDefendentLink_Defendent_DefendentId",
                        column: x => x.DefendentId,
                        principalTable: "Defendent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClaimPlaintiffLink",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimId = table.Column<int>(type: "int", nullable: false),
                    PlaintiffId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimPlaintiffLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClaimPlaintiffLink_Claim_ClaimId",
                        column: x => x.ClaimId,
                        principalTable: "Claim",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClaimPlaintiffLink_Plaintiff_PlaintiffId",
                        column: x => x.PlaintiffId,
                        principalTable: "Plaintiff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilerAssociations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilerId = table.Column<int>(type: "int", nullable: false),
                    ClaimId = table.Column<int>(type: "int", nullable: false),
                    AssociationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilerAssociations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilerAssociations_Claim_ClaimId",
                        column: x => x.ClaimId,
                        principalTable: "Claim",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilerAssociations_Filer_AssociationId",
                        column: x => x.AssociationId,
                        principalTable: "Filer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FilerAssociations_Filer_FilerId",
                        column: x => x.FilerId,
                        principalTable: "Filer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Claim_CountyId",
                table: "Claim",
                column: "CountyId");

            migrationBuilder.CreateIndex(
                name: "IX_Claim_FilerId",
                table: "Claim",
                column: "FilerId");

            migrationBuilder.CreateIndex(
                name: "IX_Claim_StatusId",
                table: "Claim",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimDefendentLink_ClaimId",
                table: "ClaimDefendentLink",
                column: "ClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimDefendentLink_DefendentId",
                table: "ClaimDefendentLink",
                column: "DefendentId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimPlaintiffLink_ClaimId",
                table: "ClaimPlaintiffLink",
                column: "ClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimPlaintiffLink_PlaintiffId",
                table: "ClaimPlaintiffLink",
                column: "PlaintiffId");

            migrationBuilder.CreateIndex(
                name: "IX_Filer_FilerTypeId",
                table: "Filer",
                column: "FilerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Filer_FirmId",
                table: "Filer",
                column: "FirmId");

            migrationBuilder.CreateIndex(
                name: "IX_FilerAssociations_AssociationId",
                table: "FilerAssociations",
                column: "AssociationId");

            migrationBuilder.CreateIndex(
                name: "IX_FilerAssociations_ClaimId",
                table: "FilerAssociations",
                column: "ClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_FilerAssociations_FilerId",
                table: "FilerAssociations",
                column: "FilerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClaimDefendentLink");

            migrationBuilder.DropTable(
                name: "ClaimPlaintiffLink");

            migrationBuilder.DropTable(
                name: "FilerAssociations");

            migrationBuilder.DropTable(
                name: "Defendent");

            migrationBuilder.DropTable(
                name: "Plaintiff");

            migrationBuilder.DropTable(
                name: "Claim");

            migrationBuilder.DropTable(
                name: "County");

            migrationBuilder.DropTable(
                name: "Filer");

            migrationBuilder.DropTable(
                name: "QueueStatus");

            migrationBuilder.DropTable(
                name: "FilerType");

            migrationBuilder.DropTable(
                name: "Firm");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarriageAPi.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EducationAndCarrier",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Education = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnnualIncome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkLocation = table.Column<int>(type: "int", nullable: false),
                    Occupation = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationAndCarrier", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EducationAndCarrier_PersonDetails_PersonId",
                        column: x => x.PersonId,
                        principalTable: "PersonDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Location_PersonDetails_PersonId",
                        column: x => x.PersonId,
                        principalTable: "PersonDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParentDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FatherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FatherOccupation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherOccupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrotherProfile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SisterProfile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FamilyType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParentDetails_PersonDetails_PersonId",
                        column: x => x.PersonId,
                        principalTable: "PersonDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonalDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Height = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BodyType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SkinTone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalDetails_PersonDetails_PersonId",
                        column: x => x.PersonId,
                        principalTable: "PersonDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReligiosBackground",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Religion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CastDivision = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubCast = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gotra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rashi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manglik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReligiosBackground", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReligiosBackground_PersonDetails_PersonId",
                        column: x => x.PersonId,
                        principalTable: "PersonDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EducationAndCarrier_PersonId",
                table: "EducationAndCarrier",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Location_PersonId",
                table: "Location",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParentDetails_PersonId",
                table: "ParentDetails",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonalDetails_PersonId",
                table: "PersonalDetails",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReligiosBackground_PersonId",
                table: "ReligiosBackground",
                column: "PersonId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EducationAndCarrier");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "ParentDetails");

            migrationBuilder.DropTable(
                name: "PersonalDetails");

            migrationBuilder.DropTable(
                name: "ReligiosBackground");

            migrationBuilder.DropTable(
                name: "PersonDetails");
        }
    }
}

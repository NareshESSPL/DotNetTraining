using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Survey_System.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SurveyTypes",
                columns: table => new
                {
                    SurveyTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurveyTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyTypes", x => x.SurveyTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Surveys",
                columns: table => new
                {
                    SurveyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurveyTypeID = table.Column<int>(type: "int", nullable: false),
                    SurveyTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveys", x => x.SurveyID);
                    table.ForeignKey(
                        name: "FK_Surveys_SurveyTypes_SurveyTypeID",
                        column: x => x.SurveyTypeID,
                        principalTable: "SurveyTypes",
                        principalColumn: "SurveyTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_SurveyTypeID",
                table: "Surveys",
                column: "SurveyTypeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Surveys");

            migrationBuilder.DropTable(
                name: "SurveyTypes");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryProject.Migrations
{
    public partial class StudentDetailAndSEEDataAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SchoolNumber",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "StudentDetail",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TelefonNömrəsi = table.Column<string>(name: "Telefon Nömrəsi", type: "nvarchar(max)", nullable: true),
                    SchoolNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudentsID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentDetail", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StudentDetail_Students_StudentsID",
                        column: x => x.StudentsID,
                        principalTable: "Students",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "ID", "CreatedDate", "DataStatus", "ModifiedDate", "Password", "Role", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 3, 22, 45, 11, 911, DateTimeKind.Local).AddTicks(8016), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$11$PG2naq7/xX4PKipzrnK7q.Bva8iQkJKIyvGpSjj45KqbiyPi537lK", 1, "adminstrator" },
                    { 2, new DateTime(2023, 5, 3, 22, 45, 11, 911, DateTimeKind.Local).AddTicks(8037), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$11$dbGUMLgcCuxGkmHyPDPR1.3VRjXwjQaWcaJl8q3S0YfXz8Mvwt8XO", 2, "insidecode" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "ID", "BirthDay", "CreatedDate", "DataStatus", "FirstName", "Gender", "LastName", "ModifiedDate", "PhoneNumber", "SchoolNumber" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 3, 22, 45, 11, 911, DateTimeKind.Local).AddTicks(8316), 1, "Turqut", 1, "Mehdiyev", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 3, 22, 45, 11, 911, DateTimeKind.Local).AddTicks(8320), 1, "Hüseyin", 1, "Aliyev", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 3, 22, 45, 11, 911, DateTimeKind.Local).AddTicks(8321), 1, "Səbinə", 2, "Mirzoyeva", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null }
                });

            migrationBuilder.InsertData(
                table: "StudentDetail",
                columns: new[] { "ID", "BirthDate", "CreatedDate", "DataStatus", "ModifiedDate", "Telefon Nömrəsi", "SchoolNumber", "StudentsID" },
                values: new object[] { 1, new DateTime(2005, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 3, 22, 45, 11, 911, DateTimeKind.Local).AddTicks(8342), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "100", 1 });

            migrationBuilder.InsertData(
                table: "StudentDetail",
                columns: new[] { "ID", "BirthDate", "CreatedDate", "DataStatus", "ModifiedDate", "Telefon Nömrəsi", "SchoolNumber", "StudentsID" },
                values: new object[] { 2, new DateTime(2006, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 3, 22, 45, 11, 911, DateTimeKind.Local).AddTicks(8345), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "101", 2 });

            migrationBuilder.InsertData(
                table: "StudentDetail",
                columns: new[] { "ID", "BirthDate", "CreatedDate", "DataStatus", "ModifiedDate", "Telefon Nömrəsi", "SchoolNumber", "StudentsID" },
                values: new object[] { 3, new DateTime(2005, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 3, 22, 45, 11, 911, DateTimeKind.Local).AddTicks(8346), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "100", 3 });

            migrationBuilder.CreateIndex(
                name: "IX_StudentDetail_StudentsID",
                table: "StudentDetail",
                column: "StudentsID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentDetail");

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.AlterColumn<string>(
                name: "SchoolNumber",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}

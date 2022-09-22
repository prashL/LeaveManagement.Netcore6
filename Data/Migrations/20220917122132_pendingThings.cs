using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementWeb_Core_6.Data.Migrations
{
    public partial class pendingThings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "LeaveTypes",
                newName: "DateModified");

            migrationBuilder.RenameColumn(
                name: "DateJoined",
                table: "LeaveTypes",
                newName: "DateCreate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateModified",
                table: "LeaveTypes",
                newName: "DateOfBirth");

            migrationBuilder.RenameColumn(
                name: "DateCreate",
                table: "LeaveTypes",
                newName: "DateJoined");
        }
    }
}

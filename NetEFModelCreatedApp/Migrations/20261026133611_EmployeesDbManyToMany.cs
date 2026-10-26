using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetEFModelCreatedApp.Migrations
{
    /// <inheritdoc />
    public partial class EmployeesDbManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectsEmployees_Employees_EmployeesId",
                table: "ProjectsEmployees");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectsEmployees_Projects_ProjectsId",
                table: "ProjectsEmployees");

            migrationBuilder.RenameColumn(
                name: "ProjectsId",
                table: "ProjectsEmployees",
                newName: "EmployeeId");

            migrationBuilder.RenameColumn(
                name: "EmployeesId",
                table: "ProjectsEmployees",
                newName: "ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectsEmployees_ProjectsId",
                table: "ProjectsEmployees",
                newName: "IX_ProjectsEmployees_EmployeeId");

            migrationBuilder.AddColumn<DateOnly>(
                name: "DateStart",
                table: "ProjectsEmployees",
                type: "date",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectsEmployees_Employees_EmployeeId",
                table: "ProjectsEmployees",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectsEmployees_Projects_ProjectId",
                table: "ProjectsEmployees",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectsEmployees_Employees_EmployeeId",
                table: "ProjectsEmployees");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectsEmployees_Projects_ProjectId",
                table: "ProjectsEmployees");

            migrationBuilder.DropColumn(
                name: "DateStart",
                table: "ProjectsEmployees");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "ProjectsEmployees",
                newName: "ProjectsId");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "ProjectsEmployees",
                newName: "EmployeesId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectsEmployees_EmployeeId",
                table: "ProjectsEmployees",
                newName: "IX_ProjectsEmployees_ProjectsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectsEmployees_Employees_EmployeesId",
                table: "ProjectsEmployees",
                column: "EmployeesId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectsEmployees_Projects_ProjectsId",
                table: "ProjectsEmployees",
                column: "ProjectsId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

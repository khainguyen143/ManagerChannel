using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ManagerChannel.Migrations
{
    public partial class update_regulation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectRegulation");

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: "1c0ad5d4-4bf9-4f0f-a9d5-d674e9fdc85a");

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: "5054f402-1c8d-407a-a8a9-8aff08ebfa76");

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: "5b53f070-2416-4200-b49c-b4eb1b0967eb");

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: "8fa9274f-42e1-4065-aadd-119eb09556fa");

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: "cc2ee4b8-75e3-493f-a634-a9dba28e646f");

            migrationBuilder.CreateTable(
                name: "Regulations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regulations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Regulations_User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Regulations_User_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Regulations_User_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Network_Regulations",
                columns: table => new
                {
                    NetworkId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RegulationId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Network_Regulations", x => new { x.RegulationId, x.NetworkId });
                    table.ForeignKey(
                        name: "FK_Network_Regulations_NetWorks_NetworkId",
                        column: x => x.NetworkId,
                        principalTable: "NetWorks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Network_Regulations_Regulations_RegulationId",
                        column: x => x.RegulationId,
                        principalTable: "Regulations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Project_Regulations",
                columns: table => new
                {
                    ProjectId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RegulationId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project_Regulations", x => new { x.RegulationId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_Project_Regulations_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Project_Regulations_Regulations_RegulationId",
                        column: x => x.RegulationId,
                        principalTable: "Regulations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Team_Regulations",
                columns: table => new
                {
                    TeamId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RegulationId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team_Regulations", x => new { x.RegulationId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_Team_Regulations_Regulations_RegulationId",
                        column: x => x.RegulationId,
                        principalTable: "Regulations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Team_Regulations_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "4d01b5d9-6458-4258-a03d-7852ac6c43a9",
                column: "CreatedDate",
                value: new DateTime(2022, 1, 10, 10, 40, 56, 814, DateTimeKind.Local).AddTicks(5187));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "4d01b5d9-6458-4258-a03d-7852ac6c43b8",
                column: "CreatedDate",
                value: new DateTime(2022, 1, 10, 10, 40, 56, 814, DateTimeKind.Local).AddTicks(5649));

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "Id", "CreatedByUserId", "CreatedDate", "DeletedByUserId", "DeletedDate", "IsDeleted", "Permission", "RoleId", "UpdatedByUserId", "UpdatedDate" },
                values: new object[,]
                {
                    { "d61ca5ad-a807-478c-aab4-8fdb07ba9e2d", "92ad4f43-4be7-4fb8-909f-ced532c58461", new DateTime(2022, 1, 10, 10, 40, 56, 814, DateTimeKind.Local).AddTicks(7638), null, null, false, 0, "4d01b5d9-6458-4258-a03d-7852ac6c43a9", null, null },
                    { "2f9e8f4f-0530-4d95-b843-961e3782ce47", "92ad4f43-4be7-4fb8-909f-ced532c58461", new DateTime(2022, 1, 10, 10, 40, 56, 814, DateTimeKind.Local).AddTicks(8304), null, null, false, 100000000, "4d01b5d9-6458-4258-a03d-7852ac6c43a9", null, null },
                    { "74b3b848-803a-4e09-b3fe-78241afe9467", "92ad4f43-4be7-4fb8-909f-ced532c58461", new DateTime(2022, 1, 10, 10, 40, 56, 814, DateTimeKind.Local).AddTicks(8313), null, null, false, 200000000, "4d01b5d9-6458-4258-a03d-7852ac6c43a9", null, null },
                    { "0a04e44c-c64d-47bf-ab16-2d6f625391b3", "92ad4f43-4be7-4fb8-909f-ced532c58461", new DateTime(2022, 1, 10, 10, 40, 56, 814, DateTimeKind.Local).AddTicks(8318), null, null, false, 300000000, "4d01b5d9-6458-4258-a03d-7852ac6c43a9", null, null },
                    { "b18bf050-4c73-4415-b5ac-2bd6cd9ee951", "92ad4f43-4be7-4fb8-909f-ced532c58461", new DateTime(2022, 1, 10, 10, 40, 56, 814, DateTimeKind.Local).AddTicks(8322), null, null, false, 0, "4d01b5d9-6458-4258-a03d-7852ac6c43b8", null, null }
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "92ad4f43-4be7-4fb8-909f-ced532c58461",
                column: "CreatedDate",
                value: new DateTime(2022, 1, 10, 10, 40, 56, 813, DateTimeKind.Local).AddTicks(1504));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4d01b5d9-6458-4258-a03d-7852ac6c43a9", "92ad4f43-4be7-4fb8-909f-ced532c58461" },
                column: "CreatedDate",
                value: new DateTime(2022, 1, 10, 10, 40, 56, 814, DateTimeKind.Local).AddTicks(6230));

            migrationBuilder.CreateIndex(
                name: "IX_Network_Regulations_NetworkId",
                table: "Network_Regulations",
                column: "NetworkId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_Regulations_ProjectId",
                table: "Project_Regulations",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Regulations_CreatedByUserId",
                table: "Regulations",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Regulations_DeletedByUserId",
                table: "Regulations",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Regulations_UpdatedByUserId",
                table: "Regulations",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_Regulations_TeamId",
                table: "Team_Regulations",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Network_Regulations");

            migrationBuilder.DropTable(
                name: "Project_Regulations");

            migrationBuilder.DropTable(
                name: "Team_Regulations");

            migrationBuilder.DropTable(
                name: "Regulations");

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: "0a04e44c-c64d-47bf-ab16-2d6f625391b3");

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: "2f9e8f4f-0530-4d95-b843-961e3782ce47");

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: "74b3b848-803a-4e09-b3fe-78241afe9467");

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: "b18bf050-4c73-4415-b5ac-2bd6cd9ee951");

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: "d61ca5ad-a807-478c-aab4-8fdb07ba9e2d");

            migrationBuilder.CreateTable(
                name: "ProjectRegulation",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Warning = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectRegulation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectRegulation_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectRegulation_User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectRegulation_User_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectRegulation_User_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "4d01b5d9-6458-4258-a03d-7852ac6c43a9",
                column: "CreatedDate",
                value: new DateTime(2022, 1, 8, 16, 40, 26, 678, DateTimeKind.Local).AddTicks(6827));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "4d01b5d9-6458-4258-a03d-7852ac6c43b8",
                column: "CreatedDate",
                value: new DateTime(2022, 1, 8, 16, 40, 26, 678, DateTimeKind.Local).AddTicks(7341));

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "Id", "CreatedByUserId", "CreatedDate", "DeletedByUserId", "DeletedDate", "IsDeleted", "Permission", "RoleId", "UpdatedByUserId", "UpdatedDate" },
                values: new object[,]
                {
                    { "5054f402-1c8d-407a-a8a9-8aff08ebfa76", "92ad4f43-4be7-4fb8-909f-ced532c58461", new DateTime(2022, 1, 8, 16, 40, 26, 678, DateTimeKind.Local).AddTicks(9442), null, null, false, 0, "4d01b5d9-6458-4258-a03d-7852ac6c43a9", null, null },
                    { "1c0ad5d4-4bf9-4f0f-a9d5-d674e9fdc85a", "92ad4f43-4be7-4fb8-909f-ced532c58461", new DateTime(2022, 1, 8, 16, 40, 26, 679, DateTimeKind.Local).AddTicks(216), null, null, false, 100000000, "4d01b5d9-6458-4258-a03d-7852ac6c43a9", null, null },
                    { "5b53f070-2416-4200-b49c-b4eb1b0967eb", "92ad4f43-4be7-4fb8-909f-ced532c58461", new DateTime(2022, 1, 8, 16, 40, 26, 679, DateTimeKind.Local).AddTicks(224), null, null, false, 200000000, "4d01b5d9-6458-4258-a03d-7852ac6c43a9", null, null },
                    { "cc2ee4b8-75e3-493f-a634-a9dba28e646f", "92ad4f43-4be7-4fb8-909f-ced532c58461", new DateTime(2022, 1, 8, 16, 40, 26, 679, DateTimeKind.Local).AddTicks(227), null, null, false, 300000000, "4d01b5d9-6458-4258-a03d-7852ac6c43a9", null, null },
                    { "8fa9274f-42e1-4065-aadd-119eb09556fa", "92ad4f43-4be7-4fb8-909f-ced532c58461", new DateTime(2022, 1, 8, 16, 40, 26, 679, DateTimeKind.Local).AddTicks(230), null, null, false, 0, "4d01b5d9-6458-4258-a03d-7852ac6c43b8", null, null }
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "92ad4f43-4be7-4fb8-909f-ced532c58461",
                column: "CreatedDate",
                value: new DateTime(2022, 1, 8, 16, 40, 26, 677, DateTimeKind.Local).AddTicks(2835));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4d01b5d9-6458-4258-a03d-7852ac6c43a9", "92ad4f43-4be7-4fb8-909f-ced532c58461" },
                column: "CreatedDate",
                value: new DateTime(2022, 1, 8, 16, 40, 26, 678, DateTimeKind.Local).AddTicks(8042));

            migrationBuilder.CreateIndex(
                name: "IX_ProjectRegulation_CreatedByUserId",
                table: "ProjectRegulation",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectRegulation_DeletedByUserId",
                table: "ProjectRegulation",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectRegulation_ProjectId",
                table: "ProjectRegulation",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectRegulation_UpdatedByUserId",
                table: "ProjectRegulation",
                column: "UpdatedByUserId");
        }
    }
}

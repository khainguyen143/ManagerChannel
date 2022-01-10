using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ManagerChannel.Migrations
{
    public partial class createdataseting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NetWorks",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_NetWorks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NetWorks_User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NetWorks_User_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NetWorks_User_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NotifyToUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsUserRead = table.Column<bool>(type: "bit", nullable: false),
                    UserReadTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NotificationType = table.Column<int>(type: "int", nullable: false),
                    NotificationContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotificationUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notification_User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notification_User_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notification_User_NotifyToUserId",
                        column: x => x.NotifyToUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notification_User_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PaymentAccounts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_PaymentAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentAccounts_User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PaymentAccounts_User_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PaymentAccounts_User_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectGoogleApis",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientSecret = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountQuotaimpact = table.Column<int>(type: "int", nullable: false),
                    TypeProjectGoogleApi = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_ProjectGoogleApis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectGoogleApis_User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectGoogleApis_User_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectGoogleApis_User_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManagementId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projects_User_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projects_User_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projects_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Role_User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Role_User_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Role_User_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoleInTeams",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleInTeams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleInTeams_User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoleInTeams_User_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoleInTeams_User_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SedingEmailJob",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ToAddresses = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToCcAddresses = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobState = table.Column<int>(type: "int", nullable: false),
                    JobResult = table.Column<int>(type: "int", nullable: true),
                    JobMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScheduleTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JobExecutingByServiceNodeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobExecutingBeginTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    JobExecutingEndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsLocked = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SedingEmailJob", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SedingEmailJob_User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SedingEmailJob_User_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SedingEmailJob_User_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentTeamId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Teams_ParentTeamId",
                        column: x => x.ParentTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teams_User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teams_User_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teams_User_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tutorials",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tutorials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tutorials_User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tutorials_User_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tutorials_User_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRestriction",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Permission = table.Column<int>(type: "int", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRestriction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRestriction_User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRestriction_User_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRestriction_User_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRestriction_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Network_PaymentAccount",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PaymentAccountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NetworkId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NetworkRate = table.Column<float>(type: "real", nullable: false),
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
                    table.PrimaryKey("PK_Network_PaymentAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Network_PaymentAccount_NetWorks_NetworkId",
                        column: x => x.NetworkId,
                        principalTable: "NetWorks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Network_PaymentAccount_PaymentAccounts_PaymentAccountId",
                        column: x => x.PaymentAccountId,
                        principalTable: "PaymentAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Network_PaymentAccount_User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Network_PaymentAccount_User_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Network_PaymentAccount_User_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "YoutubeChannels",
                columns: table => new
                {
                    ChannelId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Etag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublishedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LinkThumbnails_High = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountVideo = table.Column<int>(type: "int", nullable: false),
                    ViewCount = table.Column<long>(type: "bigint", nullable: false),
                    SubscriberCount = table.Column<long>(type: "bigint", nullable: false),
                    HiddenSubscriberCount = table.Column<bool>(type: "bit", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartPayment = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NetworkId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    NetworkRate = table.Column<float>(type: "real", nullable: false),
                    ProjectGoogleApiId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YoutubeChannels", x => x.ChannelId);
                    table.ForeignKey(
                        name: "FK_YoutubeChannels_NetWorks_NetworkId",
                        column: x => x.NetworkId,
                        principalTable: "NetWorks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_YoutubeChannels_ProjectGoogleApis_ProjectGoogleApiId",
                        column: x => x.ProjectGoogleApiId,
                        principalTable: "ProjectGoogleApis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_YoutubeChannels_User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_YoutubeChannels_User_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_YoutubeChannels_User_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectRegulation",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Warning = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "RolePermission",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Permission = table.Column<int>(type: "int", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolePermission_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePermission_User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RolePermission_User_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RolePermission_User_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolePermissionInTeams",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Permission = table.Column<int>(type: "int", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissionInTeams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolePermissionInTeams_RoleInTeams_RoleId",
                        column: x => x.RoleId,
                        principalTable: "RoleInTeams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePermissionInTeams_User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RolePermissionInTeams_User_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RolePermissionInTeams_User_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRoleInTeams",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TeamId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoleInTeams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoleInTeams_RoleInTeams_RoleId",
                        column: x => x.RoleId,
                        principalTable: "RoleInTeams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoleInTeams_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRoleInTeams_User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRoleInTeams_User_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRoleInTeams_User_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRoleInTeams_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User_YoutubeChannelHistory",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ChannelId = table.Column<int>(type: "int", nullable: false),
                    YoutubeChannelChannelId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_YoutubeChannelHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_YoutubeChannelHistory_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_YoutubeChannelHistory_YoutubeChannels_YoutubeChannelChannelId",
                        column: x => x.YoutubeChannelChannelId,
                        principalTable: "YoutubeChannels",
                        principalColumn: "ChannelId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VideoId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublicDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsClamed = table.Column<bool>(type: "bit", nullable: false),
                    IsDeletedByChannelManager = table.Column<bool>(type: "bit", nullable: false),
                    LinkThumbnails_High = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ViewCount = table.Column<long>(type: "bigint", nullable: false),
                    LikeCount = table.Column<long>(type: "bigint", nullable: false),
                    CommentCount = table.Column<long>(type: "bigint", nullable: false),
                    ChannelId = table.Column<string>(type: "nvarchar(450)", nullable: true),
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
                    table.PrimaryKey("PK_Videos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Videos_User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Videos_User_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Videos_User_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Videos_YoutubeChannels_ChannelId",
                        column: x => x.ChannelId,
                        principalTable: "YoutubeChannels",
                        principalColumn: "ChannelId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Network_UserRoleIns",
                columns: table => new
                {
                    UserRoleInTeamId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Network_PaymentAccountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Network_UserRoleIns", x => new { x.UserRoleInTeamId, x.Network_PaymentAccountId });
                    table.ForeignKey(
                        name: "FK_Network_UserRoleIns_Network_PaymentAccount_Network_PaymentAccountId",
                        column: x => x.Network_PaymentAccountId,
                        principalTable: "Network_PaymentAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Network_UserRoleIns_UserRoleInTeams_UserRoleInTeamId",
                        column: x => x.UserRoleInTeamId,
                        principalTable: "UserRoleInTeams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectUserRoleInTeams",
                columns: table => new
                {
                    UserRoleInTeamId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProjectId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectUserRoleInTeams", x => new { x.ProjectId, x.UserRoleInTeamId });
                    table.ForeignKey(
                        name: "FK_ProjectUserRoleInTeams_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectUserRoleInTeams_UserRoleInTeams_UserRoleInTeamId",
                        column: x => x.UserRoleInTeamId,
                        principalTable: "UserRoleInTeams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole_YoutubeChannels",
                columns: table => new
                {
                    ChannelId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserRoleInTeamId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole_YoutubeChannels", x => new { x.UserRoleInTeamId, x.ChannelId });
                    table.ForeignKey(
                        name: "FK_UserRole_YoutubeChannels_UserRoleInTeams_UserRoleInTeamId",
                        column: x => x.UserRoleInTeamId,
                        principalTable: "UserRoleInTeams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_YoutubeChannels_YoutubeChannels_ChannelId",
                        column: x => x.ChannelId,
                        principalTable: "YoutubeChannels",
                        principalColumn: "ChannelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReportDataVideoDaily",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VideoId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ViewCount = table.Column<long>(type: "bigint", nullable: false),
                    likeCount = table.Column<int>(type: "int", nullable: false),
                    AverageViewDurationInSecond = table.Column<float>(type: "real", nullable: false),
                    IsMonetize = table.Column<bool>(type: "bit", nullable: false),
                    ViewGain = table.Column<long>(type: "bigint", nullable: false),
                    RevenueGain = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportDataVideoDaily", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportDataVideoDaily_Videos_VideoId",
                        column: x => x.VideoId,
                        principalTable: "Videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Network_Channel_History",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ChannelId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YoutubeChannelChannelId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Network_UserRoleInTeamId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Network_UserRoleInTeamUserRoleInTeamId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Network_UserRoleInTeamNetwork_PaymentAccountId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PaymentAccountId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NetworkRate = table.Column<float>(type: "real", nullable: false),
                    NetWorkId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Network_Channel_History", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Network_Channel_History_Network_UserRoleIns_Network_UserRoleInTeamUserRoleInTeamId_Network_UserRoleInTeamNetwork_PaymentAcco~",
                        columns: x => new { x.Network_UserRoleInTeamUserRoleInTeamId, x.Network_UserRoleInTeamNetwork_PaymentAccountId },
                        principalTable: "Network_UserRoleIns",
                        principalColumns: new[] { "UserRoleInTeamId", "Network_PaymentAccountId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Network_Channel_History_NetWorks_NetWorkId",
                        column: x => x.NetWorkId,
                        principalTable: "NetWorks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Network_Channel_History_PaymentAccounts_PaymentAccountId",
                        column: x => x.PaymentAccountId,
                        principalTable: "PaymentAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Network_Channel_History_YoutubeChannels_YoutubeChannelChannelId",
                        column: x => x.YoutubeChannelChannelId,
                        principalTable: "YoutubeChannels",
                        principalColumn: "ChannelId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReportDataChannelDailies",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ChannelId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ViewCount = table.Column<long>(type: "bigint", nullable: false),
                    AverageViewDurationInSecond = table.Column<float>(type: "real", nullable: false),
                    IsMonetize = table.Column<bool>(type: "bit", nullable: false),
                    ViewGain = table.Column<long>(type: "bigint", nullable: false),
                    RevenueGain = table.Column<long>(type: "bigint", nullable: false),
                    CountVideo = table.Column<int>(type: "int", nullable: false),
                    SubscriberCount = table.Column<long>(type: "bigint", nullable: false),
                    SubscriberGain = table.Column<long>(type: "bigint", nullable: false),
                    Network_UserRoleInTeamId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Network_UserRoleInTeamUserRoleInTeamId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Network_UserRoleInTeamNetwork_PaymentAccountId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    NetworkRate = table.Column<float>(type: "real", nullable: false),
                    USRevenueGain = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportDataChannelDailies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportDataChannelDailies_Network_UserRoleIns_Network_UserRoleInTeamUserRoleInTeamId_Network_UserRoleInTeamNetwork_PaymentAcc~",
                        columns: x => new { x.Network_UserRoleInTeamUserRoleInTeamId, x.Network_UserRoleInTeamNetwork_PaymentAccountId },
                        principalTable: "Network_UserRoleIns",
                        principalColumns: new[] { "UserRoleInTeamId", "Network_PaymentAccountId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReportDataChannelDailies_YoutubeChannels_ChannelId",
                        column: x => x.ChannelId,
                        principalTable: "YoutubeChannels",
                        principalColumn: "ChannelId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "IsDeleted", "UpdatedDate", "UserName" },
                values: new object[] { "92ad4f43-4be7-4fb8-909f-ced532c58461", new DateTime(2022, 1, 8, 16, 40, 26, 677, DateTimeKind.Local).AddTicks(2835), null, false, null, "admin" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreatedByUserId", "CreatedDate", "DeletedByUserId", "DeletedDate", "Description", "IsDeleted", "Name", "UpdatedByUserId", "UpdatedDate" },
                values: new object[] { "4d01b5d9-6458-4258-a03d-7852ac6c43a9", "92ad4f43-4be7-4fb8-909f-ced532c58461", new DateTime(2022, 1, 8, 16, 40, 26, 678, DateTimeKind.Local).AddTicks(6827), null, null, null, false, "application_admin", null, null });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreatedByUserId", "CreatedDate", "DeletedByUserId", "DeletedDate", "Description", "IsDeleted", "Name", "UpdatedByUserId", "UpdatedDate" },
                values: new object[] { "4d01b5d9-6458-4258-a03d-7852ac6c43b8", "92ad4f43-4be7-4fb8-909f-ced532c58461", new DateTime(2022, 1, 8, 16, 40, 26, 678, DateTimeKind.Local).AddTicks(7341), null, null, null, false, "application_user", null, null });

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

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId", "CreatedDate" },
                values: new object[] { "4d01b5d9-6458-4258-a03d-7852ac6c43a9", "92ad4f43-4be7-4fb8-909f-ced532c58461", new DateTime(2022, 1, 8, 16, 40, 26, 678, DateTimeKind.Local).AddTicks(8042) });

            migrationBuilder.CreateIndex(
                name: "IX_Network_Channel_History_Network_UserRoleInTeamUserRoleInTeamId_Network_UserRoleInTeamNetwork_PaymentAccountId",
                table: "Network_Channel_History",
                columns: new[] { "Network_UserRoleInTeamUserRoleInTeamId", "Network_UserRoleInTeamNetwork_PaymentAccountId" });

            migrationBuilder.CreateIndex(
                name: "IX_Network_Channel_History_NetWorkId",
                table: "Network_Channel_History",
                column: "NetWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_Network_Channel_History_PaymentAccountId",
                table: "Network_Channel_History",
                column: "PaymentAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Network_Channel_History_YoutubeChannelChannelId",
                table: "Network_Channel_History",
                column: "YoutubeChannelChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_Network_PaymentAccount_CreatedByUserId",
                table: "Network_PaymentAccount",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Network_PaymentAccount_DeletedByUserId",
                table: "Network_PaymentAccount",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Network_PaymentAccount_NetworkId",
                table: "Network_PaymentAccount",
                column: "NetworkId");

            migrationBuilder.CreateIndex(
                name: "IX_Network_PaymentAccount_PaymentAccountId",
                table: "Network_PaymentAccount",
                column: "PaymentAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Network_PaymentAccount_UpdatedByUserId",
                table: "Network_PaymentAccount",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Network_UserRoleIns_Network_PaymentAccountId",
                table: "Network_UserRoleIns",
                column: "Network_PaymentAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_NetWorks_CreatedByUserId",
                table: "NetWorks",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_NetWorks_DeletedByUserId",
                table: "NetWorks",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_NetWorks_UpdatedByUserId",
                table: "NetWorks",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_CreatedByUserId",
                table: "Notification",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_DeletedByUserId",
                table: "Notification",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_NotifyToUserId",
                table: "Notification",
                column: "NotifyToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_UpdatedByUserId",
                table: "Notification",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentAccounts_CreatedByUserId",
                table: "PaymentAccounts",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentAccounts_DeletedByUserId",
                table: "PaymentAccounts",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentAccounts_UpdatedByUserId",
                table: "PaymentAccounts",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectGoogleApis_CreatedByUserId",
                table: "ProjectGoogleApis",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectGoogleApis_DeletedByUserId",
                table: "ProjectGoogleApis",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectGoogleApis_UpdatedByUserId",
                table: "ProjectGoogleApis",
                column: "UpdatedByUserId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CreatedByUserId",
                table: "Projects",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_DeletedByUserId",
                table: "Projects",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_UpdatedByUserId",
                table: "Projects",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_UserId",
                table: "Projects",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUserRoleInTeams_UserRoleInTeamId",
                table: "ProjectUserRoleInTeams",
                column: "UserRoleInTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportDataChannelDailies_ChannelId",
                table: "ReportDataChannelDailies",
                column: "ChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportDataChannelDailies_Network_UserRoleInTeamUserRoleInTeamId_Network_UserRoleInTeamNetwork_PaymentAccountId",
                table: "ReportDataChannelDailies",
                columns: new[] { "Network_UserRoleInTeamUserRoleInTeamId", "Network_UserRoleInTeamNetwork_PaymentAccountId" });

            migrationBuilder.CreateIndex(
                name: "IX_ReportDataVideoDaily_VideoId",
                table: "ReportDataVideoDaily",
                column: "VideoId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_CreatedByUserId",
                table: "Role",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_DeletedByUserId",
                table: "Role",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_UpdatedByUserId",
                table: "Role",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleInTeams_CreatedByUserId",
                table: "RoleInTeams",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleInTeams_DeletedByUserId",
                table: "RoleInTeams",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleInTeams_UpdatedByUserId",
                table: "RoleInTeams",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermission_CreatedByUserId",
                table: "RolePermission",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermission_DeletedByUserId",
                table: "RolePermission",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermission_RoleId",
                table: "RolePermission",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermission_UpdatedByUserId",
                table: "RolePermission",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissionInTeams_CreatedByUserId",
                table: "RolePermissionInTeams",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissionInTeams_DeletedByUserId",
                table: "RolePermissionInTeams",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissionInTeams_RoleId",
                table: "RolePermissionInTeams",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissionInTeams_UpdatedByUserId",
                table: "RolePermissionInTeams",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SedingEmailJob_CreatedByUserId",
                table: "SedingEmailJob",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SedingEmailJob_DeletedByUserId",
                table: "SedingEmailJob",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SedingEmailJob_UpdatedByUserId",
                table: "SedingEmailJob",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_CreatedByUserId",
                table: "Teams",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_DeletedByUserId",
                table: "Teams",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_ParentTeamId",
                table: "Teams",
                column: "ParentTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_UpdatedByUserId",
                table: "Teams",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tutorials_CreatedByUserId",
                table: "Tutorials",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tutorials_DeletedByUserId",
                table: "Tutorials",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tutorials_UpdatedByUserId",
                table: "Tutorials",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_YoutubeChannelHistory_UserId",
                table: "User_YoutubeChannelHistory",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_YoutubeChannelHistory_YoutubeChannelChannelId",
                table: "User_YoutubeChannelHistory",
                column: "YoutubeChannelChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRestriction_CreatedByUserId",
                table: "UserRestriction",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRestriction_DeletedByUserId",
                table: "UserRestriction",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRestriction_UpdatedByUserId",
                table: "UserRestriction",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRestriction_UserId",
                table: "UserRestriction",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_YoutubeChannels_ChannelId",
                table: "UserRole_YoutubeChannels",
                column: "ChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleInTeams_CreatedByUserId",
                table: "UserRoleInTeams",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleInTeams_DeletedByUserId",
                table: "UserRoleInTeams",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleInTeams_RoleId",
                table: "UserRoleInTeams",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleInTeams_TeamId",
                table: "UserRoleInTeams",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleInTeams_UpdatedByUserId",
                table: "UserRoleInTeams",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleInTeams_UserId",
                table: "UserRoleInTeams",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_ChannelId",
                table: "Videos",
                column: "ChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_CreatedByUserId",
                table: "Videos",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_DeletedByUserId",
                table: "Videos",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_UpdatedByUserId",
                table: "Videos",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_YoutubeChannels_CreatedByUserId",
                table: "YoutubeChannels",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_YoutubeChannels_DeletedByUserId",
                table: "YoutubeChannels",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_YoutubeChannels_NetworkId",
                table: "YoutubeChannels",
                column: "NetworkId");

            migrationBuilder.CreateIndex(
                name: "IX_YoutubeChannels_ProjectGoogleApiId",
                table: "YoutubeChannels",
                column: "ProjectGoogleApiId");

            migrationBuilder.CreateIndex(
                name: "IX_YoutubeChannels_UpdatedByUserId",
                table: "YoutubeChannels",
                column: "UpdatedByUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Network_Channel_History");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "ProjectRegulation");

            migrationBuilder.DropTable(
                name: "ProjectUserRoleInTeams");

            migrationBuilder.DropTable(
                name: "ReportDataChannelDailies");

            migrationBuilder.DropTable(
                name: "ReportDataVideoDaily");

            migrationBuilder.DropTable(
                name: "RolePermission");

            migrationBuilder.DropTable(
                name: "RolePermissionInTeams");

            migrationBuilder.DropTable(
                name: "SedingEmailJob");

            migrationBuilder.DropTable(
                name: "Tutorials");

            migrationBuilder.DropTable(
                name: "User_YoutubeChannelHistory");

            migrationBuilder.DropTable(
                name: "UserRestriction");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "UserRole_YoutubeChannels");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Network_UserRoleIns");

            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Network_PaymentAccount");

            migrationBuilder.DropTable(
                name: "UserRoleInTeams");

            migrationBuilder.DropTable(
                name: "YoutubeChannels");

            migrationBuilder.DropTable(
                name: "PaymentAccounts");

            migrationBuilder.DropTable(
                name: "RoleInTeams");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "NetWorks");

            migrationBuilder.DropTable(
                name: "ProjectGoogleApis");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}

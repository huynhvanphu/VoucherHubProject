using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessAPI.Migrations
{
    public partial class DbInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CampaignGame",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignGame", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FK_Customer_Account = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_Account_FK_Customer_Account",
                        column: x => x.FK_Customer_Account,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerNontification",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Sender = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SenderType = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FK_CustomerNontification = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerNontification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerNontification_Customer_FK_CustomerNontification",
                        column: x => x.FK_CustomerNontification,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StoreOwner",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    Website = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CampaignId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FK_StoreOwner_Campaign = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FK_StoreOwner_Account = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreOwner", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreOwner_Account_FK_StoreOwner_Account",
                        column: x => x.FK_StoreOwner_Account,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Campaign",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Slogan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CampaignGameId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FK_Campaign_CampaignGame = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StoreOwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaign", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Campaign_CampaignGame_FK_Campaign_CampaignGame",
                        column: x => x.FK_Campaign_CampaignGame,
                        principalTable: "CampaignGame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Campaign_StoreOwner_StoreOwnerId",
                        column: x => x.StoreOwnerId,
                        principalTable: "StoreOwner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StoreOwnerNontification",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Sender = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SenderType = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    StoreOwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FK_StoreOwnerNontification = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreOwnerNontification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreOwnerNontification_StoreOwner_FK_StoreOwnerNontification",
                        column: x => x.FK_StoreOwnerNontification,
                        principalTable: "StoreOwner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customer_Campaign",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GrantedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CampaignId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FK_Customer_Campaign_Campaign = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FK_Customer_Campaign_Customer = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer_Campaign", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_Campaign_Campaign_FK_Customer_Campaign_Campaign",
                        column: x => x.FK_Customer_Campaign_Campaign,
                        principalTable: "Campaign",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customer_Campaign_Customer_FK_Customer_Campaign_Customer",
                        column: x => x.FK_Customer_Campaign_Customer,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Voucher",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CampaignId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FK_Voucher_Campaign = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Customer_CampaignId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FK_Voucher_Customer_Campaign = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voucher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Voucher_Campaign_FK_Voucher_Campaign",
                        column: x => x.FK_Voucher_Campaign,
                        principalTable: "Campaign",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Voucher_Customer_Campaign_FK_Voucher_Customer_Campaign",
                        column: x => x.FK_Voucher_Customer_Campaign,
                        principalTable: "Customer_Campaign",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Campaign_FK_Campaign_CampaignGame",
                table: "Campaign",
                column: "FK_Campaign_CampaignGame");

            migrationBuilder.CreateIndex(
                name: "IX_Campaign_StoreOwnerId",
                table: "Campaign",
                column: "StoreOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_FK_Customer_Account",
                table: "Customer",
                column: "FK_Customer_Account");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Campaign_FK_Customer_Campaign_Campaign",
                table: "Customer_Campaign",
                column: "FK_Customer_Campaign_Campaign");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Campaign_FK_Customer_Campaign_Customer",
                table: "Customer_Campaign",
                column: "FK_Customer_Campaign_Customer");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerNontification_FK_CustomerNontification",
                table: "CustomerNontification",
                column: "FK_CustomerNontification");

            migrationBuilder.CreateIndex(
                name: "IX_StoreOwner_FK_StoreOwner_Account",
                table: "StoreOwner",
                column: "FK_StoreOwner_Account");

            migrationBuilder.CreateIndex(
                name: "IX_StoreOwner_FK_StoreOwner_Campaign",
                table: "StoreOwner",
                column: "FK_StoreOwner_Campaign");

            migrationBuilder.CreateIndex(
                name: "IX_StoreOwnerNontification_FK_StoreOwnerNontification",
                table: "StoreOwnerNontification",
                column: "FK_StoreOwnerNontification");

            migrationBuilder.CreateIndex(
                name: "IX_Voucher_FK_Voucher_Campaign",
                table: "Voucher",
                column: "FK_Voucher_Campaign");

            migrationBuilder.CreateIndex(
                name: "IX_Voucher_FK_Voucher_Customer_Campaign",
                table: "Voucher",
                column: "FK_Voucher_Customer_Campaign");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreOwner_Campaign_FK_StoreOwner_Campaign",
                table: "StoreOwner",
                column: "FK_StoreOwner_Campaign",
                principalTable: "Campaign",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campaign_CampaignGame_FK_Campaign_CampaignGame",
                table: "Campaign");

            migrationBuilder.DropForeignKey(
                name: "FK_Campaign_StoreOwner_StoreOwnerId",
                table: "Campaign");

            migrationBuilder.DropTable(
                name: "CustomerNontification");

            migrationBuilder.DropTable(
                name: "StoreOwnerNontification");

            migrationBuilder.DropTable(
                name: "Voucher");

            migrationBuilder.DropTable(
                name: "Customer_Campaign");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "CampaignGame");

            migrationBuilder.DropTable(
                name: "StoreOwner");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Campaign");
        }
    }
}

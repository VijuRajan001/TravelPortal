using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DataRepository.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    FacebookId = table.Column<long>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PictureUrl = table.Column<string>(nullable: true),
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReimbursementInfo",
                columns: table => new
                {
                    ReimbursementInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnyOtherExpenseReimbursed = table.Column<bool>(nullable: false),
                    BandWorkLevel = table.Column<string>(nullable: true),
                    ClientName = table.Column<string>(nullable: true),
                    CostCenter = table.Column<string>(nullable: true),
                    DateofArrival = table.Column<DateTime>(nullable: false),
                    DateofDeparture = table.Column<DateTime>(nullable: false),
                    Designation = table.Column<string>(nullable: true),
                    EmployeeId = table.Column<string>(nullable: true),
                    EmployeeName = table.Column<string>(nullable: true),
                    FlightChargesReimbursed = table.Column<bool>(nullable: false),
                    LocationofTravel = table.Column<string>(nullable: true),
                    ProjectCode = table.Column<string>(nullable: true),
                    PurposeofTravel = table.Column<string>(nullable: true),
                    ReimbursementStatus = table.Column<string>(nullable: true),
                    TravelBillabletoCustomer = table.Column<bool>(nullable: false),
                    TravelExpenseReimbursed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReimbursementInfo", x => x.ReimbursementInfoId);
                });

            migrationBuilder.CreateTable(
                name: "RequestInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Approver = table.Column<string>(nullable: true),
                    Dob = table.Column<DateTime>(nullable: false),
                    EmployeeId = table.Column<string>(nullable: true),
                    EmployeeName = table.Column<string>(nullable: true),
                    ManagerId = table.Column<string>(nullable: true),
                    ManagerName = table.Column<string>(nullable: true),
                    ProjectId = table.Column<string>(nullable: true),
                    RequestStatus = table.Column<string>(nullable: true),
                    TravelCountry = table.Column<string>(nullable: true),
                    TravelReturn = table.Column<DateTime>(nullable: false),
                    TravelStart = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Gender = table.Column<string>(nullable: true),
                    IdentityId = table.Column<string>(nullable: true),
                    Locale = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_AspNetUsers_IdentityId",
                        column: x => x.IdentityId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BoardingLodgingInfo",
                columns: table => new
                {
                    BoardingInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AmountSpent = table.Column<double>(nullable: false),
                    Currency = table.Column<string>(nullable: true),
                    Eligibility = table.Column<int>(nullable: false),
                    FromDate = table.Column<DateTime>(nullable: false),
                    PlaceofStay = table.Column<string>(nullable: true),
                    ReimbursementInfoId = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    ToDate = table.Column<DateTime>(nullable: false),
                    Total = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardingLodgingInfo", x => x.BoardingInfoId);
                    table.ForeignKey(
                        name: "FK_BoardingLodgingInfo_ReimbursementInfo_ReimbursementInfoId",
                        column: x => x.ReimbursementInfoId,
                        principalTable: "ReimbursementInfo",
                        principalColumn: "ReimbursementInfoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FareInfo",
                columns: table => new
                {
                    FareInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AmountSpent = table.Column<double>(nullable: false),
                    Currency = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Eligibility = table.Column<int>(nullable: false),
                    From = table.Column<string>(nullable: true),
                    ReimbursementInfoId = table.Column<int>(nullable: false),
                    Remark = table.Column<string>(nullable: true),
                    To = table.Column<string>(nullable: true),
                    Total = table.Column<double>(nullable: false),
                    TravelMode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FareInfo", x => x.FareInfoId);
                    table.ForeignKey(
                        name: "FK_FareInfo_ReimbursementInfo_ReimbursementInfoId",
                        column: x => x.ReimbursementInfoId,
                        principalTable: "ReimbursementInfo",
                        principalColumn: "ReimbursementInfoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocalTravelExpenseInfo",
                columns: table => new
                {
                    LocalTravelExpenseInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AmountSpent = table.Column<double>(nullable: false),
                    Currency = table.Column<double>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    From = table.Column<string>(nullable: true),
                    ModeofConveyance = table.Column<string>(nullable: true),
                    ReimbursementInfoId = table.Column<int>(nullable: false),
                    SupportbyVoucher = table.Column<bool>(nullable: false),
                    To = table.Column<string>(nullable: true),
                    Total = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalTravelExpenseInfo", x => x.LocalTravelExpenseInfoId);
                    table.ForeignKey(
                        name: "FK_LocalTravelExpenseInfo_ReimbursementInfo_ReimbursementInfoId",
                        column: x => x.ReimbursementInfoId,
                        principalTable: "ReimbursementInfo",
                        principalColumn: "ReimbursementInfoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OtherExpensesInfo",
                columns: table => new
                {
                    OtherExpensesInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AmountSpent = table.Column<double>(nullable: false),
                    Currency = table.Column<double>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Eligibility = table.Column<int>(nullable: false),
                    NatureofExpense = table.Column<string>(nullable: true),
                    ReimbursementInfoId = table.Column<int>(nullable: false),
                    SupportbyVoucher = table.Column<bool>(nullable: false),
                    Total = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherExpensesInfo", x => x.OtherExpensesInfoId);
                    table.ForeignKey(
                        name: "FK_OtherExpensesInfo_ReimbursementInfo_ReimbursementInfoId",
                        column: x => x.ReimbursementInfoId,
                        principalTable: "ReimbursementInfo",
                        principalColumn: "ReimbursementInfoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PerDiemInfo",
                columns: table => new
                {
                    PerDiemInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArrivalDate = table.Column<DateTime>(nullable: false),
                    Currency = table.Column<string>(nullable: true),
                    DepartureDate = table.Column<DateTime>(nullable: false),
                    Eligibility = table.Column<int>(nullable: false),
                    ReimbursementInfoId = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    Total = table.Column<double>(nullable: false),
                    TotalAmount = table.Column<double>(nullable: false),
                    TotalDays = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerDiemInfo", x => x.PerDiemInfoId);
                    table.ForeignKey(
                        name: "FK_PerDiemInfo_ReimbursementInfo_ReimbursementInfoId",
                        column: x => x.ReimbursementInfoId,
                        principalTable: "ReimbursementInfo",
                        principalColumn: "ReimbursementInfoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TravelExpensesWithoutVoucherInfo",
                columns: table => new
                {
                    TravelExpensesWithoutVoucherInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AmountSpent = table.Column<double>(nullable: false),
                    Currency = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    From = table.Column<string>(nullable: true),
                    ModeofConveyance = table.Column<string>(nullable: true),
                    ReimbursementInfoId = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    To = table.Column<string>(nullable: true),
                    Total = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelExpensesWithoutVoucherInfo", x => x.TravelExpensesWithoutVoucherInfoId);
                    table.ForeignKey(
                        name: "FK_TravelExpensesWithoutVoucherInfo_ReimbursementInfo_ReimbursementInfoId",
                        column: x => x.ReimbursementInfoId,
                        principalTable: "ReimbursementInfo",
                        principalColumn: "ReimbursementInfoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TravelExpensesWithVoucherInfo",
                columns: table => new
                {
                    TravelExpensesWithVoucherInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AmountSpent = table.Column<double>(nullable: false),
                    Currency = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    From = table.Column<string>(nullable: true),
                    ModeofConveyance = table.Column<string>(nullable: true),
                    ReimbursementInfoId = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    To = table.Column<string>(nullable: true),
                    Total = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelExpensesWithVoucherInfo", x => x.TravelExpensesWithVoucherInfoId);
                    table.ForeignKey(
                        name: "FK_TravelExpensesWithVoucherInfo_ReimbursementInfo_ReimbursementInfoId",
                        column: x => x.ReimbursementInfoId,
                        principalTable: "ReimbursementInfo",
                        principalColumn: "ReimbursementInfoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlightInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FlightCost = table.Column<double>(nullable: false),
                    FlightDirection = table.Column<string>(nullable: true),
                    FlightFrom = table.Column<string>(nullable: true),
                    FlightItemId = table.Column<string>(nullable: true),
                    FlightName = table.Column<string>(nullable: true),
                    FlightTo = table.Column<string>(nullable: true),
                    RequestInfoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlightInfo_RequestInfo_RequestInfoId",
                        column: x => x.RequestInfoId,
                        principalTable: "RequestInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ForexInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CardExpiryDate = table.Column<DateTime>(nullable: true),
                    CardNumber = table.Column<string>(nullable: true),
                    CardType = table.Column<string>(nullable: true),
                    RequestInfoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForexInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ForexInfo_RequestInfo_RequestInfoId",
                        column: x => x.RequestInfoId,
                        principalTable: "RequestInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amenities = table.Column<string>(nullable: true),
                    CheckinTime = table.Column<DateTime>(nullable: false),
                    CheckoutTime = table.Column<DateTime>(nullable: false),
                    HotelName = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    MobileNo = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    RequestInfoId = table.Column<int>(nullable: false),
                    Website = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelInfo_RequestInfo_RequestInfoId",
                        column: x => x.RequestInfoId,
                        principalTable: "RequestInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PassportInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PassportExpiryDate = table.Column<DateTime>(nullable: true),
                    PassportNumber = table.Column<string>(nullable: true),
                    RequestInfoId = table.Column<int>(nullable: false),
                    VisaExpiryDate = table.Column<DateTime>(nullable: true),
                    VisaNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassportInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PassportInfo_RequestInfo_RequestInfoId",
                        column: x => x.RequestInfoId,
                        principalTable: "RequestInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BoardingLodgingInfo_ReimbursementInfoId",
                table: "BoardingLodgingInfo",
                column: "ReimbursementInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_IdentityId",
                table: "Customer",
                column: "IdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_FareInfo_ReimbursementInfoId",
                table: "FareInfo",
                column: "ReimbursementInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightInfo_RequestInfoId",
                table: "FlightInfo",
                column: "RequestInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_ForexInfo_RequestInfoId",
                table: "ForexInfo",
                column: "RequestInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelInfo_RequestInfoId",
                table: "HotelInfo",
                column: "RequestInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_LocalTravelExpenseInfo_ReimbursementInfoId",
                table: "LocalTravelExpenseInfo",
                column: "ReimbursementInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherExpensesInfo_ReimbursementInfoId",
                table: "OtherExpensesInfo",
                column: "ReimbursementInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_PassportInfo_RequestInfoId",
                table: "PassportInfo",
                column: "RequestInfoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PerDiemInfo_ReimbursementInfoId",
                table: "PerDiemInfo",
                column: "ReimbursementInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelExpensesWithoutVoucherInfo_ReimbursementInfoId",
                table: "TravelExpensesWithoutVoucherInfo",
                column: "ReimbursementInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelExpensesWithVoucherInfo_ReimbursementInfoId",
                table: "TravelExpensesWithVoucherInfo",
                column: "ReimbursementInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BoardingLodgingInfo");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "FareInfo");

            migrationBuilder.DropTable(
                name: "FlightInfo");

            migrationBuilder.DropTable(
                name: "ForexInfo");

            migrationBuilder.DropTable(
                name: "HotelInfo");

            migrationBuilder.DropTable(
                name: "LocalTravelExpenseInfo");

            migrationBuilder.DropTable(
                name: "OtherExpensesInfo");

            migrationBuilder.DropTable(
                name: "PassportInfo");

            migrationBuilder.DropTable(
                name: "PerDiemInfo");

            migrationBuilder.DropTable(
                name: "TravelExpensesWithoutVoucherInfo");

            migrationBuilder.DropTable(
                name: "TravelExpensesWithVoucherInfo");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "RequestInfo");

            migrationBuilder.DropTable(
                name: "ReimbursementInfo");
        }
    }
}

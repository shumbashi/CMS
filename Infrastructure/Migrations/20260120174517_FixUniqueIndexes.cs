using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixUniqueIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdentityId",
                table: "PersonsInCompanies",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<string>(
                name: "PesrsonName",
                table: "PersonsInCompanies",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "EditorName",
                table: "Editors",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<Guid>(
                name: "IdentityId",
                table: "Editors",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "IdentityId",
                table: "ContractParties",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_PersonsInCompanies_IdentityId",
                table: "PersonsInCompanies",
                column: "IdentityId");

            migrationBuilder.CreateIndex(
                name: "UQ_AdministrativeNumber",
                table: "Identities",
                column: "AdministrativeNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_NationalNumber",
                table: "Identities",
                column: "NationalNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_PhoneNumber",
                table: "Identities",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Idx_CourtDivision",
                table: "Editors",
                column: "CourtDivision");

            migrationBuilder.CreateIndex(
                name: "Idx_FinancialBalance",
                table: "Editors",
                column: "FinancialBalance");

            migrationBuilder.CreateIndex(
                name: "IX_Editors_IdentityId",
                table: "Editors",
                column: "IdentityId");

            migrationBuilder.CreateIndex(
                name: "UQ_DecisionNumber",
                table: "Editors",
                column: "DecisionNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_InspectionNumber",
                table: "Editors",
                column: "InspectionNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_SealNumber",
                table: "Editors",
                column: "SealNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Idx_DocumentStatus",
                table: "Documents",
                column: "DocumentStatus");

            migrationBuilder.CreateIndex(
                name: "Idx_IssueDate",
                table: "Documents",
                column: "IssueDate");

            migrationBuilder.CreateIndex(
                name: "UQ_AuthenticationNumber",
                table: "Documents",
                column: "AuthenticationNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_DocumentCode",
                table: "Documents",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContractParties_IdentityId",
                table: "ContractParties",
                column: "IdentityId");

            migrationBuilder.CreateIndex(
                name: "UQ_CommercialRecord",
                table: "Companies",
                column: "CommercialRecord",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_CompanyName",
                table: "Companies",
                column: "CompanyName");

            migrationBuilder.AddForeignKey(
                name: "FK_ContractParties_Identities_IdentityId",
                table: "ContractParties",
                column: "IdentityId",
                principalTable: "Identities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Editors_Identities_IdentityId",
                table: "Editors",
                column: "IdentityId",
                principalTable: "Identities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonsInCompanies_Identities_IdentityId",
                table: "PersonsInCompanies",
                column: "IdentityId",
                principalTable: "Identities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContractParties_Identities_IdentityId",
                table: "ContractParties");

            migrationBuilder.DropForeignKey(
                name: "FK_Editors_Identities_IdentityId",
                table: "Editors");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonsInCompanies_Identities_IdentityId",
                table: "PersonsInCompanies");

            migrationBuilder.DropIndex(
                name: "IX_PersonsInCompanies_IdentityId",
                table: "PersonsInCompanies");

            migrationBuilder.DropIndex(
                name: "UQ_AdministrativeNumber",
                table: "Identities");

            migrationBuilder.DropIndex(
                name: "UQ_NationalNumber",
                table: "Identities");

            migrationBuilder.DropIndex(
                name: "UQ_PhoneNumber",
                table: "Identities");

            migrationBuilder.DropIndex(
                name: "Idx_CourtDivision",
                table: "Editors");

            migrationBuilder.DropIndex(
                name: "Idx_FinancialBalance",
                table: "Editors");

            migrationBuilder.DropIndex(
                name: "IX_Editors_IdentityId",
                table: "Editors");

            migrationBuilder.DropIndex(
                name: "UQ_DecisionNumber",
                table: "Editors");

            migrationBuilder.DropIndex(
                name: "UQ_InspectionNumber",
                table: "Editors");

            migrationBuilder.DropIndex(
                name: "UQ_SealNumber",
                table: "Editors");

            migrationBuilder.DropIndex(
                name: "Idx_DocumentStatus",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "Idx_IssueDate",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "UQ_AuthenticationNumber",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "UQ_DocumentCode",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_ContractParties_IdentityId",
                table: "ContractParties");

            migrationBuilder.DropIndex(
                name: "UQ_CommercialRecord",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "UQ_CompanyName",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "IdentityId",
                table: "PersonsInCompanies");

            migrationBuilder.DropColumn(
                name: "PesrsonName",
                table: "PersonsInCompanies");

            migrationBuilder.DropColumn(
                name: "EditorName",
                table: "Editors");

            migrationBuilder.DropColumn(
                name: "IdentityId",
                table: "Editors");

            migrationBuilder.DropColumn(
                name: "IdentityId",
                table: "ContractParties");
        }
    }
}

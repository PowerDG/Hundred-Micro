using Microsoft.EntityFrameworkCore.Migrations;

namespace Research.Migrations
{
    public partial class InitZero : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbpRoles_AbpUsers_CreatorUserId",
                table: "AbpRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpRoles_AbpUsers_DeleterUserId",
                table: "AbpRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpRoles_AbpUsers_LastModifierUserId",
                table: "AbpRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpTenants_AbpUsers_CreatorUserId",
                table: "AbpTenants");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpTenants_AbpUsers_DeleterUserId",
                table: "AbpTenants");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpTenants_AbpEditions_EditionId",
                table: "AbpTenants");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpTenants_AbpUsers_LastModifierUserId",
                table: "AbpTenants");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpUsers_AbpUsers_CreatorUserId",
                table: "AbpUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpUsers_AbpUsers_DeleterUserId",
                table: "AbpUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpUsers_AbpUsers_LastModifierUserId",
                table: "AbpUsers");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "AbpUsers",
                newName: "surname");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "AbpUsers",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "AbpUsers",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AbpUsers",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "AbpUsers",
                newName: "user_name");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "AbpUsers",
                newName: "tenant_id");

            migrationBuilder.RenameColumn(
                name: "SecurityStamp",
                table: "AbpUsers",
                newName: "security_stamp");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "AbpUsers",
                newName: "phone_number");

            migrationBuilder.RenameColumn(
                name: "PasswordResetCode",
                table: "AbpUsers",
                newName: "password_reset_code");

            migrationBuilder.RenameColumn(
                name: "NormalizedUserName",
                table: "AbpUsers",
                newName: "normalized_user_name");

            migrationBuilder.RenameColumn(
                name: "NormalizedEmailAddress",
                table: "AbpUsers",
                newName: "normalized_email_address");

            migrationBuilder.RenameColumn(
                name: "LockoutEndDateUtc",
                table: "AbpUsers",
                newName: "lockout_end_date_utc");

            migrationBuilder.RenameColumn(
                name: "LastModifierUserId",
                table: "AbpUsers",
                newName: "last_modifier_user_id");

            migrationBuilder.RenameColumn(
                name: "LastModificationTime",
                table: "AbpUsers",
                newName: "modified_time");

            migrationBuilder.RenameColumn(
                name: "IsTwoFactorEnabled",
                table: "AbpUsers",
                newName: "is_two_factor_enabled");

            migrationBuilder.RenameColumn(
                name: "IsPhoneNumberConfirmed",
                table: "AbpUsers",
                newName: "is_phone_number_confirmed");

            migrationBuilder.RenameColumn(
                name: "IsLockoutEnabled",
                table: "AbpUsers",
                newName: "is_lockout_enabled");

            migrationBuilder.RenameColumn(
                name: "IsEmailConfirmed",
                table: "AbpUsers",
                newName: "is_email_confirmed");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "AbpUsers",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "AbpUsers",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "EmailConfirmationCode",
                table: "AbpUsers",
                newName: "email_confirmation_code");

            migrationBuilder.RenameColumn(
                name: "EmailAddress",
                table: "AbpUsers",
                newName: "email_address");

            migrationBuilder.RenameColumn(
                name: "DeletionTime",
                table: "AbpUsers",
                newName: "deleted_time");

            migrationBuilder.RenameColumn(
                name: "DeleterUserId",
                table: "AbpUsers",
                newName: "deleter_user_id");

            migrationBuilder.RenameColumn(
                name: "CreatorUserId",
                table: "AbpUsers",
                newName: "creator_user_id");

            migrationBuilder.RenameColumn(
                name: "CreationTime",
                table: "AbpUsers",
                newName: "create_time");

            migrationBuilder.RenameColumn(
                name: "ConcurrencyStamp",
                table: "AbpUsers",
                newName: "concurrency_stamp");

            migrationBuilder.RenameColumn(
                name: "AuthenticationSource",
                table: "AbpUsers",
                newName: "authentication_source");

            migrationBuilder.RenameColumn(
                name: "AccessFailedCount",
                table: "AbpUsers",
                newName: "access_failed_count");

            migrationBuilder.RenameIndex(
                name: "IX_AbpUsers_TenantId_NormalizedUserName",
                table: "AbpUsers",
                newName: "IX_AbpUsers_tenant_id_normalized_user_name");

            migrationBuilder.RenameIndex(
                name: "IX_AbpUsers_TenantId_NormalizedEmailAddress",
                table: "AbpUsers",
                newName: "IX_AbpUsers_tenant_id_normalized_email_address");

            migrationBuilder.RenameIndex(
                name: "IX_AbpUsers_LastModifierUserId",
                table: "AbpUsers",
                newName: "IX_AbpUsers_last_modifier_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_AbpUsers_DeleterUserId",
                table: "AbpUsers",
                newName: "IX_AbpUsers_deleter_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_AbpUsers_CreatorUserId",
                table: "AbpUsers",
                newName: "IX_AbpUsers_creator_user_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "AbpTenants",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AbpTenants",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "TenancyName",
                table: "AbpTenants",
                newName: "tenancy_name");

            migrationBuilder.RenameColumn(
                name: "LastModifierUserId",
                table: "AbpTenants",
                newName: "last_modifier_user_id");

            migrationBuilder.RenameColumn(
                name: "LastModificationTime",
                table: "AbpTenants",
                newName: "modified_time");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "AbpTenants",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "AbpTenants",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "EditionId",
                table: "AbpTenants",
                newName: "edition_id");

            migrationBuilder.RenameColumn(
                name: "DeletionTime",
                table: "AbpTenants",
                newName: "deleted_time");

            migrationBuilder.RenameColumn(
                name: "DeleterUserId",
                table: "AbpTenants",
                newName: "deleter_user_id");

            migrationBuilder.RenameColumn(
                name: "CreatorUserId",
                table: "AbpTenants",
                newName: "creator_user_id");

            migrationBuilder.RenameColumn(
                name: "CreationTime",
                table: "AbpTenants",
                newName: "create_time");

            migrationBuilder.RenameColumn(
                name: "ConnectionString",
                table: "AbpTenants",
                newName: "connection_string");

            migrationBuilder.RenameIndex(
                name: "IX_AbpTenants_TenancyName",
                table: "AbpTenants",
                newName: "IX_AbpTenants_tenancy_name");

            migrationBuilder.RenameIndex(
                name: "IX_AbpTenants_LastModifierUserId",
                table: "AbpTenants",
                newName: "IX_AbpTenants_last_modifier_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_AbpTenants_EditionId",
                table: "AbpTenants",
                newName: "IX_AbpTenants_edition_id");

            migrationBuilder.RenameIndex(
                name: "IX_AbpTenants_DeleterUserId",
                table: "AbpTenants",
                newName: "IX_AbpTenants_deleter_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_AbpTenants_CreatorUserId",
                table: "AbpTenants",
                newName: "IX_AbpTenants_creator_user_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "AbpRoles",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AbpRoles",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "AbpRoles",
                newName: "tenant_id");

            migrationBuilder.RenameColumn(
                name: "NormalizedName",
                table: "AbpRoles",
                newName: "normalized_name");

            migrationBuilder.RenameColumn(
                name: "LastModifierUserId",
                table: "AbpRoles",
                newName: "last_modifier_user_id");

            migrationBuilder.RenameColumn(
                name: "LastModificationTime",
                table: "AbpRoles",
                newName: "modified_time");

            migrationBuilder.RenameColumn(
                name: "IsStatic",
                table: "AbpRoles",
                newName: "is_static");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "AbpRoles",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "IsDefault",
                table: "AbpRoles",
                newName: "is_default");

            migrationBuilder.RenameColumn(
                name: "DisplayName",
                table: "AbpRoles",
                newName: "display_name");

            migrationBuilder.RenameColumn(
                name: "DeletionTime",
                table: "AbpRoles",
                newName: "deleted_time");

            migrationBuilder.RenameColumn(
                name: "DeleterUserId",
                table: "AbpRoles",
                newName: "deleter_user_id");

            migrationBuilder.RenameColumn(
                name: "CreatorUserId",
                table: "AbpRoles",
                newName: "creator_user_id");

            migrationBuilder.RenameColumn(
                name: "CreationTime",
                table: "AbpRoles",
                newName: "create_time");

            migrationBuilder.RenameColumn(
                name: "ConcurrencyStamp",
                table: "AbpRoles",
                newName: "concurrency_stamp");

            migrationBuilder.RenameIndex(
                name: "IX_AbpRoles_TenantId_NormalizedName",
                table: "AbpRoles",
                newName: "IX_AbpRoles_tenant_id_normalized_name");

            migrationBuilder.RenameIndex(
                name: "IX_AbpRoles_LastModifierUserId",
                table: "AbpRoles",
                newName: "IX_AbpRoles_last_modifier_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_AbpRoles_DeleterUserId",
                table: "AbpRoles",
                newName: "IX_AbpRoles_deleter_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_AbpRoles_CreatorUserId",
                table: "AbpRoles",
                newName: "IX_AbpRoles_creator_user_id");

            migrationBuilder.AlterColumn<string>(
                name: "surname",
                table: "AbpUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "AbpUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "AbpUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                name: "user_name",
                table: "AbpUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "security_stamp",
                table: "AbpUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "phone_number",
                table: "AbpUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 32,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "password_reset_code",
                table: "AbpUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 328,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "normalized_user_name",
                table: "AbpUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "normalized_email_address",
                table: "AbpUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "email_confirmation_code",
                table: "AbpUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 328,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "email_address",
                table: "AbpUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "concurrency_stamp",
                table: "AbpUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "authentication_source",
                table: "AbpUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 64,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "AbpTenants",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "tenancy_name",
                table: "AbpTenants",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                name: "connection_string",
                table: "AbpTenants",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1024,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "AbpRoles",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 32);

            migrationBuilder.AlterColumn<string>(
                name: "normalized_name",
                table: "AbpRoles",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 32);

            migrationBuilder.AlterColumn<string>(
                name: "display_name",
                table: "AbpRoles",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                name: "concurrency_stamp",
                table: "AbpRoles",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "AbpRoles",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpRoles_AbpUsers_creator_user_id",
                table: "AbpRoles",
                column: "creator_user_id",
                principalTable: "AbpUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpRoles_AbpUsers_deleter_user_id",
                table: "AbpRoles",
                column: "deleter_user_id",
                principalTable: "AbpUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpRoles_AbpUsers_last_modifier_user_id",
                table: "AbpRoles",
                column: "last_modifier_user_id",
                principalTable: "AbpUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpTenants_AbpUsers_creator_user_id",
                table: "AbpTenants",
                column: "creator_user_id",
                principalTable: "AbpUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpTenants_AbpUsers_deleter_user_id",
                table: "AbpTenants",
                column: "deleter_user_id",
                principalTable: "AbpUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpTenants_AbpEditions_edition_id",
                table: "AbpTenants",
                column: "edition_id",
                principalTable: "AbpEditions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpTenants_AbpUsers_last_modifier_user_id",
                table: "AbpTenants",
                column: "last_modifier_user_id",
                principalTable: "AbpUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUsers_AbpUsers_creator_user_id",
                table: "AbpUsers",
                column: "creator_user_id",
                principalTable: "AbpUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUsers_AbpUsers_deleter_user_id",
                table: "AbpUsers",
                column: "deleter_user_id",
                principalTable: "AbpUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUsers_AbpUsers_last_modifier_user_id",
                table: "AbpUsers",
                column: "last_modifier_user_id",
                principalTable: "AbpUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbpRoles_AbpUsers_creator_user_id",
                table: "AbpRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpRoles_AbpUsers_deleter_user_id",
                table: "AbpRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpRoles_AbpUsers_last_modifier_user_id",
                table: "AbpRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpTenants_AbpUsers_creator_user_id",
                table: "AbpTenants");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpTenants_AbpUsers_deleter_user_id",
                table: "AbpTenants");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpTenants_AbpEditions_edition_id",
                table: "AbpTenants");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpTenants_AbpUsers_last_modifier_user_id",
                table: "AbpTenants");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpUsers_AbpUsers_creator_user_id",
                table: "AbpUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpUsers_AbpUsers_deleter_user_id",
                table: "AbpUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpUsers_AbpUsers_last_modifier_user_id",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "description",
                table: "AbpRoles");

            migrationBuilder.RenameColumn(
                name: "surname",
                table: "AbpUsers",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "AbpUsers",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "AbpUsers",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "AbpUsers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_name",
                table: "AbpUsers",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "tenant_id",
                table: "AbpUsers",
                newName: "TenantId");

            migrationBuilder.RenameColumn(
                name: "security_stamp",
                table: "AbpUsers",
                newName: "SecurityStamp");

            migrationBuilder.RenameColumn(
                name: "phone_number",
                table: "AbpUsers",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "password_reset_code",
                table: "AbpUsers",
                newName: "PasswordResetCode");

            migrationBuilder.RenameColumn(
                name: "normalized_user_name",
                table: "AbpUsers",
                newName: "NormalizedUserName");

            migrationBuilder.RenameColumn(
                name: "normalized_email_address",
                table: "AbpUsers",
                newName: "NormalizedEmailAddress");

            migrationBuilder.RenameColumn(
                name: "lockout_end_date_utc",
                table: "AbpUsers",
                newName: "LockoutEndDateUtc");

            migrationBuilder.RenameColumn(
                name: "last_modifier_user_id",
                table: "AbpUsers",
                newName: "LastModifierUserId");

            migrationBuilder.RenameColumn(
                name: "modified_time",
                table: "AbpUsers",
                newName: "LastModificationTime");

            migrationBuilder.RenameColumn(
                name: "is_two_factor_enabled",
                table: "AbpUsers",
                newName: "IsTwoFactorEnabled");

            migrationBuilder.RenameColumn(
                name: "is_phone_number_confirmed",
                table: "AbpUsers",
                newName: "IsPhoneNumberConfirmed");

            migrationBuilder.RenameColumn(
                name: "is_lockout_enabled",
                table: "AbpUsers",
                newName: "IsLockoutEnabled");

            migrationBuilder.RenameColumn(
                name: "is_email_confirmed",
                table: "AbpUsers",
                newName: "IsEmailConfirmed");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "AbpUsers",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "is_active",
                table: "AbpUsers",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "email_confirmation_code",
                table: "AbpUsers",
                newName: "EmailConfirmationCode");

            migrationBuilder.RenameColumn(
                name: "email_address",
                table: "AbpUsers",
                newName: "EmailAddress");

            migrationBuilder.RenameColumn(
                name: "deleted_time",
                table: "AbpUsers",
                newName: "DeletionTime");

            migrationBuilder.RenameColumn(
                name: "deleter_user_id",
                table: "AbpUsers",
                newName: "DeleterUserId");

            migrationBuilder.RenameColumn(
                name: "creator_user_id",
                table: "AbpUsers",
                newName: "CreatorUserId");

            migrationBuilder.RenameColumn(
                name: "create_time",
                table: "AbpUsers",
                newName: "CreationTime");

            migrationBuilder.RenameColumn(
                name: "concurrency_stamp",
                table: "AbpUsers",
                newName: "ConcurrencyStamp");

            migrationBuilder.RenameColumn(
                name: "authentication_source",
                table: "AbpUsers",
                newName: "AuthenticationSource");

            migrationBuilder.RenameColumn(
                name: "access_failed_count",
                table: "AbpUsers",
                newName: "AccessFailedCount");

            migrationBuilder.RenameIndex(
                name: "IX_AbpUsers_tenant_id_normalized_user_name",
                table: "AbpUsers",
                newName: "IX_AbpUsers_TenantId_NormalizedUserName");

            migrationBuilder.RenameIndex(
                name: "IX_AbpUsers_tenant_id_normalized_email_address",
                table: "AbpUsers",
                newName: "IX_AbpUsers_TenantId_NormalizedEmailAddress");

            migrationBuilder.RenameIndex(
                name: "IX_AbpUsers_last_modifier_user_id",
                table: "AbpUsers",
                newName: "IX_AbpUsers_LastModifierUserId");

            migrationBuilder.RenameIndex(
                name: "IX_AbpUsers_deleter_user_id",
                table: "AbpUsers",
                newName: "IX_AbpUsers_DeleterUserId");

            migrationBuilder.RenameIndex(
                name: "IX_AbpUsers_creator_user_id",
                table: "AbpUsers",
                newName: "IX_AbpUsers_CreatorUserId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "AbpTenants",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "AbpTenants",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "tenancy_name",
                table: "AbpTenants",
                newName: "TenancyName");

            migrationBuilder.RenameColumn(
                name: "last_modifier_user_id",
                table: "AbpTenants",
                newName: "LastModifierUserId");

            migrationBuilder.RenameColumn(
                name: "modified_time",
                table: "AbpTenants",
                newName: "LastModificationTime");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "AbpTenants",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "is_active",
                table: "AbpTenants",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "edition_id",
                table: "AbpTenants",
                newName: "EditionId");

            migrationBuilder.RenameColumn(
                name: "deleted_time",
                table: "AbpTenants",
                newName: "DeletionTime");

            migrationBuilder.RenameColumn(
                name: "deleter_user_id",
                table: "AbpTenants",
                newName: "DeleterUserId");

            migrationBuilder.RenameColumn(
                name: "creator_user_id",
                table: "AbpTenants",
                newName: "CreatorUserId");

            migrationBuilder.RenameColumn(
                name: "create_time",
                table: "AbpTenants",
                newName: "CreationTime");

            migrationBuilder.RenameColumn(
                name: "connection_string",
                table: "AbpTenants",
                newName: "ConnectionString");

            migrationBuilder.RenameIndex(
                name: "IX_AbpTenants_tenancy_name",
                table: "AbpTenants",
                newName: "IX_AbpTenants_TenancyName");

            migrationBuilder.RenameIndex(
                name: "IX_AbpTenants_last_modifier_user_id",
                table: "AbpTenants",
                newName: "IX_AbpTenants_LastModifierUserId");

            migrationBuilder.RenameIndex(
                name: "IX_AbpTenants_edition_id",
                table: "AbpTenants",
                newName: "IX_AbpTenants_EditionId");

            migrationBuilder.RenameIndex(
                name: "IX_AbpTenants_deleter_user_id",
                table: "AbpTenants",
                newName: "IX_AbpTenants_DeleterUserId");

            migrationBuilder.RenameIndex(
                name: "IX_AbpTenants_creator_user_id",
                table: "AbpTenants",
                newName: "IX_AbpTenants_CreatorUserId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "AbpRoles",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "AbpRoles",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "tenant_id",
                table: "AbpRoles",
                newName: "TenantId");

            migrationBuilder.RenameColumn(
                name: "normalized_name",
                table: "AbpRoles",
                newName: "NormalizedName");

            migrationBuilder.RenameColumn(
                name: "last_modifier_user_id",
                table: "AbpRoles",
                newName: "LastModifierUserId");

            migrationBuilder.RenameColumn(
                name: "modified_time",
                table: "AbpRoles",
                newName: "LastModificationTime");

            migrationBuilder.RenameColumn(
                name: "is_static",
                table: "AbpRoles",
                newName: "IsStatic");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "AbpRoles",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "is_default",
                table: "AbpRoles",
                newName: "IsDefault");

            migrationBuilder.RenameColumn(
                name: "display_name",
                table: "AbpRoles",
                newName: "DisplayName");

            migrationBuilder.RenameColumn(
                name: "deleted_time",
                table: "AbpRoles",
                newName: "DeletionTime");

            migrationBuilder.RenameColumn(
                name: "deleter_user_id",
                table: "AbpRoles",
                newName: "DeleterUserId");

            migrationBuilder.RenameColumn(
                name: "creator_user_id",
                table: "AbpRoles",
                newName: "CreatorUserId");

            migrationBuilder.RenameColumn(
                name: "create_time",
                table: "AbpRoles",
                newName: "CreationTime");

            migrationBuilder.RenameColumn(
                name: "concurrency_stamp",
                table: "AbpRoles",
                newName: "ConcurrencyStamp");

            migrationBuilder.RenameIndex(
                name: "IX_AbpRoles_tenant_id_normalized_name",
                table: "AbpRoles",
                newName: "IX_AbpRoles_TenantId_NormalizedName");

            migrationBuilder.RenameIndex(
                name: "IX_AbpRoles_last_modifier_user_id",
                table: "AbpRoles",
                newName: "IX_AbpRoles_LastModifierUserId");

            migrationBuilder.RenameIndex(
                name: "IX_AbpRoles_deleter_user_id",
                table: "AbpRoles",
                newName: "IX_AbpRoles_DeleterUserId");

            migrationBuilder.RenameIndex(
                name: "IX_AbpRoles_creator_user_id",
                table: "AbpRoles",
                newName: "IX_AbpRoles_CreatorUserId");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "AbpUsers",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "AbpUsers",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AbpUsers",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AbpUsers",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SecurityStamp",
                table: "AbpUsers",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "AbpUsers",
                maxLength: 32,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PasswordResetCode",
                table: "AbpUsers",
                maxLength: 328,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedUserName",
                table: "AbpUsers",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedEmailAddress",
                table: "AbpUsers",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmailConfirmationCode",
                table: "AbpUsers",
                maxLength: 328,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                table: "AbpUsers",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                table: "AbpUsers",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AuthenticationSource",
                table: "AbpUsers",
                maxLength: 64,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AbpTenants",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenancyName",
                table: "AbpTenants",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConnectionString",
                table: "AbpTenants",
                maxLength: 1024,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AbpRoles",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedName",
                table: "AbpRoles",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                table: "AbpRoles",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                table: "AbpRoles",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpRoles_AbpUsers_CreatorUserId",
                table: "AbpRoles",
                column: "CreatorUserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpRoles_AbpUsers_DeleterUserId",
                table: "AbpRoles",
                column: "DeleterUserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpRoles_AbpUsers_LastModifierUserId",
                table: "AbpRoles",
                column: "LastModifierUserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpTenants_AbpUsers_CreatorUserId",
                table: "AbpTenants",
                column: "CreatorUserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpTenants_AbpUsers_DeleterUserId",
                table: "AbpTenants",
                column: "DeleterUserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpTenants_AbpEditions_EditionId",
                table: "AbpTenants",
                column: "EditionId",
                principalTable: "AbpEditions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpTenants_AbpUsers_LastModifierUserId",
                table: "AbpTenants",
                column: "LastModifierUserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUsers_AbpUsers_CreatorUserId",
                table: "AbpUsers",
                column: "CreatorUserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUsers_AbpUsers_DeleterUserId",
                table: "AbpUsers",
                column: "DeleterUserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUsers_AbpUsers_LastModifierUserId",
                table: "AbpUsers",
                column: "LastModifierUserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

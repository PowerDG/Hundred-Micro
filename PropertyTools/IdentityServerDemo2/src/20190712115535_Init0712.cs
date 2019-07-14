using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Research.Migrations
{
    public partial class Init0712 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
            name: "AbpAuditLogs",
            columns: table => new
            {
                id = table.Column<long>(nullable: false)
            .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                tenant_id = table.Column<int>(nullable: true),
                user_id = table.Column<long>(nullable: true),
                service_name = table.Column<string>(maxLength: 256, nullable: true),
                method_name = table.Column<string>(maxLength: 256, nullable: true),
                parameters = table.Column<string>(maxLength: 1024, nullable: true),
                return_value = table.Column<string>(nullable: true),
                execution_time = table.Column<DateTime>(nullable: false),
                execution_duration = table.Column<int>(nullable: false),
                client_ip_address = table.Column<string>(maxLength: 64, nullable: true),
                client_name = table.Column<string>(maxLength: 128, nullable: true),
                browser_info = table.Column<string>(maxLength: 512, nullable: true),
                exception = table.Column<string>(maxLength: 2000, nullable: true),
                impersonator_user_id = table.Column<long>(nullable: true),
                impersonator_tenant_id = table.Column<int>(nullable: true),
                custom_data = table.Column<string>(maxLength: 2000, nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AbpAuditLogs", x => x.id);
            });

            migrationBuilder.CreateTable(
            name: "AbpBackgroundJobs",
            columns: table => new
            {
                id = table.Column<long>(nullable: false)
            .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                create_time = table.Column<DateTime>(nullable: false),
                creator_user_id = table.Column<long>(nullable: true),
                job_type = table.Column<string>(maxLength: 512, nullable: false),
                job_args = table.Column<string>(maxLength: 1048576, nullable: false),
                try_count = table.Column<short>(nullable: false),
                next_try_time = table.Column<DateTime>(nullable: false),
                last_try_time = table.Column<DateTime>(nullable: true),
                is_abandoned = table.Column<bool>(nullable: false),
                priority = table.Column<byte>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AbpBackgroundJobs", x => x.id);
            });

            migrationBuilder.CreateTable(
            name: "AbpEditions",
            columns: table => new
            {
                id = table.Column<int>(nullable: false)
            .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                create_time = table.Column<DateTime>(nullable: false),
                creator_user_id = table.Column<long>(nullable: true),
                modified_time = table.Column<DateTime>(nullable: true),
                last_modifier_user_id = table.Column<long>(nullable: true),
                is_deleted = table.Column<bool>(nullable: false),
                deleter_user_id = table.Column<long>(nullable: true),
                deleted_time = table.Column<DateTime>(nullable: true),
                name = table.Column<string>(maxLength: 32, nullable: false),
                display_name = table.Column<string>(maxLength: 64, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AbpEditions", x => x.id);
            });

            migrationBuilder.CreateTable(
            name: "AbpEntityChangeSets",
            columns: table => new
            {
                id = table.Column<long>(nullable: false)
            .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                browser_info = table.Column<string>(maxLength: 512, nullable: true),
                client_ip_address = table.Column<string>(maxLength: 64, nullable: true),
                client_name = table.Column<string>(maxLength: 128, nullable: true),
                create_time = table.Column<DateTime>(nullable: false),
                extension_data = table.Column<string>(nullable: true),
                impersonator_tenant_id = table.Column<int>(nullable: true),
                impersonator_user_id = table.Column<long>(nullable: true),
                reason = table.Column<string>(maxLength: 256, nullable: true),
                tenant_id = table.Column<int>(nullable: true),
                user_id = table.Column<long>(nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AbpEntityChangeSets", x => x.id);
            });

            migrationBuilder.CreateTable(
            name: "AbpLanguages",
            columns: table => new
            {
                id = table.Column<int>(nullable: false)
            .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                create_time = table.Column<DateTime>(nullable: false),
                creator_user_id = table.Column<long>(nullable: true),
                modified_time = table.Column<DateTime>(nullable: true),
                last_modifier_user_id = table.Column<long>(nullable: true),
                is_deleted = table.Column<bool>(nullable: false),
                deleter_user_id = table.Column<long>(nullable: true),
                deleted_time = table.Column<DateTime>(nullable: true),
                tenant_id = table.Column<int>(nullable: true),
                name = table.Column<string>(maxLength: 10, nullable: false),
                display_name = table.Column<string>(maxLength: 64, nullable: false),
                icon = table.Column<string>(maxLength: 128, nullable: true),
                is_disabled = table.Column<bool>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AbpLanguages", x => x.id);
            });

            migrationBuilder.CreateTable(
            name: "AbpLanguageTexts",
            columns: table => new
            {
                id = table.Column<long>(nullable: false)
            .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                create_time = table.Column<DateTime>(nullable: false),
                creator_user_id = table.Column<long>(nullable: true),
                modified_time = table.Column<DateTime>(nullable: true),
                last_modifier_user_id = table.Column<long>(nullable: true),
                tenant_id = table.Column<int>(nullable: true),
                language_name = table.Column<string>(maxLength: 10, nullable: false),
                source = table.Column<string>(maxLength: 128, nullable: false),
                key = table.Column<string>(maxLength: 256, nullable: false),
                value = table.Column<string>(maxLength: 67108864, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AbpLanguageTexts", x => x.id);
            });

            migrationBuilder.CreateTable(
            name: "AbpNotifications",
            columns: table => new
            {
                id = table.Column<Guid>(nullable: false),
                create_time = table.Column<DateTime>(nullable: false),
                creator_user_id = table.Column<long>(nullable: true),
                notification_name = table.Column<string>(maxLength: 96, nullable: false),
                data = table.Column<string>(maxLength: 1048576, nullable: true),
                data_type_name = table.Column<string>(maxLength: 512, nullable: true),
                entity_type_name = table.Column<string>(maxLength: 250, nullable: true),
                entity_type_assembly_qualified_name = table.Column<string>(maxLength: 512, nullable: true),
                entity_id = table.Column<string>(maxLength: 96, nullable: true),
                severity = table.Column<byte>(nullable: false),
                user_ids = table.Column<string>(maxLength: 131072, nullable: true),
                excluded_user_ids = table.Column<string>(maxLength: 131072, nullable: true),
                tenant_ids = table.Column<string>(maxLength: 131072, nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AbpNotifications", x => x.id);
            });

            migrationBuilder.CreateTable(
            name: "AbpNotificationSubscriptions",
            columns: table => new
            {
                id = table.Column<Guid>(nullable: false),
                create_time = table.Column<DateTime>(nullable: false),
                creator_user_id = table.Column<long>(nullable: true),
                tenant_id = table.Column<int>(nullable: true),
                user_id = table.Column<long>(nullable: false),
                notification_name = table.Column<string>(maxLength: 96, nullable: true),
                entity_type_name = table.Column<string>(maxLength: 250, nullable: true),
                entity_type_assembly_qualified_name = table.Column<string>(maxLength: 512, nullable: true),
                entity_id = table.Column<string>(maxLength: 96, nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AbpNotificationSubscriptions", x => x.id);
            });

            migrationBuilder.CreateTable(
            name: "AbpOrganizationUnitRoles",
            columns: table => new
            {
                id = table.Column<long>(nullable: false)
            .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                create_time = table.Column<DateTime>(nullable: false),
                creator_user_id = table.Column<long>(nullable: true),
                tenant_id = table.Column<int>(nullable: true),
                role_id = table.Column<int>(nullable: false),
                organization_unit_id = table.Column<long>(nullable: false),
                is_deleted = table.Column<bool>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AbpOrganizationUnitRoles", x => x.id);
            });

            migrationBuilder.CreateTable(
            name: "AbpOrganizationUnits",
            columns: table => new
            {
                id = table.Column<long>(nullable: false)
            .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                create_time = table.Column<DateTime>(nullable: false),
                creator_user_id = table.Column<long>(nullable: true),
                modified_time = table.Column<DateTime>(nullable: true),
                last_modifier_user_id = table.Column<long>(nullable: true),
                is_deleted = table.Column<bool>(nullable: false),
                deleter_user_id = table.Column<long>(nullable: true),
                deleted_time = table.Column<DateTime>(nullable: true),
                tenant_id = table.Column<int>(nullable: true),
                parent_id = table.Column<long>(nullable: true),
                code = table.Column<string>(maxLength: 95, nullable: false),
                display_name = table.Column<string>(maxLength: 128, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AbpOrganizationUnits", x => x.id);
                table.ForeignKey(
    name: "FK_AbpOrganizationUnits_AbpOrganizationUnits_ParentId",
    column: x => x.parent_id,
    principalTable: "AbpOrganizationUnits",
    principalColumn: "Id",
    onDelete: ReferentialAction.Restrict);
            });

            migrationBuilder.CreateTable(
            name: "AbpPersistedGrants",
            columns: table => new
            {
                id = table.Column<string>(maxLength: 200, nullable: false),
                type = table.Column<string>(maxLength: 50, nullable: false),
                subject_id = table.Column<string>(maxLength: 200, nullable: true),
                client_id = table.Column<string>(maxLength: 200, nullable: false),
                create_time = table.Column<DateTime>(nullable: false),
                expiration = table.Column<DateTime>(nullable: true),
                data = table.Column<string>(maxLength: 50000, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AbpPersistedGrants", x => x.id);
            });

            migrationBuilder.CreateTable(
            name: "AbpTenantNotifications",
            columns: table => new
            {
                id = table.Column<Guid>(nullable: false),
                create_time = table.Column<DateTime>(nullable: false),
                creator_user_id = table.Column<long>(nullable: true),
                tenant_id = table.Column<int>(nullable: true),
                notification_name = table.Column<string>(maxLength: 96, nullable: false),
                data = table.Column<string>(maxLength: 1048576, nullable: true),
                data_type_name = table.Column<string>(maxLength: 512, nullable: true),
                entity_type_name = table.Column<string>(maxLength: 250, nullable: true),
                entity_type_assembly_qualified_name = table.Column<string>(maxLength: 512, nullable: true),
                entity_id = table.Column<string>(maxLength: 96, nullable: true),
                severity = table.Column<byte>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AbpTenantNotifications", x => x.id);
            });

            migrationBuilder.CreateTable(
            name: "AbpUserAccounts",
            columns: table => new
            {
                id = table.Column<long>(nullable: false)
            .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                create_time = table.Column<DateTime>(nullable: false),
                creator_user_id = table.Column<long>(nullable: true),
                modified_time = table.Column<DateTime>(nullable: true),
                last_modifier_user_id = table.Column<long>(nullable: true),
                is_deleted = table.Column<bool>(nullable: false),
                deleter_user_id = table.Column<long>(nullable: true),
                deleted_time = table.Column<DateTime>(nullable: true),
                tenant_id = table.Column<int>(nullable: true),
                user_id = table.Column<long>(nullable: false),
                user_link_id = table.Column<long>(nullable: true),
                user_name = table.Column<string>(maxLength: 256, nullable: true),
                email_address = table.Column<string>(maxLength: 256, nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AbpUserAccounts", x => x.id);
            });

            migrationBuilder.CreateTable(
            name: "AbpUserLoginAttempts",
            columns: table => new
            {
                id = table.Column<long>(nullable: false)
            .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                tenant_id = table.Column<int>(nullable: true),
                tenancy_name = table.Column<string>(maxLength: 64, nullable: true),
                user_id = table.Column<long>(nullable: true),
                user_name_or_email_address = table.Column<string>(maxLength: 255, nullable: true),
                client_ip_address = table.Column<string>(maxLength: 64, nullable: true),
                client_name = table.Column<string>(maxLength: 128, nullable: true),
                browser_info = table.Column<string>(maxLength: 512, nullable: true),
                result = table.Column<byte>(nullable: false),
                create_time = table.Column<DateTime>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AbpUserLoginAttempts", x => x.id);
            });

            migrationBuilder.CreateTable(
            name: "AbpUserNotifications",
            columns: table => new
            {
                id = table.Column<Guid>(nullable: false),
                tenant_id = table.Column<int>(nullable: true),
                user_id = table.Column<long>(nullable: false),
                tenant_notification_id = table.Column<Guid>(nullable: false),
                state = table.Column<int>(nullable: false),
                create_time = table.Column<DateTime>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AbpUserNotifications", x => x.id);
            });

            migrationBuilder.CreateTable(
            name: "AbpUserOrganizationUnits",
            columns: table => new
            {
                id = table.Column<long>(nullable: false)
            .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                create_time = table.Column<DateTime>(nullable: false),
                creator_user_id = table.Column<long>(nullable: true),
                tenant_id = table.Column<int>(nullable: true),
                user_id = table.Column<long>(nullable: false),
                organization_unit_id = table.Column<long>(nullable: false),
                is_deleted = table.Column<bool>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AbpUserOrganizationUnits", x => x.id);
            });

            migrationBuilder.CreateTable(
            name: "AbpUsers",
            columns: table => new
            {
                id = table.Column<long>(nullable: false)
            .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                create_time = table.Column<DateTime>(nullable: false),
                creator_user_id = table.Column<long>(nullable: true),
                modified_time = table.Column<DateTime>(nullable: true),
                last_modifier_user_id = table.Column<long>(nullable: true),
                is_deleted = table.Column<bool>(nullable: false),
                deleter_user_id = table.Column<long>(nullable: true),
                deleted_time = table.Column<DateTime>(nullable: true),
                authentication_source = table.Column<string>(maxLength: 64, nullable: true),
                user_name = table.Column<string>(maxLength: 256, nullable: false),
                tenant_id = table.Column<int>(nullable: true),
                email_address = table.Column<string>(maxLength: 256, nullable: false),
                name = table.Column<string>(maxLength: 64, nullable: false),
                surname = table.Column<string>(maxLength: 64, nullable: false),
                password = table.Column<string>(maxLength: 128, nullable: false),
                email_confirmation_code = table.Column<string>(maxLength: 328, nullable: true),
                password_reset_code = table.Column<string>(maxLength: 328, nullable: true),
                lockout_end_date_utc = table.Column<DateTime>(nullable: true),
                access_failed_count = table.Column<int>(nullable: false),
                is_lockout_enabled = table.Column<bool>(nullable: false),
                phone_number = table.Column<string>(maxLength: 32, nullable: true),
                is_phone_number_confirmed = table.Column<bool>(nullable: false),
                security_stamp = table.Column<string>(maxLength: 128, nullable: true),
                is_two_factor_enabled = table.Column<bool>(nullable: false),
                is_email_confirmed = table.Column<bool>(nullable: false),
                is_active = table.Column<bool>(nullable: false),
                normalized_user_name = table.Column<string>(maxLength: 256, nullable: false),
                normalized_email_address = table.Column<string>(maxLength: 256, nullable: false),
                concurrency_stamp = table.Column<string>(maxLength: 128, nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AbpUsers", x => x.id);
                table.ForeignKey(
    name: "FK_AbpUsers_AbpUsers_CreatorUserId",
    column: x => x.creator_user_id,
    principalTable: "AbpUsers",
    principalColumn: "Id",
    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
    name: "FK_AbpUsers_AbpUsers_DeleterUserId",
    column: x => x.deleter_user_id,
    principalTable: "AbpUsers",
    principalColumn: "Id",
    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
    name: "FK_AbpUsers_AbpUsers_LastModifierUserId",
    column: x => x.last_modifier_user_id,
    principalTable: "AbpUsers",
    principalColumn: "Id",
    onDelete: ReferentialAction.Restrict);
            });

            migrationBuilder.CreateTable(
            name: "AbpFeatures",
            columns: table => new
            {
                id = table.Column<long>(nullable: false)
            .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                create_time = table.Column<DateTime>(nullable: false),
                creator_user_id = table.Column<long>(nullable: true),
                tenant_id = table.Column<int>(nullable: true),
                name = table.Column<string>(maxLength: 128, nullable: false),
                value = table.Column<string>(maxLength: 2000, nullable: false),
                discriminator = table.Column<string>(nullable: false),
                edition_id = table.Column<int>(nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AbpFeatures", x => x.id);
                table.ForeignKey(
    name: "FK_AbpFeatures_AbpEditions_EditionId",
    column: x => x.edition_id,
    principalTable: "AbpEditions",
    principalColumn: "Id",
    onDelete: ReferentialAction.Cascade);
            });

            migrationBuilder.CreateTable(
            name: "AbpEntityChanges",
            columns: table => new
            {
                id = table.Column<long>(nullable: false)
            .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                change_time = table.Column<DateTime>(nullable: false),
                change_type = table.Column<byte>(nullable: false),
                entity_change_set_id = table.Column<long>(nullable: false),
                entity_id = table.Column<string>(maxLength: 48, nullable: true),
                entity_type_full_name = table.Column<string>(maxLength: 192, nullable: true),
                tenant_id = table.Column<int>(nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AbpEntityChanges", x => x.id);
                table.ForeignKey(
    name: "FK_AbpEntityChanges_AbpEntityChangeSets_EntityChangeSetId",
    column: x => x.entity_change_set_id,
    principalTable: "AbpEntityChangeSets",
    principalColumn: "Id",
    onDelete: ReferentialAction.Cascade);
            });

            migrationBuilder.CreateTable(
            name: "AbpRoles",
            columns: table => new
            {
                id = table.Column<int>(nullable: false)
            .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                create_time = table.Column<DateTime>(nullable: false),
                creator_user_id = table.Column<long>(nullable: true),
                modified_time = table.Column<DateTime>(nullable: true),
                last_modifier_user_id = table.Column<long>(nullable: true),
                is_deleted = table.Column<bool>(nullable: false),
                deleter_user_id = table.Column<long>(nullable: true),
                deleted_time = table.Column<DateTime>(nullable: true),
                tenant_id = table.Column<int>(nullable: true),
                name = table.Column<string>(maxLength: 32, nullable: false),
                display_name = table.Column<string>(maxLength: 64, nullable: false),
                is_static = table.Column<bool>(nullable: false),
                is_default = table.Column<bool>(nullable: false),
                normalized_name = table.Column<string>(maxLength: 32, nullable: false),
                concurrency_stamp = table.Column<string>(maxLength: 128, nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AbpRoles", x => x.id);
                table.ForeignKey(
    name: "FK_AbpRoles_AbpUsers_CreatorUserId",
    column: x => x.creator_user_id,
    principalTable: "AbpUsers",
    principalColumn: "Id",
    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
    name: "FK_AbpRoles_AbpUsers_DeleterUserId",
    column: x => x.deleter_user_id,
    principalTable: "AbpUsers",
    principalColumn: "Id",
    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
    name: "FK_AbpRoles_AbpUsers_LastModifierUserId",
    column: x => x.last_modifier_user_id,
    principalTable: "AbpUsers",
    principalColumn: "Id",
    onDelete: ReferentialAction.Restrict);
            });

            migrationBuilder.CreateTable(
            name: "AbpSettings",
            columns: table => new
            {
                id = table.Column<long>(nullable: false)
            .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                create_time = table.Column<DateTime>(nullable: false),
                creator_user_id = table.Column<long>(nullable: true),
                modified_time = table.Column<DateTime>(nullable: true),
                last_modifier_user_id = table.Column<long>(nullable: true),
                tenant_id = table.Column<int>(nullable: true),
                user_id = table.Column<long>(nullable: true),
                name = table.Column<string>(maxLength: 256, nullable: false),
                value = table.Column<string>(maxLength: 2000, nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AbpSettings", x => x.id);
                table.ForeignKey(
    name: "FK_AbpSettings_AbpUsers_UserId",
    column: x => x.user_id,
    principalTable: "AbpUsers",
    principalColumn: "Id",
    onDelete: ReferentialAction.Restrict);
            });

            migrationBuilder.CreateTable(
            name: "AbpTenants",
            columns: table => new
            {
                id = table.Column<int>(nullable: false)
            .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                create_time = table.Column<DateTime>(nullable: false),
                creator_user_id = table.Column<long>(nullable: true),
                modified_time = table.Column<DateTime>(nullable: true),
                last_modifier_user_id = table.Column<long>(nullable: true),
                is_deleted = table.Column<bool>(nullable: false),
                deleter_user_id = table.Column<long>(nullable: true),
                deleted_time = table.Column<DateTime>(nullable: true),
                tenancy_name = table.Column<string>(maxLength: 64, nullable: false),
                name = table.Column<string>(maxLength: 128, nullable: false),
                connection_string = table.Column<string>(maxLength: 1024, nullable: true),
                is_active = table.Column<bool>(nullable: false),
                edition_id = table.Column<int>(nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AbpTenants", x => x.id);
                table.ForeignKey(
    name: "FK_AbpTenants_AbpUsers_CreatorUserId",
    column: x => x.creator_user_id,
    principalTable: "AbpUsers",
    principalColumn: "Id",
    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
    name: "FK_AbpTenants_AbpUsers_DeleterUserId",
    column: x => x.deleter_user_id,
    principalTable: "AbpUsers",
    principalColumn: "Id",
    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
    name: "FK_AbpTenants_AbpEditions_EditionId",
    column: x => x.edition_id,
    principalTable: "AbpEditions",
    principalColumn: "Id",
    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
    name: "FK_AbpTenants_AbpUsers_LastModifierUserId",
    column: x => x.last_modifier_user_id,
    principalTable: "AbpUsers",
    principalColumn: "Id",
    onDelete: ReferentialAction.Restrict);
            });

            migrationBuilder.CreateTable(
            name: "AbpUserClaims",
            columns: table => new
            {
                id = table.Column<long>(nullable: false)
            .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                create_time = table.Column<DateTime>(nullable: false),
                creator_user_id = table.Column<long>(nullable: true),
                tenant_id = table.Column<int>(nullable: true),
                user_id = table.Column<long>(nullable: false),
                claim_type = table.Column<string>(maxLength: 256, nullable: true),
                claim_value = table.Column<string>(nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AbpUserClaims", x => x.id);
                table.ForeignKey(
    name: "FK_AbpUserClaims_AbpUsers_UserId",
    column: x => x.user_id,
    principalTable: "AbpUsers",
    principalColumn: "Id",
    onDelete: ReferentialAction.Cascade);
            });

            migrationBuilder.CreateTable(
            name: "AbpUserLogins",
            columns: table => new
            {
                id = table.Column<long>(nullable: false)
            .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                tenant_id = table.Column<int>(nullable: true),
                user_id = table.Column<long>(nullable: false),
                login_provider = table.Column<string>(maxLength: 128, nullable: false),
                provider_key = table.Column<string>(maxLength: 256, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AbpUserLogins", x => x.id);
                table.ForeignKey(
    name: "FK_AbpUserLogins_AbpUsers_UserId",
    column: x => x.user_id,
    principalTable: "AbpUsers",
    principalColumn: "Id",
    onDelete: ReferentialAction.Cascade);
            });

            migrationBuilder.CreateTable(
            name: "AbpUserRoles",
            columns: table => new
            {
                id = table.Column<long>(nullable: false)
            .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                create_time = table.Column<DateTime>(nullable: false),
                creator_user_id = table.Column<long>(nullable: true),
                tenant_id = table.Column<int>(nullable: true),
                user_id = table.Column<long>(nullable: false),
                role_id = table.Column<int>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AbpUserRoles", x => x.id);
                table.ForeignKey(
    name: "FK_AbpUserRoles_AbpUsers_UserId",
    column: x => x.user_id,
    principalTable: "AbpUsers",
    principalColumn: "Id",
    onDelete: ReferentialAction.Cascade);
            });

            migrationBuilder.CreateTable(
            name: "AbpUserTokens",
            columns: table => new
            {
                id = table.Column<long>(nullable: false)
            .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                tenant_id = table.Column<int>(nullable: true),
                user_id = table.Column<long>(nullable: false),
                login_provider = table.Column<string>(maxLength: 128, nullable: true),
                name = table.Column<string>(maxLength: 128, nullable: true),
                value = table.Column<string>(maxLength: 512, nullable: true),
                expire_date = table.Column<DateTime>(nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AbpUserTokens", x => x.id);
                table.ForeignKey(
    name: "FK_AbpUserTokens_AbpUsers_UserId",
    column: x => x.user_id,
    principalTable: "AbpUsers",
    principalColumn: "Id",
    onDelete: ReferentialAction.Cascade);
            });

            migrationBuilder.CreateTable(
            name: "AbpEntityPropertyChanges",
            columns: table => new
            {
                id = table.Column<long>(nullable: false)
            .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                entity_change_id = table.Column<long>(nullable: false),
                new_value = table.Column<string>(maxLength: 512, nullable: true),
                original_value = table.Column<string>(maxLength: 512, nullable: true),
                property_name = table.Column<string>(maxLength: 96, nullable: true),
                property_type_full_name = table.Column<string>(maxLength: 192, nullable: true),
                tenant_id = table.Column<int>(nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AbpEntityPropertyChanges", x => x.id);
                table.ForeignKey(
    name: "FK_AbpEntityPropertyChanges_AbpEntityChanges_EntityChangeId",
    column: x => x.entity_change_id,
    principalTable: "AbpEntityChanges",
    principalColumn: "Id",
    onDelete: ReferentialAction.Cascade);
            });

            migrationBuilder.CreateTable(
            name: "AbpPermissions",
            columns: table => new
            {
                id = table.Column<long>(nullable: false)
            .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                create_time = table.Column<DateTime>(nullable: false),
                creator_user_id = table.Column<long>(nullable: true),
                tenant_id = table.Column<int>(nullable: true),
                name = table.Column<string>(maxLength: 128, nullable: false),
                is_granted = table.Column<bool>(nullable: false),
                discriminator = table.Column<string>(nullable: false),
                role_id = table.Column<int>(nullable: true),
                user_id = table.Column<long>(nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AbpPermissions", x => x.id);
                table.ForeignKey(
    name: "FK_AbpPermissions_AbpRoles_RoleId",
    column: x => x.role_id,
    principalTable: "AbpRoles",
    principalColumn: "Id",
    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
    name: "FK_AbpPermissions_AbpUsers_UserId",
    column: x => x.user_id,
    principalTable: "AbpUsers",
    principalColumn: "Id",
    onDelete: ReferentialAction.Cascade);
            });

            migrationBuilder.CreateTable(
            name: "AbpRoleClaims",
            columns: table => new
            {
                id = table.Column<long>(nullable: false)
            .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                create_time = table.Column<DateTime>(nullable: false),
                creator_user_id = table.Column<long>(nullable: true),
                tenant_id = table.Column<int>(nullable: true),
                role_id = table.Column<int>(nullable: false),
                claim_type = table.Column<string>(maxLength: 256, nullable: true),
                claim_value = table.Column<string>(nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AbpRoleClaims", x => x.id);
                table.ForeignKey(
    name: "FK_AbpRoleClaims_AbpRoles_RoleId",
    column: x => x.role_id,
    principalTable: "AbpRoles",
    principalColumn: "Id",
    onDelete: ReferentialAction.Cascade);
            });

            migrationBuilder.CreateIndex(
            name: "IX_AbpAuditLogs_TenantId_ExecutionDuration",
            table: "AbpAuditLogs",
            columns: new[] { "tenant_id", "tenant_id" });

            migrationBuilder.CreateIndex(
            name: "IX_AbpAuditLogs_TenantId_ExecutionTime",
            table: "AbpAuditLogs",
            columns: new[] { "tenant_id", "tenant_id" });

            migrationBuilder.CreateIndex(
            name: "IX_AbpAuditLogs_TenantId_UserId",
            table: "AbpAuditLogs",
            columns: new[] { "tenant_id", "tenant_id" });

            migrationBuilder.CreateIndex(
            name: "IX_AbpBackgroundJobs_IsAbandoned_NextTryTime",
            table: "AbpBackgroundJobs",
            columns: new[] { "is_abandoned", "is_abandoned" });

            migrationBuilder.CreateIndex(
            name: "IX_AbpEntityChanges_EntityChangeSetId",
            table: "AbpEntityChanges",
            column: "EntityChangeSetId");

            migrationBuilder.CreateIndex(
            name: "IX_AbpEntityChanges_EntityTypeFullName_EntityId",
            table: "AbpEntityChanges",
            columns: new[] { "entity_type_full_name", "entity_type_full_name" });

            migrationBuilder.CreateIndex(
            name: "IX_AbpEntityChangeSets_TenantId_CreationTime",
            table: "AbpEntityChangeSets",
            columns: new[] { "tenant_id", "tenant_id" });

            migrationBuilder.CreateIndex(
            name: "IX_AbpEntityChangeSets_TenantId_Reason",
            table: "AbpEntityChangeSets",
            columns: new[] { "tenant_id", "tenant_id" });

            migrationBuilder.CreateIndex(
            name: "IX_AbpEntityChangeSets_TenantId_UserId",
            table: "AbpEntityChangeSets",
            columns: new[] { "tenant_id", "tenant_id" });

            migrationBuilder.CreateIndex(
            name: "IX_AbpEntityPropertyChanges_EntityChangeId",
            table: "AbpEntityPropertyChanges",
            column: "EntityChangeId");

            migrationBuilder.CreateIndex(
            name: "IX_AbpFeatures_EditionId_Name",
            table: "AbpFeatures",
            columns: new[] { "edition_id", "edition_id" });

            migrationBuilder.CreateIndex(
            name: "IX_AbpFeatures_TenantId_Name",
            table: "AbpFeatures",
            columns: new[] { "tenant_id", "tenant_id" });

            migrationBuilder.CreateIndex(
            name: "IX_AbpLanguages_TenantId_Name",
            table: "AbpLanguages",
            columns: new[] { "tenant_id", "tenant_id" });

            migrationBuilder.CreateIndex(
            name: "IX_AbpLanguageTexts_TenantId_Source_LanguageName_Key",
            table: "AbpLanguageTexts",
            columns: new[] { "tenant_id", "tenant_id", "tenant_id", "tenant_id" });

            migrationBuilder.CreateIndex(
            name: "IX_AbpNotificationSubscriptions_NotificationName_EntityTypeName~",
            table: "AbpNotificationSubscriptions",
            columns: new[] { "notification_name", "notification_name", "notification_name", "notification_name" });

            migrationBuilder.CreateIndex(
            name: "IX_AbpNotificationSubscriptions_TenantId_NotificationName_Entit~",
            table: "AbpNotificationSubscriptions",
            columns: new[] { "tenant_id", "tenant_id", "tenant_id", "tenant_id", "tenant_id" });

            migrationBuilder.CreateIndex(
            name: "IX_AbpOrganizationUnitRoles_TenantId_OrganizationUnitId",
            table: "AbpOrganizationUnitRoles",
            columns: new[] { "tenant_id", "tenant_id" });

            migrationBuilder.CreateIndex(
            name: "IX_AbpOrganizationUnitRoles_TenantId_RoleId",
            table: "AbpOrganizationUnitRoles",
            columns: new[] { "tenant_id", "tenant_id" });

            migrationBuilder.CreateIndex(
            name: "IX_AbpOrganizationUnits_ParentId",
            table: "AbpOrganizationUnits",
            column: "ParentId");

            migrationBuilder.CreateIndex(
            name: "IX_AbpOrganizationUnits_TenantId_Code",
            table: "AbpOrganizationUnits",
            columns: new[] { "tenant_id", "tenant_id" });

            migrationBuilder.CreateIndex(
            name: "IX_AbpPermissions_TenantId_Name",
            table: "AbpPermissions",
            columns: new[] { "tenant_id", "tenant_id" });

            migrationBuilder.CreateIndex(
            name: "IX_AbpPermissions_RoleId",
            table: "AbpPermissions",
            column: "RoleId");

            migrationBuilder.CreateIndex(
            name: "IX_AbpPermissions_UserId",
            table: "AbpPermissions",
            column: "UserId");

            migrationBuilder.CreateIndex(
            name: "IX_AbpPersistedGrants_SubjectId_ClientId_Type",
            table: "AbpPersistedGrants",
            columns: new[] { "subject_id", "subject_id", "subject_id" });

            migrationBuilder.CreateIndex(
            name: "IX_AbpRoleClaims_RoleId",
            table: "AbpRoleClaims",
            column: "RoleId");

            migrationBuilder.CreateIndex(
            name: "IX_AbpRoleClaims_TenantId_ClaimType",
            table: "AbpRoleClaims",
            columns: new[] { "tenant_id", "tenant_id" });

            migrationBuilder.CreateIndex(
            name: "IX_AbpRoles_CreatorUserId",
            table: "AbpRoles",
            column: "CreatorUserId");

            migrationBuilder.CreateIndex(
            name: "IX_AbpRoles_DeleterUserId",
            table: "AbpRoles",
            column: "DeleterUserId");

            migrationBuilder.CreateIndex(
            name: "IX_AbpRoles_LastModifierUserId",
            table: "AbpRoles",
            column: "LastModifierUserId");

            migrationBuilder.CreateIndex(
            name: "IX_AbpRoles_TenantId_NormalizedName",
            table: "AbpRoles",
            columns: new[] { "tenant_id", "tenant_id" });

            migrationBuilder.CreateIndex(
            name: "IX_AbpSettings_UserId",
            table: "AbpSettings",
            column: "UserId");

            migrationBuilder.CreateIndex(
            name: "IX_AbpSettings_TenantId_Name",
            table: "AbpSettings",
            columns: new[] { "tenant_id", "tenant_id" });

            migrationBuilder.CreateIndex(
            name: "IX_AbpTenantNotifications_TenantId",
            table: "AbpTenantNotifications",
            column: "TenantId");

            migrationBuilder.CreateIndex(
            name: "IX_AbpTenants_CreatorUserId",
            table: "AbpTenants",
            column: "CreatorUserId");

            migrationBuilder.CreateIndex(
            name: "IX_AbpTenants_DeleterUserId",
            table: "AbpTenants",
            column: "DeleterUserId");

            migrationBuilder.CreateIndex(
            name: "IX_AbpTenants_EditionId",
            table: "AbpTenants",
            column: "EditionId");

            migrationBuilder.CreateIndex(
            name: "IX_AbpTenants_LastModifierUserId",
            table: "AbpTenants",
            column: "LastModifierUserId");

            migrationBuilder.CreateIndex(
            name: "IX_AbpTenants_TenancyName",
            table: "AbpTenants",
            column: "TenancyName");

            migrationBuilder.CreateIndex(
            name: "IX_AbpUserAccounts_EmailAddress",
            table: "AbpUserAccounts",
            column: "EmailAddress");

            migrationBuilder.CreateIndex(
            name: "IX_AbpUserAccounts_UserName",
            table: "AbpUserAccounts",
            column: "UserName");

            migrationBuilder.CreateIndex(
            name: "IX_AbpUserAccounts_TenantId_EmailAddress",
            table: "AbpUserAccounts",
            columns: new[] { "tenant_id", "tenant_id" });

            migrationBuilder.CreateIndex(
            name: "IX_AbpUserAccounts_TenantId_UserId",
            table: "AbpUserAccounts",
            columns: new[] { "tenant_id", "tenant_id" });

            migrationBuilder.CreateIndex(
            name: "IX_AbpUserAccounts_TenantId_UserName",
            table: "AbpUserAccounts",
            columns: new[] { "tenant_id", "tenant_id" });

            migrationBuilder.CreateIndex(
            name: "IX_AbpUserClaims_UserId",
            table: "AbpUserClaims",
            column: "UserId");

            migrationBuilder.CreateIndex(
            name: "IX_AbpUserClaims_TenantId_ClaimType",
            table: "AbpUserClaims",
            columns: new[] { "tenant_id", "tenant_id" });

            migrationBuilder.CreateIndex(
            name: "IX_AbpUserLoginAttempts_UserId_TenantId",
            table: "AbpUserLoginAttempts",
            columns: new[] { "user_id", "user_id" });

            migrationBuilder.CreateIndex(
            name: "IX_AbpUserLoginAttempts_TenancyName_UserNameOrEmailAddress_Resu~",
            table: "AbpUserLoginAttempts",
            columns: new[] { "tenancy_name", "tenancy_name", "tenancy_name" });

            migrationBuilder.CreateIndex(
            name: "IX_AbpUserLogins_UserId",
            table: "AbpUserLogins",
            column: "UserId");

            migrationBuilder.CreateIndex(
            name: "IX_AbpUserLogins_TenantId_UserId",
            table: "AbpUserLogins",
            columns: new[] { "tenant_id", "tenant_id" });

            migrationBuilder.CreateIndex(
            name: "IX_AbpUserLogins_TenantId_LoginProvider_ProviderKey",
            table: "AbpUserLogins",
            columns: new[] { "tenant_id", "tenant_id", "tenant_id" });


        }
    }
}
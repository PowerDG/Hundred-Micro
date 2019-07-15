using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Research.Migrations
{
    public partial class Initial : Migration
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
                        name: "FK_AbpOrganizationUnits_AbpOrganizationUnits_parent_id",
                        column: x => x.parent_id,
                        principalTable: "AbpOrganizationUnits",
                        principalColumn: "id",
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
                        name: "FK_AbpUsers_AbpUsers_creator_user_id",
                        column: x => x.creator_user_id,
                        principalTable: "AbpUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AbpUsers_AbpUsers_deleter_user_id",
                        column: x => x.deleter_user_id,
                        principalTable: "AbpUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AbpUsers_AbpUsers_last_modifier_user_id",
                        column: x => x.last_modifier_user_id,
                        principalTable: "AbpUsers",
                        principalColumn: "id",
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
                    Discriminator = table.Column<string>(nullable: false),
                    EditionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpFeatures", x => x.id);
                    table.ForeignKey(
                        name: "FK_AbpFeatures_AbpEditions_EditionId",
                        column: x => x.EditionId,
                        principalTable: "AbpEditions",
                        principalColumn: "id",
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
                        name: "FK_AbpEntityChanges_AbpEntityChangeSets_entity_change_set_id",
                        column: x => x.entity_change_set_id,
                        principalTable: "AbpEntityChangeSets",
                        principalColumn: "id",
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
                        name: "FK_AbpRoles_AbpUsers_creator_user_id",
                        column: x => x.creator_user_id,
                        principalTable: "AbpUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AbpRoles_AbpUsers_deleter_user_id",
                        column: x => x.deleter_user_id,
                        principalTable: "AbpUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AbpRoles_AbpUsers_last_modifier_user_id",
                        column: x => x.last_modifier_user_id,
                        principalTable: "AbpUsers",
                        principalColumn: "id",
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
                        name: "FK_AbpSettings_AbpUsers_user_id",
                        column: x => x.user_id,
                        principalTable: "AbpUsers",
                        principalColumn: "id",
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
                        name: "FK_AbpTenants_AbpUsers_creator_user_id",
                        column: x => x.creator_user_id,
                        principalTable: "AbpUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AbpTenants_AbpUsers_deleter_user_id",
                        column: x => x.deleter_user_id,
                        principalTable: "AbpUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AbpTenants_AbpEditions_edition_id",
                        column: x => x.edition_id,
                        principalTable: "AbpEditions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AbpTenants_AbpUsers_last_modifier_user_id",
                        column: x => x.last_modifier_user_id,
                        principalTable: "AbpUsers",
                        principalColumn: "id",
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
                        name: "FK_AbpUserClaims_AbpUsers_user_id",
                        column: x => x.user_id,
                        principalTable: "AbpUsers",
                        principalColumn: "id",
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
                        name: "FK_AbpUserLogins_AbpUsers_user_id",
                        column: x => x.user_id,
                        principalTable: "AbpUsers",
                        principalColumn: "id",
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
                        name: "FK_AbpUserRoles_AbpUsers_user_id",
                        column: x => x.user_id,
                        principalTable: "AbpUsers",
                        principalColumn: "id",
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
                        name: "FK_AbpUserTokens_AbpUsers_user_id",
                        column: x => x.user_id,
                        principalTable: "AbpUsers",
                        principalColumn: "id",
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
                        name: "FK_AbpEntityPropertyChanges_AbpEntityChanges_entity_change_id",
                        column: x => x.entity_change_id,
                        principalTable: "AbpEntityChanges",
                        principalColumn: "id",
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
                    Discriminator = table.Column<string>(nullable: false),
                    role_id = table.Column<int>(nullable: true),
                    user_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpPermissions", x => x.id);
                    table.ForeignKey(
                        name: "FK_AbpPermissions_AbpRoles_role_id",
                        column: x => x.role_id,
                        principalTable: "AbpRoles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AbpPermissions_AbpUsers_user_id",
                        column: x => x.user_id,
                        principalTable: "AbpUsers",
                        principalColumn: "id",
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
                        name: "FK_AbpRoleClaims_AbpRoles_role_id",
                        column: x => x.role_id,
                        principalTable: "AbpRoles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbpAuditLogs_tenant_id_execution_duration",
                table: "AbpAuditLogs",
                columns: new[] { "tenant_id", "execution_duration" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpAuditLogs_tenant_id_execution_time",
                table: "AbpAuditLogs",
                columns: new[] { "tenant_id", "execution_time" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpAuditLogs_tenant_id_user_id",
                table: "AbpAuditLogs",
                columns: new[] { "tenant_id", "user_id" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpBackgroundJobs_is_abandoned_next_try_time",
                table: "AbpBackgroundJobs",
                columns: new[] { "is_abandoned", "next_try_time" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpEntityChanges_entity_change_set_id",
                table: "AbpEntityChanges",
                column: "entity_change_set_id");

            migrationBuilder.CreateIndex(
                name: "IX_AbpEntityChanges_entity_type_full_name_entity_id",
                table: "AbpEntityChanges",
                columns: new[] { "entity_type_full_name", "entity_id" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpEntityChangeSets_tenant_id_create_time",
                table: "AbpEntityChangeSets",
                columns: new[] { "tenant_id", "create_time" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpEntityChangeSets_tenant_id_reason",
                table: "AbpEntityChangeSets",
                columns: new[] { "tenant_id", "reason" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpEntityChangeSets_tenant_id_user_id",
                table: "AbpEntityChangeSets",
                columns: new[] { "tenant_id", "user_id" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpEntityPropertyChanges_entity_change_id",
                table: "AbpEntityPropertyChanges",
                column: "entity_change_id");

            migrationBuilder.CreateIndex(
                name: "IX_AbpFeatures_EditionId_name",
                table: "AbpFeatures",
                columns: new[] { "EditionId", "name" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpFeatures_tenant_id_name",
                table: "AbpFeatures",
                columns: new[] { "tenant_id", "name" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpLanguages_tenant_id_name",
                table: "AbpLanguages",
                columns: new[] { "tenant_id", "name" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpLanguageTexts_tenant_id_source_language_name_key",
                table: "AbpLanguageTexts",
                columns: new[] { "tenant_id", "source", "language_name", "key" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpNotificationSubscriptions_notification_name_entity_type_n~",
                table: "AbpNotificationSubscriptions",
                columns: new[] { "notification_name", "entity_type_name", "entity_id", "user_id" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpNotificationSubscriptions_tenant_id_notification_name_ent~",
                table: "AbpNotificationSubscriptions",
                columns: new[] { "tenant_id", "notification_name", "entity_type_name", "entity_id", "user_id" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpOrganizationUnitRoles_tenant_id_organization_unit_id",
                table: "AbpOrganizationUnitRoles",
                columns: new[] { "tenant_id", "organization_unit_id" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpOrganizationUnitRoles_tenant_id_role_id",
                table: "AbpOrganizationUnitRoles",
                columns: new[] { "tenant_id", "role_id" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpOrganizationUnits_parent_id",
                table: "AbpOrganizationUnits",
                column: "parent_id");

            migrationBuilder.CreateIndex(
                name: "IX_AbpOrganizationUnits_tenant_id_code",
                table: "AbpOrganizationUnits",
                columns: new[] { "tenant_id", "code" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpPermissions_tenant_id_name",
                table: "AbpPermissions",
                columns: new[] { "tenant_id", "name" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpPermissions_role_id",
                table: "AbpPermissions",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_AbpPermissions_user_id",
                table: "AbpPermissions",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_AbpPersistedGrants_subject_id_client_id_type",
                table: "AbpPersistedGrants",
                columns: new[] { "subject_id", "client_id", "type" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpRoleClaims_role_id",
                table: "AbpRoleClaims",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_AbpRoleClaims_tenant_id_claim_type",
                table: "AbpRoleClaims",
                columns: new[] { "tenant_id", "claim_type" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpRoles_creator_user_id",
                table: "AbpRoles",
                column: "creator_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_AbpRoles_deleter_user_id",
                table: "AbpRoles",
                column: "deleter_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_AbpRoles_last_modifier_user_id",
                table: "AbpRoles",
                column: "last_modifier_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_AbpRoles_tenant_id_normalized_name",
                table: "AbpRoles",
                columns: new[] { "tenant_id", "normalized_name" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpSettings_user_id",
                table: "AbpSettings",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_AbpSettings_tenant_id_name",
                table: "AbpSettings",
                columns: new[] { "tenant_id", "name" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpTenantNotifications_tenant_id",
                table: "AbpTenantNotifications",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "IX_AbpTenants_creator_user_id",
                table: "AbpTenants",
                column: "creator_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_AbpTenants_deleter_user_id",
                table: "AbpTenants",
                column: "deleter_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_AbpTenants_edition_id",
                table: "AbpTenants",
                column: "edition_id");

            migrationBuilder.CreateIndex(
                name: "IX_AbpTenants_last_modifier_user_id",
                table: "AbpTenants",
                column: "last_modifier_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_AbpTenants_tenancy_name",
                table: "AbpTenants",
                column: "tenancy_name");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserAccounts_email_address",
                table: "AbpUserAccounts",
                column: "email_address");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserAccounts_user_name",
                table: "AbpUserAccounts",
                column: "user_name");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserAccounts_tenant_id_email_address",
                table: "AbpUserAccounts",
                columns: new[] { "tenant_id", "email_address" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserAccounts_tenant_id_user_id",
                table: "AbpUserAccounts",
                columns: new[] { "tenant_id", "user_id" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserAccounts_tenant_id_user_name",
                table: "AbpUserAccounts",
                columns: new[] { "tenant_id", "user_name" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserClaims_user_id",
                table: "AbpUserClaims",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserClaims_tenant_id_claim_type",
                table: "AbpUserClaims",
                columns: new[] { "tenant_id", "claim_type" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserLoginAttempts_user_id_tenant_id",
                table: "AbpUserLoginAttempts",
                columns: new[] { "user_id", "tenant_id" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserLoginAttempts_tenancy_name_user_name_or_email_address~",
                table: "AbpUserLoginAttempts",
                columns: new[] { "tenancy_name", "user_name_or_email_address", "result" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserLogins_user_id",
                table: "AbpUserLogins",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserLogins_tenant_id_user_id",
                table: "AbpUserLogins",
                columns: new[] { "tenant_id", "user_id" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserLogins_tenant_id_login_provider_provider_key",
                table: "AbpUserLogins",
                columns: new[] { "tenant_id", "login_provider", "provider_key" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserNotifications_user_id_state_create_time",
                table: "AbpUserNotifications",
                columns: new[] { "user_id", "state", "create_time" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserOrganizationUnits_tenant_id_organization_unit_id",
                table: "AbpUserOrganizationUnits",
                columns: new[] { "tenant_id", "organization_unit_id" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserOrganizationUnits_tenant_id_user_id",
                table: "AbpUserOrganizationUnits",
                columns: new[] { "tenant_id", "user_id" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserRoles_user_id",
                table: "AbpUserRoles",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserRoles_tenant_id_role_id",
                table: "AbpUserRoles",
                columns: new[] { "tenant_id", "role_id" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserRoles_tenant_id_user_id",
                table: "AbpUserRoles",
                columns: new[] { "tenant_id", "user_id" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_creator_user_id",
                table: "AbpUsers",
                column: "creator_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_deleter_user_id",
                table: "AbpUsers",
                column: "deleter_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_last_modifier_user_id",
                table: "AbpUsers",
                column: "last_modifier_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_tenant_id_normalized_email_address",
                table: "AbpUsers",
                columns: new[] { "tenant_id", "normalized_email_address" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_tenant_id_normalized_user_name",
                table: "AbpUsers",
                columns: new[] { "tenant_id", "normalized_user_name" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserTokens_user_id",
                table: "AbpUserTokens",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserTokens_tenant_id_user_id",
                table: "AbpUserTokens",
                columns: new[] { "tenant_id", "user_id" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbpAuditLogs");

            migrationBuilder.DropTable(
                name: "AbpBackgroundJobs");

            migrationBuilder.DropTable(
                name: "AbpEntityPropertyChanges");

            migrationBuilder.DropTable(
                name: "AbpFeatures");

            migrationBuilder.DropTable(
                name: "AbpLanguages");

            migrationBuilder.DropTable(
                name: "AbpLanguageTexts");

            migrationBuilder.DropTable(
                name: "AbpNotifications");

            migrationBuilder.DropTable(
                name: "AbpNotificationSubscriptions");

            migrationBuilder.DropTable(
                name: "AbpOrganizationUnitRoles");

            migrationBuilder.DropTable(
                name: "AbpOrganizationUnits");

            migrationBuilder.DropTable(
                name: "AbpPermissions");

            migrationBuilder.DropTable(
                name: "AbpPersistedGrants");

            migrationBuilder.DropTable(
                name: "AbpRoleClaims");

            migrationBuilder.DropTable(
                name: "AbpSettings");

            migrationBuilder.DropTable(
                name: "AbpTenantNotifications");

            migrationBuilder.DropTable(
                name: "AbpTenants");

            migrationBuilder.DropTable(
                name: "AbpUserAccounts");

            migrationBuilder.DropTable(
                name: "AbpUserClaims");

            migrationBuilder.DropTable(
                name: "AbpUserLoginAttempts");

            migrationBuilder.DropTable(
                name: "AbpUserLogins");

            migrationBuilder.DropTable(
                name: "AbpUserNotifications");

            migrationBuilder.DropTable(
                name: "AbpUserOrganizationUnits");

            migrationBuilder.DropTable(
                name: "AbpUserRoles");

            migrationBuilder.DropTable(
                name: "AbpUserTokens");

            migrationBuilder.DropTable(
                name: "AbpEntityChanges");

            migrationBuilder.DropTable(
                name: "AbpRoles");

            migrationBuilder.DropTable(
                name: "AbpEditions");

            migrationBuilder.DropTable(
                name: "AbpEntityChangeSets");

            migrationBuilder.DropTable(
                name: "AbpUsers");
        }
    }
}

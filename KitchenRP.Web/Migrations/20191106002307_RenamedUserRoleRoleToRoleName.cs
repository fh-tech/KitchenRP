using System.Text.Json;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KitchenRP.Web.Migrations
{
    public partial class RenamedUserRoleRoleToRoleName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reservations_users_owner_id",
                table: "reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_reservations_resources_reserved_resource_id",
                table: "reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_resources_resource_types_resource_type_id",
                table: "resources");

            migrationBuilder.DropForeignKey(
                name: "FK_restrictions_resources_restricted_resource_id",
                table: "restrictions");

            migrationBuilder.DropForeignKey(
                name: "FK_status_changes_reservation_statuses_current_status_id",
                table: "status_changes");

            migrationBuilder.DropForeignKey(
                name: "FK_status_changes_reservation_statuses_previous_status_id",
                table: "status_changes");

            migrationBuilder.DropForeignKey(
                name: "FK_status_changes_reservations_reservation_id",
                table: "status_changes");

            migrationBuilder.DropForeignKey(
                name: "FK_users_user_roles_role_id",
                table: "users");

            migrationBuilder.DropColumn(
                name: "role",
                table: "user_roles");

            migrationBuilder.AlterColumn<string>(
                name: "sub",
                table: "users",
                fixedLength: true,
                maxLength: 8,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character(8)",
                oldFixedLength: true,
                oldMaxLength: 8);

            migrationBuilder.AlterColumn<long>(
                name: "role_id",
                table: "users",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "users",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "role_name",
                table: "user_roles",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "reservation_id",
                table: "status_changes",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "reason",
                table: "status_changes",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<long>(
                name: "previous_status_id",
                table: "status_changes",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "current_status_id",
                table: "status_changes",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "restricted_resource_id",
                table: "restrictions",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "display_error",
                table: "restrictions",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<long>(
                name: "resource_type_id",
                table: "resources",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<JsonDocument>(
                name: "meta_data",
                table: "resources",
                nullable: true,
                oldClrType: typeof(JsonDocument),
                oldType: "jsonb");

            migrationBuilder.AlterColumn<string>(
                name: "display_name",
                table: "resources",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "resources",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "type",
                table: "resource_types",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "display_name",
                table: "resource_types",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<long>(
                name: "reserved_resource_id",
                table: "reservations",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "owner_id",
                table: "reservations",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "reservation_statuses",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "display_name",
                table: "reservation_statuses",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "sub",
                table: "refresh_tokens",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "key",
                table: "refresh_tokens",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_reservations_users_owner_id",
                table: "reservations",
                column: "owner_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_reservations_resources_reserved_resource_id",
                table: "reservations",
                column: "reserved_resource_id",
                principalTable: "resources",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_resources_resource_types_resource_type_id",
                table: "resources",
                column: "resource_type_id",
                principalTable: "resource_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_restrictions_resources_restricted_resource_id",
                table: "restrictions",
                column: "restricted_resource_id",
                principalTable: "resources",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_status_changes_reservation_statuses_current_status_id",
                table: "status_changes",
                column: "current_status_id",
                principalTable: "reservation_statuses",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_status_changes_reservation_statuses_previous_status_id",
                table: "status_changes",
                column: "previous_status_id",
                principalTable: "reservation_statuses",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_status_changes_reservations_reservation_id",
                table: "status_changes",
                column: "reservation_id",
                principalTable: "reservations",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_users_user_roles_role_id",
                table: "users",
                column: "role_id",
                principalTable: "user_roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reservations_users_owner_id",
                table: "reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_reservations_resources_reserved_resource_id",
                table: "reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_resources_resource_types_resource_type_id",
                table: "resources");

            migrationBuilder.DropForeignKey(
                name: "FK_restrictions_resources_restricted_resource_id",
                table: "restrictions");

            migrationBuilder.DropForeignKey(
                name: "FK_status_changes_reservation_statuses_current_status_id",
                table: "status_changes");

            migrationBuilder.DropForeignKey(
                name: "FK_status_changes_reservation_statuses_previous_status_id",
                table: "status_changes");

            migrationBuilder.DropForeignKey(
                name: "FK_status_changes_reservations_reservation_id",
                table: "status_changes");

            migrationBuilder.DropForeignKey(
                name: "FK_users_user_roles_role_id",
                table: "users");

            migrationBuilder.DropColumn(
                name: "role_name",
                table: "user_roles");

            migrationBuilder.AlterColumn<string>(
                name: "sub",
                table: "users",
                type: "character(8)",
                fixedLength: true,
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldFixedLength: true,
                oldMaxLength: 8,
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "role_id",
                table: "users",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "role",
                table: "user_roles",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<long>(
                name: "reservation_id",
                table: "status_changes",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "reason",
                table: "status_changes",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "previous_status_id",
                table: "status_changes",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "current_status_id",
                table: "status_changes",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "restricted_resource_id",
                table: "restrictions",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "display_error",
                table: "restrictions",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "resource_type_id",
                table: "resources",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<JsonDocument>(
                name: "meta_data",
                table: "resources",
                type: "jsonb",
                nullable: false,
                oldClrType: typeof(JsonDocument),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "display_name",
                table: "resources",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "resources",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "type",
                table: "resource_types",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "display_name",
                table: "resource_types",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "reserved_resource_id",
                table: "reservations",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "owner_id",
                table: "reservations",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "reservation_statuses",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "display_name",
                table: "reservation_statuses",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "sub",
                table: "refresh_tokens",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "key",
                table: "refresh_tokens",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_reservations_users_owner_id",
                table: "reservations",
                column: "owner_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reservations_resources_reserved_resource_id",
                table: "reservations",
                column: "reserved_resource_id",
                principalTable: "resources",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_resources_resource_types_resource_type_id",
                table: "resources",
                column: "resource_type_id",
                principalTable: "resource_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_restrictions_resources_restricted_resource_id",
                table: "restrictions",
                column: "restricted_resource_id",
                principalTable: "resources",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_status_changes_reservation_statuses_current_status_id",
                table: "status_changes",
                column: "current_status_id",
                principalTable: "reservation_statuses",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_status_changes_reservation_statuses_previous_status_id",
                table: "status_changes",
                column: "previous_status_id",
                principalTable: "reservation_statuses",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_status_changes_reservations_reservation_id",
                table: "status_changes",
                column: "reservation_id",
                principalTable: "reservations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_users_user_roles_role_id",
                table: "users",
                column: "role_id",
                principalTable: "user_roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

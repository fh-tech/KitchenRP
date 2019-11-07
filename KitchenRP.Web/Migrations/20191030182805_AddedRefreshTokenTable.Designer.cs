﻿// <auto-generated />
using System;
using System.Text.Json;
using KitchenRP.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NodaTime;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace KitchenRP.Web.Migrations
{
    [DbContext(typeof(KitchenRpContext))]
    [Migration("20191030182805_AddedRefreshTokenTable")]
    partial class AddedRefreshTokenTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("KitchenRP.DataAccess.Models.RefreshToken", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<Instant>("Expires")
                        .HasColumnName("expires")
                        .HasColumnType("timestamp");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnName("key")
                        .HasColumnType("text");

                    b.Property<string>("Sub")
                        .IsRequired()
                        .HasColumnName("sub")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("refresh_tokens");
                });

            modelBuilder.Entity("KitchenRP.DataAccess.Models.Reservation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("AllowNotifications")
                        .HasColumnName("allow_notifications")
                        .HasColumnType("boolean");

                    b.Property<Instant>("EndTime")
                        .HasColumnName("end_time")
                        .HasColumnType("timestamp");

                    b.Property<long>("OwnerId")
                        .HasColumnName("owner_id")
                        .HasColumnType("bigint");

                    b.Property<long>("ReservedResourceId")
                        .HasColumnName("reserved_resource_id")
                        .HasColumnType("bigint");

                    b.Property<Instant>("StartTime")
                        .HasColumnName("start_time")
                        .HasColumnType("timestamp");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.HasIndex("ReservedResourceId");

                    b.ToTable("reservations");
                });

            modelBuilder.Entity("KitchenRP.DataAccess.Models.ReservationStatus", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnName("display_name")
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnName("status")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("reservation_statuses");
                });

            modelBuilder.Entity("KitchenRP.DataAccess.Models.Resource", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("description")
                        .HasColumnType("text");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnName("display_name")
                        .HasColumnType("text");

                    b.Property<JsonDocument>("MetaData")
                        .IsRequired()
                        .HasColumnName("meta_data")
                        .HasColumnType("jsonb");

                    b.Property<long>("ResourceTypeId")
                        .HasColumnName("resource_type_id")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ResourceTypeId");

                    b.ToTable("resources");
                });

            modelBuilder.Entity("KitchenRP.DataAccess.Models.ResourceType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnName("display_name")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnName("type")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("resource_types");
                });

            modelBuilder.Entity("KitchenRP.DataAccess.Models.Restriction", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("DisplayError")
                        .IsRequired()
                        .HasColumnName("display_error")
                        .HasColumnType("text");

                    b.Property<bool>("IgnoreYear")
                        .HasColumnName("ignore_year")
                        .HasColumnType("boolean");

                    b.Property<Instant>("RestrictFrom")
                        .HasColumnName("restrict_from")
                        .HasColumnType("timestamp");

                    b.Property<Instant>("RestrictTo")
                        .HasColumnName("restrict_to")
                        .HasColumnType("timestamp");

                    b.Property<long>("RestrictedResourceId")
                        .HasColumnName("restricted_resource_id")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RestrictedResourceId");

                    b.ToTable("restrictions");
                });

            modelBuilder.Entity("KitchenRP.DataAccess.Models.RestrictionData", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("MaxUsagePerMonthInHours")
                        .HasColumnName("max_usage_per_month_in_hours")
                        .HasColumnType("integer");

                    b.Property<int?>("MaxUsagePerWeekInCount")
                        .HasColumnName("max_usage_per_week_in_count")
                        .HasColumnType("integer");

                    b.Property<long>("RestrictionId")
                        .HasColumnName("restriction_id")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RestrictionId")
                        .IsUnique();

                    b.ToTable("restriction_data");
                });

            modelBuilder.Entity("KitchenRP.DataAccess.Models.StatusChange", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long?>("ChangeByUserId")
                        .HasColumnName("change_by_user_id")
                        .HasColumnType("bigint");

                    b.Property<Instant>("ChangedAt")
                        .HasColumnName("changed_at")
                        .HasColumnType("timestamp");

                    b.Property<long>("CurrentStatusId")
                        .HasColumnName("current_status_id")
                        .HasColumnType("bigint");

                    b.Property<long>("PreviousStatusID")
                        .HasColumnName("previous_status_id")
                        .HasColumnType("bigint");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnName("reason")
                        .HasColumnType("text");

                    b.Property<long>("ReservationId")
                        .HasColumnName("reservation_id")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ChangeByUserId");

                    b.HasIndex("CurrentStatusId");

                    b.HasIndex("PreviousStatusID");

                    b.HasIndex("ReservationId");

                    b.ToTable("status_changes");
                });

            modelBuilder.Entity("KitchenRP.DataAccess.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("AllowNotifications")
                        .HasColumnName("allow_notifications")
                        .HasColumnType("boolean");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasColumnType("text");

                    b.Property<long>("RoleId")
                        .HasColumnName("role_id")
                        .HasColumnType("bigint");

                    b.Property<string>("Sub")
                        .IsRequired()
                        .HasColumnName("sub")
                        .HasColumnType("character(8)")
                        .IsFixedLength(true)
                        .HasMaxLength(8);

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("KitchenRP.DataAccess.Models.UserRole", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnName("role")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("user_roles");
                });

            modelBuilder.Entity("KitchenRP.DataAccess.Models.Reservation", b =>
                {
                    b.HasOne("KitchenRP.DataAccess.Models.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KitchenRP.DataAccess.Models.Resource", "ReservedResource")
                        .WithMany()
                        .HasForeignKey("ReservedResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KitchenRP.DataAccess.Models.Resource", b =>
                {
                    b.HasOne("KitchenRP.DataAccess.Models.ResourceType", "ResourceType")
                        .WithMany()
                        .HasForeignKey("ResourceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KitchenRP.DataAccess.Models.Restriction", b =>
                {
                    b.HasOne("KitchenRP.DataAccess.Models.Resource", "RestrictedResource")
                        .WithMany()
                        .HasForeignKey("RestrictedResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KitchenRP.DataAccess.Models.RestrictionData", b =>
                {
                    b.HasOne("KitchenRP.DataAccess.Models.Restriction", null)
                        .WithOne("Data")
                        .HasForeignKey("KitchenRP.DataAccess.Models.RestrictionData", "RestrictionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KitchenRP.DataAccess.Models.StatusChange", b =>
                {
                    b.HasOne("KitchenRP.DataAccess.Models.User", "ChangedBy")
                        .WithMany()
                        .HasForeignKey("ChangeByUserId");

                    b.HasOne("KitchenRP.DataAccess.Models.ReservationStatus", "CurrentStatus")
                        .WithMany()
                        .HasForeignKey("CurrentStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KitchenRP.DataAccess.Models.ReservationStatus", "PreviousStatus")
                        .WithMany()
                        .HasForeignKey("PreviousStatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KitchenRP.DataAccess.Models.Reservation", "Reservation")
                        .WithMany()
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KitchenRP.DataAccess.Models.User", b =>
                {
                    b.HasOne("KitchenRP.DataAccess.Models.UserRole", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

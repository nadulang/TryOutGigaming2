﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NotificationService.Infrastructure.Persistences;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace NotificationService.Migrations
{
    [DbContext(typeof(NotificationContext))]
    partial class NotificationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("NotificationService.Domain.Entities.NotificationLogsModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("created_at")
                        .HasColumnType("bigint");

                    b.Property<string>("email_destination")
                        .HasColumnType("text");

                    b.Property<int>("from")
                        .HasColumnType("integer");

                    b.Property<int>("notification_id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("read_at")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("target")
                        .HasColumnType("integer");

                    b.Property<string>("type")
                        .HasColumnType("text");

                    b.Property<long>("updated_at")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.HasIndex("notification_id");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("NotificationService.Domain.Entities.NotificationModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("created_at")
                        .HasColumnType("bigint");

                    b.Property<string>("message")
                        .HasColumnType("text");

                    b.Property<string>("title")
                        .HasColumnType("text");

                    b.Property<long>("updated_at")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("NotificationService.Domain.Entities.NotificationLogsModel", b =>
                {
                    b.HasOne("NotificationService.Domain.Entities.NotificationModel", "notification")
                        .WithMany()
                        .HasForeignKey("notification_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

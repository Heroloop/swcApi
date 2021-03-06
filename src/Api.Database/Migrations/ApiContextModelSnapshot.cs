﻿// <auto-generated />
using Api.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Api.Database.Migrations
{
    [DbContext(typeof(ApiContext))]
    partial class ApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("swc")
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Api.Database.Entity.Threats.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description")
                        .HasMaxLength(255);

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.HasKey("Id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("Api.Database.Entity.Threats.Threat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Host");

                    b.Property<string>("Identifier")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasComputedColumnSql("CONCAT('swc-',[Id])");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Protocol");

                    b.Property<string>("QueryString");

                    b.Property<string>("Referer")
                        .HasMaxLength(255);

                    b.Property<int>("StatusId");

                    b.Property<int>("TypeId");

                    b.Property<string>("UserAgent");

                    b.Property<string>("XForwardHost");

                    b.Property<string>("XForwardProto");

                    b.HasKey("Id");

                    b.HasIndex("Referer")
                        .IsUnique()
                        .HasFilter("[Referer] IS NOT NULL");

                    b.HasIndex("StatusId");

                    b.HasIndex("TypeId");

                    b.ToTable("Threats");
                });

            modelBuilder.Entity("Api.Database.Entity.Threats.ThreatType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Type");
                });

            modelBuilder.Entity("Api.Database.Entity.Threats.Threat", b =>
                {
                    b.HasOne("Api.Database.Entity.Threats.Status", "Status")
                        .WithMany("Threats")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Api.Database.Entity.Threats.ThreatType", "ThreatType")
                        .WithMany("Threats")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

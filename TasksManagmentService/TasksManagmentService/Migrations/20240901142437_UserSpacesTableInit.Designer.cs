﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TasksManagmentService.Data;

#nullable disable

namespace TasksManagmentService.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240901142437_UserSpacesTableInit")]
    partial class UserSpacesTableInit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.33")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TasksManagmentService.Data.Entities.Space", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("creatorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Spaces");
                });

            modelBuilder.Entity("TasksManagmentService.Data.Entities.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SpaceId")
                        .HasColumnType("int");

                    b.Property<bool>("isDefault")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("SpaceId");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("TasksManagmentService.Data.Entities.TaskAssignment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SpaceId")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SpaceId");

                    b.HasIndex("StatusId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("TasksManagmentService.Data.Entities.UserSpaces", b =>
                {
                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SpaceId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.ToTable("UserSpaces");
                });

            modelBuilder.Entity("TasksManagmentService.Data.Entities.Status", b =>
                {
                    b.HasOne("TasksManagmentService.Data.Entities.Space", null)
                        .WithMany("Statuses")
                        .HasForeignKey("SpaceId");
                });

            modelBuilder.Entity("TasksManagmentService.Data.Entities.TaskAssignment", b =>
                {
                    b.HasOne("TasksManagmentService.Data.Entities.Space", null)
                        .WithMany("Tasks")
                        .HasForeignKey("SpaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TasksManagmentService.Data.Entities.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Status");
                });

            modelBuilder.Entity("TasksManagmentService.Data.Entities.Space", b =>
                {
                    b.Navigation("Statuses");

                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
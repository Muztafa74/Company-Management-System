﻿// <auto-generated />
using System;
using Company.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Company.Migrations
{
    [DbContext(typeof(CompanyContext))]
    [Migration("20230924113715_v1")]
    partial class v1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Company.Models.Emp_project", b =>
                {
                    b.Property<int>("emp_id")
                        .HasColumnType("int");

                    b.Property<int?>("proj_id")
                        .HasColumnType("int");

                    b.Property<int?>("workingHours")
                        .HasColumnType("int");

                    b.HasKey("emp_id", "proj_id");

                    b.HasIndex("proj_id");

                    b.ToTable("Emp_Projects");
                });

            modelBuilder.Entity("Company.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Office_id")
                        .HasColumnType("int");

                    b.Property<int?>("Password")
                        .HasColumnType("int");

                    b.Property<float?>("Salary")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("Office_id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Company.Models.Office", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Offices");
                });

            modelBuilder.Entity("Company.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Company.Models.Emp_project", b =>
                {
                    b.HasOne("Company.Models.Employee", "Employee")
                        .WithMany("projects")
                        .HasForeignKey("emp_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Company.Models.Project", "Project")
                        .WithMany("emp_Projects")
                        .HasForeignKey("proj_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Company.Models.Employee", b =>
                {
                    b.HasOne("Company.Models.Office", "office")
                        .WithMany("employees")
                        .HasForeignKey("Office_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("office");
                });

            modelBuilder.Entity("Company.Models.Employee", b =>
                {
                    b.Navigation("projects");
                });

            modelBuilder.Entity("Company.Models.Office", b =>
                {
                    b.Navigation("employees");
                });

            modelBuilder.Entity("Company.Models.Project", b =>
                {
                    b.Navigation("emp_Projects");
                });
#pragma warning restore 612, 618
        }
    }
}

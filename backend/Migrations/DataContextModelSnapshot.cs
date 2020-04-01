﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using backend.Data;

namespace Backend.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("backend.Models.BestPractice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DeptName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Method")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ObjectiveName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Practice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Purpose")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StepNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StepNumber1")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("StepdeptName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("StepobjectiveName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("StepuserId")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("userId");

                    b.HasIndex("StepuserId", "StepdeptName", "StepobjectiveName", "StepNumber1");

                    b.ToTable("BestPractices");
                });

            modelBuilder.Entity("backend.Models.CommonDifficulty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cause")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeptName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Difficulty")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ObjectiveName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Solution")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StepNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StepNumber1")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("StepdeptName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("StepobjectiveName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("StepuserId")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("userId");

                    b.HasIndex("StepuserId", "StepdeptName", "StepobjectiveName", "StepNumber1");

                    b.ToTable("CommonDifficulties");
                });

            modelBuilder.Entity("backend.Models.Department", b =>
                {
                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.Property<string>("DeptName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FuncName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userId", "DeptName");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("backend.Models.Employee", b =>
                {
                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<bool>("CanEdit")
                        .HasColumnType("bit");

                    b.Property<string>("DepartmentDeptName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("DepartmentuserId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("deptName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userId", "EmployeeId");

                    b.HasIndex("DepartmentuserId", "DepartmentDeptName");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("backend.Models.Objective", b =>
                {
                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.Property<string>("deptName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ObjectiveName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Goal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Time")
                        .HasColumnType("int");

                    b.HasKey("userId", "deptName", "ObjectiveName");

                    b.ToTable("Objectives");
                });

            modelBuilder.Entity("backend.Models.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeptName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("EmployeeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ObjectiveName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("userId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("backend.Models.Step", b =>
                {
                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.Property<string>("deptName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("objectiveName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("StepNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Goal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userId", "deptName", "objectiveName", "StepNumber");

                    b.ToTable("Steps");
                });

            modelBuilder.Entity("backend.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeIdIncrement")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("backend.Models.BestPractice", b =>
                {
                    b.HasOne("backend.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Models.Step", null)
                        .WithMany("BestPractice")
                        .HasForeignKey("StepuserId", "StepdeptName", "StepobjectiveName", "StepNumber1");
                });

            modelBuilder.Entity("backend.Models.CommonDifficulty", b =>
                {
                    b.HasOne("backend.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Models.Step", null)
                        .WithMany("CommonDifficulty")
                        .HasForeignKey("StepuserId", "StepdeptName", "StepobjectiveName", "StepNumber1");
                });

            modelBuilder.Entity("backend.Models.Department", b =>
                {
                    b.HasOne("backend.Models.User", "User")
                        .WithMany("Department")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("backend.Models.Employee", b =>
                {
                    b.HasOne("backend.Models.User", "User")
                        .WithMany("Employee")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Models.Department", null)
                        .WithMany("Employee")
                        .HasForeignKey("DepartmentuserId", "DepartmentDeptName");
                });

            modelBuilder.Entity("backend.Models.Objective", b =>
                {
                    b.HasOne("backend.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("backend.Models.Department", "Department")
                        .WithMany("Objective")
                        .HasForeignKey("userId", "deptName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("backend.Models.Schedule", b =>
                {
                    b.HasOne("backend.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("backend.Models.Step", b =>
                {
                    b.HasOne("backend.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("backend.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("userId", "deptName")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("backend.Models.Objective", "Objective")
                        .WithMany("Step")
                        .HasForeignKey("userId", "deptName", "objectiveName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

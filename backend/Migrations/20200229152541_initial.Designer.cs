﻿// <auto-generated />
using System;
using backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace backend.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200229152541_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1");

            modelBuilder.Entity("backend.Models.BestPractice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DeptName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Method")
                        .HasColumnType("TEXT");

                    b.Property<string>("ObjectiveName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Practice")
                        .HasColumnType("TEXT");

                    b.Property<string>("Purpose")
                        .HasColumnType("TEXT");

                    b.Property<string>("StepNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("StepNumber1")
                        .HasColumnType("TEXT");

                    b.Property<string>("StepdeptName")
                        .HasColumnType("TEXT");

                    b.Property<string>("StepobjectiveName")
                        .HasColumnType("TEXT");

                    b.Property<int?>("StepuserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("userId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("userId");

                    b.HasIndex("StepuserId", "StepdeptName", "StepobjectiveName", "StepNumber1");

                    b.ToTable("BestPractices");
                });

            modelBuilder.Entity("backend.Models.CommonDifficulty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cause")
                        .HasColumnType("TEXT");

                    b.Property<string>("DeptName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Difficulty")
                        .HasColumnType("TEXT");

                    b.Property<string>("ObjectiveName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Solution")
                        .HasColumnType("TEXT");

                    b.Property<string>("StepNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("StepNumber1")
                        .HasColumnType("TEXT");

                    b.Property<string>("StepdeptName")
                        .HasColumnType("TEXT");

                    b.Property<string>("StepobjectiveName")
                        .HasColumnType("TEXT");

                    b.Property<int?>("StepuserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("userId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("userId");

                    b.HasIndex("StepuserId", "StepdeptName", "StepobjectiveName", "StepNumber1");

                    b.ToTable("CommonDifficulties");
                });

            modelBuilder.Entity("backend.Models.Department", b =>
                {
                    b.Property<int>("userId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DeptName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Function")
                        .HasColumnType("TEXT");

                    b.HasKey("userId", "DeptName");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("backend.Models.Employee", b =>
                {
                    b.Property<int>("userId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("CanEdit")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DepartmentDeptName")
                        .HasColumnType("TEXT");

                    b.Property<int?>("DepartmentuserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<string>("deptName")
                        .HasColumnType("TEXT");

                    b.HasKey("userId", "EmployeeId");

                    b.HasIndex("DepartmentuserId", "DepartmentDeptName");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("backend.Models.EmployeeIdIncrement", b =>
                {
                    b.Property<int>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("employeeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("userId");

                    b.ToTable("EmployeeIdIncrementors");
                });

            modelBuilder.Entity("backend.Models.Objective", b =>
                {
                    b.Property<int>("userId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("deptName")
                        .HasColumnType("TEXT");

                    b.Property<string>("ObjectiveName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Goal")
                        .HasColumnType("TEXT");

                    b.Property<int>("Time")
                        .HasColumnType("INTEGER");

                    b.HasKey("userId", "deptName", "ObjectiveName");

                    b.ToTable("Objectives");
                });

            modelBuilder.Entity("backend.Models.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("DeptName")
                        .HasColumnType("TEXT");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("EmployeeName")
                        .HasColumnType("TEXT");

                    b.Property<string>("ObjectiveName")
                        .HasColumnType("TEXT");

                    b.Property<int>("userId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("userId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("backend.Models.Step", b =>
                {
                    b.Property<int>("userId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("deptName")
                        .HasColumnType("TEXT");

                    b.Property<string>("objectiveName")
                        .HasColumnType("TEXT");

                    b.Property<string>("StepNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("Goal")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("userId", "deptName", "objectiveName", "StepNumber");

                    b.ToTable("Steps");
                });

            modelBuilder.Entity("backend.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("BLOB");

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

                    b.HasOne("backend.Models.Department", "Department")
                        .WithMany("Employee")
                        .HasForeignKey("DepartmentuserId", "DepartmentDeptName");
                });

            modelBuilder.Entity("backend.Models.Objective", b =>
                {
                    b.HasOne("backend.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
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
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("userId", "deptName")
                        .OnDelete(DeleteBehavior.Cascade)
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

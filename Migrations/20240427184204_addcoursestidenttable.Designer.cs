﻿// <auto-generated />
using MVC_Project_eng_ayman.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVC_Project_eng_ayman.Migrations
{
    [DbContext(typeof(ITIContext))]
    [Migration("20240427184204_addcoursestidenttable")]
    partial class addcoursestidenttable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CourseDepartment", b =>
                {
                    b.Property<int>("CoursesId")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentsDeptId")
                        .HasColumnType("int");

                    b.HasKey("CoursesId", "DepartmentsDeptId");

                    b.HasIndex("DepartmentsDeptId");

                    b.ToTable("CourseDepartment");
                });

            modelBuilder.Entity("MVC_Project_eng_ayman.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Crs_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("MVC_Project_eng_ayman.Models.Department", b =>
                {
                    b.Property<int>("DeptId")
                        .HasColumnType("int");

                    b.Property<string>("DeptName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DeptId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("MVC_Project_eng_ayman.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("DeptNo")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DeptNo");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("MVC_Project_eng_ayman.Models.StudentCourse", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("CrsId")
                        .HasColumnType("int");

                    b.Property<int>("Degree")
                        .HasColumnType("int");

                    b.HasKey("StudentId", "CrsId");

                    b.HasIndex("CrsId");

                    b.ToTable("StudentCourses");
                });

            modelBuilder.Entity("CourseDepartment", b =>
                {
                    b.HasOne("MVC_Project_eng_ayman.Models.Course", null)
                        .WithMany()
                        .HasForeignKey("CoursesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVC_Project_eng_ayman.Models.Department", null)
                        .WithMany()
                        .HasForeignKey("DepartmentsDeptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MVC_Project_eng_ayman.Models.Student", b =>
                {
                    b.HasOne("MVC_Project_eng_ayman.Models.Department", "Department")
                        .WithMany("Students")
                        .HasForeignKey("DeptNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("MVC_Project_eng_ayman.Models.StudentCourse", b =>
                {
                    b.HasOne("MVC_Project_eng_ayman.Models.Course", "Course")
                        .WithMany("CourseStudent")
                        .HasForeignKey("CrsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVC_Project_eng_ayman.Models.Student", "Student")
                        .WithMany("studentCourses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("MVC_Project_eng_ayman.Models.Course", b =>
                {
                    b.Navigation("CourseStudent");
                });

            modelBuilder.Entity("MVC_Project_eng_ayman.Models.Department", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("MVC_Project_eng_ayman.Models.Student", b =>
                {
                    b.Navigation("studentCourses");
                });
#pragma warning restore 612, 618
        }
    }
}

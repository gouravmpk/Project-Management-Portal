﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectManagementPortal.DL;

#nullable disable

namespace ProjectManagementPortal.DL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ProjectManagementPortal.DL.Entities.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentId"), 1L, 1);

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartmentId");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            DepartmentId = 1,
                            DepartmentName = "Software Development"
                        },
                        new
                        {
                            DepartmentId = 2,
                            DepartmentName = "Marketing"
                        },
                        new
                        {
                            DepartmentId = 3,
                            DepartmentName = "Human Resources"
                        },
                        new
                        {
                            DepartmentId = 4,
                            DepartmentName = "Sales"
                        },
                        new
                        {
                            DepartmentId = 5,
                            DepartmentName = "Finance"
                        },
                        new
                        {
                            DepartmentId = 6,
                            DepartmentName = "Quality Assurance"
                        });
                });

            modelBuilder.Entity("ProjectManagementPortal.DL.Entities.Designation", b =>
                {
                    b.Property<int>("DesignationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DesignationId"), 1L, 1);

                    b.Property<string>("DesignationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DesignationId");

                    b.ToTable("Designations");

                    b.HasData(
                        new
                        {
                            DesignationId = 1,
                            DesignationName = "Manager"
                        },
                        new
                        {
                            DesignationId = 2,
                            DesignationName = "Software Engineer"
                        },
                        new
                        {
                            DesignationId = 3,
                            DesignationName = "Marketing Representative"
                        },
                        new
                        {
                            DesignationId = 4,
                            DesignationName = "QA Engineer"
                        },
                        new
                        {
                            DesignationId = 5,
                            DesignationName = "HR Representative"
                        },
                        new
                        {
                            DesignationId = 6,
                            DesignationName = "Sales Representative"
                        },
                        new
                        {
                            DesignationId = 7,
                            DesignationName = "Finance Advisor"
                        });
                });

            modelBuilder.Entity("ProjectManagementPortal.DL.Entities.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectId"), 1L, 1);

                    b.Property<string>("ClientName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("GoalOfProject")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("ProjectDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProjectMasterId")
                        .HasColumnType("int");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TechnologiesUsed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("ProjectId");

                    b.HasIndex("ProjectMasterId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("ProjectManagementPortal.DL.Entities.ProjectAssignment", b =>
                {
                    b.Property<int>("ProjectAssignmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectAssignmentId"), 1L, 1);

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ProjectAssignmentId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("UserId");

                    b.ToTable("ProjectAssigments");
                });

            modelBuilder.Entity("ProjectManagementPortal.DL.Entities.ProjectMaster", b =>
                {
                    b.Property<int>("ProjectMasterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectMasterId"), 1L, 1);

                    b.Property<string>("ProjectStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjectMasterId");

                    b.ToTable("ProjectMasters");

                    b.HasData(
                        new
                        {
                            ProjectMasterId = 1,
                            ProjectStatus = "Proposed"
                        },
                        new
                        {
                            ProjectMasterId = 2,
                            ProjectStatus = "Active"
                        },
                        new
                        {
                            ProjectMasterId = 3,
                            ProjectStatus = "Resolved"
                        });
                });

            modelBuilder.Entity("ProjectManagementPortal.DL.Entities.TaskAssignment", b =>
                {
                    b.Property<int>("TaskAssignmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaskAssignmentId"), 1L, 1);

                    b.Property<int>("TaskId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("TaskAssignmentId");

                    b.HasIndex("TaskId");

                    b.HasIndex("UserId");

                    b.ToTable("TaskAssignments");
                });

            modelBuilder.Entity("ProjectManagementPortal.DL.Entities.TaskMaster", b =>
                {
                    b.Property<int>("TaskMasterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaskMasterId"), 1L, 1);

                    b.Property<string>("TaskStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TaskMasterId");

                    b.ToTable("TaskMasters");

                    b.HasData(
                        new
                        {
                            TaskMasterId = 1,
                            TaskStatus = "To do"
                        },
                        new
                        {
                            TaskMasterId = 2,
                            TaskStatus = "In Progress"
                        },
                        new
                        {
                            TaskMasterId = 3,
                            TaskStatus = "Done"
                        });
                });

            modelBuilder.Entity("ProjectManagementPortal.DL.Entities.Tasks", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaskId"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("TaskDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TaskMasterId")
                        .HasColumnType("int");

                    b.Property<string>("TaskName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("TaskId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("TaskMasterId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("ProjectManagementPortal.DL.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int>("DesignationId")
                        .HasColumnType("int");

                    b.Property<string>("EmailId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("DesignationId");

                    b.HasIndex("EmailId")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ProjectManagementPortal.DL.Entities.Project", b =>
                {
                    b.HasOne("ProjectManagementPortal.DL.Entities.ProjectMaster", "ProjectMaster")
                        .WithMany()
                        .HasForeignKey("ProjectMasterId");

                    b.Navigation("ProjectMaster");
                });

            modelBuilder.Entity("ProjectManagementPortal.DL.Entities.ProjectAssignment", b =>
                {
                    b.HasOne("ProjectManagementPortal.DL.Entities.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectManagementPortal.DL.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProjectManagementPortal.DL.Entities.TaskAssignment", b =>
                {
                    b.HasOne("ProjectManagementPortal.DL.Entities.Tasks", "Tasks")
                        .WithMany()
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectManagementPortal.DL.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tasks");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProjectManagementPortal.DL.Entities.Tasks", b =>
                {
                    b.HasOne("ProjectManagementPortal.DL.Entities.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectManagementPortal.DL.Entities.TaskMaster", "TaskMaster")
                        .WithMany()
                        .HasForeignKey("TaskMasterId");

                    b.Navigation("Project");

                    b.Navigation("TaskMaster");
                });

            modelBuilder.Entity("ProjectManagementPortal.DL.Entities.User", b =>
                {
                    b.HasOne("ProjectManagementPortal.DL.Entities.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectManagementPortal.DL.Entities.Designation", "Designation")
                        .WithMany()
                        .HasForeignKey("DesignationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Designation");
                });
#pragma warning restore 612, 618
        }
    }
}

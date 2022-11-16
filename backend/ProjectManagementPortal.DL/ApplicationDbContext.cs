using Microsoft.EntityFrameworkCore;
using ProjectManagementPortal.DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementPortal.DL
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users  { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<TaskAssignment> TaskAssignments { get; set; }
        public DbSet<ProjectAssignment> ProjectAssigments { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Designation> Designations { get; set; }

        public DbSet<TaskMaster> TaskMasters { get; set; }
        public DbSet<ProjectMaster> ProjectMasters { get; set; }



        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ProjectAssignment>().HasKey(x => new { x.ProjectId, x.UserId });
            builder.Entity<ProjectAssignment>().HasKey(x => new { x.ProjectAssignmentId});
            builder.Entity<TaskAssignment>().HasKey(x => new { x.UserId, x.TaskId });  //Composite Key
            builder.Entity<TaskAssignment>().HasKey(x => new { x.TaskAssignmentId });
            builder.Entity<User>().HasIndex(u => u.EmailId).IsUnique();
           


            SeedData(builder);
            base.OnModelCreating(builder);
        }

        private void SeedData(ModelBuilder builder)
        {
            builder.Entity<Department>().HasData(
                new Department
                {
                    DepartmentId=1,
                    DepartmentName="Software Development"
                },
                new Department
                {
                    DepartmentId = 2,
                    DepartmentName = "Marketing"
                },
                new Department
                {
                    DepartmentId = 3,
                    DepartmentName = "Human Resources"
                },
                new Department
                {
                    DepartmentId = 4,
                    DepartmentName = "Sales"
                },
                new Department
                {
                    DepartmentId = 5,
                    DepartmentName = "Finance"
                },
                new Department
                {
                    DepartmentId = 6,
                    DepartmentName = "Quality Assurance"
                }
                );

            builder.Entity<Designation>().HasData(
                new Designation
                {
                    DesignationId=1,
                    DesignationName="Manager"
                },
                new Designation
                {
                    DesignationId = 2,
                    DesignationName = "Software Engineer"
                },
                new Designation
                {
                    DesignationId = 3,
                    DesignationName = "Marketing Representative"
                },
                new Designation
                {
                    DesignationId = 4,
                    DesignationName = "QA Engineer"
                },
                new Designation
                {
                    DesignationId = 5,
                    DesignationName = "HR Representative"
                },
                new Designation
                {
                    DesignationId = 6,
                    DesignationName = "Sales Representative"
                },
                new Designation
                {
                    DesignationId = 7,
                    DesignationName = "Finance Advisor"
                }
                );

            builder.Entity<ProjectMaster>().HasData(
                new ProjectMaster
                {
                    ProjectMasterId=1,
                    ProjectStatus="Proposed"
                },
                new ProjectMaster
                {
                    ProjectMasterId = 2,
                    ProjectStatus = "Active"
                },
                new ProjectMaster
                {
                    ProjectMasterId = 3,
                    ProjectStatus = "Resolved"
                }
                );

            builder.Entity<TaskMaster>().HasData(
                new TaskMaster
                {
                    TaskMasterId = 1,
                    TaskStatus = "To do"
                },
                new TaskMaster
                {
                    TaskMasterId = 2,
                    TaskStatus = "In Progress"
                },
                new TaskMaster
                {
                    TaskMasterId = 3,
                    TaskStatus = "Done"
                }
                );
        }
    }
}

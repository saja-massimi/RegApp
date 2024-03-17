using Microsoft.EntityFrameworkCore;
using RegApp.Models;

namespace RegApp.Data
{
    public class CompDBcontext:DbContext
    {
        public CompDBcontext(DbContextOptions<CompDBcontext> options) : base(options)
        {

        }

        public DbSet<DepartmentsModel> Departments { get; set; }
        public DbSet<EmployeesModel> Employees { get; set; }
        public DbSet<EmployeesLeaveModel> EmployeesLeave { get; set; }
        public DbSet<JobTitleModel> JobTitle { get; set; }
        public DbSet<LeaveTypeModel> LeaveType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



            modelBuilder.Entity<EmployeesModel>()
                .Property(a => a.Salary)
                .HasColumnType("deciaml(10,2)");



            modelBuilder.Entity<EmployeesModel>()
                .Property(a => a.LeaveBalance)
                .HasColumnType("deciaml(10,2)");

            modelBuilder.Entity<EmployeesModel>()
              .HasOne(e => e.Department)
              .WithMany()
              .HasForeignKey(e => e.DepartmentID);


            modelBuilder.Entity<EmployeesLeaveModel>()
             .HasOne(e => e.leaveType)
             .WithMany()
             .HasForeignKey(e => e.LeaveType);

        }






    }
}

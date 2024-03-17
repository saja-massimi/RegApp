using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegApp.Models
{
    public class EmployeesModel
    {
       

        [Key]
        public int EmpID { get; set; }

        public string? EmpNameEN { get; set; }

        public string? EmpNameAR { get; set; }

        public int ManagerID { get; set; }

        public bool isManger { get; set; }

        public decimal Salary { get; set; }

        public DateTime HireDate { get; set; }

        public string? JobTitle { get; set; }

        public decimal LeaveBalance { get; set; }

        public DateTime empCreated { get; set; }

        public string? empCreatedBy { get; set; }

        public DateTime empModified { get; set; }

        public string? empModifiedBy { get; set; }

        public int DepartmentID { get; set; }     

        [ForeignKey("DepartmentID")]
        public DepartmentsModel? Department { get; set; }
       
    
    }
}

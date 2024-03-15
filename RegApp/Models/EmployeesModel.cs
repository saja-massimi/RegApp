using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegApp.Models
{
    public class EmployeesModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmpID { get; set; }

        public string? EmpNameEN { get; set; }

        public string? EmpNameAR { get; set; }


        [ForeignKey("Manager")]
        public int ManagerID { get; set; }

        public bool isManger { get; set; }

        public decimal Salary { get; set; }

        public DateTime HireDate { get; set; }

        public string? JobTitle { get; set; }

        [ForeignKey("Department")]
        public int DepartmentID { get; set; }

        public decimal LeaveBalance { get; set; }

        public DateTime empCreated { get; set; }

        public string? empCreatedBy { get; set; }

        public DateTime empModified { get; set; }

        public string? empModifiedBy { get; set; }


        //  public DepartmentsModel? dep { get; set; }




        public string? DepartmentNameEN { get; set; }

        public string? DepartmentNameAR { get; set; }

        public DateTime Created { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime Modified { get; set; }

        public string? ModifiedBy { get; set; }



    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegApp.Models
{
    public class EmployeesLeaveModel
    {
        [Key]
        public int ID { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [ForeignKey("ID")]
        public int LeaveTypeID { get; set; }

        public int NumberOfDays { get; set; }

        public string? Notes { get; set; }

        public DateTime Created { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime Modified { get; set; }

        public string? MdifiedBy { get; set; }



        public LeavesTypeModel? LeavesType { get; set; }

    }
}

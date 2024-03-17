using System.ComponentModel.DataAnnotations;

namespace RegApp.Models
{
    public class LeaveTypeModel
    {
        [Key]
        public int ID { get; set; }

        public string? Type { get; set; }

        public int LeaveBalance { get; set; }

        public DateTime Created { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime Modified { get; set; }

        public string? ModifiedBy { get; set; }
    }
}

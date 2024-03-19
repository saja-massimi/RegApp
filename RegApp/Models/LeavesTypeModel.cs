using System.ComponentModel.DataAnnotations;

namespace RegApp.Models
{
    public class LeavesTypeModel
    {
        [Key]
        public int Leave_ID { get; set; }

        public string? Type { get; set; }

        public int LeaveBalance { get; set; }

        public DateTime leaveCreated { get; set; }

        public string? leaveCreatedBy { get; set; }

        public DateTime leaveModified { get; set; }

        public string? leaveModifiedBy { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegApp.Models
{
    public class DepartmentsModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string? DepartmentNameEN { get; set; }

        public string? DepartmentNameAR { get; set; }

        public DateTime Created { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime Modified { get; set; }

        public string? ModifiedBy { get; set; }


    }
}

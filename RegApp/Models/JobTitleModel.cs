using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegApp.Models
{
    public class JobTitleModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string? TitleEn { get; set; }

        public string? TitleAR { get; set; }

        public DateTime Created { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime Modified { get; set; }

        public string? ModifiedBy { get; set; }
    }
}

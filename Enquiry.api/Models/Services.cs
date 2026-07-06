using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Enquiry.api.Models
{
    public class Services
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ServiceId { get; set; }

        public string ServiceName { get; set; } = string.Empty;

        public DateTime CreatedData { get; set; }

        public bool IsActive { get; set; }

        public double Rate {  get; set; }
    }
}

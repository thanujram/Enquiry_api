using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Enquiry.api.Models
{
    public class EnquiryMaster
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EnquiryId { get; set; }

        public string CustomerName  { get; set; } = string.Empty;

        public string MobileNo { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public int ServiceId { get; set; }

        public DateTime EnquiryDate { get; set; }

        public string Status { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;
    }
}

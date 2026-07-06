using Microsoft.EntityFrameworkCore;

namespace Enquiry.api.Models
{
    public class EnquiryDbContext:DbContext
    {
        public EnquiryDbContext(DbContextOptions<EnquiryDbContext> opt):base(opt)
        {

        }

        public DbSet<EnquiryMaster> EnquiryMasters { get; set; }
        public DbSet<Services> Services { get; set; }
    }
}

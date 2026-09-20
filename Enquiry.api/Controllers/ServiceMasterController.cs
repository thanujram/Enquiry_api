using Enquiry.api.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Enquiry.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAngular")]
    public class ServiceMasterController : ControllerBase
    {
        private readonly EnquiryDbContext _context;

        public ServiceMasterController(EnquiryDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Services> getAllServices()
        {
            var services = _context.Services.ToList();
            return services;
        }

        [HttpPost]
        public IActionResult AddNewServices(Services obj)
        {
            _context.Services.Add(obj);
            _context.SaveChanges();
            return Created("Service Created successfully", obj);
        }

        [HttpPut]
        public IActionResult UpdateServices(int ServiceId, Services obj)
        {
            var oldServiceData = _context.Services.SingleOrDefault(x => x.ServiceId == ServiceId);

            if (oldServiceData == null)
            {
                return NotFound("Service Not Found for ID " + ServiceId);
            }
            else
            {
                oldServiceData.ServiceName = obj.ServiceName;
                oldServiceData.IsActive = obj.IsActive;
                _context.SaveChanges();
                return Ok("Service Update Success");
            }
            
        }

        [HttpDelete]
        public IActionResult DeleteServiceById(int ServiceId)
        {
            var ServiceData = _context.Services.SingleOrDefault(x => x.ServiceId.Equals(ServiceId));

            if (ServiceData == null)
            {
                return NotFound("Service Not Found for ID " + ServiceId);
            }
            else
            {
                _context.Services.Remove(ServiceData);
                _context.SaveChanges();
                return Ok("Service Delete Success");
            }
        }
    }
}

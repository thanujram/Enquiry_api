using Enquiry.api.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
[EnableCors("AllowAngular")]
public class EnquiryController : ControllerBase
{
    private readonly EnquiryDbContext _context;
    public EnquiryController(EnquiryDbContext context)
    {
        _context = context;
    }

    // GET: api/EnquiryMaster
    //[HttpGet]
    //public async Task<ActionResult<IEnumerable<EnquiryMaster>>> GetEnquiryMaster()
    //{
    //    return await _context.EnquiryMasters.ToListAsync();
    //}


    // GET: api/EnquiryMaster
    [HttpGet]
    public async Task<ActionResult<IEnumerable<object>>> GetEnquiryMaster() { 
   
        var result = await (from enquiry in _context.EnquiryMasters
                            join service in _context.Services
                            on enquiry.ServiceId equals service.ServiceId
                            select new {
                                enquiry.EnquiryId,
                                enquiry.CustomerName,
                                enquiry.MobileNo,
                                enquiry.City,
                                enquiry.EnquiryDate,
                                enquiry.Status,
                                enquiry.Message,
                                service.ServiceName,
                                service.Rate
                            }).ToListAsync();
        return Ok(result);
    }

    // GET: api/EnquiryMaster/5
    [HttpGet("{enquiryid}")]
    public async Task<ActionResult<EnquiryMaster>> GetEnquiryMaster(int enquiryid)
    {
        var enquirymaster = await _context.EnquiryMasters.FindAsync(enquiryid);

        if (enquirymaster == null)
        {
            return NotFound();
        }

        return enquirymaster;
    }

    // PUT: api/EnquiryMaster/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{enquiryid}")]
    public async Task<IActionResult> PutEnquiryMaster(int? enquiryid, EnquiryMaster enquirymaster)
    {
        if (enquiryid != enquirymaster.EnquiryId)
        {
            return BadRequest();
        }

        _context.Entry(enquirymaster).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EnquiryMasterExists(enquiryid))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/EnquiryMaster
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<EnquiryMaster>> PostEnquiryMaster(EnquiryMaster enquirymaster)
    {
        _context.EnquiryMasters.Add(enquirymaster);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetEnquiryMaster", new { enquiryid = enquirymaster.EnquiryId }, enquirymaster);
    }

    // DELETE: api/EnquiryMaster/5
    [HttpDelete("{enquiryid}")]
    public async Task<IActionResult> DeleteEnquiryMaster(int? enquiryid)
    {
        var enquirymaster = await _context.EnquiryMasters.FindAsync(enquiryid);
        if (enquirymaster == null)
        {
            return NotFound();
        }

        _context.EnquiryMasters.Remove(enquirymaster);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool EnquiryMasterExists(int? enquiryid)
    {
        return _context.EnquiryMasters.Any(e => e.EnquiryId == enquiryid);
    }
}

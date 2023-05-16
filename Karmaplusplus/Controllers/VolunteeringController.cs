using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Karmaplusplus.Models;

namespace Karmaplusplus.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class VolunteeringsController : ControllerBase
  {
    private readonly KarmaplusplusContext _db;

    public VolunteeringsController(KarmaplusplusContext db)
    {
      _db = db;
    }

    // GET: api/volunteerings?page=1&pagesize=20
    [HttpGet]
    public async Task<IActionResult> GetVolunteerings( int id, string userId, string volunteeringName, string description, string email, string location, string zipCode, string date, string time, int page = 1, int pageSize = 10)
    {
      IQueryable<Volunteering> query = _db.Volunteerings.AsQueryable();

      if (userId != null)
      {
        query = query.Where(entry => entry.UserId == userId);
      }
      if (volunteeringName != null)
      {
        query = query.Where(entry => entry.VolunteeringName == volunteeringName);
      }
      if (description != null)
      {
        query = query.Where(entry => entry.Description == description);
      }
      if (email != null)
      {  
        query = query.Where(entry => entry.Email == email);
      }
      if (id != 0)
      {  
        query = query.Where(entry => entry.VolunteeringId  == id);
      }
      if (zipCode != null)
      {
        query = query.Where(entry => entry.ZipCode == zipCode);
      }  
      if (location != null)
      {
        query = query.Where(entry => entry.Location == location);
      }  
      if (date != null)
      {
        query = query.Where(entry => entry.Date == date);
      }  
      if (time != null)
      {
        query = query.Where(entry => entry.Time == time);
      }  
      
        // Calculate the number of items to skip based on the page size and requested page. 
        int skip = (page - 1) * pageSize;

        // Retrieve the data from your data source, applying the pagination parameters.  
        List<Volunteering> volunteerings = await query
            .Skip(skip)
            .Take(pageSize)
            .ToListAsync();

        // Determine the total number of items in your data source.
        int totalCount = _db.Volunteerings.Count();

        // Create a response object to hold the paginated data and total count.
        var response = new
        {
            Data = volunteerings,
            TotalCount = totalCount,
            Page = page,
            PageSize = pageSize
        };

        // Return the paginated data to the client.
        return Ok(response);
    }

    // GET: api/Volunteerings/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Volunteering>> GetVolunteering(int id)
    {
      Volunteering volunteering = await _db.Volunteerings.FindAsync(id);

      if (volunteering == null)
      {
        return NotFound();
      }

      return volunteering;
    }
    
    // POST api/volunteerings
    [HttpPost]
    public async Task<ActionResult<Volunteering>> Post(Volunteering volunteering)
    {
      _db.Volunteerings.Add(volunteering);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetVolunteering), new { id = volunteering.VolunteeringId }, volunteering);
    }

    // PUT: api/volunteerings/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Volunteering volunteering)
    {
      if (id != volunteering.VolunteeringId)
      {
        return BadRequest();
      }

      _db.Volunteerings.Update(volunteering);

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!VolunteeringExists(id))
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

    // DELETE: api/volunteerings/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVolunteering(int id)
    {
      Volunteering Volunteering = await _db.Volunteerings.FindAsync(id);
      if (Volunteering == null)
      {
        return NotFound();
      }

      _db.Volunteerings.Remove(Volunteering);
      await _db.SaveChangesAsync();

      return NoContent();
    }
    private bool VolunteeringExists(int id)
    {
      return _db.Volunteerings.Any(e => e.VolunteeringId == id);
    }
  }
}
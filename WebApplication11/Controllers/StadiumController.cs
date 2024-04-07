using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication11.Data;
using WebApplication11.model;

namespace WebApplication11.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class StadiumController : Controller
    {
        private StadiumAPIDbContext dbContext;

        public StadiumController(StadiumAPIDbContext dbContext)
        {
            this.dbContext = dbContext;

        
        }
        [HttpGet]
        public async Task<IActionResult> GetStadium()
        {
            return Ok( await dbContext.Stadium.ToListAsync());

        }

        [HttpPost]

        public async Task<IActionResult> AddStadiumDetails(AddStadiumRequest addstadiumRequest)
        {
#pragma warning disable CS8601 // Possible null reference assignment.
            var stadium = new Stadium()
            {
                Id = Guid.NewGuid(),
                Gate = addstadiumRequest.Gate,
                TypeName = addstadiumRequest.TypeName,
                numberOfPeople = addstadiumRequest.numberOfPeople,
            };
#pragma warning restore CS8601 // Possible null reference assignment.
            await dbContext.Stadium.AddAsync(stadium);
            await dbContext.SaveChangesAsync();
            return Ok(stadium);

        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateStadiumDetails([FromRoute] Guid id, UpdateStadiumRequest updatestadiumRequest)
        {
            var stadium = await dbContext.Stadium.FindAsync(id);
            if (stadium != null)
            {
                stadium.Gate = updatestadiumRequest.Gate;
                stadium.TypeName = updatestadiumRequest.TypeName;
                stadium.numberOfPeople = updatestadiumRequest.numberOfPeople;
                await dbContext.SaveChangesAsync();
                return Ok(stadium);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteStadiumDetails(Guid id)
        {
            var stadium = await dbContext.Stadium.FindAsync(id);
            if (stadium != null)
            {
                dbContext.Remove(stadium);
                dbContext.SaveChanges();
                return Ok(stadium);
            }
            return NotFound();
        }
    }
}

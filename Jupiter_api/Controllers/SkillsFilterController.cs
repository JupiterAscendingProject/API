using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using Jupiter_api.Models;

namespace Jupiter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsFilterController : ControllerBase
    {
        private readonly CoreDbContext _context;

       

        public SkillsFilterController(CoreDbContext context) => _context = context;
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetSkills()
        {
            return await _context.TrackDetails.Select(t => t.TrackName).ToListAsync();
        }

    }
}

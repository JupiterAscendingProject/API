using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using Jupiter_api.Models;
using Microsoft.Extensions.Caching.Memory;

namespace Jupiter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsFilterController : ControllerBase
    {
        private readonly IMemoryCache _cache;
        private readonly CoreDbContext _context;

        public SkillsFilterController(CoreDbContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetSkills()
        {
            var Skills = await _context.TrackDetails.Select(t => t.TrackName).ToListAsync();
            Cache cache = new Cache(_cache);

            var result = cache.ConfigSetting(Skills);
            return result;
            
           
        }

    }
}

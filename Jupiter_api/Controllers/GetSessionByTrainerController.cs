using Jupiter_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;
using Microsoft.Extensions.Caching.Memory;


namespace Jupiter_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetSessionByTrainerController : ControllerBase
    {
        private readonly CoreDbContext _Context;
        private readonly IMemoryCache _cache;

        public GetSessionByTrainerController(CoreDbContext context, IMemoryCache cache)
        {
            _Context = context;
            _cache = cache;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MainTable>>> GetMainTables()
        {

            
            var maintables = await _Context.MainTables.ToListAsync();
            Cache cache = new Cache(_cache);

            var result = cache.ConfigSetting(maintables);
            return result;
            
        }



        // GET: api/AddMeeting/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MainTable>> GetMainTable(int id)
        {
            var mainTable = await _Context.MainTables.FindAsync(id);

            if (mainTable == null)
            {
                return NotFound();
            }

            return mainTable;
        }


        // GET: api/AddMeeting/Trainerid
        [HttpGet]
        [Route("~/api/TrainerId/MainTable")]
        public async Task<IEnumerable<object>> GettMainTableByTrainerid(int Trainerid)
        {
            var maintables = await _Context.MainTables.Where(b => b.TrainerId == Trainerid).ToListAsync();
            Cache cache = new Cache(_cache);

            var result = cache.ConfigSetting(maintables);
            return result;
            
        }


        // GET: api/AddMeeting/Skillid
        [HttpGet]
        [Route("~/api/SkillId/MainTable")]
        public async Task<IEnumerable<object>> GetMainnTableByModule(int Skillid)
        {
            var maintables = await _Context.MainTables.Where(b => b.Module == Skillid).ToListAsync();
            Cache cache = new Cache(_cache);

            var result = cache.ConfigSetting(maintables);
            return result;
            
        }


        // GET: api/AddMeeting/Trackid
        [HttpGet]
        [Route("~/api/TrackId/MainTable")]
        public async Task<IEnumerable<object>> GetMainTTableByTrackid(int Trackid)
        {
            var maintables = await _Context.MainTables.Where(b => b.Track == Trackid).ToListAsync();
            Cache cache = new Cache(_cache);

            var result = cache.ConfigSetting(maintables);
            return result;
        }

        // PUT: api/AddMeeting/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMainTable(int id, MainTable mainTable)
        {
            if (id != mainTable.SessionId)
            {
                return BadRequest();
            }

            _Context.Entry(mainTable).State = EntityState.Modified;

            try
            {
                await _Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MainTableExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(mainTable);
        }



        // POST: api/AddMeeting
        [HttpPost]
        public async Task<ActionResult<MainTable>> PostMainTable(MainTable mainTable)
        {
            _Context.MainTables.Add(mainTable);
            try
            {
                await _Context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MainTableExists(mainTable.SessionId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMainTable", new { id = mainTable.SessionId }, mainTable);
        }



        // DELETE: api/AddMeeting/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMainTable(int id)
        {
            var mainTable = await _Context.MainTables.FindAsync(id);
            if (mainTable == null)
            {
                return NotFound();
            }

            _Context.MainTables.Remove(mainTable);
            await _Context.SaveChangesAsync();

            return NoContent();
        }

        private bool MainTableExists(int id)
        {
            return _Context.MainTables.Any(e => e.SessionId == id);
        }



    }
}

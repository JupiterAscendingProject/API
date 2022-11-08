using Jupiter_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;

namespace Jupiter_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetSessionByTrainerController : ControllerBase
    {
        private readonly CoreDbContext _Context;

        public GetSessionByTrainerController(CoreDbContext context)
        {
            _Context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MainTable>>> GetMainTables()
        {
            return await _Context.MainTables.ToListAsync();
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
        public async Task<IEnumerable<object>> GettMainTable(int Trainerid)
        {
            return await _Context.MainTables.Where(b => b.TrainerId == Trainerid).ToListAsync();
        }


        // GET: api/AddMeeting/Skillid
        [HttpGet]
        [Route("~/api/SkillId/MainTable")]
        public async Task<IEnumerable<object>> GetMainnTable(int Skillid)
        {
            return await _Context.MainTables.Where(b => b.Module == Skillid).ToListAsync();
        }


        // GET: api/AddMeeting/Trackid
        [HttpGet]
        [Route("~/api/TrackId/MainTable")]
        public async Task<IEnumerable<object>> GetMainTTable(int Trackid)
        {
            return await _Context.MainTables.Where(b => b.Track == Trackid).ToListAsync();
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

            return NoContent();
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

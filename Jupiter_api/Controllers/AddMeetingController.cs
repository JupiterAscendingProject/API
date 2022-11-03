using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Jupiter_api.Models;
using Microsoft.AspNetCore.Authorization;

namespace Jupiter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class AddMeetingController : ControllerBase
    {
        private readonly CoreDbContext _context;

        public AddMeetingController(CoreDbContext context)
        {
            _context = context;
        }

        // GET: api/AddMeeting
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MainTable>>> GetMainTables()
        {
            return await _context.MainTables.ToListAsync();
        }

        // GET: api/AddMeeting/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MainTable>> GetMainTable(int id)
        {
            var mainTable = await _context.MainTables.FindAsync(id);

            if (mainTable == null)
            {
                return NotFound();
            }

            return mainTable;
        }

        // PUT: api/AddMeeting/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMainTable(int id, MainTable mainTable)
        {
            if (id != mainTable.SessionId)
            {
                return BadRequest();
            }

            _context.Entry(mainTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
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
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MainTable>> PostMainTable(MainTable mainTable)
        {
            _context.MainTables.Add(mainTable);
            try
            {
                await _context.SaveChangesAsync();
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
            var mainTable = await _context.MainTables.FindAsync(id);
            if (mainTable == null)
            {
                return NotFound();
            }

            _context.MainTables.Remove(mainTable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MainTableExists(int id)
        {
            return _context.MainTables.Any(e => e.SessionId == id);
        }
    }
}

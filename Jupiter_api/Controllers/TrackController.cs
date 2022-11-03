using Jupiter_api.Models;
using Jupiter_api.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Jupiter_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackController : ControllerBase
    {

        private readonly CoreDbContext _context;

        public TrackController(CoreDbContext context)
        {
            _context = context;
        }


        // Get all tracks
        [HttpGet]
        [Route("GetAllTracks")]
        public async Task<ActionResult<IEnumerable<TrackDetail>>> GetAllTracks()
        {
            return await _context.TrackDetails.ToListAsync();
        }


        // Get track by ID
        //[HttpGet("{id}")]
        //[Route("GetTrackByID")]
        //public async Task<ActionResult<TrackDetail>> GetTrackByID(int id)
        //{
        //    var TrackDetails = await _context.TrackDetails.FindAsync(id);

        //    if (TrackDetails == null)
        //    {
        //        return NotFound();
        //    }

        //    return TrackDetails;
        //}



        // Get modules of a track
        [HttpGet]
        [Route("ModulesOfTrack")]
        public async Task<TrackModuleDto> GetModulesOfTrack(int trackno)
        {
            var TrackDetails = await _context.TrackDetails.FindAsync(trackno);
            List<ModuleDetail> moduleList = new List<ModuleDetail>();
            var ans = _context.TrackModules.Where(t => t.TrackNo == trackno).ToList();
            foreach (var module in ans)
            {
                var ModuleDetails = await _context.ModuleDetails.FindAsync(module.ModuleNo);
                moduleList.Add(ModuleDetails);
            }
            var trackModule = new TrackModuleDto()
            {
                TrackName = TrackDetails.TrackName,
                TrackNo = trackno,
                Modules = moduleList
            };
            return trackModule;
        }



        // add Track
        [HttpPost]
        [Route("AddTrack")]
        public async Task<ActionResult<TrackDetail>> AddTrack(TrackDto track)
        {
            var newTrack = new TrackDetail()
            {
                TrackName = track.TrackName
            };
            _context.TrackDetails.Add(newTrack);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return Conflict();
            }

            return Ok();
        }


        // Delete track by id
        [HttpDelete("DeleteTrackById")]
        public async Task<IActionResult> DeleteTrack(int id)
        {
            var track = await _context.TrackDetails.FindAsync(id);
            if (track == null)
            {
                return NotFound();
            }

            _context.TrackDetails.Remove(track);
            await _context.SaveChangesAsync();

            return Ok("Track deleted successfully");
        }



    }
}

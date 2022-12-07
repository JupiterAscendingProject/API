using Jupiter_api.Models;
using Jupiter_api.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Jupiter_api.Controllers

    // module controller
    // nandinee
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuleController : ControllerBase
    {

        private readonly CoreDbContext _context;

        public ModuleController(CoreDbContext context)
        {
            _context = context;
        }


        // Get all modules
        [HttpGet]
        [Route("GetAllModules")]
        public async Task<ActionResult<IEnumerable<ModuleDetail>>> GetAllModules()
        {
            return await _context.ModuleDetails.ToListAsync();
        }



        // Get module by ID
        [HttpGet("GetModulesByID")]
        public async Task<ActionResult<ModuleDetail>> GetModuleByID(int id)
        {
            var ModuleDetails = await _context.ModuleDetails.FindAsync(id);

            if (ModuleDetails == null)
            {
                return NotFound();
            }

            return ModuleDetails;
        }



        // add module
        [HttpPost]
        [Route("AddModule")]
        public async Task<ActionResult<ModuleDetail>> AddModule(ModuleDto module)
        {
            var newModule = new ModuleDetail()
            {
                ModuleName = module.ModuleName
            };
            _context.ModuleDetails.Add(newModule);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return Conflict();
            }

            return Ok(newModule);
        }



        // Delete module by id
        [HttpDelete("DeleteModuleById")]
        public async Task<IActionResult> DeleteModule(int id)
        {
            var module = await _context.ModuleDetails.FindAsync(id);
            if (module == null)
            {
                return NotFound();
            }

            _context.ModuleDetails.Remove(module);
            await _context.SaveChangesAsync();

            return Ok("Module deleted successfully");
        }

    }
}

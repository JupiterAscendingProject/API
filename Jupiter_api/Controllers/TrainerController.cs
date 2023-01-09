using Jupiter_api.Models;
using Jupiter_api.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Jupiter_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerController : ControllerBase
    {

        private readonly IMemoryCache _cache;
        private readonly CoreDbContext _context;

        public TrainerController(CoreDbContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }


        // GET: All the trainers
        [HttpGet]
        [Route("GetAllTrainers")]
        public async Task<ActionResult<IEnumerable<TrainerDetail>>> GetAllTrainerDetails()
        {
            List<TrainerDetail> TrainersDetails = await _context.TrainerDetails.ToListAsync();
            Cache cache = new Cache(_cache);

            var result = cache.ConfigSetting(TrainersDetails);
            return result;
        }



        // GET: all the details of trainer by id
        [HttpGet("TrainerById")]
        public async Task<ActionResult<TrainerDetail>> GetTrainerDetailById(int id)
        {
            var TrainerDetail = await _context.TrainerDetails.FindAsync(id);

            if (TrainerDetail == null)
            {
                return NotFound();
            }

            return TrainerDetail;
        }



        // POST: Add trainer
        [HttpPost]
        [Route("AddTrainer")]
        public void Post([FromBody] TrainerDetail value)
        {
            _context.TrainerDetails.Add(value);
            _context.SaveChanges();
        }


        // Get trainers by module id
        [HttpGet]
        [Route("trainersOfModule")]
        public async Task<List<TrainerDetail>> GetTrainersOfModule(int moduleno)
        {
            //var TrackDetails = await _context.TrackDetails.FindAsync(moduleno);
            List<TrainerDetail> trarinerList = new List<TrainerDetail>();
            var ans = _context.TrainerModules.Where(t => t.ModuleNo == moduleno).ToList();
            foreach (var trainer in ans)
            {
                var trainerDetails = await _context.TrainerDetails.FindAsync(trainer.EmpId);
                trarinerList.Add(trainerDetails);
            }

            Cache cache = new Cache(_cache);

            var result = cache.ConfigSetting(trarinerList);
            return result;
        }



        // GET: api/TrainerName
        [HttpGet]
        [Route("GetTrainerNames")]
        public async Task<ActionResult<IEnumerable<string>>> GetTrainerNames()
        {
            List<string> TrainerNames = await _context.TrainerDetails.Select(t => t.TrainerName).ToListAsync();
            Cache cache = new Cache(_cache);

            var result = cache.ConfigSetting(TrainerNames);
            return result;
            
        }

        private bool TrainerDetailExists(int id)
        {
            return _context.TrainerDetails.Any(e => e.EmpId == id);
        }
        
        //Get Modules of a Trainer
        [HttpGet]
        [Route("GetTrainerModules")]
        public async Task<IEnumerable<object>> GetTrainerModule(int Trainerid)
        {
            var TrainerNames = await _context.TrainerModules.Where(b => b.EmpId == Trainerid).ToListAsync();
            Cache cache = new Cache(_cache);

            var result = cache.ConfigSetting(TrainerNames);
            return result;
        }
        
        // Get skills of a trainer
        [HttpGet]
        [Route("SkillsOfTrainer")]
        public async Task<TrainerSkillDto> GetSKillsOfTrainer(int trainerId)
        {
            var TrainerDetails = await _context.TrainerDetails.FindAsync(trainerId);
            List<Skill> skillList = new List<Skill>();
            var ans = _context.TrainerSkills.Where(t => t.EmpId == trainerId).ToList();
            foreach (var skill in ans)
            {
                var skillDetails = await _context.Skills.FindAsync(skill.SkillId);
                skillList.Add(skillDetails);
            }
            var trainerskill = new TrainerSkillDto()
            {
                TrainerName = TrainerDetails.TrainerName,
                EmpId = trainerId,
                Skills = skillList
            };
            return trainerskill;
        }

    }
}

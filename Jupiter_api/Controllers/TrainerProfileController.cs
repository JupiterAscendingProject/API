using Jupiter_api.Models;
using Jupiter_api.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jupiter_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerProfileController : ControllerBase
    {
        private readonly CoreDbContext _context;

        public TrainerProfileController(CoreDbContext context)
        {
            _context = context;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<TrainerDetailsDto>> GetTrainerDetail(int id)
        {
            var TrainerDetail = await _context.TrainerDetails.FindAsync(id);
            var TrainerdtoRes = new TrainerDetailsDto()
            {
                EmpId = TrainerDetail.EmpId,
                TrainerName = TrainerDetail.TrainerName,
                TrainerSkills = TrainerDetail.TrainerSkills
            };
            return TrainerdtoRes;
        }
    }
}

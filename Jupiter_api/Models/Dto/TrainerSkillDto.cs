namespace Jupiter_api.Models.Dto
{
    public class TrainerSkillDto
    {
        public int EmpId { get; set; }
        public string TrainerName { get; set; }

        public List<Skill> Skills { get; set; }
    }
}

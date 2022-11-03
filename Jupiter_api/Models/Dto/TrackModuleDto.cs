namespace Jupiter_api.Models.Dto
{
    public class TrackModuleDto
    {
        public int TrackNo { get; set; }
        public string TrackName { get; set; }

        public List<ModuleDetail> Modules { get; set; }
    }
}

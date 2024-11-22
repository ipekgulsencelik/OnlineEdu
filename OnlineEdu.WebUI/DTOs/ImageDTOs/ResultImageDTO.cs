using OnlineEdu.WebUI.DTOs.AboutDTOs;

namespace OnlineEdu.WebUI.DTOs.ImageDTOs
{
    public class ResultImageDTO
    {
        public int ImageID { get; set; }
        public string? Url { get; set; }
        public string? Description { get; set; }
        public int AboutID { get; set; }
        public ResultAboutDTO? About { get; set; }
        public bool IsHome { get; set; }
        public bool Status { get; set; }
    }
}
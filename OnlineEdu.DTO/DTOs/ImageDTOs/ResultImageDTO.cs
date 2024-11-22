using OnlineEdu.DTO.DTOs.AboutDTOs;

namespace OnlineEdu.DTO.DTOs.ImageDTOs
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
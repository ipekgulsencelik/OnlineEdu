namespace OnlineEdu.DTO.DTOs.ImageDTOs
{
    public class UpdateImageDTO
    {
        public int ImageID { get; set; }
        public string? Url { get; set; }
        public string? Description { get; set; }
        public int AboutID { get; set; }
        public bool IsHome { get; set; }
        public bool Status { get; set; }
    }
}
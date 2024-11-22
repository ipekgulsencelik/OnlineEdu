namespace OnlineEdu.WebUI.DTOs.ImageDTOs
{
    public class CreateImageDTO
    {
        public string? Url { get; set; }
        public string? Description { get; set; }
        public int AboutID { get; set; }
        public bool IsHome { get; set; }
        public bool Status { get; set; }
    }
}
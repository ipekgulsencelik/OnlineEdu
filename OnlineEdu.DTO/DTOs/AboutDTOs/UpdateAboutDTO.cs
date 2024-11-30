namespace OnlineEdu.DTO.DTOs.AboutDTOs
{
    public class UpdateAboutDTO
    {
        public int AboutID { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl1 { get; set; }
        public string? ImageUrl2 { get; set; }
        public bool IsShown { get; set; }
    }
}
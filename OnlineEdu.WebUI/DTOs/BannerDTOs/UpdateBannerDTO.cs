namespace OnlineEdu.WebUI.DTOs.BannerDTOs
{
    public class UpdateBannerDTO
    {
        public int BannerID { get; set; }
        public string? Title { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsShown { get; set; }
    }
}
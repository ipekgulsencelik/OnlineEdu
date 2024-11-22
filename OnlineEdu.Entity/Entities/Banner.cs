namespace OnlineEdu.Entity.Entities
{
    public class Banner
    {
        public int BannerID { get; set; }
        public string? Title { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsShown { get; set; }
    }
}
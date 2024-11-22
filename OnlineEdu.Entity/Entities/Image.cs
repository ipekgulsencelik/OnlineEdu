namespace OnlineEdu.Entity.Entities
{
    public class Image
    {
        public int ImageID { get; set; }
        public string? Url { get; set; }
        public string? Description { get; set; }
        public int AboutID { get; set; }
        public About? About { get; set; }
        public bool IsHome { get; set; }
        public bool Status { get; set; }
    }
}
namespace OnlineEdu.Entity.Entities
{
    public class TeacherSocialMedia
    {
        public int TeacherSocialMediaID { get; set; }
        public string? Url { get; set; }
        public string? SocialMediaName { get; set; }
        public string? Icon { get; set; }
        public bool IsShown { get; set; }
        public int TeacherId { get; set; }
        public virtual AppUser Teacher { get; set; }
    }
}
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DTO.DTOs.TeacherSocialMediaDTOs
{
    public class ResultTeacherSocialMediaDTO
    {
        public int TeacherSocialMediaID { get; set; }
        public string? Url { get; set; }
        public string? SocialMediaName { get; set; }
        public string? Icon { get; set; }
        public bool IsShown { get; set; }
        public int TeacherId { get; set; }
        public AppUser Teacher { get; set; }
    }
}
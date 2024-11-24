namespace OnlineEdu.DTO.DTOs.TeacherSocialMediaDTOs
{
    public class CreateTeacherSocialMediaDTO
    {
        public string? Url { get; set; }
        public string? SocialMediaName { get; set; }
        public string? Icon { get; set; }
        public int TeacherId { get; set; }
    }
}
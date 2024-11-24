using OnlineEdu.WebUI.DTOs.TeacherSocialMediaDTOs;

namespace OnlineEdu.WebUI.DTOs.UserDTOs
{
    public class ResultUserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ImageUrl { get; set; }
        public List<ResultTeacherSocialMediaDTO> TeacherSocialMedias { get; set; }
    }
}
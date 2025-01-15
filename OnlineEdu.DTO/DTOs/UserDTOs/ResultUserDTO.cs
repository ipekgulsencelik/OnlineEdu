using OnlineEdu.DTO.DTOs.TeacherSocialMediaDTOs;

namespace OnlineEdu.DTO.DTOs.UserDTOs
{
    public class ResultUserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ImageUrl { get; set; }

        public List<ResultTeacherSocialMediaDTO> TeacherSocialMedias { get; set; }
    }
}
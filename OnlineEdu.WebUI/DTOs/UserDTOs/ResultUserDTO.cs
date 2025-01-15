using OnlineEdu.WebUI.DTOs.BlogDTOs;
using OnlineEdu.WebUI.DTOs.CourseDTOs;
using OnlineEdu.WebUI.DTOs.CourseRegisterDTOs;
using OnlineEdu.WebUI.DTOs.TeacherSocialMediaDTOs;

namespace OnlineEdu.WebUI.DTOs.UserDTOs
{
    public class ResultUserDTO
    {
       public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string? ImageUrl { get; set; }
        public List<ResultTeacherSocialMediaDTO> TeacherSocialMedias { get; set; }
        public List<ResultCourseDTO> Courses { get; set; }
        public List<ResultCourseRegisterDTO> CourseRegisters { get; set; }
        public List<ResultBlogDTO> Blogs { get; set; }
    }
}
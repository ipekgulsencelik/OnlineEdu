using OnlineEdu.WebUI.DTOs.CourseDTOs;
using OnlineEdu.WebUI.DTOs.UserDTOs;

namespace OnlineEdu.WebUI.DTOs.CourseRegisterDTOs
{
    public class UpdateCourseRegisterDTO
    {
        public int CourseRegisterID { get; set; }
        public int AppUserId { get; set; }
        public ResultUserDTO AppUser { get; set; }
        public int CourseID { get; set; }
        public ResultCourseDTO Course { get; set; }
    }
}
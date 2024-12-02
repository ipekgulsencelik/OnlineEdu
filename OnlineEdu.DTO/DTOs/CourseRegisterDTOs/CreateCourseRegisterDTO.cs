using OnlineEdu.DTO.DTOs.CourseDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DTO.DTOs.CourseRegisterDTOs
{
    public class CreateCourseRegisterDTO
    {
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int CourseID { get; set; }
        public ResultCourseDTO Course { get; set; }
    }
}
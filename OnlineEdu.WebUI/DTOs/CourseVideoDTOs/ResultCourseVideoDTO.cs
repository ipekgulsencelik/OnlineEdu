using OnlineEdu.WebUI.DTOs.CourseDTOs;

namespace OnlineEdu.WebUI.DTOs.CourseVideoDTOs
{
    public class ResultCourseVideoDTO
    {
        public int CourseVideoID { get; set; }

        public int CourseID { get; set; }
        public ResultCourseDTO Course { get; set; }

        public int VideoNumber { get; set; }
        public string? VideoUrl { get; set; }
    }
}
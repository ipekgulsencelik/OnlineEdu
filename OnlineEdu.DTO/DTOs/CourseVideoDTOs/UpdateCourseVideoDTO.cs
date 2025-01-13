namespace OnlineEdu.DTO.DTOs.CourseVideoDTOs
{
    public class UpdateCourseVideoDTO
    {
        public int CourseVideoID { get; set; }

        public int CourseID { get; set; }

        public int VideoNumber { get; set; }
        public string? VideoUrl { get; set; }
    }
}
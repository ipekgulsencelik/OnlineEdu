namespace OnlineEdu.DTO.DTOs.CourseVideoDTOs
{
    public class CreateCourseVideoDTO
    {
        public int CourseID { get; set; }
        public int VideoNumber { get; set; }
        public string? VideoUrl { get; set; }
    }
}
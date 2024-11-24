namespace OnlineEdu.WebUI.DTOs.CourseDTOs
{
    public class UpdateCourseDTO
    {
        public int CourseID { get; set; }
        public string? CourseName { get; set; }
        public string? ImageUrl { get; set; }
        public int CourseCategoryID { get; set; }
        public decimal Price { get; set; }
        public bool IsShown { get; set; }
        public int AppUserId { get; set; }
    }
}
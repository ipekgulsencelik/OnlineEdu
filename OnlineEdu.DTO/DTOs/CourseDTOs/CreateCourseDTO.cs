namespace OnlineEdu.DTO.DTOs.CourseDTOs
{
    public class CreateCourseDTO
    {
        public string? CourseName { get; set; }
        public string? ImageUrl { get; set; }
        public int CourseCategoryID { get; set; }
        public int AppUserId { get; set; }
        public decimal Price { get; set; }
        public bool IsShown { get; set; }
    }
}
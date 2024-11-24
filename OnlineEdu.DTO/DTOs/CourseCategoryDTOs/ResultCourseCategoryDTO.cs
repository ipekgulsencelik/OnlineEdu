namespace OnlineEdu.DTO.DTOs.CourseCategoryDTOs
{
    public class ResultCourseCategoryDTO
    {
        public int CourseCategoryID { get; set; }
        public string? Name { get; set; }
        public string? Icon { get; set; }
        public string? Description { get; set; }
        public bool IsShown { get; set; }
        public int AppUserId { get; set; }
    }
}
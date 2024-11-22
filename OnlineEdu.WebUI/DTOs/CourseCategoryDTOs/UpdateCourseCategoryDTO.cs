namespace OnlineEdu.WebUI.DTOs.CourseCategoryDTOs
{
    public class UpdateCourseCategoryDTO
    {
        public int CourseCategoryID { get; set; }
        public string? Name { get; set; }
        public string? Icon { get; set; }
        public string? Description { get; set; }
        public bool IsShown { get; set; }
    }
}
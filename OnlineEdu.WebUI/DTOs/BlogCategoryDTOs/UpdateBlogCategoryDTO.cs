namespace OnlineEdu.WebUI.DTOs.BlogCategoryDTOs
{
    public class UpdateBlogCategoryDTO
    {
        public int BlogCategoryID { get; set; }
        public string? Name { get; set; }
        public bool IsShown { get; set; }
    }
}
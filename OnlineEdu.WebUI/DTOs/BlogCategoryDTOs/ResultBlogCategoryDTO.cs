using OnlineEdu.WebUI.DTOs.BlogDTOs;

namespace OnlineEdu.WebUI.DTOs.BlogCategoryDTOs
{
    public class ResultBlogCategoryDTO
    {
        public int BlogCategoryID { get; set; }
        public string? Name { get; set; }
        public List<ResultBlogDTO>? Blogs { get; set; }
    }
}
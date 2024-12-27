using OnlineEdu.DTO.DTOs.BlogDTOs;

namespace OnlineEdu.DTO.DTOs.BlogCategoryDTOs
{
    public class ResultBlogCategoryDTO
    {
        public int BlogCategoryID { get; set; }
        public string? Name { get; set; }
        public bool IsShown { get; set; }
        public List<ResultBlogDTO>? Blogs { get; set; }
    }
}
namespace OnlineEdu.Entity.Entities
{
    public class BlogCategory
    {
        public int BlogCategoryID { get; set; }
        public string? Name { get; set; }
        public List<Blog>? Blogs { get; set; }
    }
}
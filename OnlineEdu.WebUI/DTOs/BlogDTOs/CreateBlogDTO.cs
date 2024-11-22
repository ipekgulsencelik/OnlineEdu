﻿namespace OnlineEdu.WebUI.DTOs.BlogDTOs
{
    public class CreateBlogDTO
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime BlogDate { get; set; }
        public int BlogCategoryID { get; set; }
    }
}
﻿using OnlineEdu.DTO.DTOs.BlogCategoryDTOs;

namespace OnlineEdu.DTO.DTOs.BlogDTOs
{
    public class ResultBlogDTO
    {
        public int BlogID { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime BlogDate { get; set; }
        public int BlogCategoryID { get; set; }
        public ResultBlogCategoryDTO? BlogCategory { get; set; }
    }
}
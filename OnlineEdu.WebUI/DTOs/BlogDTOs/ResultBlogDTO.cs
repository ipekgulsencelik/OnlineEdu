﻿using OnlineEdu.Entity.Entities;
using OnlineEdu.WebUI.DTOs.BlogCategoryDTOs;

namespace OnlineEdu.WebUI.DTOs.BlogDTOs
{
    public class ResultBlogDTO
    {
        public int BlogID { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime BlogDate { get; set; }
        public bool IsShown { get; set; }
        public int BlogCategoryID { get; set; }
        public ResultBlogCategoryDTO? BlogCategory { get; set; }
        public int WriterId { get; set; }
        public AppUser Writer { get; set; }
    }
}
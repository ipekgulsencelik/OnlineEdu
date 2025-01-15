﻿using OnlineEdu.WebUI.DTOs.CourseCategoryDTOs;
using OnlineEdu.WebUI.DTOs.UserDTOs;

namespace OnlineEdu.WebUI.DTOs.CourseDTOs
{
    public class ResultCourseDTO
    {
        public int CourseID { get; set; }
        public string? CourseName { get; set; }
        public string? ImageUrl { get; set; }
        public int CourseCategoryID { get; set; }
        public ResultCourseCategoryDTO? CourseCategory { get; set; }
        public decimal Price { get; set; }
        public bool IsShown { get; set; }
        public int AppUserId { get; set; }
        public ResultUserDTO AppUser { get; set; }
    }
}
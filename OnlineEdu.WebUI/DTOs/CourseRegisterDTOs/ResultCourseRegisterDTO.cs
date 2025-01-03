﻿using OnlineEdu.WebUI.DTOs.CourseDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.WebUI.DTOs.CourseRegisterDTOs
{
    public class ResultCourseRegisterDTO
    {
        public int CourseRegisterID { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int CourseID { get; set; }
        public ResultCourseDTO Course { get; set; }
    }
}
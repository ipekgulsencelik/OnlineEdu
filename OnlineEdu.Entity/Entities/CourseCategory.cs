﻿namespace OnlineEdu.Entity.Entities
{
    public class CourseCategory
    {
        public int CourseCategoryID { get; set; }
        public string? Name { get; set; }
        public string? Icon { get; set; }
        public string? Description { get; set; }
        public bool IsShown { get; set; }
        public virtual List<Course>? Courses { get; set; }
    }
}
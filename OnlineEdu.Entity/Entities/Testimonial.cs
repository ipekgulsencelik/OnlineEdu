﻿namespace OnlineEdu.Entity.Entities
{
    public class Testimonial
    {
        public int TestimonialID { get; set; }
        public string? Name { get; set; }
        public string? Title { get; set; }
        public string? ImageUrl { get; set; }
        public string? Comment { get; set; }
        public int Star { get; set; }
        public bool IsShown { get; set; }
    }
}
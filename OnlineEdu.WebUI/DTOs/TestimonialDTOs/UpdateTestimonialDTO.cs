﻿namespace OnlineEdu.WebUI.DTOs.TestimonialDTOs
{
    public class UpdateTestimonialDTO
    {
        public int TestimonialID { get; set; }
        public string? Name { get; set; }
        public string? Title { get; set; }
        public string? ImageUrl { get; set; }
        public string? Comment { get; set; }
        public int Star { get; set; }
    }
}
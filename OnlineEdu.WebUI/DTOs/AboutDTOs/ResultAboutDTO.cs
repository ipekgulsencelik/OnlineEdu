﻿using OnlineEdu.WebUI.DTOs.FeatureDTOs;

namespace OnlineEdu.WebUI.DTOs.AboutDTOs
{
    public class ResultAboutDTO
    {
        public int AboutID { get; set; }
        public string? Title { get; set; }
        public string? SubTitle { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl1 { get; set; }
        public string? ImageUrl2 { get; set; }
        public string? Item1 { get; set; }
        public string? Item2 { get; set; }
        public string? Item3 { get; set; }
        public string? Item4 { get; set; }
        public List<ResultFeatureDTO>? Features { get; set; }
    }
}
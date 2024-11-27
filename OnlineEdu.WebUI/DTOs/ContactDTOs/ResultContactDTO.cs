﻿namespace OnlineEdu.WebUI.DTOs.ContactDTOs
{
    public class ResultContactDTO
    {
        public int ContactID { get; set; }
        public string? MapUrl { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public bool IsShown { get; set; }
    }
}
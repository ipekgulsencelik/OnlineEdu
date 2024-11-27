﻿namespace OnlineEdu.DTO.DTOs.ContactDTOs
{
    public class UpdateContactDTO
    {
        public int ContactID { get; set; }
        public string? MapUrl { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public bool IsShown { get; set; }
    }
}
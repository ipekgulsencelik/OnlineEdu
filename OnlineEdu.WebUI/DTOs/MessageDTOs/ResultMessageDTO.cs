﻿namespace OnlineEdu.WebUI.DTOs.MessageDTOs
{
    public class ResultMessageDTO
    {
        public int MessageID { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Subject { get; set; }
        public string? Content { get; set; }
    }
}
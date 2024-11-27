namespace OnlineEdu.DTO.DTOs.SocialMediaDTOs
{
    public class ResultSocialMediaDTO
    {
        public int SocialMediaID { get; set; }
        public string? Icon { get; set; }
        public string? Url { get; set; }
        public string? Title { get; set; }
        public bool IsShown { get; set; }
    }
}
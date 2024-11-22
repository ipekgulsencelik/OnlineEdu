namespace OnlineEdu.DTO.DTOs.SubscriberDTOs
{
    public class CreateSubscriberDTO
    {
        public string? Email { get; set; }
        private bool IsActive { get => false; }
    }
}
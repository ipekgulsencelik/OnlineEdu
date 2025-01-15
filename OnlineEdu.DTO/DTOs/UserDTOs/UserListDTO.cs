namespace OnlineEdu.DTO.DTOs.UserDTOs
{
    public class UserListDTO
    {
        public int Id { get; set; }
        public string NameSurname { get; set; }
        public string UserName { get; set; }
        public List<string> Roles { get; set; }
    }
}
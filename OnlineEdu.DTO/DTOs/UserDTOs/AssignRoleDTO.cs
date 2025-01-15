namespace OnlineEdu.DTO.DTOs.UserDTOs
{
    public class AssignRoleDTO
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool RoleExist { get; set; }
    }
}
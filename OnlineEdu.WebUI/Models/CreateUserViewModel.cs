using OnlineEdu.WebUI.DTOs.UserDTOs;
using System.ComponentModel.DataAnnotations;

namespace OnlineEdu.WebUI.Models
{
    public class CreateUserViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Şifreler birbiriyle uyumlu değil.")]
        public string ConfirmPassword { get; set; }
        public List<AssignRoleDTO> Roles { get; set; }
    }
}
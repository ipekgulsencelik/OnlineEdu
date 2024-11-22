using Microsoft.AspNetCore.Identity;
using OnlineEdu.Entity.Entities;
using OnlineEdu.WebUI.DTOs.UserDTOs;

namespace OnlineEdu.WebUI.Services.UserServices
{
    public interface IUserService
    {
        Task<IdentityResult> CreateUserAsync(UserRegisterDTO userRegisterDTO);
        Task<string> LoginAsync(UserLoginDTO userLoginDTO);
        Task<bool> LogoutAsync();
        Task<bool> CreateRoleAsync(UserRoleDTO userRoleDTO);
        Task<bool> AssignRoleAsync(List<AssignRoleDTO> assignRoleDTO);
        Task<List<AppUser>> GetAllUsersAsync();
    }
}
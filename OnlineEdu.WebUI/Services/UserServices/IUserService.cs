using Microsoft.AspNetCore.Identity;
using OnlineEdu.Entity.Entities;
using OnlineEdu.WebUI.DTOs.UserDTOs;

namespace OnlineEdu.WebUI.Services.UserServices
{
    public interface IUserService
    {
        Task<IdentityResult> CreateUserAsync(UserRegisterDTO userRegisterDTO);
        Task<IdentityResult> CreateTeacherUserAsync(UserRegisterDTO userRegisterDTO);
        Task<string> LoginAsync(UserLoginDTO userLoginDTO);
        Task LogoutAsync();
        Task<bool> CreateRoleAsync(UserRoleDTO userRoleDTO);
        Task<bool> AssignRoleAsync(List<AssignRoleDTO> assignRoleDTO);
        Task<List<AppUser>> GetAllUsersAsync();
        Task<AppUser> GetUserByIdAsync(int id);
        Task<List<ResultUserDTO>> Get4Teachers();
        Task<int> GetTeacherCount();
        Task<List<ResultUserDTO>> GetAllTeachers();
        Task DeleteUserAsync(int id);
    }
}
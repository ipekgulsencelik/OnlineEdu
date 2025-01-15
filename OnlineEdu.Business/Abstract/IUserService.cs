using Microsoft.AspNetCore.Identity;
using OnlineEdu.DTO.DTOs.UserDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Abstract
{
    public interface IUserService
    {
        Task<IdentityResult> CreateUserAsync(RegisterDTO userRegisterDTO);
        Task<IdentityResult> CreateTeacherUserAsync(RegisterDTO userRegisterDTO);
        Task<string> LoginAsync(LoginDTO userLoginDTO);
        Task LogoutAsync();
        Task<bool> CreateRoleAsync(UserRoleDTO userRoleDTO);
        Task<bool> AssignRoleAsync(List<AssignRoleDTO> assignRoleDTO);
        Task<List<AppUser>> GetAllUsersAsync();
        Task<List<ResultUserDTO>> Get4Teachers();
        Task<AppUser> GetUserByIdAsync(int id);
        Task<int> GetTeacherCount();
        Task<List<ResultUserDTO>> GetAllTeachers();
        Task DeleteUserAsync(int id);
    }
}
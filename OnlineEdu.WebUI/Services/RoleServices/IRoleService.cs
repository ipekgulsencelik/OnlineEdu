using OnlineEdu.WebUI.DTOs.RoleDTOs;

namespace OnlineEdu.WebUI.Services.RoleServices
{
    public interface IRoleService
    {
        Task<List<ResultRoleDTO>> GetAllRolesAsync();
        Task<UpdateRoleDTO> GetRoleByIdAsync(int id);
        Task CreateRoleAsync(CreateRoleDTO createRoleDTO);
        Task DeleteRoleAsync(int id);
    }
}
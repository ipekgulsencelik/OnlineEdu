using OnlineEdu.DTO.DTOs.LoginDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Abstract
{
    public interface IJwtService
    {
        Task<LoginResponseDTO> CreateTokenAsync(AppUser user);
    }
}
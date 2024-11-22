using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OnlineEdu.DataAccess.Context;
using OnlineEdu.Entity.Entities;
using OnlineEdu.WebUI.DTOs.UserDTOs;

namespace OnlineEdu.WebUI.Services.UserServices
{
    public class UserService(UserManager<AppUser> _userManager, SignInManager<AppUser> _signInManager, RoleManager<AppRole> _roleManager, IMapper _mapper, OnlineEduContext _context) : IUserService
    {
        public async Task<bool> AssignRoleAsync(List<AssignRoleDTO> assignRoleDTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateRoleAsync(UserRoleDTO userRoleDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> CreateUserAsync(UserRegisterDTO userRegisterDTO)
        {
            var user = new AppUser
            {
                FirstName = userRegisterDTO.FirstName,
                LastName = userRegisterDTO.LastName,
                UserName = userRegisterDTO.UserName,
                Email = userRegisterDTO.Email,
            };
            if (userRegisterDTO.Password != userRegisterDTO.ConfirmPassword)
            {
                return new IdentityResult();
            }

            var result = await _userManager.CreateAsync(user, userRegisterDTO.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Student");
                return result;
            }

            return result;
        }

        public Task<List<AppUser>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<string> LoginAsync(UserLoginDTO userLoginDTO)
        {
            var user = await _userManager.FindByEmailAsync(userLoginDTO.Email);
            if (user == null)
            {
                return null;
            }

            var result = await _signInManager.PasswordSignInAsync(user, userLoginDTO.Password, false, false);
            if (!result.Succeeded)
            {
                return null;
            }
            else
            {
                var IsAdmin = await _userManager.IsInRoleAsync(user, "Admin");
                if (IsAdmin) { return "Admin"; }
                var IsTeacher = await _userManager.IsInRoleAsync(user, "Teacher");
                if (IsTeacher) { return "Teacher"; }
                var IsStudent = await _userManager.IsInRoleAsync(user, "Student");
                if (IsStudent) { return "Student"; }
            }

            return null;
        }

        public Task<bool> LogoutAsync()
        {
            throw new NotImplementedException();
        }
    }
}
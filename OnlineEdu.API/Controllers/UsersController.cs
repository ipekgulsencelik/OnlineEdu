﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.UserDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(UserManager<AppUser> _userManager, SignInManager<AppUser> _signInManager, IJwtService _jwtService, IMapper _mapper) : ControllerBase
    {
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return BadRequest("Bu Email Sistemde Kayıtlı Değil");
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
            if (!result.Succeeded)
            {
                return BadRequest("Kullanıcı Adı veya Şifre Hatalı");
            }

            var token = await _jwtService.CreateTokenAsync(user);
            return Ok(token);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTO model)
        {
            var user = _mapper.Map<AppUser>(model);

            if (ModelState.IsValid)
            {
                var result = await _userManager.CreateAsync(user, model.Password);

                if (!result.Succeeded)
                {
                    return BadRequest(result.Errors);
                }

                await _userManager.AddToRoleAsync(user, "Student");
                return Ok("Kullanıcı Kaydı Başarılı");
            }

            return BadRequest();
        }

        [HttpPost("CreateTeacher")]
        public async Task<IActionResult> CreateTeacher(RegisterDTO model)
        {
            var user = _mapper.Map<AppUser>(model);

            if (ModelState.IsValid)
            {
                var result = await _userManager.CreateAsync(user, model.Password);

                if (!result.Succeeded)
                {
                    return BadRequest(result.Errors);
                }

                await _userManager.AddToRoleAsync(user, "Teacher");
                return Ok("Kullanıcı Kaydı Başarılı");
            }

            return BadRequest();
        }

        [HttpGet("TeacherList")]
        public async Task<IActionResult> TeacherList()
        {
            var teachers = await _userManager.GetUsersInRoleAsync("Teacher");
            return Ok(teachers);
        }

        [HttpGet("StudentList")]
        public async Task<IActionResult> StudentList()
        {
            var students = await _userManager.GetUsersInRoleAsync("Student");
            return Ok(students);
        }

        [HttpGet("Get4Teachers")]
        public async Task<IActionResult> Get4Teachers()
        {
            var users = await _userManager.Users.Include(x => x.TeacherSocialMedias).ToListAsync();

            var teachers = users.Where(user => _userManager.IsInRoleAsync(user, "Teacher").Result).OrderByDescending(x => x.Id).Take(4).ToList();

            return Ok(teachers);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            await _userManager.DeleteAsync(user);
            return Ok("Kullanıcı Silindi");
        }
    }
}
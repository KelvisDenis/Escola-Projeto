using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCrypt.Net;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Application.DTOs;
using SchoolProject.Application.Interfaces;
using SchoolProject.Domain.Entities;
using SchoolProject.Infrastructure.Data;
using SchoolProject.Infrastructure.Repositories.Implemetantion;
using SchoolProject.Infrastructure.Repositories.Interfaces;


namespace SchoolProject.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserApiController : ControllerBase
    {
        private readonly IUserRepository _context;
        private readonly ILogger<UserApiController> _logger;
        private readonly IUserService _userService;

        public UserApiController(IUserRepository context, ILogger<UserApiController> logger, IUserService userService) {
            _context = context;
            _logger = logger;
            _userService = userService;

        }


        [HttpPost("User/Login/")]
        public async Task<IActionResult> LoginUser([FromBody] UserStudentLoginDTO? loginDTO){
            var user = await _userService.LoginUser(loginDTO);
            return Ok(user);
        }
        
        
        [HttpPost("User/create/")]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateDTO? userParm){
            var user = new UserModel{
                Id = 0,
                DateAcces = DateTime.Now,
                Enrollment = userParm.Enrollment,
                HashPassword = BCrypt.Net.BCrypt.HashPassword(userParm.Password),
                TypeUser = userParm.TypeUser,

            };
            await _context.AddUser(user);
            return Ok("User created");
        }
    }
}
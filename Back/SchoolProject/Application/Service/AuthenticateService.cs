using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using SchoolProject.Application.DTOs;
using SchoolProject.Application.Interfaces;
using SchoolProject.Domain.Entities;
using SchoolProject.Domain.Erros;
using SchoolProject.Infrastructure.Repositories.Interfaces;

namespace SchoolProject.Application.Service
{
    public class AuthenticateService:IAuthenticate
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly ILogger<IAuthenticate> _logger;


        public AuthenticateService(IMapper mapper, IUserRepository userRepository, ILogger<IAuthenticate> logger){
            _mapper = mapper;
            _userRepository = userRepository;
            _logger = logger;

        }

        public async Task<UserStudentLoggedDTO> Authenticate(UserStudentLoginDTO? loginDto){
            if (loginDto == null){
                _logger.LogError("Parametre User DTO is null");
                throw new BadRequestException("Parametre DTO is null");
            }
            try{
                // Fetch user model
                var user = await _userRepository.GetUserByEnrollment(loginDto.Enrollment);
                var verifyHash = BCrypt.Net.BCrypt.Verify(loginDto.Password, user.HashPassword);
                if(user == null || verifyHash == false){
                    _logger.LogError($"Was not possible fetch user model, enrollment or password invalid {loginDto.Enrollment}");
                    throw new NotFoundException("Not Found user modelm, enrollment or password invalid");
                }

                 // Gera o token JWT
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("a_secure_key_with_32_bytes_minimum"); // Chave secreta para o token
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.Id.ToString()),
                        new Claim(ClaimTypes.Email, user.Enrollment)
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(10),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);

                // Mapper 
                var userDto = _mapper.Map<UserStudentLoggedDTO>(user);
                userDto.Token = tokenHandler.WriteToken(token);

                return userDto;
            
            }catch(Exception ex){
                _logger.LogError("An error occurred while authenticate user => " + ex);
                throw new BadRequestException("An error occurred in process is authenticate => " + ex.Message);
            }
        }
        
    }
}
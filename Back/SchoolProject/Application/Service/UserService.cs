using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolProject.Application.DTOs;
using SchoolProject.Application.Interfaces;
using SchoolProject.Domain.Entities;
using SchoolProject.Domain.Erros;
using SchoolProject.Infrastructure.Repositories.Interfaces;

namespace SchoolProject.Application.Service
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _repositoryUser;
        private readonly IAuthenticate _authenticate;
        private readonly ILogger<IUserService> _logger;

        public UserService(IUserRepository repositoryUser, ILogger<IUserService> logger, IAuthenticate authenticate){
            _repositoryUser = repositoryUser;
            _logger = logger;
            _authenticate = authenticate;
        }


        public async Task<UserStudentLoggedDTO> LoginUser(UserStudentLoginDTO? login){
            if (login == null){
                _logger.LogError("Parametre is null");
                throw new BadRequestException("Parametre is null");
            }
            try{
               var user = await _authenticate.Authenticate(login);
               _logger.LogInformation($"Successfull login user => {login.Enrollment}");
               return user;


            }catch(Exception ex){
                _logger.LogError("An error occurred while logged user => "+ ex);
                throw new InternalServerErrorException("An error occurred while logged user => "+ ex.Message);
            }
        }
        
    }
}
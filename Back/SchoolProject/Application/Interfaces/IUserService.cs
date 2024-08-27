using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolProject.Application.DTOs;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserStudentLoggedDTO> LoginUser(UserStudentLoginDTO? login);
        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolProject.Application.DTOs;

namespace SchoolProject.Application.Interfaces
{
    public interface IAuthenticate
    {
        Task<UserStudentLoggedDTO> Authenticate(UserStudentLoginDTO? loginDto);
    }
}
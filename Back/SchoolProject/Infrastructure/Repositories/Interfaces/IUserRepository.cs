using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Infrastructure.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task AddUser(UserModel? user);
        Task<UserModel> GetUserById(int? id);
        Task<UserModel> GetUserByEnrollment(string? enrollment);
        Task UpdateUser(UserModel? user);
        Task RemoveUser(int? id);
    }
}
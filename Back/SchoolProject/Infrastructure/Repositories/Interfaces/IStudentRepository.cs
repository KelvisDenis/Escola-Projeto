using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Infrastructure.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        Task<StudentModel> GetStudentByIDAsync(int? id); 
        Task<StudentModel> GetStudentByStudentByIdUserAsync(int? id);
        Task<IEnumerable<StudentModel>> GetAllStudentByIDClassAsync(int? id);
        
    }
}
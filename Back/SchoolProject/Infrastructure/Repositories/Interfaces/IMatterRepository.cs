using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Infrastructure.Repositories.Interfaces
{
    public interface IMatterRepository
    {
        Task<MattersModel> GetMattersByIDAsync(int? id);
        Task<IEnumerable<MattersModel>> GetMatterByIDClassAsync(int? id);
       
    }
}
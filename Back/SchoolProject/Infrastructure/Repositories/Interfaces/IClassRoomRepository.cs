using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Infrastructure.Repositories.Interfaces
{
    public interface IClassRoomRepository
    {
      
        Task<ClassRoomModel> GetClassRoomByIDAsync(int? id);
        Task<ClassRoomModel> GetClassRoomByNameAsync(string? name);
       
    }
}
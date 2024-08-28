using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Infrastructure.Repositories.Interfaces
{
    public interface IJoinStudentNoteRepository
    {
        Task<StudentNoteJoin> GetJoinStudentNoteByIDAsync(int? id);
        Task<IEnumerable<StudentNoteJoin>> GetJoinStudentNoteByIDStudentAsync(int? id);
        Task<IEnumerable<StudentNoteJoin>> GetJoinStudentNoteByIDNotesAsync(int? id);
    }
}
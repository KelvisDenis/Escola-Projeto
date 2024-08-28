using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Infrastructure.Repositories.Interfaces
{
    public interface INoteRepository
    {
        Task<NoteModel> GetNoteByIdAsync(int? id);
        Task<IEnumerable<NoteModel>> GetNoteByIdMatterAsync(int? id);
        
    }
}
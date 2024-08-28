using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Domain.Entities;
using SchoolProject.Domain.Erros;
using SchoolProject.Infrastructure.Data;
using SchoolProject.Infrastructure.Repositories.Interfaces;

namespace SchoolProject.Infrastructure.Repositories.Implemetantion
{
    public class NoteRepository:INoteRepository
    {
        private readonly MyContext _context;
        private readonly ILogger<INoteRepository> _logger;

        public NoteRepository(MyContext context, ILogger<INoteRepository> logger){
            _context = context;
            _logger = logger;

        }
        public async Task<NoteModel> GetNoteByIdAsync(int? id){
            if(id == null){
                _logger.LogError("Parametre ID is null");
                throw new BadRequestException("Parametre is nulll");
            }
            try{
                var note = await _context.NoteDB.FindAsync(id);
                if(note == null){
                    _logger.LogError($"Not found note with this ID {id}");
                    throw new NotFoundException($"Not found note by ID {id}");
                }
                _logger.LogInformation($"success in fetch of note by ID {id}");
                return note;

            }catch(NotFoundException ex){
                _logger.LogError($"Not found note model with this ID {id} => "+ ex);
                throw new NotFoundException($"Not found note model by ID {id} => " + ex.Message);

            }catch(Exception ex){
                _logger.LogError($"An error occurred while fetch note model with this ID {id} => "+ ex);
                throw new InternalServerErrorException($"An error occurred while fetch note model by ID {id} => " + ex.Message);
            }
        }
        public async Task<IEnumerable<NoteModel>> GetNoteByIdMatterAsync(int? id){
             if(id == null){
                _logger.LogError("Parametre ID is null");
                throw new BadRequestException("Parametre is nulll");
            }
            try{
                var notes = await _context.NoteDB.Where(x => x.IdMatters == id).ToListAsync();
                if(notes.Count == 0){
                    _logger.LogError($"Not found notes with ID matters {id}");
                    throw new NotFoundException("Not found note");
                }
                _logger.LogInformation($"Success in fetch notes with ID matters {id}");
                return notes;
                
            }catch(NotFoundException ex){
                _logger.LogError($"Not found note model with this ID matter {id} => "+ ex);
                throw new NotFoundException($"Not found note model by ID => " + ex.Message);

            }catch(Exception ex){
                _logger.LogError($"An error occurred while fetch note model with this ID matter {id} => "+ ex);
                throw new InternalServerErrorException($"An error occurred while fetch note model by ID  => " + ex.Message);
            }
        }
    }
}
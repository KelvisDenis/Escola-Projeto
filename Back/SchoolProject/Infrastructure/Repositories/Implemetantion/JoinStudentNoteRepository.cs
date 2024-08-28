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
    public class JoinStudentNoteRepository: IJoinStudentNoteRepository
    {
        private readonly MyContext _context;
        private readonly ILogger<IJoinStudentNoteRepository> _logger;
        public JoinStudentNoteRepository(MyContext context, ILogger<IJoinStudentNoteRepository> logger){
            _context = context;
            _logger = logger;
        }

        public async Task<StudentNoteJoin> GetJoinStudentNoteByIDAsync(int? id){
             if(id == null){
                _logger.LogError("Parametre ID is null");
                throw new BadRequestException("Parametre is nulll");
            }
            try{
                var studentNoteJoin = await _context.StudentNoteJoinsDB.FindAsync(id);
                if(studentNoteJoin == null){
                    _logger.LogError($"Not found join with this ID {id}");
                    throw new NotFoundException($"Not found join by ID {id}");
                }
                _logger.LogInformation($"success in fetch of join by ID {id}");
                return studentNoteJoin;

            }catch(NotFoundException ex){
                _logger.LogError($"Not found join model with this ID {id} => "+ ex);
                throw new NotFoundException($"Not found join model by ID {id} => " + ex.Message);

            }catch(Exception ex){
                _logger.LogError($"An error occurred while fetch join model with this ID {id} => "+ ex);
                throw new InternalServerErrorException($"An error occurred while fetch join model by ID {id} => " + ex.Message);
            }
        }
        public async Task<IEnumerable<StudentNoteJoin>> GetJoinStudentNoteByIDStudentAsync(int? id){
            if(id == null){
                _logger.LogError("Parametre ID is null");
                throw new BadRequestException("Parametre is nulll");
            }
            try{
                var studentNotesJoin = await _context.StudentNoteJoinsDB.Where(x => x.StudentId == id).ToListAsync();
                if(studentNotesJoin.Count == 0){
                    _logger.LogError($"Not found join models with this ID {id} student");
                    throw new NotFoundException($"Not found joins by ID {id} student");
                }
                _logger.LogInformation($"success in fetch of join models by ID {id} student");
                return studentNotesJoin;

            }catch(NotFoundException ex){
                _logger.LogError($"Not found join models with this ID {id} students => "+ ex);
                throw new NotFoundException($"Not found join model by ID {id} students=> " + ex.Message);

            }catch(Exception ex){
                _logger.LogError($"An error occurred while fetch join models with this ID {id} students => "+ ex);
                throw new InternalServerErrorException($"An error occurred while fetch join models by ID {id} students => " + ex.Message);
            }
        }
        public async Task<IEnumerable<StudentNoteJoin>> GetJoinStudentNoteByIDNotesAsync(int? id){
             if(id == null){
                _logger.LogError("Parametre ID is null");
                throw new BadRequestException("Parametre is nulll");
            }
            try{
                var studentNotesJoin = await _context.StudentNoteJoinsDB.Where(x => x.NoteId == id).ToListAsync();
                if(studentNotesJoin.Count == 0){
                    _logger.LogError($"Not found join models with this ID {id} notes");
                    throw new NotFoundException($"Not found joins by ID {id} notes");
                }
                _logger.LogInformation($"success in fetch of join models by ID {id} notes");
                return studentNotesJoin;

            }catch(NotFoundException ex){
                _logger.LogError($"Not found join models with this ID {id} notes => "+ ex);
                throw new NotFoundException($"Not found join model by ID {id} notes=> " + ex.Message);

            }catch(Exception ex){
                _logger.LogError($"An error occurred while fetch join models with this ID {id} notes => "+ ex);
                throw new InternalServerErrorException($"An error occurred while fetch join models by ID {id} notes => " + ex.Message);
            }
        }
    }
}
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
    public class StudentRepository:IStudentRepository
    {
        private readonly MyContext _context;
        private readonly ILogger<IStudentRepository> _logger;


        public StudentRepository(MyContext context, ILogger<StudentRepository> logger){
            _context = context;
            _logger = logger;

        }
        
        public async Task<StudentModel> GetStudentByIDAsync(int? id){
              if (id == null){
                _logger.LogError("Parametre ID is null in StudentRepository");
                throw new BadRequestException("Parametre is null");
            }
            try{
                var student = await _context.StudentDB.FindAsync(id);
                if (student == null){
                    _logger.LogError($"Not Found student with ID {id}");
                    throw new NotFoundException($"Student not found By this ID {id}");
                }
                _logger.LogInformation($"Success in fetch student with this ID {id}");
                return student;

            }catch(NotFoundException ex){
                _logger.LogError($"Not found student model with ID {id}=> "+ ex);
                throw new NotFoundException($"Not found student model by ID {id} => " + ex.Message);

            }catch(Exception ex){
                _logger.LogError($"An error occurred while fetch student model with this ID {id} => "+ ex);
                throw new InternalServerErrorException($"An error occurred while fetch student model with ID {id}=> " + ex.Message);
            }
        }
        public async Task<StudentModel> GetStudentByStudentByIdUserAsync(int? id){
            if (id == null){
                 _logger.LogError("Parametre ID is null in StudentRepository");
                throw new BadRequestException("Parametre is null");
            }
            try{
                var student = await _context.StudentDB.FirstOrDefaultAsync(x => x.IdUser == id);
                if (student == null ){
                    _logger.LogError($"Not found student with this ID {id} of iduser");
                    throw new NotFoundException("Not found student");
                }
                _logger.LogInformation($"Success fetch student with ID user {id}");
                return student;

            }catch(NotFoundException ex){
                _logger.LogError($"Not found student model with this ID user {id} => "+ ex);
                throw new NotFoundException($"Not found student model by ID {id} => " + ex.Message);

            }catch(Exception ex){
                _logger.LogError($"An error occurred while fetch student model with this ID user{id} => "+ ex);
                throw new InternalServerErrorException($"An error occurred while fetch student model with ID => " + ex.Message);
            }
        }
        public async Task<IEnumerable<StudentModel>> GetAllStudentByIDClassAsync(int? id){
             if (id == null){
                 _logger.LogError("Parametre ID is null in StudentRepository");
                throw new BadRequestException("Parametre is null");
            }
            try{
                var students = await _context.StudentDB.Where(x => x.IdClass == id).ToListAsync();
                if (students.Count == 0){
                    _logger.LogError($"Not found students with ID class {id}");
                    throw new NotFoundException("Not found students of class");
                }
                 _logger.LogInformation($"Success fetch students with ID class {id}");
                return students;

            }catch(NotFoundException ex){
                _logger.LogError($"Not found students model with this ID class {id} => "+ ex);
                throw new NotFoundException($"Not found students by ID => " + ex.Message);

            }catch(Exception ex){
                _logger.LogError($"An error occurred while fetch students with this ID class {id} => "+ ex);
                throw new InternalServerErrorException($"An error occurred while fetch students by ID => " + ex.Message);
            }
        }
    }
}
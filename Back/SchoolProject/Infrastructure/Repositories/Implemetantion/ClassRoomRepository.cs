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
    public class ClassRoomRepository:IClassRoomRepository
    {
        private readonly MyContext _context;    
        private readonly ILogger<IClassRoomRepository> _logger;
        public ClassRoomRepository(MyContext context, ILogger<IClassRoomRepository> logger){
            _context = context;
            _logger = logger;

        }
        public async Task<ClassRoomModel> GetClassRoomByIDAsync(int? id){
             if(id == null){
                _logger.LogError("Parametre ID is null");
                throw new BadRequestException("Parametre is nulll");
            }
            try{
                var room = await _context.ClassDB.FindAsync(id);
                if(room == null){
                    _logger.LogError($"Not found class room with this ID {id}");
                    throw new NotFoundException($"Not found class room by ID {id}");
                }
                _logger.LogInformation($"success in fetch of class room by ID {id}");
                return room;

            }catch(NotFoundException ex){
                _logger.LogError($"Not found class room model with this ID {id} => "+ ex);
                throw new NotFoundException($"Not found class room  model by ID {id} => " + ex.Message);

            }catch(Exception ex){
                _logger.LogError($"An error occurred while fetch class room  model with this ID {id} => "+ ex);
                throw new InternalServerErrorException($"An error occurred while fetchclass room  model by ID {id} => " + ex.Message);
            }
        }
        public async Task<ClassRoomModel> GetClassRoomByNameAsync(string? name){
             if(name == null){
                _logger.LogError("Parametre name is null");
                throw new BadRequestException("Parametre is nulll");
            }
            try{
                var room = await _context.ClassDB.FirstOrDefaultAsync(x => x.Name == name); 
                if(room == null){
                    _logger.LogError($"Not found class room with this name {name}");
                    throw new NotFoundException($"Not found class room by name {name}");
                }
                _logger.LogInformation($"success in fetch of class room by name {name}");
                return room;

            }catch(NotFoundException ex){
                _logger.LogError($"Not found class room model with this name {name} => "+ ex);
                throw new NotFoundException($"Not found class room  model by name {name} => " + ex.Message);

            }catch(Exception ex){
                _logger.LogError($"An error occurred while fetch class room  model with this name {name} => "+ ex);
                throw new InternalServerErrorException($"An error occurred while fetchclass room  model by name {name} => " + ex.Message);
            }
        }
    }
}
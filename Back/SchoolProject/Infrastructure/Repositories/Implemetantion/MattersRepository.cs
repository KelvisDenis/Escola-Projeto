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
    public class MattersRepository:IMatterRepository
    {
        private readonly MyContext _context;
        private readonly ILogger<IMatterRepository> _logger;

        public MattersRepository(MyContext context, ILogger<IMatterRepository> logger){
            _context = context;
            _logger = logger;
        }

        public async Task<MattersModel> GetMattersByIDAsync(int? id){
             if(id == null){
                _logger.LogError("Parametre ID is null");
                throw new BadRequestException("Parametre is nulll");
            }
            try{
                var matter = await _context.MattersDB.FindAsync(id);
                if(matter == null){
                    _logger.LogError($"Not found matter with this ID {id}");
                    throw new NotFoundException($"Not found matter by ID {id}");
                }
                _logger.LogInformation($"success in fetch of matter by ID {id}");
                return matter;

            }catch(NotFoundException ex){
                _logger.LogError($"Not found matter model with this ID {id} => "+ ex);
                throw new NotFoundException($"Not found matter model by ID {id} => " + ex.Message);

            }catch(Exception ex){
                _logger.LogError($"An error occurred while fetch matter model with this ID {id} => "+ ex);
                throw new InternalServerErrorException($"An error occurred while fetch mattter model by ID {id} => " + ex.Message);
            }
        }
        public async Task<IEnumerable<MattersModel>> GetMatterByIDClassAsync(int? id){
             if(id == null){
                _logger.LogError("Parametre ID is null");
                throw new BadRequestException("Parametre is nulll");
            }
            try{
                var matters = await _context.MattersDB.Where(x => x.IdClass == id).ToListAsync();
                if(matters.Count == 0){
                    _logger.LogError($"Not found matters with this ID class {id}");
                    throw new NotFoundException($"Not found matters by ID");
                }
                _logger.LogInformation($"success in fetch of matters by ID {id}");
                return matters;

            }catch(NotFoundException ex){
                _logger.LogError($"Not found matters model with this ID class {id} => "+ ex);
                throw new NotFoundException($"Not found matters model by ID => " + ex.Message);

            }catch(Exception ex){
                _logger.LogError($"An error occurred while fetch matters model with this ID class {id} => "+ ex);
                throw new InternalServerErrorException($"An error occurred while fetch matters model by ID  => " + ex.Message);
            }
        }
    }
} 
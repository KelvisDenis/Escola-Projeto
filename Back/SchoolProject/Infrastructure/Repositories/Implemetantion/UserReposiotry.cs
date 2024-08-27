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
    public class UserReposiotry: IUserRepository
    {
        private readonly MyContext _context;
        private readonly ILogger<IUserRepository> _logger;

        public UserReposiotry(MyContext context, ILogger<IUserRepository> logger){
            _context = context;
            _logger = logger;
        }


        public async Task AddUser(UserModel? user){
            if (user == null){
                _logger.LogError("Parametre is null");
                throw new BadRequestException("Parameter is null");
            }
            try{

                await _context.UserDB.AddAsync(user);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Succesfull in add user model");


            }catch(DbUpdateException ex){
                _logger.LogError("An error occurred in Database while adding user model => " + ex);
                throw new ConflictException("Error occurred in database while adding user model => " + ex.Message);
            }catch(Exception ex){
                _logger.LogError("An error occurred while adding user model => " + ex);
                throw new ConflictException("An error occurred while adding user model => " + ex.Message);
            }
        }
        public async Task<UserModel> GetUserById(int? id){
            if (id == null){
                 _logger.LogError("ID parametre is null");
                throw new BadRequestException("ID parameter is null");
            }
            try{
                var userID = await _context.UserDB.FindAsync(id);
                if (userID == null){
                    _logger.LogError($"Not Found user model with this ID:{id}");
                    throw new NotFoundException($"Not Found user model with this ID{id}");
                }
                 _logger.LogInformation($"Succesfull in fetch user model with this ID {id}");
                return userID;

            }catch(NotFoundException ex){
                _logger.LogError($"Not Found user model with this ID{id} => " + ex);
                throw new NotFoundException($"Not Found user model with this ID {id} =>  " + ex.Message);
            }catch(Exception ex){
                _logger.LogError($"An error occurred while fetch user model by ID {id}=> " + ex);
                throw new InternalServerErrorException("An error occurred while fetch user model by ID => " + ex.Message);
            }
        }
        public async Task<UserModel> GetUserByEnrollment(string? enrollment){
             if (enrollment == null){
                 _logger.LogError("Enrollment parametre is null");
                throw new BadRequestException("Enrollment parameter is null");
            }
            try{
                var userEnrollment = await _context.UserDB.FirstOrDefaultAsync(x => x.Enrollment == enrollment);
                if (userEnrollment == null){
                    _logger.LogError($"Not Found user model with this enrollment:{enrollment}");
                    throw new NotFoundException($"Not Found user model with this enrollmetn {enrollment}");
                }
                 _logger.LogInformation($"Succesfull in fetch user model with this enrollment {enrollment}");
                return userEnrollment;

            }catch(NotFoundException ex){
                _logger.LogError($"Not Found user model with this enrollmetn {enrollment} => " + ex);
                throw new NotFoundException($"Not Found user model with this enrollmetn {enrollment} =>  " + ex.Message);
            }catch(Exception ex){
                _logger.LogError($"An error occurred while fetch user model by enrollmetn {enrollment} => " + ex);
                throw new InternalServerErrorException("An error occurred while fetch user model by enrollment => " + ex.Message);
            }
        }
        public async Task UpdateUser(UserModel? user){
            if (user == null){
                 _logger.LogError("Parametre is null");
                throw new BadRequestException("Parameter is null");
            }
            try{
                var verifyExistUser = await _context.UserDB.AnyAsync(x => x.Id == user.Id);
                if (verifyExistUser == false){
                    _logger.LogError($"User model with this ID:{user.Id} not found");
                    throw new NotFoundException($"User model with this ID {user.Id} was not founs");
                }
                _context.UserDB.Update(user);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Succesfull in update user model with this ID {user.Id}");               


            }catch(NotFoundException ex){
                _logger.LogError($"Not Found user model with this ID {user.Id} to update => " + ex);
                throw new NotFoundException($"Not Found user model with this ID {user.Id} to update =>  " + ex.Message);
            }catch(Exception ex){
                _logger.LogError($"An error occurred while update user model with this ID {user.Id} => " + ex);
                throw new InternalServerErrorException("An error occurred while update user model => " + ex.Message);
            }
        }
        public async Task RemoveUser(int? id){
            if (id == null){
                 _logger.LogError("ID parametre is null");
                throw new BadRequestException("ID parameter is null");
            }
            try{
                var userID = await _context.UserDB.FindAsync(id);
                if (userID == null){
                    _logger.LogError($"Not Found user model with this ID:{id}");
                    throw new NotFoundException($"Not Found user model with this ID{id}");
                }
                _context.UserDB.Remove(userID);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Succesfull in remove user model with this ID {id}");

            }catch(NotFoundException ex){
                _logger.LogError($"Not Found user model with this ID{id} to remove => " + ex);
                throw new NotFoundException($"Not Found user model with this ID {id} to remove=>  " + ex.Message);
            }catch(Exception ex){
                _logger.LogError($"An error occurred while removing  user model by ID {id}=> " + ex);
                throw new InternalServerErrorException("An error occurred while removing user model by ID => " + ex.Message);
            }
        }
    }
}
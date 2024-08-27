using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

using System.Threading.Tasks;
using SchoolProject.Domain.Entities;
using SchoolProject.Application.DTOs;

namespace SchoolProject.Application.Mapper
{
    public class UserProfile:Profile
    {
        public UserProfile(){
            CreateMap<UserModel, UserStudentLoggedDTO>();
        }
    }
}
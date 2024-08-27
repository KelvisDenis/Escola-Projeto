using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Application.DTOs
{
    public class UserStudentLoggedDTO
    {
        public string? Enrollment { get; set;}
        public string? Token { get; set;}


        public UserStudentLoggedDTO(){}
        public UserStudentLoggedDTO(string? enrollment, string? token){
            Enrollment = enrollment;
            Token = token;
        }
    }
}
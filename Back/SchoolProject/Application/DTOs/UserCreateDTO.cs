using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SchoolProject.Domain.Enums;

namespace SchoolProject.Application.DTOs
{
    public class UserCreateDTO
    {
        [Required]
        [StringLength(maximumLength:256, MinimumLength =9)]
        public string? Enrollment { get; set; }
        [Required]
        [StringLength(maximumLength:256, MinimumLength =8)]
        public string? Password { get; set;}
        public TypeUserEnum? TypeUser { get; set;}


        public UserCreateDTO(){}
        public UserCreateDTO(string? enrollment, string? password, TypeUserEnum? typeUser){
            Enrollment = enrollment;
            Password = password;
            TypeUser = typeUser;
        }
    }
}
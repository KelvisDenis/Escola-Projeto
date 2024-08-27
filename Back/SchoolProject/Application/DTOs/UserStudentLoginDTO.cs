using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Application.DTOs
{
    public class UserStudentLoginDTO
    {
        [Required]
        [StringLength(maximumLength:256, MinimumLength = 9)]
        public string? Enrollment { get; set; }
        [Required]	
        [StringLength(maximumLength:256, MinimumLength =8)]
        public string? Password { get; set;}


        public UserStudentLoginDTO(){}
        public UserStudentLoginDTO(string? enrollment, string? password){
            Enrollment = enrollment;
            Password = password;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SchoolProject.Domain.Enums;

namespace SchoolProject.Domain.Entities
{
    public class UserModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength:256, MinimumLength = 9)]
        public string? Enrollment { get; set; }
        [Required]
        public string? HashPassword { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime? DateAcces { get; set; }
        [Required]
        public TypeUserEnum? TypeUser { get; set; }


        public UserModel(){}

        public UserModel(int id, string? enrollment, string? hashPassword, DateTime? date, TypeUserEnum? typeUser){
            Id = id;
            Enrollment = enrollment;
            HashPassword = hashPassword;
            DateAcces = date;
            TypeUser = typeUser;
        }
    }
}
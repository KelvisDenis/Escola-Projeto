using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Domain.Entities
{
    public class StudentModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public int IdClass { get; set; }
        [Required]
        public int IdUser { get; set; }
        [Required]
        public double Frequency { get; set; }



        public StudentModel(){}
        public StudentModel(int id, string name, int idClass, double frequency, int idUser){
            Id = id;
            Name = name;
            IdClass = idClass;
            IdUser = idUser;
            Frequency = frequency;

        }
 
    }
}
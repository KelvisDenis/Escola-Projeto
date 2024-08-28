using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Domain.Entities
{
    public class MattersModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int IdClass { get; set; }
        public double? Frequency { get; set; }

        public MattersModel(){}
        public MattersModel(int id, string? name, double? frequency, int idClass){
            Id = id;
            Name = name;
            IdClass = idClass;
            Frequency = frequency;
        }
    }
}
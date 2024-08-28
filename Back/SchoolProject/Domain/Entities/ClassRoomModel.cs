using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Domain.Entities
{
    public class ClassRoomModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }


        public ClassRoomModel(){}
        public ClassRoomModel(int id, string name){
            Id = id;
            Name = name;
        }
    }
}
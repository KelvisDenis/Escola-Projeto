using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Domain.Entities
{
    public class NoteModel
    {
        public int Id { get; set; }
        public int IdMatters { get; set; }
        public int? Note { get; set; }


        public NoteModel(){}
        public NoteModel(int id, int idMatters, int? note){
            Id = id;
            IdMatters = idMatters;
            Note = note;
        }
    }
}
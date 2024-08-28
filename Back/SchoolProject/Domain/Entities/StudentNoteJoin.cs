using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Domain.Entities
{
    public class StudentNoteJoin
    {
        public int Id { get; set; }
        public int StudentId { get; set;}
        public int NoteId { get;}

        public StudentNoteJoin(){}

        public StudentNoteJoin(int id, int studentId, int noteId){
            Id = id;
            StudentId = studentId;
            NoteId = noteId;
        }
    }
}
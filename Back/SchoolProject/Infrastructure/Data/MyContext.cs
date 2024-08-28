using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Infrastructure.Data
{
    public class MyContext:DbContext
    {
        public MyContext(DbContextOptions<MyContext> op):base(op){}



        public DbSet<UserModel> UserDB { get; set; }
        public DbSet<StudentModel> StudentDB { get; set; }
        public DbSet<ClassRoomModel> ClassDB { get; set; }
        public DbSet<NoteModel> NoteDB { get; set; }
        public DbSet<MattersModel> MattersDB { get; set; }
        public DbSet<StudentNoteJoin> StudentNoteJoinsDB { get; set; }
    }


}
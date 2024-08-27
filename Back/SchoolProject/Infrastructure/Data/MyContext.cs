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
    }


}
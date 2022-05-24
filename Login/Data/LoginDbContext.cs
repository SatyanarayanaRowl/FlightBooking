using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Login.Models;

namespace Login.Data
{
    public class LoginDbContext:DbContext
    {
        public LoginDbContext(DbContextOptions options) : base(options)
        {
        }
        //Dbset
        public DbSet<Logins> Logins { get; set; }
    }
}

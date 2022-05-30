using Login.Data;
using Login.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly LoginDbContext loginDbContext;

        public LoginRepository(LoginDbContext loginDbContext)
        {
            this.loginDbContext = loginDbContext;
        }
        public async Task<Logins> GetUserDetails(string UserName, string PassWord)
        {
            return await loginDbContext.Logins.FirstOrDefaultAsync(x => x.UserName == UserName && x.PassWord== PassWord);
        }

        public async Task<Logins> GetUserWithUserName(string user)
        {
            return await loginDbContext.Logins.FirstOrDefaultAsync(x => x.UserName == user);
        }

        public async Task InsertUserDetails(Logins Login)
        {
            await loginDbContext.Logins.AddAsync(Login);
            await loginDbContext.SaveChangesAsync();
        }
        
    }
}

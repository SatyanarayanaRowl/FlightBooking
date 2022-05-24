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
        public async Task<Logins> GetUserDetails(string UserName, string Password)
        {
            return await loginDbContext.Logins.FirstOrDefaultAsync(x => x.UserName == UserName && x.Password== Password);
        }

        public async Task InsertUserDetails(Logins Login)
        {
            await loginDbContext.Logins.AddAsync(Login);
            await loginDbContext.SaveChangesAsync();
        }

        public Task InsertUserDetails(string UserName, string Password)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Login.Models;

namespace Login.Repository
{
    public interface ILoginRepository
    {
        Task<Logins> GetUserDetails(string UserName, string Password);
        Task InsertUserDetails(Logins Login);
    }
}

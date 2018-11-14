using System;
using System.Collections.Generic;
using System.Linq;
using Vidly.Models;
using System.Data.Entity;
using Vidly.Helpers;
using Vidly.Infrastracture;

namespace Vidly.Repository
{
    public class EFUserService : IUserService
    {
        private readonly ApplicationDbContext _dbContext;
        public EFUserService(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public User FindByMail(string email)
        {
            return _dbContext.Users
                .Include(x => x.UserRoles)
                .Where(x => x.Email.Equals(email))
                .FirstOrDefault();
        }

        public User Login(string email,string password)
        {
            return _dbContext.Users
                .Include(x=>x.UserRoles)
                .Where(x => x.Email.Equals(email) && x.Password.Equals(password))
                .FirstOrDefault();
        }

    }
}
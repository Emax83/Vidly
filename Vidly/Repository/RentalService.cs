using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Infrastracture;

namespace Vidly.Repository
{
    
    public class RentalService : IRentalService
    {
        private readonly ApplicationDbContext _dbContext;
        public RentalService(ApplicationDbContext context)
        {
            _dbContext = context;
        }
        
    }
}
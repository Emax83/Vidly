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

    }
}
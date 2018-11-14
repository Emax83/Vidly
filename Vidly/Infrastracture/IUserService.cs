using Vidly.Models;

namespace Vidly.Infrastracture
{
    public interface IUserService
    {
        User FindByMail(string email);
        User Login(string username, string password);
    }
}

using System.Threading.Tasks;
using ObaOba.API.Models;

namespace ObaOba.API.Repositories
{
    public interface IAuthRepository
    {
        Task<User> Register(User user);
        Task<User> Login(string email, string password);
        Task<bool> EmailExists(string email); 
    }
}
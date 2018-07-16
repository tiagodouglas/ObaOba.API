using System.Threading.Tasks;
using ObaOba.API.Models;

namespace ObaOba.API.Services
{
    public interface IAuthService
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string email, string password);
        Task<bool> EmailExists (string email);
    }
}
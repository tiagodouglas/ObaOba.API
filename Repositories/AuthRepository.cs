using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ObaOba.API.Data;
using ObaOba.API.Models;

namespace ObaOba.API.Repositories
{
    public class AuthRepository: IAuthRepository
    {
        private readonly DataContext _context;

        public AuthRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<User> Register(User user) 
        {
            await _context.AddAsync(user);

            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> Login(string email, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<bool> EmailExists(string email) 
        {
            if (await _context.Users.AnyAsync(x => x.Email == email))
                return true;
            return false;
        }
    }
}
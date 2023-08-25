using Microsoft.EntityFrameworkCore;
using MyPocketAPI.Data;
using MyPocketAPI.Data.Models;
using MyPocketAPI.Services.Interfaces;
using System.Runtime.InteropServices;

namespace MyPocketAPI.Services
{
    public class UserService : IUserService
    {
        private readonly MyPocketDbContext _context;
        public UserService(MyPocketDbContext context)
        {
            _context = context;
        }

        public async Task<User>? GetUserAsync(string login, string password)
        {
            if (_context.Users == null)
            {
                return null;
            }
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == login || u.Phone == login);
            
            if (user != null) {
                var currentUserPassword = _context.UserPasswords
                .Where(p => p.UserId == user.UserId && p.State == Data.Enumerations.PasswordState.Current && p.Password == password)
                .FirstOrDefault();

                if (currentUserPassword != null) { return user; }
            }

            return null;
        }

        public async Task<bool>? InsertUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            if(_context.SaveChanges() != 0)
            {
                return true;
            }

            return false;
        }

    }
}

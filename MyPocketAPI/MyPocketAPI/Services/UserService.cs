using Microsoft.EntityFrameworkCore;
using MyPocketAPI.Data;
using MyPocketAPI.Data.Models;

namespace MyPocketAPI.Services
{
    public class UserService : IUserService
    {
        private readonly MyPocketDbContext _context;


        public UserService(MyPocketDbContext context)
        {
            _context = context;
        }

        public async Task<User>? GetUserAsync(string email, string phone, string password)
        {
            if (_context.Users == null)
            {
                return null;
            }
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email || u.Phone == phone);            

            return user;
        }

    }
}

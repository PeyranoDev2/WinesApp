using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly WineAppContext _context;

        public UserRepository(WineAppContext context)
        {
            _context = context;
        }

        public List<User> Get()
        {
            return _context.Users.ToList();
        }
        public User? Get(string  username)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username);
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
using Data.Entities;

namespace Data.Repository
{
    public interface IUserRepository
    {
        void AddUser(User user);
        List<User> Get();
        User? Get(string username);
    }
}
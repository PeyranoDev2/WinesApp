using Common.Models;
using Data.Entities;
using Data.Models;

namespace Services.UserServices
{
    public interface IUserService
    {
        void AddUser(UserForCreateDTO userForCreateDTO);
        public User? AuthenticateUser(Credentials authRequestBody);
    }
}
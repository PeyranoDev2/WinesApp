using Common.Models;
using Data.Entities;
using Data.Models;
using Data.Repository;

namespace Services.UserServices
{
    public class UserService : IUserService
    {
        public readonly IUserRepository _userRepository;
        public UserService(IUserRepository userHardCodedDBRepository)
        {
            _userRepository = userHardCodedDBRepository;
        }

        public void AddUser(UserForCreateDTO userForCreateDTO)

        {
            _userRepository.AddUser(new User
            {
                Id = _userRepository.Get().Max(x => x.Id) + 1,
                Username = userForCreateDTO.Username,
                Password = userForCreateDTO.Password
            }
            );

        }
        public User? AuthenticateUser(Credentials authRequestBody)
        {
            User? userToReturn = _userRepository.Get(authRequestBody.Username);
            if (userToReturn is not null && userToReturn.Password == authRequestBody.Password)
                return userToReturn;
            return null;
        }
    }
}
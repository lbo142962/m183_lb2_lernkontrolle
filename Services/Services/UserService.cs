using Filmsammlung.Data;
using Filmsammlung.Model;
using Filmsammlung.Services.Interfaces;

namespace Filmsammlung.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository genericRepository;
        public UserService(IGenericRepository genericRepository)
        {
            this.genericRepository = genericRepository;
        }
        public User AddUser(User user)
        {
           genericRepository.Insert(user);
            return user;
        }

        public bool DeleteUser(int id)
        {
            var user = genericRepository.GetById<User>(id);
            if(user == null)
            {
                return false;   
            }
            genericRepository.Delete(user);
            return true;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return genericRepository.GetAll<User>();
        }

        public IEnumerable<Noten> GetAllNotenByUserId(int userId)
        {
            return genericRepository.GetAll<Noten>().Where(u => u.userId == userId);
        }

        public User GetUserById(int userRequestedId)
        {
            return genericRepository.GetById<User>(userRequestedId);
        }

        public void UpdateUser(User user)
        {
            genericRepository.Update(user);
        }
    }
}

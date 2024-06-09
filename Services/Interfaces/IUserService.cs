using Filmsammlung.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmsammlung.Services.Interfaces
{
    public interface IUserService
    {
        public User GetUserById(int userRequestedId);
        public IEnumerable<User> GetAllUsers();
        public IEnumerable<Noten> GetAllNotenByUserId(int userId);

        public User AddUser(User user);
        public void UpdateUser(User user);
        public bool DeleteUser(int id);
    }
}

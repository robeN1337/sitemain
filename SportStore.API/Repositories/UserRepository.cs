using SportStore.API.Entities;
using SportStore.API.Interfaces;

namespace SportStore.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        public IList<User> Users { get; set; } = new List<User>();
        public User CreateUser(User user)
        {
            user.guid = Guid.NewGuid();
            Users.Add(user);
            return user;
        }
        public bool DeleteUser(Guid id)
        {
            var result = FindUserById(id);
            Users.Remove(result);
            return true;
        }
    
        public User EditUser(User user, Guid id)
        {
            var result = FindUserById(id);
            // update
            
            result.Username = user.Username;
            result.Email = user.Email;
            result.Password = user.Password;
            return result;
        }
        public User FindUserById(Guid id)
        {
            var result = Users.Where(u => u.guid == id).FirstOrDefault();
            if (result == null)
            {
                throw new Exception($"Нет пользователя с id = {id}");
            }

            return result;
        }
        public List<User> GetUsers()
        {
            return (List<User>)Users;
        }
    }
}


using StudentSystem.Others;
using System.Web;

namespace StudentSystem.Model
{
    public class UserRepository
    {
        protected IEnumerable<User> _users;
        private int _nextId;

        public UserRepository()
        {
            _users = new List<User>();
            _nextId = 0;
        }

        public virtual void AddUser(User user)
        {
            user.Id = _nextId++;
            _users.Append(user);
        }

        public virtual void DeleteUser(int id)
        {
            _users = _users.Where(u => u.Id != id);
            //var user = _users.FirstOrDefault(u => u.Id == id);
            //if (user != null)
            //{
            //    _users.Remove(user);
            //}
        }

        public bool ValidateUser(string name, string password)
        {
            foreach (var user in _users)
            {
                if (user.Names == name && user.Password == password)
                {
                    return true;
                }
            }

            return false;
        }

        public bool ValidateUserLambda(string name, string password)
        {
            return _users.Where(x => x.Names == name && x.Password == password)
                .FirstOrDefault() != null ? true : false;
        }

        public bool ValidateUserLinq(string name, string password)
        {
            return (from user in _users
                    where user.Names == name && user.Password == password
                    select user).FirstOrDefault() != null ? true : false;
        }

        public User? GetUserByNameAndPassword(string name, string password)
        {
             return _users.Where(x => x.Names == name && x.Password == password)
                .FirstOrDefault();
        }

        public void SetUserActive(string username, DateTime validDate)
        {
            var user = _users.FirstOrDefault(u => u.Names == username);
            if (user != null)
            {
                user.Expires = validDate;
            }
        }

        public void AssignUserRole(string username, UserRolesEnum role)
        {
            var user = _users.FirstOrDefault(u => u.Names == username);
            if (user != null)
            {
                user.Role = role;
            }
        }
    }
}

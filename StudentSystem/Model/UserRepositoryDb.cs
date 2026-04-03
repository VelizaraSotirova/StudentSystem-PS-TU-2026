using StudentSystem.Model.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Model
{
    public class UserRepositoryDb : UserRepository
    {
        private DatabaseContext _dbContext;

        public UserRepositoryDb()
        {
            _dbContext = new DatabaseContext();
            _users = _dbContext.Users;
        }

        public void CreatedDatabase()
        {
                _dbContext.Database.EnsureCreated();
        }

        public IEnumerable<string> GetAllUserNames()
        {
            IEnumerable<string> userNames = _dbContext.Users.Select(u => u.Names).ToList();
            return userNames;
        }
    }
}

using StudentSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.ViewModel
{
    public class AdminViewModel
    {
        public IEnumerable<string> AllUserNames { get; set; }

        public AdminViewModel()
        {
            var userRepository = new UserRepositoryDb();
            AllUserNames = userRepository.GetAllUserNames();
        }
    }
}

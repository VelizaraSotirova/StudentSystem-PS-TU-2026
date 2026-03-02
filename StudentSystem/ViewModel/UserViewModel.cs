using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentSystem.Model;
using StudentSystem.Others;

namespace StudentSystem.ViewModel
{
    public class UserViewModel
    {
        private User _user;
        public UserViewModel(User user)
        {
            _user = user;
        }
        public string Names
        {
            get { return _user.Names; }
        }

        public string Email
        {
            get 
            { 
                if (string.IsNullOrEmpty(_user.Email))
                {
                    return string.Empty;
                }
                return _user.Email[0] + "*****@*****.***"; 
            }
            
        }

        public string IsAdmin
        {
            get 
            { 
                if (_user.IsAdmin)
                        return "ADMIN";
                else
                    return string.Empty;
            }
        }

        public string IsBlocked
        {
            get
            {
                if (_user.FailedLoginAttempts > 5)
                    return "BLOCKED";
                else
                    return $"Hello, {Names}";
            }
        }

        public string StudentCard
        {
            get
            {
                return $"Student: {_user.Names}\n" +
                       $"Faculty Number: {_user.FacultyNumber}";
            }
        }

        public string FullProfile
        {
            get
            {
                return $"Name: {_user.Names}\n" +
                       $"Email: {Email}\n" +
                       $"Role: {_user.Role}\n" +
                       $"Faculty Number: {_user.FacultyNumber}";
            }
        }
    }
}

using StudentSystem.Others;
using System;

namespace StudentSystem.Model
{
    public class User
    {
        private int _id;
        private string _names;
        private string _password;
        private string _email;
        private string? _facultyNumber;
        private UserRolesEnum _role;
        private int _failedLoginAttempts;
        private DateTime _expires;

        public User()
        {
            
        }
        public User(string names, string password, UserRolesEnum role)
        {
            this._names = names;
            this._password = password;
            this._role = role;
        }

        public User(string names, string password, string email, string facultyNumber, UserRolesEnum role, int failedLoginAttempts)
        {
            this._names = names;
            this._password = password;
            this._email = email;
            this._facultyNumber = facultyNumber;
            this._role = role;
            this._failedLoginAttempts = failedLoginAttempts;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Names
        {
            get { return _names; }
            set { _names = value; }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string? FacultyNumber
        {
            get { return _facultyNumber; }
            set { _facultyNumber = value; }
        }

        public UserRolesEnum Role
        {
            get { return _role; }
            set { _role = value; }
        }

        public int FailedLoginAttempts
        {
            get { return _failedLoginAttempts; }
            set { _failedLoginAttempts = value; }
        }

        public DateTime Expires
        {
            get { return _expires; }
            set { _expires = value; }
        }

        public bool IsAdmin
        {
            get { return Role.Equals(UserRolesEnum.ADMIN); }
        }

        public bool IsBlocked
        {
            get { return FailedLoginAttempts > 5; }
        }

        private string Encrypt(string text)
        {
            string result = "";

            foreach (char c in text)
            {
                result += (char)(c + 1);
            }

            return result;
        }

        private string Decrypt(string text)
        {
            string result = "";

            foreach (char c in text)
            {
                result += (char)(c - 1);
            }

            return result;
        }
    }
}

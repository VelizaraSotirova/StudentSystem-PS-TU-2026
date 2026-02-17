using System;

namespace StudentSystem.Model
{
    internal class User
    {
        private string _names;
        private string _password;
        private string _email;
        private string _role;
        private int _failedLoginAttempts;

        public User(string names, string password, string email, string role, int failedLoginAttempts)
        {
            this._names = names;
            this._password = password;
            this._email = email;
            this._role = role;
            this._failedLoginAttempts = failedLoginAttempts;
        }

        public string Names
        {
            get { return _names; }
            set { _names = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Role
        {
            get { return _role; }
            set { _role = value; }
        }

        public int FailedLoginAttempts
        {
            get { return _failedLoginAttempts; }
            set { _failedLoginAttempts = value; }
        }

        public bool IsAdmin
        {
            get { return Role.ToUpper() == "ADMIN"; }
        }

        public bool IsBlocked
        {
            get { return FailedLoginAttempts > 5; }
        }
    }
}

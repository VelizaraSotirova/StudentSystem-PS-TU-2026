using System.Windows;

namespace StudentSystem.Model
{
    internal class UserLoginAttempt
    {
        private string _usernameEntered;
        private string _passwordEntered;
        private int _attemptCount;
        private UserRepository _userRepository;

        public int AttemptCount
        {
            get { return _attemptCount; }
        }

        public string ErrorMessage
        {
            get; set;
        }

        public UserLoginAttempt(string usernameEntered, string passwordEntered, UserRepository userRepository)
        {
            _usernameEntered = usernameEntered;
            _passwordEntered = passwordEntered;
            _userRepository = userRepository;
            _attemptCount = 0;
        }


        public bool Validate()
        {
            if(string.IsNullOrEmpty(_usernameEntered))
            {
                ErrorMessage = "The field Username cannot be empty";
                return false;
            }

            if (string.IsNullOrEmpty(_passwordEntered))
            {
                ErrorMessage = "The field Password cannot be empty";
                return false;
            }

            return true;
        }

        public bool AssertCredentials()
        {
            bool isValid = _userRepository.ValidateUserLambda(_usernameEntered, _passwordEntered);

            if (!isValid)
            {
                _attemptCount++;
                ErrorMessage = "Invalid username or password";
                return false;
            }

            return true;
        }

        public User ExecuteLoginUser()
        {
            var user = _userRepository.GetUserByNameAndPassword(_usernameEntered, _passwordEntered);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            return user;
        }

        public void PushLoggedInStatus()
        {
            _userRepository.SetUserActive(_usernameEntered, DateTime.Now);
        }
    }
}

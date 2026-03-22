using StudentSystem.Model;
using StudentSystem.View;

namespace StudentSystem.ViewModel
{
    public class LoginViewModel
    {
        private UserLoginAttempt _userLoginAttempt;
        private UserRepository _userRepository;

        public string UserNameText { get; set; }
        public string PasswordText { get; set; }

        public string ErrorMessage
        {
            get
            {
                if (_userLoginAttempt == null)
                    return string.Empty;

                return _userLoginAttempt.ErrorMessage;
            }
        }

        public LoginViewModel(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void LoginExecute()
        {
            _userLoginAttempt = new UserLoginAttempt(UserNameText, PasswordText, _userRepository);

            if (!_userLoginAttempt.Validate())
                return;

            if (!_userLoginAttempt.AssertCredentials())
                return;

            var user = _userLoginAttempt.ExecuteLoginUser();

            _userLoginAttempt.PushLoggedInStatus();

            // Going to MainWindow with the logged in user
            var userViewModel = new UserViewModel(user);
            var mainWindow = new MainWindow(userViewModel);

            mainWindow.DisplayUser();
            mainWindow.Show();
        }

    }
}

using StudentSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StudentSystem.View
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private LoginViewModel _viewModel;
        public LoginWindow(LoginViewModel loginViewModel)
        {
            InitializeComponent();
            _viewModel = loginViewModel;
        }


        private void button_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.UserNameText = textBoxUserName.Text;
            _viewModel.PasswordText = textBoxPassword.Text;
            _viewModel.LoginExecute();
            if (!string.IsNullOrEmpty(_viewModel.ErrorMessage))
            {
                MessageBox.Show(_viewModel.ErrorMessage, "Login Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

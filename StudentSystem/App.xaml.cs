using StudentSystem.Model;
using StudentSystem.View;
using StudentSystem.ViewModel;
using System.Configuration;
using System.Data;
using System.Windows;

namespace StudentSystem
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            UserRepository userRepository = new UserRepository();

            User user = new User("Velizara Sotirova", "123456", "velizara@abv.bg", "121223009", Others.UserRolesEnum.STUDENT, 2);
            User student2 = new User("Student2", "123", Others.UserRolesEnum.STUDENT);
            User teacher = new User("Teacher", "1234", Others.UserRolesEnum.PROFESSOR);
            User admin = new User("Admin", "12345", Others.UserRolesEnum.ADMIN);
            
            userRepository.AddUser(user);
            userRepository.AddUser(student2);
            userRepository.AddUser(teacher);
            userRepository.AddUser(admin);

            //UserViewModel userViewModel = new UserViewModel(user);
            //MainWindow mainWindow = new MainWindow(userViewModel);
            //mainWindow.DisplayUser();
            //mainWindow.Show();

            LoginViewModel loginViewModel = new LoginViewModel(userRepository);
            LoginWindow loginWindow = new LoginWindow(loginViewModel);
            loginWindow.Show();
        }
    }

}

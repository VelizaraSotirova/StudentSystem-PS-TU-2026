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

            User user = new User("Velizara Sotirova", "1234", "velizara@abv.bg", "admin", 2);
            UserViewModel userViewModel = new UserViewModel(user);
            MainWindow mainWindow = new MainWindow(userViewModel);
            mainWindow.DisplayUser();
            mainWindow.Show();
        }
    }

}

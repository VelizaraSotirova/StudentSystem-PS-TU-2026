using System.Security.RightsManagement;
using System.Windows;

using StudentSystem.Model;
using StudentSystem.View;
using StudentSystem.ViewModel;
using StudentSystem.Others;
using StudentSystemExtended.Others;

namespace StudentSystemExtended
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                var user = new User ("John Doe", "password123", UserRolesEnum.STUDENT);

                var viewModel = new UserViewModel(user);

                MainWindow w = new MainWindow(viewModel);
                w.ShowDialog();

                w.DisplayError();
            }

            catch (Exception ex)
            {
                var log = new ActionOnError(Delegates.Log);
                log(ex.Message);
            }

            finally
            {
                Console.WriteLine("Executed in any case!");
            }
        }
    }
}

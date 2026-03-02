using StudentSystem.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;

namespace StudentSystem.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private UserViewModel _mainWindow;
        public MainWindow(UserViewModel mainWindow)
        {
            this._mainWindow = mainWindow;
            InitializeComponent();
        }

        public void DisplayUser()
        {
            //return $"Welcome{Environment.NewLine}User:{_mainWindow.Names}{Environment.NewLine}Role:{_mainWindow.IsAdmin}{Environment.NewLine}";
            TextBlock textBlockUser = new TextBlock();
            textBlockUser.Text = $"Welcome{Environment.NewLine}User: {_mainWindow.Names}{Environment.NewLine}Role: {_mainWindow.IsAdmin}{Environment.NewLine}";

            textBlockUser.Text = _mainWindow.StudentCard;
            textBlockUser.Text = _mainWindow.FullProfile;


            this.Content = textBlockUser;
        }

        public void DisplayError()
        {
            throw new Exception("This is a test exception from MainWindow");
        }
    }
}
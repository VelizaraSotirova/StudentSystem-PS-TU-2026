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
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private AdminViewModel _viewModel;
        public AdminWindow(AdminViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            AllUserNames.ItemsSource = _viewModel.AllUserNames;
        }
    }
}

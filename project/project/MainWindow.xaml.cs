using project.Helpers;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if (UserStoredData.userType == "student")
            {
                btnStudent.Visibility = Visibility.Visible;
                loginBtn.Visibility = Visibility.Collapsed;
            }
            else if(UserStoredData.userType == "teacher")
            {
                btnTeacher.Visibility = Visibility.Visible;
                loginBtn.Visibility = Visibility.Collapsed;
            }
            else if(UserStoredData.userType == "admin")
            {
                btnTeacher.Visibility = Visibility.Visible;
                btnStudent.Visibility = Visibility.Visible;
                loginBtn.Visibility = Visibility.Collapsed;

            }
            else
            {
                btnTeacher.Visibility = Visibility.Collapsed;
                btnStudent.Visibility = Visibility.Collapsed;
                loginBtn.Visibility = Visibility.Visible;
            }
            
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

    }
}

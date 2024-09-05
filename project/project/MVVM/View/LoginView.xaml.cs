using Newtonsoft.Json;
using project.Helpers;
using project.MVVM.Model;
using project.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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

namespace project.MVVM.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            LoginModel login = new LoginModel();
            login.username = txtUsrName.Text;
            login.password = txtPass.Password;
            string serializedModel = JsonConvert.SerializeObject(login);
            var response = await HttpClientService.Login(serializedModel);
            if (response != null)
            {
                LoginResponseModel user = JsonConvert.DeserializeObject<LoginResponseModel>(response);
                UserStoredData.Id = user.Id;
                UserStoredData.userName = user.userName;
                UserStoredData.userType = user.userType;
                MainWindow nmw= new MainWindow();
                nmw.Show();
                Application.Current.MainWindow.Close();
            }
            else
            {
                MessageBox.Show("wrong");
            }
            
        }
    }
}

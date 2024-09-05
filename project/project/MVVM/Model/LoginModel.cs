using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.MVVM.Model
{
    public class LoginModel
    {
        public string username { get; set; }
        public string password { get; set; }
    }

    public class LoginResponseModel
    {
        public int Id { get; set; }
        public string userName { get; set; }
        public string userType { get; set; }
    }
}

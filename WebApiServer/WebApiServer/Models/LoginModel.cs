namespace WebApiServer.Models
{
    public class LoginRequestModel
    {
        public string username { get; set; }
        public string password { get; set; }
    }
    public class LoginResponseModel
    {
        public int Id { get; set; }
        public string userName { get; set; }
        public string userType { get; set; }
        public string identification { get; set; }
    }

}

namespace DotNetCoreSampleApi.Models
{
    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public System.DateTime Date { get; set; } = System.DateTime.Now;
    }
}
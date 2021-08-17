namespace AccessControl.Models
{
    public class User
    {
        public int Id { get; set; }
        public Employee Employee { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
namespace API.Models
{
    public class UserModel
    {
        public UserModel(string name = "", string password = "", string email = "", string surname = "")
        {
            this.Name = name;
            this.Password = password;
            this.Email = email;
            this.Surname = surname;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

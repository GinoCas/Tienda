namespace API.Models
{
    public class UserModel
    {
        public UserModel(int id = -1, string name = "", string surname = "", string email = "", string password = "")
        {
			this.Id = id; 
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

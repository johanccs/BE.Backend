namespace BE.Data.Dtos
{
    public class LoginDto
    {
        public string Email { get; private set; }

        public string Password { get; private set; }

        public LoginDto(string email, string password)
        {
            Email = email;
            Password = password;
        }
        
    }
}

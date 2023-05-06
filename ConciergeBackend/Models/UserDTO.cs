namespace ConciergeBackend.Models
{
    public class UserRegisterDTO
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
    }

    public class UserResponseDTO
    {
        public required int ID { get; set; }
        public required string Token { get; set; }
    }

    public class UserLoginDTO
    {
        public required string Username { get; set; }
        public required string Password { get; set; }

    }
}

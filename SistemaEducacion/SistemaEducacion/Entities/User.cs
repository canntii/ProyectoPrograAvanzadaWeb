namespace SistemaEducacion.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string? FirstNameUser { get; set; }
        public string? LastNameUser { get; set; }
        public string? EmailUser { get; set; }
        public string? PasswordUser { get; set; }
        public int? RoleID { get; set; }
        public string? RoleName { get; set; }
        public bool? Estado { get; set; }
        public string? Token { get; set; }
        public bool Temporary { get; set; }
        public string? TemporalPassword { get; set; }
    }

    public class UserAnswer
    {
        public UserAnswer()
        {
            Code = "00";
            Message = string.Empty;
        }

        public string? Code { get; set; }
        public string? Message { get; set; }
        public User? Datum { get; set; }
        public List<User>? Data { get; set; }
    }
}

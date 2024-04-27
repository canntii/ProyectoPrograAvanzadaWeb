namespace SistemaEducacion.WebEntities
{
    public class User
    {
        public int UserId { get; set; }
        public string? FirstNameUser { get; set;}
        public string? LastNameUser { get; set; }
        public string? EmailUser { get; set; }
        public string? PasswordUser { get; set; }
        public int? RoleID { get; set; }
        public string? NameRole { get; set; }
        public int? SubscriptionID { get; set; }
        public string? SubscriptionType { get; set; }
        public string? TemporalPassword {  get; set; }
        public int IsTeacher { get; set; } //1 Usuario normal //2 En proceso de aprobacion //3 Teacher
        public string? PictureUrl { get; set; }
        public IFormFile? PictureUploads { get; set; }
        public bool? Estado { get; set; }
        public string? Token { get; set; }
        public bool Temporary { get; set; }
    }

    public class UserAnswer
    {
        public string? Code { get; set; }
        public string? Message { get; set; }
        public User? Datum { get; set; }
        public List<User>? Data { get; set; }
    }
}

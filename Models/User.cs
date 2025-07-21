namespace CrudApiJwt.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;

        // Nova propriedade para controle de acesso
        public string Role { get; set; } = "User"; // valor padrão

        public ICollection<Contact> Contacts { get; set; }
    }
}

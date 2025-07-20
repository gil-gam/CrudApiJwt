namespace CrudApiJwt.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        // Nova propriedade para controle de acesso
        public string Role { get; set; } = "User"; // valor padrão

        public ICollection<Contact> Contacts { get; set; }
    }
}

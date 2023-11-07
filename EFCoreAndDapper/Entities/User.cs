using EFCoreAndDapper.Entities.ValueObjects;

namespace EFCoreAndDapper.Entities
{
    public class User : Entity
    {
        public string Name { get; set; } = string.Empty;

        public string Username { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public Address? Address { get; set; }

        private List<Post> _posts = new();
        public ICollection<Post> Posts => _posts;
    }
}
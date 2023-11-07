namespace EFCoreAndDapper.Entities
{
    public class Post : Entity
    {
        public int UserId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public PostDetail Detail { get; set; }

        private List<Comment> _comments = new();
        public ICollection<Comment> Comments => _comments;
    }
}
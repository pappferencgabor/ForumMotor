using System.Text.Json.Serialization;

namespace ForumMotor.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual string? ForumUserId { get; set; } = null;

        [JsonIgnore]
        public virtual ForumUser? User { get; set; } = null;
        [JsonIgnore]
        public ICollection<Topic>? Topics { get; set; } = null;
    }
}

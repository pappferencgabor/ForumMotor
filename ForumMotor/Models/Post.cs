namespace ForumMotor.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string ForumUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public int TopicId { get; set; }
        public int PostReply { get; set; }

        public virtual ForumUser User { get; set; }
        public virtual Topic Topic { get; set; }
        public virtual Post? Reply { get; set; }
    }
}

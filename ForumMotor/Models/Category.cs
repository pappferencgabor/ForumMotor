namespace ForumMotor.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public virtual string ForumUserId { get; set; }

        public virtual ForumUser User { get; set; }
        //public ICollection<Topic> Topics { get; set; }
    }
}

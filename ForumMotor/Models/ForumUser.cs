using Microsoft.AspNetCore.Identity;

namespace ForumMotor.Models
{
    public class ForumUser : IdentityUser
    {
        public string? FirstName { get; set; }

    }
}

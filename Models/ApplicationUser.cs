using Microsoft.AspNetCore.Identity;

namespace ARPGTradeBeta.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ICollection<Character> Characters { get; set; } = new List<Character>();
        public ICollection<Item> Items { get; set; } = new List<Item>();
    }
}

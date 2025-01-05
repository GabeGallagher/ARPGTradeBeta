using ARPGTradeBeta.Models.Enums;
using ARPGTradeBeta.Models;

namespace ARPGTradeBeta.DTOs
{
    public class ItemDTO
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public ItemType Type { get; set; }
        public Rarity Rarity { get; set; }
        public Guid? CharacterId { get; set; }
        public DateTime PostedDate { get; set; }
        public Guid PlayerId { get; set; }
    }
}

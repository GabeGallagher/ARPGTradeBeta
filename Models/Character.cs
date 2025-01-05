namespace ARPGTradeBeta.Models
{
    public class Character
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public Guid PlayerId { get; set; }
        public ICollection<Item>? EquippedItems { get; set; }
    }
}

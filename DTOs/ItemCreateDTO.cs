namespace ARPGTradeBeta.DTOs
{
    public class ItemCreateDTO
    {
        public required string Name { get; set; }
        public required string Type { get; set; }
        public required string Rarity { get; set; }
        public required decimal Price { get; set; }
        public required DateTime PostedDate { get; set; }
    }
}

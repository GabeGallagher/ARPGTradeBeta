using ARPGTradeBeta.Models;

namespace ARPGTradeBeta.DTOs
{
    public class CharacterDTO
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public Guid PlayerId { get; set; }
    }
}

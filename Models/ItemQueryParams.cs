using Microsoft.AspNetCore.Mvc;

namespace ARPGTradeBeta.Models
{
    public class ItemQueryParams
    {
        [FromQuery(Name = "name")]
        public string? Name { get; set; }
        [FromQuery(Name = "type")]
        public string? Type { get; set; }
        [FromQuery(Name = "rarity")]
        public string? Rarity { get; set; }
        [FromQuery(Name = "price")]
        public decimal? Price { get; set; }
        [FromQuery(Name = "datePosted")]
        public string? DatePosted { get; set; }
    }
}

using ARPGTradeBeta.DTOs;
using ARPGTradeBeta.Models;
using ARPGTradeBeta.Models.Enums;
using ARPGTradeBeta.Repos;
using Microsoft.AspNetCore.Mvc;

namespace ARPGTradeBeta.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemRepository _itemRepository;

        public ItemsController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        [HttpGet("get-items")]
        public async Task<ActionResult<IEnumerable<ItemDTO>>> GetItemsFromQuery(
            [FromQuery] string? name,
            [FromQuery] string? type,
            [FromQuery] string? rarity,
            [FromQuery] decimal? price,
            [FromQuery] string? datePosted)
        {
            var itemQueryParams = new ItemQueryParams
            {
                Name = name,
                Type = type,
                Rarity = rarity,
                Price = price,
                DatePosted = datePosted
            };

            try
            {
                var items = await _itemRepository.GetItemsWithQueryAsync(itemQueryParams);
                var itemDtos = items.Select(item => new ItemDTO
                {
                    Name = item.Name,
                    Price = item.Price,
                    Type = item.Type,
                    Rarity = item.Rarity,
                    PostedDate = item.PostedDate,
                    PlayerId = item.PlayerId

                });
                return Ok(itemDtos);
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to retrieve items: {ex.Message}");
            }
        }

        [HttpPost("create-item")]
        public async Task<ActionResult<ItemDTO>> CreateItem([FromBody] ItemCreateDTO itemCreateDTO)
        {
            var godUser = new ApplicationUser { };

            var item = new Item
            {
                Name = itemCreateDTO.Name,
                Type = GetItemDTOType(itemCreateDTO.Type),
                Rarity = GetItemDTORarity(itemCreateDTO.Rarity),
                Price = itemCreateDTO.Price,
                PostedDate = DateTime.UtcNow
            };

            try
            {
                var result = await _itemRepository.AddAsync(item);
                var dto = new ItemDTO
                {
                    Id = result.Id,
                    Name = result.Name,
                    Price = result.Price,
                    Type = result.Type,
                    Rarity = result.Rarity,
                    PostedDate = DateTime.UtcNow,
                    PlayerId = Guid.NewGuid() // Change to user id when User accounts are implemented
                };
                return CreatedAtAction(nameof(GetItemsFromQuery), new {id = result.Id}, dto);
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to create item: {ex.Message}");
            }
        }

        private ItemType GetItemDTOType(string type)
        {
            return type switch
            {
                "Weapon" => ItemType.Weapon,
                "Helm" => ItemType.Helm,
                "Chest" => ItemType.Chest,
                "Belt" => ItemType.Belt,
                "Ring" => ItemType.Ring,
                "Gloves" => ItemType.Gloves,
                "Boots" => ItemType.Boots,
                "Off-Hand" => ItemType.OffHand,
                "Amulet" => ItemType.Amulet,
                _ => throw new ArgumentException($"Invalid item type: {type}")
            };
        }

        private Rarity GetItemDTORarity(string rarity)
        {
            return rarity switch
            {
                "Normal" => Rarity.Normal,
                "Uncommon" => Rarity.Uncommon,
                "Rare" => Rarity.Rare,
                "Legendary" => Rarity.Legendary,
                _ => throw new ArgumentException($"Invalid item rarity: {rarity}")
            };
        }
    }
}

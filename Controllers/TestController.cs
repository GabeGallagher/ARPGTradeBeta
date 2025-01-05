using ARPGTradeBeta.Models;
using ARPGTradeBeta.Repos;
using Microsoft.AspNetCore.Mvc;
using ARPGTradeBeta.Models.Enums;
using ARPGTradeBeta.DTOs;

namespace ARPGTradeBeta.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IItemRepository _itemRepository;
        private readonly IRepository<Character> _characterRepository;

        public TestController(IItemRepository itemRepository, IRepository<Character> characterRepository)
        {
            _itemRepository = itemRepository;
            _characterRepository = characterRepository;
        }

        [HttpPost("test-create-item")]
        public async Task<ActionResult<ItemDTO>> TestCreateItem()
        {
            var testUser = new ApplicationUser { };

            var testItem = new Item
            {
                Name = "Test Sword",
                Price = 100.00m,
                Type = ItemType.Weapon,
                Rarity = Rarity.Normal,
                PostedDate = DateTime.UtcNow,
                PlayerId = Guid.NewGuid()
            };

            try
            {
                var result = await _itemRepository.AddAsync(testItem);
                var dto = new ItemDTO
                {
                    Id = result.Id,
                    Name = result.Name,
                    Price = result.Price,
                    Type = result.Type,
                    Rarity = result.Rarity,
                    PostedDate = result.PostedDate,
                    PlayerId = result.PlayerId
                };
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return BadRequest($"Repo test failed: {ex.Message}");
            }
        }

        [HttpPost("test-create-character")]
        public async Task<ActionResult<CharacterDTO>> TestCreateCharacter()
        {
            var testCharacter = new Character
            {
                Id = Guid.NewGuid(),
                Name = "TestCharacter",
                PlayerId = Guid.NewGuid(),
            };

            try
            {
                var result = await _characterRepository.AddAsync(testCharacter);
                var dto = new CharacterDTO
                {
                    Id = result.Id,
                    Name = result.Name,
                    PlayerId = result.PlayerId
                };
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return BadRequest($"Repo test failed: {ex.Message}");
            }
        }

        [HttpGet("test-get-items")]
        public async Task<ActionResult<IEnumerable<ItemDTO>>> TestGetItems()
        {
            try
            {
                var items = await _itemRepository.GetAllAsync();
                var dtos = items.Select(item => new ItemDTO
                {
                    Id = item.Id,
                    Name = item.Name,
                    Price = item.Price,
                    Type = item.Type,
                    Rarity = item.Rarity,
                    PostedDate = item.PostedDate,
                    PlayerId = item.PlayerId
                });
                return Ok(dtos);
            }
            catch (Exception ex)
            {
                return BadRequest($"Repo test failed: {ex.Message}");
            }
        }

        [HttpGet("test-get-characters")]
        public async Task<ActionResult<IEnumerable<CharacterDTO>>> TestGetCharacters()
        {
            try
            {
                var characters = await _characterRepository.GetAllAsync();
                var dtos = characters.Select(character => new CharacterDTO
                {
                    Id = character.Id,
                    Name = character.Name,
                    PlayerId = character.PlayerId
                });
                return Ok(dtos);
            }
            catch (Exception ex)
            {
                return BadRequest($"Repo test failed: {ex.Message}");
            }
        }
    }
}

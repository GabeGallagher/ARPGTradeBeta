using ARPGTradeBeta.Models;

namespace ARPGTradeBeta.Repos
{
    public interface IItemRepository : IRepository<Item>
    {
        Task<IEnumerable<Item>> GetItemsByPlayerIdAsync(Guid playerId);
        Task<IEnumerable<Item>> GetItemsByCharacterIdAsync(Guid characterId);
    }
}

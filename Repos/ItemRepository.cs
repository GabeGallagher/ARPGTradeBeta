using ARPGTradeBeta.Data;
using ARPGTradeBeta.Models;
using Microsoft.EntityFrameworkCore;

namespace ARPGTradeBeta.Repos
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        public ItemRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Item>> GetItemsByCharacterIdAsync(Guid characterId)
        {
            return await _dbSet
                .Where(i =>  i.CharacterId == characterId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Item>> GetItemsByPlayerIdAsync(Guid playerId)
        {
            return await _dbSet
                .Where(i => i.PlayerId == playerId)
                .ToListAsync();
        }
    }
}

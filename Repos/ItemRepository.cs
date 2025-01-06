using ARPGTradeBeta.Data;
using ARPGTradeBeta.Models;
using Microsoft.EntityFrameworkCore;

namespace ARPGTradeBeta.Repos
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        public ItemRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Item>> GetItemsWithQueryAsync(ItemQueryParams itemQueryParams)
        {
            var query = _dbSet.AsQueryable();

            if (!string.IsNullOrWhiteSpace(itemQueryParams.Name))
                query = query.Where(i => i.Name.Contains(itemQueryParams.Name));

            if (!string.IsNullOrWhiteSpace(itemQueryParams.Type))
                query = query.Where(i => i.Type.ToString() == itemQueryParams.Type);

            if (!string.IsNullOrWhiteSpace(itemQueryParams.Rarity))
                query = query.Where(i => i.Rarity.ToString() == itemQueryParams.Rarity);

            if (itemQueryParams.Price.HasValue)
                query = query.Where(i => (i.Price <= itemQueryParams.Price.Value));

            if (!string.IsNullOrWhiteSpace(itemQueryParams.DatePosted))
            {
                var currenTime = DateTime.UtcNow;
                query = itemQueryParams.DatePosted switch
                {
                    "Last Hour" => query.Where(i => i.PostedDate >= currenTime.AddHours(-1)),
                    "24 Hours" => query.Where(i => i.PostedDate >= currenTime.AddDays(-1)),
                    "Last Week" => query.Where(i => i.PostedDate >= currenTime.AddDays(-7)),
                    _ => query
                };
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Item>> GetItemsByPlayerIdAsync(Guid playerId)
        {
            return await _dbSet
                .Where(i => i.PlayerId == playerId)
                .ToListAsync();
        }
    }
}

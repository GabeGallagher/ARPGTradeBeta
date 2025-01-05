using ARPGTradeBeta.Data;
using ARPGTradeBeta.Models;
using Microsoft.EntityFrameworkCore;

namespace ARPGTradeBeta.Repos
{
    public class CharacterRepository : Repository<Character>, ICharacterRepository
    {
        public CharacterRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Character>> GetCharactersByPlayerIdAsync(Guid playerId)
        {
            return await _dbSet
                .Where(i => i.PlayerId == playerId)
                .ToListAsync();
        }
    }
}

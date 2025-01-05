using ARPGTradeBeta.Models;

namespace ARPGTradeBeta.Repos
{
    public interface ICharacterRepository : IRepository<Character>
    {
        Task<IEnumerable<Character>> GetCharactersByPlayerIdAsync(Guid playerId);
    }
}

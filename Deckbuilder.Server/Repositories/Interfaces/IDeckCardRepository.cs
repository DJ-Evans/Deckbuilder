using Deckbuilder.Server.Entities;
using Deckbuilder.Server.Models;

namespace Deckbuilder.Server.Repositories.Interfaces
{
    public interface IDeckCardRepository
    {
        Task<int?> AddDeckCard(int deckId, int cardId);
    }
}

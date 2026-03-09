using Deckbuilder.Server.Models;
using Deckbuilder.Server.Models.Core;

namespace Deckbuilder.Server.Services.Interfaces
{
    public interface IDeckCardService
    {
        Task<Result<int?>> AddDeckCard(int deckId, int cardId);
    }
}

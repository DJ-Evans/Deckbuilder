using Deckbuilder.Server.Models;
using Deckbuilder.Server.Models.Core;

namespace Deckbuilder.Server.Services.Interfaces
{
    public interface IDeckService
    {
        Task<Result<DeckModel>> GetAsync(int deckId);

        Task<Result<List<DeckModel>>> GetAllAsync(); // Should probably change this to a "SearchDecksAsync" Where you pass in a search criteria model and do filtering in the repo.

        Task<Result<DeckModel>> SaveDeck(DeckModel deck);
    }
}

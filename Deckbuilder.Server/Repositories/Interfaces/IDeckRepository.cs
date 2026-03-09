using Deckbuilder.Server.Entities;
using Deckbuilder.Server.Models;

namespace Deckbuilder.Server.Repositories.Interfaces
{
    public interface IDeckRepository
    {
        /// <summary>
        /// Gets a deck by id.
        /// </summary>
        /// <param name="deckId">The deck id.</param>
        /// <returns>A deck entity.</returns> 
        Task<DeckModel> GetAsync(int deckId);

        Task<List<DeckModel>> GetAll();

        Task<int?> UpdateDeck(DeckModel model);

        Task<int?> CreateDeck(DeckModel model);
    }
}

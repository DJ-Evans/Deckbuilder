using Deckbuilder.Server.Entities;
using Deckbuilder.Server.Models;

namespace Deckbuilder.Server.Repositories.Interfaces
{
    public interface ICardRepository
    {
        /// <summary>
        /// Gets a deck by id.
        /// </summary>
        /// <param name="deckId">The deck id.</param>
        /// <returns>A deck entity.</returns>
        Task<CardModel> GetAsync(int cardId);
        Task<List<CardModel>> GetCardsByName(string cardName);
        Task<List<CardModel>> GetAll();
        Task<int?> CreateCard(CardModel model);
    }
}

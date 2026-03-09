using Deckbuilder.Server.Models;
using Deckbuilder.Server.Models.Core;
using Deckbuilder.Server.Repositories;
using Deckbuilder.Server.Repositories.Interfaces;
using Deckbuilder.Server.Services.Interfaces;

namespace Deckbuilder.Server.Services
{
    public class DeckCardService : IDeckCardService
    {
        public IDeckCardRepository DeckCardRepository { get; set; }

        public DeckCardService(IDeckCardRepository deckCardRepository)
        {
            this.DeckCardRepository = deckCardRepository;
        }

        public async Task<Result<int?>> AddDeckCard(int deckId, int cardId)
        {
            var deckCardId = await this.DeckCardRepository.AddDeckCard(deckId, cardId);
            return Result.Success(deckCardId);
        }
    }
}

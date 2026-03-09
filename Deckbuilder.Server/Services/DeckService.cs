using Deckbuilder.Server.Entities;
using Deckbuilder.Server.Models;
using Deckbuilder.Server.Models.Core;
using Deckbuilder.Server.Repositories.Interfaces;
using Deckbuilder.Server.Services.Interfaces;

namespace Deckbuilder.Server.Services
{
    public class DeckService : IDeckService
    {
        public IDeckRepository DeckRepository { get; set; }

        public DeckService(IDeckRepository deckRepository)
        {
            this.DeckRepository = deckRepository;
        }

        public async Task<Result<DeckModel>> GetAsync(int deckId)
        {
            var result = await this.DeckRepository.GetAsync(deckId);
            return Result<DeckModel>.Success(result);
        }

        public async Task<Result<List<DeckModel>>> GetAllAsync()
        {
            var result = await this.DeckRepository.GetAll();
            return Result<List<DeckModel>>.Success(result);
        }

        public async Task<Result<DeckModel>> SaveDeck(DeckModel deck)
        {
            if (deck.DeckId != null)
            {
                var deckId = await this.DeckRepository.UpdateDeck(deck);
                return await this.GetAsync(deckId.Value);
            }
            else
            {
                var deckId = await this.DeckRepository.CreateDeck(deck);
                return await this.GetAsync(deckId.Value);
            }
        }
    }
}

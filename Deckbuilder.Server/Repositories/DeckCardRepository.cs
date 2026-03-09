using Deckbuilder.Server.Entities;
using Deckbuilder.Server.Mappers;
using Deckbuilder.Server.Models;
using Deckbuilder.Server.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Deckbuilder.Server.Repositories
{
    public class DeckCardRepository : IDeckCardRepository
    {
        private AppDbContext _context { get; set; }

        public DeckCardRepository(AppDbContext context)
        {
            this._context = context;
        }

        public async Task<int?> AddDeckCard(int deckId, int cardId)
        {
            var entity = new DeckCard { DeckId = deckId, CardId = cardId };
            var result = this._context.DeckCards.Add(entity);
            await this._context.SaveChangesAsync();
            return result.Entity.DeckCardId;
        }
    }
}

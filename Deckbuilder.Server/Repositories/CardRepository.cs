using Deckbuilder.Server.Entities;
using Deckbuilder.Server.Mappers;
using Deckbuilder.Server.Models;
using Deckbuilder.Server.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Deckbuilder.Server.Repositories
{
    public class CardRepository : ICardRepository
    {
        private AppDbContext _context { get; set; }

        public CardRepository(AppDbContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Gets a deck by id.
        /// </summary>
        /// <param name="deckId">The deck id.</param>
        /// <returns>A deck entity.</returns>
        public async Task<CardModel> GetAsync(int cardId)
        {
            var entity = await this
                ._context.Cards.AsNoTracking()
                .Where(x => x.CardId == cardId)
                .FirstOrDefaultAsync();

            return entity.ToModel();
        }

        public async Task<List<CardModel>> GetCardsByName(string cardName)
        {
            Console.WriteLine($"Repository searching for cardName: {cardName}");
            var entities = await this
                ._context.Cards.Where(x => x.CardName.Contains(cardName))
                .AsNoTracking()
                .ToListAsync();

            return entities.Select(card => card.ToModel()).ToList();
        }

        public async Task<List<CardModel>> GetAll()
        {
            var entities = await this._context.Cards.AsNoTracking().ToListAsync();

            return entities.Select(card => card.ToModel()).ToList();
        }

        public async Task<int?> CreateCard(CardModel model)
        {
            var entitity = model.ToEntity();
            var result = this._context.Cards.Add(entitity);
            await this._context.SaveChangesAsync();
            return result.Entity.CardId;
        }
    }
}

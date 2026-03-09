using Deckbuilder.Server.Entities;
using Deckbuilder.Server.Mappers;
using Deckbuilder.Server.Models;
using Deckbuilder.Server.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Deckbuilder.Server.Repositories
{
    public class DeckRepository : IDeckRepository
    {
        private AppDbContext _context { get; set; }

        public DeckRepository(AppDbContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Gets a deck by id.
        /// </summary>
        /// <param name="deckId">The deck id.</param>
        /// <returns>A deck entity.</returns>
        public async Task<DeckModel> GetAsync(int deckId)
        {
            var entity = await this
                ._context.Decks.AsNoTracking()
                .Where(x => x.DeckId == deckId)
                .FirstOrDefaultAsync();

            return entity.ToModel();
        }

        public async Task<List<DeckModel>> GetAll()
        {
            var entities = await this._context.Decks.AsNoTracking().ToListAsync();

            return entities.Select(deck => deck.ToModel()).ToList();
        }

        public async Task<int?> UpdateDeck(DeckModel model)
        {
            var entity = model.ToEntity();
            this._context.Entry(entity).State = EntityState.Modified;
            await this._context.SaveChangesAsync();
            return entity.DeckId;
        }

        public async Task<int?> CreateDeck(DeckModel model)
        {
            var entity = model.ToEntity();
            var result = this._context.Decks.Add(entity);
            await this._context.SaveChangesAsync();
            return result.Entity.DeckId;
        }
    }
}

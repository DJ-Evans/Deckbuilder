using Deckbuilder.Server.Entities;
using Deckbuilder.Server.Models;

namespace Deckbuilder.Server.Mappers
{
    public static class DeckExtensions
    {
        public static DeckModel ToModel(this Deck deck)
        {
            if (deck == null)
                return null;

            return new DeckModel
            {
                DeckId = deck.DeckId,
                UserId = deck.UserId,
                DeckName = deck.DeckName,
                Description = deck.Description,
                Colors = deck.Colors,
                Format = deck.Format,
            };
        }

        public static Deck ToEntity(this DeckModel deck)
        {
            if (deck == null)
                return null;

            return new Deck
            {
                DeckId = deck.DeckId,
                UserId = deck.UserId,
                DeckName = deck.DeckName,
                Description = deck.Description,
                Colors = deck.Colors,
                Format = deck.Format,
            };
        }
    }
}

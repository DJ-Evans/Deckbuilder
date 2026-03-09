using Deckbuilder.Server.Entities;

namespace Deckbuilder.Server.Mappers
{
    public static class DeckCardExtensions
    {
        public static DeckCard ToEntity(int deckId, int cardId)
        {
            if (deckId == null || cardId == null)
            {
                return null;
            }
            return new DeckCard { DeckId = deckId, CardId = cardId };
        }
    }
}

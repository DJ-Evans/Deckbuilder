using Deckbuilder.Server.Entities;
using Deckbuilder.Server.Models;

namespace Deckbuilder.Server.Mappers
{
    public static class CardExtensions
    {
        public static CardModel ToModel(this Card card)
        {
            if (card == null)
                return null;

            return new CardModel
            {
                CardId = card.CardId,
                TcgPlayerId = card.TcgPlayerId,
                CardName = card.CardName,
                CardType = card.CardType,
                ColorIdentity = card.ColorIdentity,
                ManaCost = card.ManaCost,
                Power = card.Power,
                Toughness = card.Toughness,
                RulesText = card.RulesText,
            };
        }

        public static Card ToEntity(this CardModel card)
        {
            if (card == null)
                return null;

            return new Card
            {
                CardId = card.CardId,
                TcgPlayerId = card.TcgPlayerId,
                CardName = card.CardName,
                CardType = card.CardType,
                ColorIdentity = card.ColorIdentity,
                ManaCost = card.ManaCost,
                Power = card.Power,
                Toughness = card.Toughness,
                RulesText = card.RulesText,
            };
        }
    }
}

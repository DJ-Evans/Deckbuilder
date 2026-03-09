using System.ComponentModel.DataAnnotations;

namespace Deckbuilder.Server.Models
{
    public class CardModel
    {
        public int? CardId { get; set; }

        public int TcgPlayerId { get; set; }

        public string? CardName { get; set; }

        public string? CardType { get; set; }

        public string? ColorIdentity { get; set; }

        public string? ManaCost { get; set; }

        public int? Power { get; set; }

        public int? Toughness { get; set; }

        public string? RulesText { get; set; }
    }
}

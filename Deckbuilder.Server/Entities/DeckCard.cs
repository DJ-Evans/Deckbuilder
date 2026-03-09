using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Deckbuilder.Server.Entities
{
    public class DeckCard
    {
        [Key]
        public int? DeckCardId { get; set; }

        public int? DeckId { get; set; }

        public int? CardId { get; set; }

        public Deck Deck { get; set; }

        public Card Card { get; set; }
    }
}

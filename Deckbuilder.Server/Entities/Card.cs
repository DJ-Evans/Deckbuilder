using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Deckbuilder.Server.Entities
{
    public class Card
    {
        [Key]
        public int? CardId { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int TcgPlayerId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(256)")]
        public string CardName { get; set; } = "";

        [Column(TypeName = "nvarchar(100)")]
        public string CardType { get; set; } = "";

        [Column(TypeName = "nvarchar(100)")]
        public string? ColorIdentity { get; set; } = "";

        [Column(TypeName = "nvarchar(100)")]
        public string? ManaCost { get; set; } = "";

        public int? Power { get; set; }

        public int? Toughness { get; set; }

        [Column(TypeName = "nvarchar(4000)")]
        public string? RulesText { get; set; } = "";
    }
}

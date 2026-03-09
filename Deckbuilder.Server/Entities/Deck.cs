using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Deckbuilder.Server.Entities
{
    public class Deck
    {
        [Key]
        public int? DeckId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string UserId { get; set; } = "";

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string DeckName { get; set; } = "";

        [Column(TypeName = "nvarchar(100)")]
        public string Description { get; set; } = "";

        [Column(TypeName = "nvarchar(100)")]
        public string Colors { get; set; } = "";

        [Column(TypeName = "nvarchar(100)")]
        public string Format { get; set; } = "";
    }
}

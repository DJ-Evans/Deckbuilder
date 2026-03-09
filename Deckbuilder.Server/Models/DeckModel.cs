using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Deckbuilder.Server.Models
{
    public class DeckModel
    {
        public int? DeckId { get; set; }

        [Required]
        [MaxLength(100)]
        public string? UserId { get; set; }

        [Required]
        [MaxLength(100)]
        public string? DeckName { get; set; }

        [MaxLength(100)]
        public string? Description { get; set; }

        [MaxLength(100)]
        public string? Colors { get; set; }

        [MaxLength(100)]
        public string? Format { get; set; }

        public List<CardModel> Cards { get; set; } = new List<CardModel>();
    }
}

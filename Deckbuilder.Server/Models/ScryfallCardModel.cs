using System.ComponentModel.DataAnnotations;

namespace Deckbuilder.Server.Models
{
    public class ScryfallCardModel
    {
        public int TcgPlayer_Id { get; set; }

        public string? Name { get; set; }

        public string? Type_Line { get; set; }

        public string[] Colors { get; set; } = [];

        public string? Mana_Cost { get; set; }

        public string? Oracle_Text { get; set; }

        // public int? Power { get; set; }
        //
        // public int? Toughness { get; set; }
    }
}

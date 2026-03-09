using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Deckbuilder.Server.Models;
using Deckbuilder.Server.Models.Core;
using Deckbuilder.Server.Repositories.Interfaces;
using Deckbuilder.Server.Services.Interfaces;

namespace Deckbuilder.Server.Services
{
    public class CardService : ICardService
    {
        public ICardRepository CardRepository { get; set; }
        public IScryfallService ScryfallService { get; set; }

        public CardService(ICardRepository cardRepository, IScryfallService scryfallService)
        {
            this.CardRepository = cardRepository;
            this.ScryfallService = scryfallService;
        }

        public async Task<Result<List<CardModel>>> GetCardsByName(string cardName)
        {
            var result = await CardRepository.GetCardsByName(cardName);
            return Result.Success(result);
        }

        public async Task<Result<List<ScryfallCardModel>>> SyncCardDataAsync()
        {
            var currentCards = await this.CardRepository.GetAll();
            var scryfallCards = await this.ScryfallService.GetScryfallDataAsync();
            Console.WriteLine(scryfallCards);
            Console.WriteLine($"scryfallCards is null: {scryfallCards == null}");
            Console.WriteLine("Error:");
            if (scryfallCards.Error != null)
            {
               Console.WriteLine(scryfallCards.Error);
            }
            foreach (var sc in scryfallCards.Value.Where(x => x != null))
            {
                if (!currentCards.Any(x => x.TcgPlayerId == sc.TcgPlayer_Id))
                {
                    var newCard = new CardModel
                    {
                        CardName = sc.Name,
                        TcgPlayerId = sc.TcgPlayer_Id,
                        CardType = sc.Type_Line,
                        ColorIdentity =
                            sc.Colors != null ? string.Join(",", sc.Colors) : string.Empty,
                        ManaCost = sc.Mana_Cost,
                        RulesText = sc.Oracle_Text,
                    };
                    Console.WriteLine("NewCard is currently: " + newCard.CardName);
                    await CardRepository.CreateCard(newCard);
                }
            }

            return Result.Success(scryfallCards.Value);
        }
    }
}

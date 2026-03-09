using Deckbuilder.Server.Models;
using Deckbuilder.Server.Models.Core;

namespace Deckbuilder.Server.Services.Interfaces
{
    public interface ICardService
    {
        Task<Result<List<CardModel>>> GetCardsByName(string cardName);
        Task<Result<List<ScryfallCardModel>>> SyncCardDataAsync();
    }
}

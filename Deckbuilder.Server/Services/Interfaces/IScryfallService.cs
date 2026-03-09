using Deckbuilder.Server.Models;
using Deckbuilder.Server.Models.Core;

namespace Deckbuilder.Server.Services.Interfaces
{
    public interface IScryfallService
    {
        Task<Result<List<ScryfallCardModel>>> GetScryfallDataAsync();
    }
}

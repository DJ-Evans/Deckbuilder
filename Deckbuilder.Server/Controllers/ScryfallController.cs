
using Deckbuilder.Server.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Deckbuilder.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ScryfallController 
{
    private IScryfallService ScryfallService { get; set; }

    private ICardService CardService { get; set; }

    public ScryfallController(IScryfallService scryfallService,
        ICardService cardService)
    {
        this.ScryfallService = scryfallService;
        this.CardService = cardService;
    }

    [HttpGet("Refresh")]
    public async Task<IActionResult> RefreshScryfallData()
    {
        var result = await this.CardService.SyncCardDataAsync();
        return new ObjectResult(result);
    }
}

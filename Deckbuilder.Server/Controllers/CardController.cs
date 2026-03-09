using Deckbuilder.Server.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Deckbuilder.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CardController 
{
    private ICardService CardService { get; set; }

    public CardController(ICardService deckService)
    {
        this.CardService = deckService;
    }

    [HttpGet]
    [Route("{cardName}")]
    public async Task<IActionResult> GetCardsByName(string cardName)
    {
        Console.WriteLine($"Controller received cardName: {cardName}");
        var result = await this.CardService.GetCardsByName(cardName);
        return new ObjectResult(result);
    }
}

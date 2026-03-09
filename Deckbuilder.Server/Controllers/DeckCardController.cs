using System.Net;
using Deckbuilder.Server.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Deckbuilder.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DeckCardController 
{
    private IDeckCardService DeckCardService { get; set; }

    public DeckCardController(IDeckCardService deckCardService)
    {
        this.DeckCardService = deckCardService;
    }

    [HttpPost]
    [Route("Add/${deckId}/${cardId}")]
    public async Task<IActionResult> AddDeckCard([FromRoute] int deckId, [FromRoute] int cardId)
    {
        var result = await this.DeckCardService.AddDeckCard(deckId, cardId);
        if (result.IsSuccess)
        {
            return new ObjectResult(result) { StatusCode = (int)HttpStatusCode.OK };
        }
        else
        {
            Console.WriteLine($"Failed too add Card to Deck.");
            return new ObjectResult(result) { StatusCode = (int)HttpStatusCode.BadRequest };
        }
    }
}

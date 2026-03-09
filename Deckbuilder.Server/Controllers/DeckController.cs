using Deckbuilder.Server.Models;
using Deckbuilder.Server.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Deckbuilder.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DeckController 
{
    private IDeckService DeckService { get; set; }

    public DeckController(IDeckService deckService)
    {
        this.DeckService = deckService;
    }

    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetDecks()
    {
        var result = await this.DeckService.GetAllAsync();
        return new ObjectResult(result);
    }

    [HttpGet]
    [Route("{deckId:int}")]
    public async Task<IActionResult> GetDeck(int deckId)
    {
        var result = await this.DeckService.GetAsync(deckId);
        return new ObjectResult(result);
    }

    [HttpPost]
    [Route("Save")]
    public async Task<IActionResult> SaveDeck([FromBody] DeckModel deckModel)
    {
        var result = await this.DeckService.SaveDeck(deckModel);
        return new ObjectResult(result);
    }
}

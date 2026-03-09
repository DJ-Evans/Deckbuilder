using Deckbuilder.Server.Models;
using Deckbuilder.Server.Models.Core;
using Deckbuilder.Server.Services.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Deckbuilder.Server.Services
{
    public class ScryfallService : IScryfallService
    {
        public async Task<Result<List<ScryfallCardModel>>> GetScryfallDataAsync()
        {
            var options = new RestClientOptions("https://api.scryfall.com/");
            var client = new RestClient(options);
            var request = new RestRequest("bulk-data/oracle-cards");
            var response = await client.GetAsync(request);

            if (response != null && response.IsSuccessful)
            {
                // Parse out the download_uri
                var meta = JObject.Parse(response.Content);
                var downloadUri = meta["download_uri"]?.ToString();

                if (string.IsNullOrEmpty(downloadUri))
                {
                    return Result<List<ScryfallCardModel>>.Failure<List<ScryfallCardModel>>(Error.BadRequest);
                }

                // Download the full card data
                var cardDataClient = new RestClient();
                var cardDataRequest = new RestRequest(downloadUri);
                var cardDataResponse = await cardDataClient.GetAsync(cardDataRequest);

                if (cardDataResponse != null && cardDataResponse.IsSuccessful)
                {
                    try
                    {
                        var scryfallCards = JsonConvert.DeserializeObject<List<ScryfallCardModel>>(
                            cardDataResponse.Content
                        );
                        return Result<List<ScryfallCardModel>>.Success(scryfallCards);
                    }
                    catch (Exception exception)
                    {
                        Result<List<ScryfallCardModel>>.Failure<List<ScryfallCardModel>>(Error.BadRequest);
                        return Result<List<ScryfallCardModel>>.Failure<List<ScryfallCardModel>>(Error.BadRequest);
                    }
                }
                else
                {
                    return Result<List<ScryfallCardModel>>.Failure<List<ScryfallCardModel>>(Error.BadRequest);
                }
            }
            else
            {
                return Result<List<ScryfallCardModel>>.Failure<List<ScryfallCardModel>>(Error.BadRequest);
            }
        }
    }
}

namespace Deckbuilder.Server.Models.Core;

public class Error(string Code, string Message)
{
    public static readonly Error None = new(string.Empty, string.Empty);
    public static readonly Error NullValue = new("Error.NullValue", "Null value not allowed.");
    public static readonly Error BadRequest = new("Error.BadRequest", "Something went wrong.");
}
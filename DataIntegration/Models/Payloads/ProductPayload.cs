namespace DataIntegration.Models.Payloads
{
    public record ProductPayload(string Id, string Name, string? Description,
            List<ProductPricePayload> Prices, string CategoryId);
}
using DataIntegration.Models.Payloads;

namespace DataIntegration.DataAccess.Api
{
    public class ProductsApiClient : BaseApiClient<ProductPayload>
    {
        public ProductsApiClient(HttpClient httpClient)
            : base(httpClient, "/Products")
        {

        }
    }
}
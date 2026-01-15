using DataIntegration.DataSource.DummyJson.DTOs;
using DataIntegration.Models.Abstractions;
using DataIntegration.Models.Payloads;

namespace DataIntegration.MappingProfiles.DummyJson
{
    public class DummyJsonProductMapper : IMapper<DummyJsonProductDto, ProductPayload>
    {
        public ProductPayload Map(DummyJsonProductDto s) =>
            new(s.Id.ToString(), s.Title, s.Description,
                [new("Piece", s.Price)], s.Category);
    }
}
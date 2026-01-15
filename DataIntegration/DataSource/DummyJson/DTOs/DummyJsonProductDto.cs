namespace DataIntegration.DataSource.DummyJson.DTOs
{
    public class DummyJsonProductDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime LastModified { get; set; }
    }
}
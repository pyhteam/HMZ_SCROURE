namespace HMZ.Data.Enities
{
    public class Product : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public decimal Price { get; set; }
        public List<ProductCategory>? ProductCategories { get; set; }
    }
}

namespace HMZ.Data.Enities
{
    public class Category : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<ProductCategory>? ProductCategories { get; set; }
    }
}

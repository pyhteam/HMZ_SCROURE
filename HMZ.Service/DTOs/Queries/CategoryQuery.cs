using System.ComponentModel.DataAnnotations;

namespace HMZ.Service.DTOs.Queries
{
    public class CategoryQuery
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace HMZ.Service.DTOs.Queries
{
    public class CategoryQuery
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
        [StringLength(500, MinimumLength = 3)]
        public string Description { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace DataAccessLibrary.DB.Entity
{
    public class City : EntityBase
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string Country { get; set; }
    }
}

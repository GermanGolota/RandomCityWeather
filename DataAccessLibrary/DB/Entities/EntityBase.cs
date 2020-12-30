using System.ComponentModel.DataAnnotations;

namespace DataAccessLibrary.DB.Entity
{
    public class EntityBase
    {
        [Key]
        public string Id { get; set; }
    }
}
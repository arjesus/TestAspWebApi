using System.ComponentModel.DataAnnotations;

namespace TestAspWebApi.Entities
{
    public class GenreEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}

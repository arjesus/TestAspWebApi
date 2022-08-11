using System.ComponentModel.DataAnnotations;

namespace TestAspWebApi.DTOs.Genres
{
    public class GenreDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace TestAspWebApi.DTOs
{
    public class GenreCreateNewDTO
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}

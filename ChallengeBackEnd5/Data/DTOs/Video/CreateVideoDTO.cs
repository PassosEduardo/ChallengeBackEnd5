using System.ComponentModel.DataAnnotations;

namespace ChallengeBackEnd5.Data.DTOs
{
    public class CreateVideoDTO
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public string url { get; set; }
        public int CategoriaId { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace ChallengeBackEnd5.Models
{
    public class Categoria
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public string color { get; set; }

        public virtual List<Video> videos { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChallengeBackEnd5.Models
{
    public class Video
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public string url { get; set; }   
        public int CategoriaId { get; set; }

        [ForeignKey("CategoriaId")]
        public virtual Categoria categoria { get; set; }

    }
}

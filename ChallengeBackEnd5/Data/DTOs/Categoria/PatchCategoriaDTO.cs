using System.ComponentModel.DataAnnotations;

namespace ChallengeBackEnd5.Data.DTOs.Categoria
{
    public class PatchCategoriaDTO
    {
        [Required]
        public string title { get; set; }
        [Required]
        public string color { get; set; }
    }
}

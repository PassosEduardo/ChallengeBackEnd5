using System.ComponentModel.DataAnnotations;

namespace ChallengeBackEnd5.Data.DTOs.Categoria
{
    public class CreateCategoriaDTO
    {
        [Required(ErrorMessage ="O campo title é obrigatório")]
        public string title { get; set; }
        [Required(ErrorMessage = "O campo color obrigatório")]
        public string color { get; set; }

    }
}

namespace ChallengeBackEnd5.Data.DTOs.Categoria
{
    public class ReadCategoriaDTO
    {

        public int Id { get; set; }

        public string title { get; set; }

        public string color { get; set; }

        public virtual object videos { get; set; }
    }
}

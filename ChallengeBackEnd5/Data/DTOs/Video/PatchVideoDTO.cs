﻿using System.ComponentModel.DataAnnotations;

namespace ChallengeBackEnd5.Data.DTOs
{
    public class PatchVideoDTO
    {
        public string Title { get; set; }
        public string description { get; set; }
        public string url { get; set; }

        public int CategoriaId { get; set; }
    }
}

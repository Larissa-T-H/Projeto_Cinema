using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public class Filme
    {
        public int FilmeId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatótio")]
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Campo Obrigatótio")]
        public string Sinopse { get; set; }
    }
}

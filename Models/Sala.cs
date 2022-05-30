using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public class Sala
    {
        public int SalaId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatótio")]
        [Display(Name = "Nº da Sala")]
        public string SalaNum { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public class Ingresso
    {
        public int IngressoId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatótio")]
        [Display(Name = "Ingresso Inteira")]
        public bool IngressoInteiro { get; set; }

        [Required(ErrorMessage = "Campo Obrigatótio")]
        [Display(Name = "Ingresso Meia")]
        public bool IngressoMeia { get; set; }

        [Required(ErrorMessage = "Campo Obrigatótio")]
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Campo Obrigatótio")]
        [Display(Name = "Sessão")]
        public int SessaoId { get; set; }
        public Sessao Sessao { get; set; }

        [Required(ErrorMessage = "Campo Obrigatótio")]
        public char Fileira { get; set; }

        [Required(ErrorMessage = "Campo Obrigatótio")]
        [Display(Name = "Assento")]
        public int AssentoNum { get; set; }
    }
}

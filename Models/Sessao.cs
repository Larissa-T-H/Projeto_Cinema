using System;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public class Sessao
    {
        public int SessaoId { get; set; }


        [Required(ErrorMessage = "Campo Obrigatótio")]
        [Display(Name = "Sessão")]
        public int SessaoNum { get; set; }  

        [Required(ErrorMessage = "Campo Obrigatótio")]
        [Display(Name = "Sala")]
        public int SalaID { get; set; }
        public Sala Sala { get; set; }

        [Required(ErrorMessage = "Campo Obrigatótio")]
        [Display(Name = "Filme")]
        public int FilmeID { get; set; }
        public Filme Filme { get; set; }

        [Required(ErrorMessage = "Campo Obrigatótio")]
        [Display(Name = "Dublado")]
        public bool IsDublado { get; set; }

        [Required(ErrorMessage = "Campo Obrigatótio")]
        [Display(Name = "Legendado")]
        public bool IsLegendado { get; set; }


        [Required(ErrorMessage = "Campo Obrigatótio")]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }


        [Required(ErrorMessage = "Campo Obrigatótio")]
        [DataType(DataType.Time)]
        [Display(Name = "Horário")]
        public DateTime Horario { get; set; }


        [Required(ErrorMessage = "Campo Obrigatótio")]
        public int Capacidade { get; set; }
    }
}

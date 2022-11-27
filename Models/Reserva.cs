using ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Helpers;
using System.ComponentModel.DataAnnotations;

namespace ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Models
{
    public class Reserva
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = MensajesDeError.Requerido)]
        [Display(Name = Alias.SalaId)]
        public int SalaId { get; set; }

        public Sala Sala { get; set; }

        [Required(ErrorMessage = MensajesDeError.Requerido)]
        [Display(Name = Alias.Cliente)]
        public int ClienteId { get; set; }

        public Cliente Cliente { get; set; }

        [Required(ErrorMessage = MensajesDeError.Requerido)]
        public int CantidadButacas { get; set; }

        public bool Activa { get; set; }

        [Required(ErrorMessage = MensajesDeError.Requerido)]
        public DateTime FechaAlta { get; set; }
    }
}
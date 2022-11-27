using ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Helpers;
using ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Models;
using System.ComponentModel.DataAnnotations;

namespace ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.ViewModels
{
    public class NuevaReserva
    {
        [Required(ErrorMessage = MensajesDeError.Requerido)]
        [Display(Name = Alias.SalaId)]
        public int SalaId { get; set; }

        public Sala Sala { get; set; }

        [Required(ErrorMessage = MensajesDeError.Requerido)]
        [Display(Name = Alias.Cliente)]
        public int ClienteId { get; set; }

        public Cliente Cliente { get; set; }

        [Required(ErrorMessage = MensajesDeError.Requerido)]
        [Display(Name = Alias.CantidadDeButacas)]
        public int CantidadButacas { get; set; }
    }
}
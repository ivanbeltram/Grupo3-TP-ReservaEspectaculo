using ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Helpers;
using ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Models;
using System.ComponentModel.DataAnnotations;

namespace ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.ViewModels
{
    public class NuevaSala
    {
        [Required(ErrorMessage = MensajesDeError.Requerido)]
        [Display(Name = Alias.NumeroSala)]
        public int NumeroDeSala { get; set; }
        [Required(ErrorMessage = MensajesDeError.Requerido)]
        [Display(Name = Alias.TipoSala)]
        public string TipoSala { get; set; }
        [Required(ErrorMessage = MensajesDeError.Requerido)]
        [Display(Name = Alias.CapacidadDeButacas)]
        public int CapacidadButacas { get; set; }
        [Required(ErrorMessage = MensajesDeError.Requerido)]
        [Display(Name = Alias.Pelicula)]
        public int PeliculaID { get; set; }
        [Display(Name = Alias.Pelicula)]
        public Pelicula Pelicula { get; set; }
        [Required(ErrorMessage = MensajesDeError.Requerido)]
        [Display(Name = Alias.FechaSala)]
        public DateTime Fecha { get; set; }
    }
}
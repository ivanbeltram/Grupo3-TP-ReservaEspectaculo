using ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Helpers;
using System.ComponentModel.DataAnnotations;

namespace ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Models
{
    public class Sala
{
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = MensajesDeError.Requerido)]
        public int NumeroDeSala { get; set; }
        [Required(ErrorMessage = MensajesDeError.Requerido)]
        public string TipoSala { get; set; }
        [Required(ErrorMessage = MensajesDeError.Requerido)]
        public int CapacidadButacas { get; set; }
        public int ButacasDisponibles { get; set; }
        public List<Reserva> Reservas { get; set; }
        public bool Confirmada { get; set; }
        [Required(ErrorMessage = MensajesDeError.Requerido)]
        [Display(Name = Alias.PeliculaId)]
        public int PeliculaID { get; set; }
        public Pelicula Pelicula { get; set; }
        [Required(ErrorMessage = MensajesDeError.Requerido)]
        public DateTime Fecha { get; set; }
    }
}

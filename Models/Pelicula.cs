using ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Helpers;
using System.ComponentModel.DataAnnotations;

namespace ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Models
{
    public class Pelicula
{
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = MensajesDeError.Requerido)]
        public string Titulo { get; set; }
        [Required(ErrorMessage = MensajesDeError.Requerido)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = MensajesDeError.Requerido)]
        [Display(Name = Alias.GeneroId)]
        public int GeneroId { get; set; }
        public Genero Genero { get; set; }
        [Required(ErrorMessage = MensajesDeError.Requerido)]
        public DateTime FechaLanzamiento { get; set; }
        public List<Sala> Salas { get; set; }
    }
}

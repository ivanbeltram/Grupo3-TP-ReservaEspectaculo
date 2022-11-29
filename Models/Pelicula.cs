using ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Helpers;
using System.ComponentModel.DataAnnotations;

namespace ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Models
{
    public class Pelicula
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = MensajesDeError.Requerido)]
        [Display(Name = Alias.Titulo)]
        public string Titulo { get; set; }
        [Required(ErrorMessage = MensajesDeError.Requerido)]
        [Display(Name = Alias.Descripcion)]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = MensajesDeError.Requerido)]
        [Display(Name = Alias.Genero)]
        public int GeneroId { get; set; }
        [Display(Name = Alias.Genero)]
        public Genero Genero { get; set; }
        [Required(ErrorMessage = MensajesDeError.Requerido)]
        [Display(Name = Alias.FechaLanzamiento)]
        public DateTime FechaLanzamiento { get; set; }
        public List<Sala> Salas { get; set; }
        public Pelicula()
        {
            Salas = new List<Sala>();
        }
        public void AgregarSala(Sala sala)
        {
            Salas.Add(sala);
        }
        public bool EliminarSala(Sala sala)
        {
            return Salas.Remove(sala);
        }
    }
}
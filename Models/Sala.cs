namespace ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Models
{
    public class Sala
{
        public int NumeroDeSala { get; set; }
        public string TipoSala { get; set; }
        public int CapacidadButacas { get; set; }
        public int ButacasDisponibles { get; set; }
        public List<Reserva> Reservas { get; set; }
        public bool Confirmada { get; set; }
        public int PeliculaID { get; set; }
        public Pelicula Pelicula { get; set; }
        public DateTime Fecha { get; set; }
    }
}

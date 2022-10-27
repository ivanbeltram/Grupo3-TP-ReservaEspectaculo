namespace ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Models
{
    public class Pelicula
{
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripción { get; set; }
        public int GeneroId { get; set; }
        public Genero Genero { get; set; }
        public DateTime FechaLanzamiento { get; set; }
        public List<Sala> Salas { get; set; }
    }
}

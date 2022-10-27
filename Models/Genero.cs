namespace ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Models
{
    public class Genero
{
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Pelicula> Peliculas { get; set; }
    }
}

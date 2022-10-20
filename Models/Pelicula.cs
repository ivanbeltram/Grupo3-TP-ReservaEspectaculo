namespace ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Models
{
    public class Pelicula
{
        public DateTime FechaLanzamiento {get; set; }
        public string Titulo {get; set; }
        public string Descripción {get; set; }
        public List<Funcion> Funciones {get; set; }
}
}

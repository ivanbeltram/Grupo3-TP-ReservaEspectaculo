namespace ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Models
{
    public class Funcion
{
        public DateTime Fecha {get; set; }
        public double Hora {get; set; }
        public string Descripcion {get; set; }
        public int ButacasDisponibles {get; set; }
        public Boolean Confirmado {get; set; }
        public List<Reserva> Reservas {get; set; }
}
}

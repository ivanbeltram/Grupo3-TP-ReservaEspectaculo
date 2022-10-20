namespace ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Models
{
    public class Reserva
{
        public DateTime FechaAlta {get; set; }
        public int CantidadButacas {get; set; }
        public Cliente Cliente {get; set; }
        public Funcion Funcion {get; set; }
}
}

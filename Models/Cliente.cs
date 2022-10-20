namespace ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Models
{
    public class Cliente
    {
        public String Nombre {get; set; }
        public String Apellido {get; set; }
        public String DNI {get; set; }
        public String Telefono {get; set; }
        public String Direccion {get; set; }
        public String Email {get; set; }
        public DateTime FechaAlta {get; set; }
        public List<Reserva> Reservas {get; set; }
    }
}

namespace ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Models
{
    public class Cliente
    {
        public String Nombre;
        public String Apellido;
        public String DNI;
        public String Telefono;
        public String Direccion;
        public String Email;
        public DateTime FechaAlta;
        public List<Reserva> Reservas;
    }
}

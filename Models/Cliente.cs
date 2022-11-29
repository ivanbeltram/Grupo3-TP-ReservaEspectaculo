namespace ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Models
{
    public class Cliente : Usuario
    {
        public List<Reserva> Reservas { get; set; }
        public Cliente()
        {
            this.Reservas = new List<Reserva>();
        }
        public void Reservar(Reserva reserva)
        {
            Reservas.Add(reserva);
        }
        public bool EliminarReserva(Reserva reserva)
        {
            return Reservas.Remove(reserva);
        }
    }
}
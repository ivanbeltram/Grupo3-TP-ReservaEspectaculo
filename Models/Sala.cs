using ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Helpers;
using System.ComponentModel.DataAnnotations;

namespace ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Models
{
    public class Sala
{
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = MensajesDeError.Requerido)]
        [Display(Name = Alias.NumeroSala)]
        public int NumeroDeSala { get; set; }
        [Required(ErrorMessage = MensajesDeError.Requerido)]
        [Display(Name = Alias.TipoSala)]
        public string TipoSala { get; set; }
        [Required(ErrorMessage = MensajesDeError.Requerido)]
        [Display(Name = Alias.CapacidadDeButacas)]
        public int CapacidadButacas { get; set; }
        [Display(Name = Alias.ButacasDisponibles)]
        public int ButacasDisponibles { get; set; }
        public List<Reserva> Reservas { get; set; }
        public bool Confirmada { get; set; }
        [Required(ErrorMessage = MensajesDeError.Requerido)]
        [Display(Name = Alias.Pelicula)]
        public int PeliculaId { get; set; }
        [Display(Name = Alias.Pelicula)]
        public Pelicula Pelicula { get; set; }
        [Required(ErrorMessage = MensajesDeError.Requerido)]
        [Display(Name = Alias.FechaSala)]
        public DateTime Fecha { get; set; }
        public string DetalleSoloSala
        {
            get
            {
                return $"{Alias.NumeroSala}: {NumeroDeSala} | {Alias.TipoSala}: {TipoSala} | {Alias.FechaSala}: {Fecha} | {Alias.CantidadDeButacas} disponibles: {ButacasDisponibles}";
            }
        }
        public string DetalleSalaConPelicula
        {
            get
            {
                if (Pelicula != null)
                {
                    return $"{Alias.NumeroSala}: {NumeroDeSala} | {Alias.TipoSala}: {TipoSala} | {Alias.FechaSala}: {Fecha} | {Alias.Pelicula}: {Pelicula.Titulo}";
                }
                else
                {
                    return MensajesDeError.DetalleSala;
                }
            }
        }
        public Sala()
        {
            Reservas = new List<Reserva>();
        }
        public bool ButacasSuficientes(int cantidadButacas)
        {
            return ButacasDisponibles >= cantidadButacas;
        }
        private void OtorgarButacas(int cantidadButacas)
        {
                ButacasDisponibles -= cantidadButacas;
        }
        public bool RecuperoDeButacasPorCancelacionDeReserva(int cantidadButacas)
        {
            bool recuperoDeButacas = false;
            if (ButacasDisponibles + cantidadButacas <= CapacidadButacas)
            {
                ButacasDisponibles += cantidadButacas;
                recuperoDeButacas = true;
            }
            return recuperoDeButacas;
        }
        public bool AgregarReserva(Reserva reserva)
        {
            bool reservaAgregada = false;
            if (reserva != null && ButacasSuficientes(reserva.CantidadButacas))
            {
                OtorgarButacas(reserva.CantidadButacas);
                Reservas.Add(reserva);
                reservaAgregada = true;
            }
            return reservaAgregada;
        }
        public bool EliminarReserva(int clienteId)
        {
            bool eliminarReserva = false;
            Reserva reservaPorEliminar = BuscarReserva(clienteId);
            if (reservaPorEliminar != null)
            {
                RecuperoDeButacasPorCancelacionDeReserva(reservaPorEliminar.CantidadButacas);
                Reservas.Remove(reservaPorEliminar);
                eliminarReserva = true;
            }
            return eliminarReserva;
        }
        private Reserva BuscarReserva(int clienteId)
        {
            Reserva ReservaEncontrada = null;
            int i = 0;
            while (i < Reservas.Count && Reservas.ElementAt(i).ClienteId != clienteId)
            {
                i++;
            }
            if (i < Reservas.Count)
            {
                ReservaEncontrada = Reservas.ElementAt(i);
            }
            return ReservaEncontrada;
        }
    }
}

namespace ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Helpers
{
    public static class MensajesDeError
    {
        public const string ButacasInsuficientes = "La sala no cuenta con butacas suficientes.";
        public const string ClienteConReserva = "No es posible generar la nueva reserva debido a que el cliente ya cuenta con una reserva activa.";
        public const string ClienteSinReservas = "Este cliente no realizó ninguna reserva.";
        public const string ConfirmacionCancelacionReservaNull = "Debe decidir si confirma o no la cancelación de la reserva.";
        public const string DetalleReserva = "No es posible obtener el detalle de la reserva.";
        public const string DetalleSala = "No es posible obtener el detalle de la sala.";
        public const string DniInvalido = "El DNI debe estar comprendido entre {1} y {2}.";
        public const string EmailInvalido = "El email no es válido.";
        public const string GeneroSinPeliculas = "Este género no cuenta con películas asignadas.";
        public const string PasswordMissmatch = "Las contraseñas no coinciden.";
        public const string PeliculaSinSalas = "Esta película no cuenta con salas asignadas.";
        public const string Requerido = "El campo {0} es requerido.";
        public const string ReservaYaCancelada = "La reserva ya fue cancelada en el pasado, y no es posible recuperarla o cancelarla nuevamente.";
        public const string SalaEnUso = "Esa sala está en uso en ese momento.";
        public const string SalaSinReservasActivas = "Esta no cuenta con ninguna reserva activa.";
        public const string SalaSinReservasInactivas = "Esta no cuenta con ninguna reserva inactiva.";
        public const string StrSoloAlfab = "Para el campo {0} sólo pueden utilizarse caracteres alfabéticos.";
    }
}
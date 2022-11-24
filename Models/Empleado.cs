using ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Helpers;
using System.ComponentModel.DataAnnotations;

namespace ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Models
{
    public class Empleado : Usuario
    {
        [Required(ErrorMessage = MensajesDeError.Requerido)]
        public int Legajo { get; set; }
    }
}
using ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Helpers;
using System.ComponentModel.DataAnnotations;

namespace ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.ViewModels
{
    public class Login
    {
		[Required(ErrorMessage = MensajesDeError.Requerido)]
		[EmailAddress(ErrorMessage = MensajesDeError.EmailInvalido)]
		[Display(Name = Alias.Email)]
		public string Email { get; set; }
		[Required(ErrorMessage = MensajesDeError.Requerido)]
		[DataType(DataType.Password)]
		[Display(Name = Alias.Password)]
		public string Password { get; set; }
		public bool Recordarme { get; set; }
	}
}
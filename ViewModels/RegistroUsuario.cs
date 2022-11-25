using ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Helpers;
using System.ComponentModel.DataAnnotations;

namespace ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.ViewModels
{
    public class RegistroUsuario
    {
		[Required(ErrorMessage = MensajesDeError.Requerido)]
		[RegularExpression(@"[a-zA-Z áéíóú]*", ErrorMessage = MensajesDeError.StrSoloAlfab)]
		public string Nombre { get; set; }
		[Required(ErrorMessage = MensajesDeError.Requerido)]
		[RegularExpression(@"[a-zA-Z áéíóú]*", ErrorMessage = MensajesDeError.StrSoloAlfab)]
		public string Apellido { get; set; }
		[Required(ErrorMessage = MensajesDeError.Requerido)]
		[Range(1000000, 99999999, ErrorMessage = MensajesDeError.DniInvalido)]
		public string Dni { get; set; }
		[Required(ErrorMessage = MensajesDeError.Requerido)]
		[EmailAddress(ErrorMessage = MensajesDeError.EmailInvalido)]
		[Display(Name = Alias.Email)]
		public string Email { get; set; }
		[Required(ErrorMessage = MensajesDeError.Requerido)]
		public string Rol { get; set; }
		[Required(ErrorMessage = MensajesDeError.Requerido)]
		[DataType(DataType.Password)]
		[Display(Name = Alias.Password)]
		public string Password { get; set; }
		[Required(ErrorMessage = MensajesDeError.Requerido)]
		[DataType(DataType.Password)]
		[Display(Name = Alias.PasswordConfirm)]
		[Compare("Password", ErrorMessage = MensajesDeError.PasswordMissmatch)]
		public string ConfirmacionPassword { get; set; }
	}
}
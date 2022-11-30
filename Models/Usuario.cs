using Microsoft.AspNetCore.Identity;
using ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Helpers;
using System.ComponentModel.DataAnnotations;

namespace ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Models
{
    public class Usuario : IdentityUser<int>
	{
		[Required(ErrorMessage = MensajesDeError.Requerido)]
		[RegularExpression(@"[a-zA-Z áéíóú]*", ErrorMessage = MensajesDeError.StrSoloAlfab)]
		public string Nombre { get; set; }

		[Required(ErrorMessage = MensajesDeError.Requerido)]
		[RegularExpression(@"[a-zA-Z áéíóú]*", ErrorMessage = MensajesDeError.StrSoloAlfab)]
		public string Apellido { get; set; }

		public string NombreCompleto {
			get {
				if (string.IsNullOrEmpty(Nombre) && string.IsNullOrEmpty(Apellido)) return "Sin definir";
				if (string.IsNullOrEmpty(Nombre)) return Apellido;
				if (string.IsNullOrEmpty(Apellido)) return Nombre;
				return $"{Nombre} {Apellido}";
			}
		}

		[Required(ErrorMessage = MensajesDeError.Requerido)]
		[EmailAddress(ErrorMessage = MensajesDeError.EmailInvalido)]
		[Display(Name = Alias.Email)]
		public override string Email
		{
			get { return base.Email; }
			set { base.Email = value; }
		}

		[Required(ErrorMessage = MensajesDeError.Requerido)]
		[Range(1000000,99999999, ErrorMessage = MensajesDeError.DniInvalido)]
		public string Dni { get; set; }

		[Display(Name = Alias.Telefono)]
		public override string PhoneNumber
		{
			get { return base.PhoneNumber; }
			set { base.PhoneNumber = value; }
		}

		[Display(Name = Alias.Direccion)]
		public string Direccion { get; set; }

		[Required(ErrorMessage = MensajesDeError.Requerido)]
		[Display(Name = Alias.FechaAltaCliente)]
		[DataType(DataType.DateTime)]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
		public DateTime FechaAlta { get; set; }

	}
}
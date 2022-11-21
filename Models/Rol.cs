using Microsoft.AspNetCore.Identity;
using ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Helpers;
using System.ComponentModel.DataAnnotations;

namespace ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Models
{
    public class Rol : IdentityRole<int>
    {
        public Rol() : base() { }
        public Rol(string name) : base(name) { }

        [Required(ErrorMessage = MensajesDeError.Requerido)]
        [Display(Name = Alias.RoleName)]
        public override string Name
        {
            get { return base.Name; }
            set { base.Name = value; }
        }
        public override string NormalizedName {
            get { return base.NormalizedName; }
            set { base.NormalizedName = value; }
        }
    }
}
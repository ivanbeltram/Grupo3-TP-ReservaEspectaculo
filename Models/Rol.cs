using ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel.DataAnnotations;

namespace ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Models
{
    public class Rol : IdentityRole<int>
    {
        public Rol() : base() { }
        public Rol(string name) : base(name) { }

        [Display (Name = Alias.RoleName)]
        public string Name {
            get { return base.Name; }
            set { base.Name = value; }
        }
        public override string NormalizedName {
            get => base.NormalizedName;
            set => base.NormalizedName = value;
        }
    }
}
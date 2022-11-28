using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Data;
using ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Helpers;
using ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Models;

namespace ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Controllers
{
    public class PreCarga : Controller
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly RoleManager<Rol> _roleManager;
        private readonly CineContext _context;
        private List<string> roles = new List<string>() { Configs.Cliente, Configs.Empleado};

        public PreCarga(UserManager<Usuario> userManager, RoleManager<Rol> roleManager, CineContext context)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._context = context;
        }

        public IActionResult Seed()
        {
            CrearRoles().Wait();
            return RedirectToAction("Index", "Home");
        }

        private async Task CrearRoles()
        {
            foreach(var rolName in roles)
            {
                if (!await _roleManager.RoleExistsAsync(rolName))
                {
                    await _roleManager.CreateAsync(new Rol(rolName));
                }
            }
        }
    }
}
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Models;
using ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.ViewModels;

namespace ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;

        public AccountController(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }

        public IActionResult Registrar()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registrar([Bind("Nombre,Apellido,Dni,Email,Rol,FechaAlta,Password,ConfirmacionPassword")]RegistroUsuario usuario)
        {
            if (ModelState.IsValid)
            {
                if(usuario.Rol == "Cliente")
                {
                    Cliente c = new Cliente()
                    {
                        Nombre = usuario.Nombre,
                        Apellido = usuario.Apellido,
                        Dni = usuario.Dni,
                        Email = usuario.Email,
                        NormalizedEmail = usuario.Email.ToUpper(),
                        UserName = usuario.Email,
                        FechaAlta = DateTime.Today
                    };
                    var resultadoCreate = await _userManager.CreateAsync(c, usuario.Password);
                    if (resultadoCreate.Succeeded)
                    {
                        await _signInManager.SignInAsync(c, isPersistent: false);
                        return RedirectToAction("Edit","Clientes", new { id = c.Id });
                    }
                    foreach (var error in resultadoCreate.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
            }
                if (usuario.Rol == "Empleado")
                {
                    Empleado e = new Empleado()
                    {
                        Nombre = usuario.Nombre,
                        Apellido = usuario.Apellido,
                        Dni = usuario.Dni,
                        Email = usuario.Email,
                        NormalizedEmail = usuario.Email.ToUpper(),
                        UserName = usuario.Email,
                        FechaAlta = DateTime.Today
                    };
                    var resultadoCreate = await _userManager.CreateAsync(e, usuario.Password);
                    if (resultadoCreate.Succeeded)
                    {
                        await _signInManager.SignInAsync(e, isPersistent: false);
                        return RedirectToAction("Edit", "Empleados", new { id = e.Id });
                    }
                    foreach (var error in resultadoCreate.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View();
        }
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Data;
using ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Helpers;
using ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Models;
using ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.ViewModels;

namespace ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly CineContext _context;

        public AccountController(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, CineContext context)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._context = context;
        }

        [AllowAnonymous]
        public IActionResult Registrar()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Registrar([Bind("Nombre,Apellido,Dni,Email,Rol,Password,ConfirmacionPassword")]RegistroUsuario usuario)
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
                        var resultadoAddRole = await _userManager.AddToRoleAsync(c, Configs.Cliente);
                        if (resultadoAddRole.Succeeded)
                        {
                            await _signInManager.SignInAsync(c, isPersistent: false);
                            return RedirectToAction("Edit", "Clientes", new { id = c.Id });
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, $"No se pudo agregar el rol {Configs.Cliente}");
                        }
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
                        var resultadoAddRole = await _userManager.AddToRoleAsync(e, Configs.Empleado);
                        if (resultadoAddRole.Succeeded)
                        {
                            await _signInManager.SignInAsync(e, isPersistent: false);
                            return RedirectToAction("Edit", "Empleados", new { id = e.Id });
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, $"No se pudo agregar el rol {Configs.Empleado}");
                        }
                    }
                    foreach (var error in resultadoCreate.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> IniciarSesion(string returnUrl)
        {
            TempData["ReturnUrl"] = returnUrl;
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> IniciarSesion(Login login)
        {
            string returnUrl = TempData["ReturnUrl"] as string;

            if (ModelState.IsValid)
            {
                var resultado = await _signInManager.PasswordSignInAsync(login.Email, login.Password, login.Recordarme, false);

                if (resultado.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                } else
                {
                    ModelState.AddModelError(String.Empty, "Inicio de sesión inválido.");
                    return View();
                }
            }
            return null;
        }
        
        public async Task<IActionResult> CerrarSesion()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
 
        public IActionResult AccesoDenegado()
        {
            return View();
        }

        // GET: Clientes
        public async Task<IActionResult> MiCuenta()
        {
            if (!_signInManager.IsSignedIn(User))
            {
                return NotFound();
            }

            Usuario usuario = _context.Usuarios.Where(u => u.Email == User.Identity.Name.ToString()).ToList().ElementAt(0);
            int idUsuario = usuario.Id;

            if (User.IsInRole(Configs.Cliente))
            {
                return RedirectToAction("Details", "Clientes", new {id = idUsuario});
            }
            if (User.IsInRole(Configs.Empleado))
            {
                return RedirectToAction("Details", "Empleados", new { id = idUsuario });
            }
            return NotFound();
        }
    }
}
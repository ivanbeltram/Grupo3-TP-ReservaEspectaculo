using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Data;
using ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Helpers;
using ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Models;
using ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.ViewModels;

namespace ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Controllers
{
    [Authorize]
    public class ReservasController : Controller
    {
        private readonly CineContext _context;
        private readonly SignInManager<Usuario> _signInManager;

        public ReservasController(CineContext context, SignInManager<Usuario> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
        }

        // GET: Reservas
        [Authorize(Roles = Configs.Empleado)]
        public async Task<IActionResult> Index()
        {
            var cineContext = _context.Reservas.Include(r => r.Cliente).Include(r => r.Sala).Include(r => r.Sala.Pelicula);
            return View(await cineContext.ToListAsync());
        }

        // GET: Reservas
        public async Task<IActionResult> MisReservas()
        {
            if (!_signInManager.IsSignedIn(User) || _context.Reservas == null)
            {
                return NotFound();
            }
            var cineContext = _context.Reservas.Include(r => r.Cliente).Include(r => r.Sala).Include(r => r.Sala.Pelicula).Where(r => r.Cliente.Email == User.Identity.Name.ToString());
            return View(await cineContext.ToListAsync());
        }

        // GET: Reservas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Reservas == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas
                .Include(r => r.Cliente)
                .Include(r => r.Sala)
                .Include(r => r.Sala.Pelicula)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (reserva == null)
            {
                return NotFound();
            }

            if (!User.IsInRole(Configs.Empleado))
            {
                if (User.Identity.Name.ToString() != reserva.Cliente.Email)
                {
                    return NotFound();
                }
            }

            return View(reserva);
        }

        // GET: Reservas/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "NombreCompleto");
            ViewData["ClienteIdCreate"] = new SelectList(_context.Clientes.Where(c => c.Email.ToString().Equals(User.Identity.Name.ToString())), "Id", "NombreCompleto");
            ViewData["SalaId"] = new SelectList(_context.Salas.Include(s => s.Pelicula), "Id", "DetalleSalaConPelicula");
            return View();
        }

        // POST: Reservas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SalaId,ClienteId,CantidadButacas")] NuevaReserva nuevaReserva)
        {
            if (ModelState.IsValid)
            {
                if (!ClienteConReservaActiva(nuevaReserva.ClienteId))
                {
                    Sala SalaSeleccionada = _context.Salas.Find(nuevaReserva.SalaId);
                    if (SalaSeleccionada.ButacasSuficientes(nuevaReserva.CantidadButacas))
                    {
                        Reserva r = new Reserva()
                        {
                            SalaId = nuevaReserva.SalaId,
                            ClienteId = nuevaReserva.ClienteId,
                            CantidadButacas = nuevaReserva.CantidadButacas,
                            Activa = true,
                            FechaAlta = DateTime.Today
                        };
                        _context.Reservas.Add(r);
                        await _context.SaveChangesAsync();
                        Cliente c = _context.Clientes.Find(nuevaReserva.ClienteId);
                        c.Reservar(r);
                        Reserva reservaAgregada = _context.Reservas.ToList().ElementAt(_context.Reservas.ToList().Count() - 1);
                        SalaSeleccionada.AgregarReserva(reservaAgregada);
                        await _context.SaveChangesAsync();
                        if (User.IsInRole(Configs.Cliente))
                        {
                            return RedirectToAction(nameof(MisReservas));
                        }
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, MensajesDeError.ButacasInsuficientes);
                        return View();
                    }
                } else
                {
                    ModelState.AddModelError(string.Empty, MensajesDeError.ClienteConReserva);
                    return View();
                }
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "NombreCompleto");
            ViewData["ClienteIdCreate"] = new SelectList(_context.Clientes.Where(c => c.Email.ToString().Equals(User.Identity.Name.ToString())), "Id", "NombreCompleto");
            ViewData["SalaId"] = new SelectList(_context.Salas.Include(s => s.Pelicula), "Id", "DetalleSala", nuevaReserva.SalaId);
            return View(nuevaReserva);
        }

        // GET: Reservas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Reservas == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "NombreCompleto", reserva.ClienteId);
            ViewData["SalaId"] = new SelectList(_context.Salas.Include(s => s.Pelicula), "Id", "NumeroDeSala", reserva.SalaId);
            return View(reserva);
        }

        // POST: Reservas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(bool ConfirmarCancelacion, int id, [Bind("Id,SalaId,ClienteId,CantidadButacas,Activa,FechaAlta")] Reserva reserva)
        {
            if (id != reserva.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (ConfirmarCancelacion != null)
                    {
                        if (!ConfirmarCancelacion)
                        {
                            _context.Reservas.Update(reserva);
                            await _context.SaveChangesAsync();
                        }
                        else
                        {
                            if (reserva.Activa)
                            {
                                Sala s = _context.Salas.Find(reserva.SalaId);
//                                List<Sala> lista = _context.Salas.Include(s => s.Reservas).Where(s => s.Id == reserva.SalaId).ToList();
//                                Sala s = lista.ElementAt(0);
//                                s.EliminarReserva(reserva.ClienteId);
                                s.RecuperoDeButacasPorCancelacionDeReserva(reserva.CantidadButacas);
                                reserva.Activa = !reserva.Activa;
                                _context.Reservas.Update(reserva);
                                await _context.SaveChangesAsync();
                            }
                            else
                            {
                                ModelState.AddModelError(string.Empty, MensajesDeError.ReservaYaCancelada);
                                return View();
                            }
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, MensajesDeError.ConfirmacionCancelacionReservaNull);
                        return View();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaExists(reserva.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                if (User.IsInRole(Configs.Cliente))
                {
                    return RedirectToAction(nameof(MisReservas));
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "NombreCompleto", reserva.ClienteId);
            ViewData["SalaId"] = new SelectList(_context.Salas.Include(s => s.Pelicula), "Id", "NumeroDeSala", reserva.SalaId);
            return View(reserva);
        }

        // GET: Reservas/Delete/5
        [Authorize(Roles = Configs.Empleado)]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Reservas == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas
                .Include(r => r.Cliente)
                .Include(r => r.Sala)
                .Include(r => r.Sala.Pelicula)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // POST: Reservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Configs.Empleado)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Reservas == null)
            {
                return Problem("Entity set 'CineContext.Reservas'  is null.");
            }
            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva != null)
            {
                Sala s = _context.Salas.Find(reserva.SalaId);
                s.EliminarReserva(reserva.ClienteId);
                Cliente c = _context.Clientes.Find(reserva.ClienteId);
                c.EliminarReserva(reserva);
                _context.Reservas.Remove(reserva);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaExists(int id)
        {
          return _context.Reservas.Any(e => e.Id == id);
        }

        private bool ClienteConReservaActiva(int idCliente)
        {
            bool tieneReserva = false;
            List<Reserva> listaDeReservas = _context.Reservas.Where(r => r.Activa == true).ToList();
            int i = 0;
            while (i < listaDeReservas.Count && listaDeReservas.ElementAt(i).ClienteId != idCliente)
            {
                i++;
            }
            if (i < listaDeReservas.Count)
            {
                tieneReserva = true;
            }
            return tieneReserva;
        }
    }
}
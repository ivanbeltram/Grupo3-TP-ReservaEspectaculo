using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Data;
using ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Helpers;
using ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Models;
using ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.ViewModels;

namespace ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Controllers
{
    public class SalasController : Controller
    {
        private readonly CineContext _context;

        public SalasController(CineContext context)
        {
            _context = context;
        }

        // GET: Salas
        public async Task<IActionResult> Index()
        {
            var cineContext = _context.Salas.Include(s => s.Pelicula);
            return View(await cineContext.ToListAsync());
        }

        // GET: Salas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Salas == null)
            {
                return NotFound();
            }

            var sala = await _context.Salas
                .Include(s => s.Pelicula)
                .Include(s => s.Reservas)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sala == null)
            {
                return NotFound();
            }

            ViewBag.Pelicula = _context.Peliculas.Where(p => p.Id == sala.PeliculaId).ToList();
            ViewBag.reservasActivasDeLaSala = _context.Reservas.Include(r => r.Cliente).Include(r => r.Sala).Include(r => r.Sala.Pelicula).Where(r => r.SalaId == id).Where(r => r.Activa == true).ToList();
            ViewBag.reservasInactivasDeLaSala = _context.Reservas.Include(r => r.Cliente).Include(r => r.Sala).Include(r => r.Sala.Pelicula).Where(r => r.SalaId == id).Where(r => r.Activa == false).ToList();

            return View(sala);
        }

        // GET: Salas/Create
        [Authorize(Roles = Configs.Empleado)]
        public IActionResult Create()
        {
            ViewData["PeliculaId"] = new SelectList(_context.Peliculas, "Id", "Titulo");
            return View();
        }

        // POST: Salas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Configs.Empleado)]
        public async Task<IActionResult> Create([Bind("NumeroDeSala,TipoSala,CapacidadButacas,PeliculaId,Fecha")] NuevaSala nuevaSala)
        {

            if (ModelState.IsValid)
            {
                if (!SalaEnUso(nuevaSala.NumeroDeSala, nuevaSala.Fecha))
                {
                    Sala s = new Sala()
                    {
                        NumeroDeSala = nuevaSala.NumeroDeSala,
                        TipoSala = nuevaSala.TipoSala,
                        CapacidadButacas = nuevaSala.CapacidadButacas,
                        ButacasDisponibles = nuevaSala.CapacidadButacas,
                        Confirmada = true,
                        PeliculaId = nuevaSala.PeliculaId,
                        Fecha = nuevaSala.Fecha
                    };
                    Pelicula p = _context.Peliculas.Find(nuevaSala.PeliculaId);
                    p.AgregarSala(s);

                    _context.Salas.Add(s);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, MensajesDeError.SalaEnUso);
                    return View();
                }
            }
            ViewData["PeliculaId"] = new SelectList(_context.Peliculas, "Id", "Titulo", nuevaSala.PeliculaId);
            return View(nuevaSala);
        }

        // GET: Salas/Edit/5
        [Authorize(Roles = Configs.Empleado)]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Salas == null)
            {
                return NotFound();
            }

            var sala = await _context.Salas.FindAsync(id);
            if (sala == null)
            {
                return NotFound();
            }
            ViewData["PeliculaId"] = new SelectList(_context.Peliculas, "Id", "Titulo", sala.PeliculaId);
            return View(sala);
        }

        // POST: Salas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Configs.Empleado)]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NumeroDeSala,TipoSala,CapacidadButacas,ButacasDisponibles,Confirmada,PeliculaId,Fecha")] Sala sala)
        {
            if (id != sala.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Salas.Update(sala);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Details", "Salas", new { id = sala.Id });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalaExists(sala.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PeliculaId"] = new SelectList(_context.Peliculas, "Id", "Titulo", sala.PeliculaId);
            return View(sala);
        }

        // GET: Salas/Delete/5
        [Authorize(Roles = Configs.Empleado)]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Salas == null)
            {
                return NotFound();
            }

            var sala = await _context.Salas
                .Include(s => s.Pelicula)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sala == null)
            {
                return NotFound();
            }

            return View(sala);
        }

        // POST: Salas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Configs.Empleado)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Salas == null)
            {
                return Problem("Entity set 'CineContext.Salas'  is null.");
            }
            var sala = await _context.Salas.FindAsync(id);
            if (sala != null)
            {
                Pelicula p = _context.Peliculas.Find(sala.PeliculaId);
                p.EliminarSala(sala);
                _context.Salas.Remove(sala);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalaExists(int id)
        {
            return _context.Salas.Any(e => e.Id == id);
        }

        private bool SalaEnUso(int numeroDeSala, DateTime fecha)
        {
            bool salaEnUso = false;
            List<Sala> listaDeSalas = _context.Salas.ToList();
            int i = 0;
            while (i < listaDeSalas.Count && !(listaDeSalas.ElementAt(i).NumeroDeSala == numeroDeSala && listaDeSalas.ElementAt(i).Fecha.ToString().Equals(fecha.ToString())))
            {
                i++;
            }
            if (i < listaDeSalas.Count)
            {
                salaEnUso = true;
            }
            return salaEnUso;
        }
    }
}

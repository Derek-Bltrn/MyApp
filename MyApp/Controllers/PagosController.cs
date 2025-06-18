using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using MyApp.Models;

namespace MyApp.Controllers
{
    public class PagosController : Controller
    {
        private readonly MyAppContext _context;

        public PagosController(MyAppContext context)
        {
            _context = context;
        }

        // Mostrar lista de pagos
        public async Task<IActionResult> Index()
        {
            var pagos = await _context.Pagos.ToListAsync();
            ViewBag.TotalPagos = pagos.Sum(p => p.Monto);
            return View(pagos);
        }

        // Mostrar formulario para crear pagos
        public IActionResult Create()
        {
            return View();
        }

        // Crear pagos
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Nombre, Monto, Fecha, Descripcion, Destinatario")] Pago pago)
        {
            if (ModelState.IsValid)
            {
                // Pagos repetidos
                bool yaExiste = await _context.Pagos.AnyAsync(p =>
                    p.Nombre == pago.Nombre &&
                    p.Monto == pago.Monto &&
                    p.Fecha == pago.Fecha);

                if (yaExiste)
                {
                    ModelState.AddModelError("", "Este pago ya existe.");
                    return View(pago);
                }

                _context.Pagos.Add(pago);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pago);
        }

        // Mostrar formulario para editar pagos
        public async Task<IActionResult> Edit(int id)
        {
            var pago = await _context.Pagos.FindAsync(id);
            if (pago == null) return NotFound();
            return View(pago);
        }

        // Editar pagos
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Nombre, Monto, Fecha, Descripcion, Destinatario")] Pago pago)
        {
            if (id != pago.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pago);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PagoExiste(pago.Id)) return NotFound();
                    else throw;
                }
            }
            return View(pago);
        }

        // Mostrar pago a eliminar
        public async Task<IActionResult> Delete(int id)
        {
            var pago = await _context.Pagos.FirstOrDefaultAsync(p => p.Id == id);
            if (pago == null) return NotFound();
            return View(pago);
        }

        // Eliminar pago
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pago = await _context.Pagos.FindAsync(id);
            if (pago != null)
            {
                _context.Pagos.Remove(pago);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        // Mostrar vista de eliminacion multiple
        public async Task<IActionResult> BulkDelete()
        {
            var pagos = await _context.Pagos.ToListAsync();
            return View(pagos);
        }

        // Mostrar multiples pagos a eliminar
        [HttpPost]
        public async Task<IActionResult> ShowBulkDelete(List<int> ids)
        {
            if (ids == null || !ids.Any())
            {
                return RedirectToAction(nameof(BulkDelete));
            }

            var pagos = await _context.Pagos
                .Where(p => ids.Contains(p.Id))
                .ToListAsync();

            return View("ShowBulkDelete", pagos);
        }

        // Eliminar multiples pagos
        [HttpPost]
        public async Task<IActionResult> BulkDeleteConfirmed(List<int> ids)
        {
            var pagosAEliminar = await _context.Pagos
                .Where(p => ids.Contains(p.Id))
                .ToListAsync();

            _context.Pagos.RemoveRange(pagosAEliminar);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool PagoExiste(int id)
        {
            return _context.Pagos.Any(p => p.Id == id);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoRumo.Data;
using ProjetoRumo.Models;

namespace ProjetoRumo.Controllers
{
    public class CopaController : Controller
    {
        private readonly PedidoContext _context;

        public CopaController(PedidoContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Copa.ToListAsync());
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var copa = await _context.Copa
                .FirstOrDefaultAsync(m => m.CopaId == id);
            if (copa == null)
            {
                return NotFound();
            }

            return View(copa);
        }
        public IActionResult Create()
        {        return View();
        }public async Task<IActionResult> Create([Bind("CopaId,BebidaEscolhida,Quantidade")] Copa copa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(copa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(copa);
        }
                public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var copa = await _context.Copa.FindAsync(id);
            if (copa == null)
            {
                return NotFound();
            }
            return View(copa);
        }        
        public async Task<IActionResult> Edit(int id, [Bind("CopaId,BebidaEscolhida,Quantidade")] Copa copa)
        {
            if (id != copa.CopaId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                  _context.Update(copa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CopaExists(copa.CopaId))
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
            return View(copa);

        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }var copa = await _context.Copa
                .FirstOrDefaultAsync(m => m.CopaId == id);
            if (copa == null)
            {
                return NotFound();
            }

            return View(copa);
        }
         public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var copa = await _context.Copa.FindAsync(id);
            _context.Copa.Remove(copa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool CopaExists(int id)
        {
            return _context.Copa.Any(e => e.CopaId == id);
        }
    }
}

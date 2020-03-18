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
    public class CozinhaController : Controller
    {
        private readonly PedidoContext _context;

        public CozinhaController(PedidoContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cozinha.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cozinha = await _context.Cozinha
                .FirstOrDefaultAsync(m => m.CozinhaId == id);
            if (cozinha == null)
            {
                return NotFound();
            }

            return View(cozinha);
        }
        public IActionResult Create()
        {
            return View();
        }
        public async Task<IActionResult> Create([Bind("CozinhaId,PratoEscolho,Quantidade")] Cozinha cozinha)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cozinha);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cozinha);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cozinha = await _context.Cozinha.FindAsync(id);
            if (cozinha == null)
            {
                return NotFound();
            }
            return View(cozinha);
        }
        public async Task<IActionResult> Edit(int id, [Bind("CozinhaId,PratoEscolho,Quantidade")] Cozinha cozinha)
        {
            if (id != cozinha.CozinhaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cozinha);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CozinhaExists(cozinha.CozinhaId))
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
            return View(cozinha);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cozinha = await _context.Cozinha
                .FirstOrDefaultAsync(m => m.CozinhaId == id);
            if (cozinha == null)
            {
                return NotFound();
            }

            return View(cozinha);
        }
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cozinha = await _context.Cozinha.FindAsync(id);
            _context.Cozinha.Remove(cozinha);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CozinhaExists(int id)
        {
            return _context.Cozinha.Any(e => e.CozinhaId == id);
        }
    }
}

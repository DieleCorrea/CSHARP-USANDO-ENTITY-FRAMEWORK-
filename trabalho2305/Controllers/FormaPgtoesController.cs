using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using trabalho2305.Data;
using trabalho2305.Models;

namespace trabalho2305.Controllers
{
    public class FormaPgtoesController : Controller
    {
        private readonly trabalho2305Context _context;

        public FormaPgtoesController(trabalho2305Context context)
        {
            _context = context;
        }

        // GET: FormaPgtoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.FormaPgto.ToListAsync());
        }

        // GET: FormaPgtoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formaPgto = await _context.FormaPgto
                .FirstOrDefaultAsync(m => m.IdFormaPgto == id);
            if (formaPgto == null)
            {
                return NotFound();
            }

            return View(formaPgto);
        }

        // GET: FormaPgtoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FormaPgtoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFormaPgto,DescricaoFormaPgto")] FormaPgto formaPgto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(formaPgto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(formaPgto);
        }

        // GET: FormaPgtoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formaPgto = await _context.FormaPgto.FindAsync(id);
            if (formaPgto == null)
            {
                return NotFound();
            }
            return View(formaPgto);
        }

        // POST: FormaPgtoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFormaPgto,DescricaoFormaPgto")] FormaPgto formaPgto)
        {
            if (id != formaPgto.IdFormaPgto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formaPgto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormaPgtoExists(formaPgto.IdFormaPgto))
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
            return View(formaPgto);
        }

        // GET: FormaPgtoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formaPgto = await _context.FormaPgto
                .FirstOrDefaultAsync(m => m.IdFormaPgto == id);
            if (formaPgto == null)
            {
                return NotFound();
            }

            return View(formaPgto);
        }

        // POST: FormaPgtoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var formaPgto = await _context.FormaPgto.FindAsync(id);
            _context.FormaPgto.Remove(formaPgto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormaPgtoExists(int id)
        {
            return _context.FormaPgto.Any(e => e.IdFormaPgto == id);
        }
    }
}

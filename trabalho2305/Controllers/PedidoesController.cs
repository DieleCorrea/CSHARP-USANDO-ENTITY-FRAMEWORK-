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
    public class PedidoesController : Controller
    {
        private readonly trabalho2305Context _context;

        public PedidoesController(trabalho2305Context context)
        {
            _context = context;
        }

        // GET: Pedidoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pedido.ToListAsync());
        }


        public async Task<IActionResult> IndexFiltro(string p_nome, string p_nomecliente, string p_formapagar, string obs, string criteriobusca)
        {


            ///////////////////////////////////////////////////////////////
            var v_formas = from x in _context.FormaPgto select x.DescricaoFormaPgto;
            @ViewBag.formapag = new SelectList(await v_formas.ToListAsync());

            ///////////////////////////////////////////////////////////////
            var v_clientes = from x in _context.Cliente select x.NomeCliente;
            @ViewBag.nomeCli = new SelectList(await v_clientes.ToListAsync());

            ///////////////////////////////////////////////////////////////

            var v_cidades = from x in _context.Cidade select x.NomeCidade;
            @ViewBag.pnomeCidade = new SelectList(await v_cidades.ToListAsync());

            var pedidosfiltro = from x in _context.Pedido select x;

            if (!String.IsNullOrEmpty(p_formapagar))
            {
                pedidosfiltro = from x in _context.Pedido
                                join y in _context.FormaPgto on x.IdFormaPgto equals y.IdFormaPgto
                                where y.DescricaoFormaPgto == p_formapagar
                                select x;
            }

            if (!String.IsNullOrEmpty(p_nome))
            {
                pedidosfiltro = from x in _context.Pedido
                                join y in _context.Cidade on x.IdCidade equals y.IdCidade
                                where y.NomeCidade == p_nome
                                select x;
            }

            if (!String.IsNullOrEmpty(p_nomecliente))
            {
                pedidosfiltro = from x in _context.Pedido
                                join y in _context.Cliente on x.IdCliente equals y.IdCliente
                                where y.NomeCliente == p_nomecliente
                                select x;
            }

            if (!String.IsNullOrEmpty(criteriobusca))
            {
                pedidosfiltro = pedidosfiltro.Where(zz => zz.Observacao == (criteriobusca));

            }

            return View(await pedidosfiltro.ToListAsync());

        }












        // GET: Pedidoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedido
                .FirstOrDefaultAsync(m => m.IdPedido == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // GET: Pedidoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pedidoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPedido,IdCliente,IdCidade,Valor,Observacao,IdFormaPgto")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pedido);
        }

        // GET: Pedidoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedido.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }
            return View(pedido);
        }

        // POST: Pedidoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPedido,IdCliente,IdCidade,Valor,Observacao,IdFormaPgto")] Pedido pedido)
        {
            if (id != pedido.IdPedido)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoExists(pedido.IdPedido))
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
            return View(pedido);
        }

        // GET: Pedidoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedido
                .FirstOrDefaultAsync(m => m.IdPedido == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // POST: Pedidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedido = await _context.Pedido.FindAsync(id);
            _context.Pedido.Remove(pedido);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoExists(int id)
        {
            return _context.Pedido.Any(e => e.IdPedido == id);
        }
    }
}

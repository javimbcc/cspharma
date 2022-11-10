using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CSPHARMA_DAL.Modelos;

namespace CSPHARMA.Pages.EP
{
    public class EditModel : PageModel
    {
        private readonly CSPHARMA_DAL.Modelos.CspharmaInformacionalContext _context;

        public EditModel(CSPHARMA_DAL.Modelos.CspharmaInformacionalContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TdcTchEstadoPedido TdcTchEstadoPedido { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.TdcTchEstadoPedidos == null)
            {
                return NotFound();
            }

            var tdctchestadopedido =  await _context.TdcTchEstadoPedidos.FirstOrDefaultAsync(m => m.MdUuid == id);
            if (tdctchestadopedido == null)
            {
                return NotFound();
            }
            TdcTchEstadoPedido = tdctchestadopedido;
           ViewData["MdUuid"] = new SelectList(_context.TdcCatEstadosDevolucionPedidos, "MdUuid", "MdUuid");
           ViewData["MdUuid"] = new SelectList(_context.TdcCatEstadosPagoEnvios, "MdUuid", "MdUuid");
           ViewData["MdUuid"] = new SelectList(_context.TdcCatLineasDistribucions, "MdUuid", "MdUuid");
           ViewData["MdUuid"] = new SelectList(_context.TdcCatEstadosEnvioPedidos, "MdUuid", "MdUuid");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TdcTchEstadoPedido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TdcTchEstadoPedidoExists(TdcTchEstadoPedido.MdUuid))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TdcTchEstadoPedidoExists(string id)
        {
          return _context.TdcTchEstadoPedidos.Any(e => e.MdUuid == id);
        }
    }
}

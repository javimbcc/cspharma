using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CSPHARMA_DAL.Modelos;

namespace CSPHARMA.Pages.EP
{
    public class CreateModel : PageModel
    {
        private readonly CSPHARMA_DAL.Modelos.CspharmaInformacionalContext _context;

        public CreateModel(CSPHARMA_DAL.Modelos.CspharmaInformacionalContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["MdUuid"] = new SelectList(_context.TdcCatEstadosDevolucionPedidos, "MdUuid", "MdUuid");
        ViewData["MdUuid"] = new SelectList(_context.TdcCatEstadosPagoEnvios, "MdUuid", "MdUuid");
        ViewData["MdUuid"] = new SelectList(_context.TdcCatLineasDistribucions, "MdUuid", "MdUuid");
        ViewData["MdUuid"] = new SelectList(_context.TdcCatEstadosEnvioPedidos, "MdUuid", "MdUuid");
            return Page();
        }

        [BindProperty]
        public TdcTchEstadoPedido TdcTchEstadoPedido { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TdcTchEstadoPedidos.Add(TdcTchEstadoPedido);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

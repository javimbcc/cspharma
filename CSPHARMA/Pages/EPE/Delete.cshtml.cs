using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CSPHARMA_DAL.Modelos;

namespace CSPHARMA.Pages.EPE
{
    public class DeleteModel : PageModel
    {
        private readonly CSPHARMA_DAL.Modelos.CspharmaInformacionalContext _context;

        public DeleteModel(CSPHARMA_DAL.Modelos.CspharmaInformacionalContext context)
        {
            _context = context;
        }

        [BindProperty]
      public TdcCatEstadosPagoEnvio TdcCatEstadosPagoEnvio { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.TdcCatEstadosPagoEnvios == null)
            {
                return NotFound();
            }

            var tdccatestadospagoenvio = await _context.TdcCatEstadosPagoEnvios.FirstOrDefaultAsync(m => m.MdUuid == id);

            if (tdccatestadospagoenvio == null)
            {
                return NotFound();
            }
            else 
            {
                TdcCatEstadosPagoEnvio = tdccatestadospagoenvio;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.TdcCatEstadosPagoEnvios == null)
            {
                return NotFound();
            }
            var tdccatestadospagoenvio = await _context.TdcCatEstadosPagoEnvios.FindAsync(id);

            if (tdccatestadospagoenvio != null)
            {
                TdcCatEstadosPagoEnvio = tdccatestadospagoenvio;
                _context.TdcCatEstadosPagoEnvios.Remove(TdcCatEstadosPagoEnvio);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

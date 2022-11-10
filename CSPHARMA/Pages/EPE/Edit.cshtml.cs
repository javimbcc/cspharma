using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CSPHARMA_DAL.Modelos;

namespace CSPHARMA.Pages.EPE
{
    public class EditModel : PageModel
    {
        private readonly CSPHARMA_DAL.Modelos.CspharmaInformacionalContext _context;

        public EditModel(CSPHARMA_DAL.Modelos.CspharmaInformacionalContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TdcCatEstadosPagoEnvio TdcCatEstadosPagoEnvio { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.TdcCatEstadosPagoEnvios == null)
            {
                return NotFound();
            }

            var tdccatestadospagoenvio =  await _context.TdcCatEstadosPagoEnvios.FirstOrDefaultAsync(m => m.MdUuid == id);
            if (tdccatestadospagoenvio == null)
            {
                return NotFound();
            }
            TdcCatEstadosPagoEnvio = tdccatestadospagoenvio;
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

            _context.Attach(TdcCatEstadosPagoEnvio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TdcCatEstadosPagoEnvioExists(TdcCatEstadosPagoEnvio.MdUuid))
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

        private bool TdcCatEstadosPagoEnvioExists(string id)
        {
          return _context.TdcCatEstadosPagoEnvios.Any(e => e.MdUuid == id);
        }
    }
}

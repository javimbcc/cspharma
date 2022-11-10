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
    public class DetailsModel : PageModel
    {
        private readonly CSPHARMA_DAL.Modelos.CspharmaInformacionalContext _context;

        public DetailsModel(CSPHARMA_DAL.Modelos.CspharmaInformacionalContext context)
        {
            _context = context;
        }

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
    }
}

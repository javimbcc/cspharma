using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CSPHARMA_DAL.Modelos;

namespace CSPHARMA.Pages.EPE
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
            return Page();
        }

        [BindProperty]
        public TdcCatEstadosPagoEnvio TdcCatEstadosPagoEnvio { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TdcCatEstadosPagoEnvios.Add(TdcCatEstadosPagoEnvio);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

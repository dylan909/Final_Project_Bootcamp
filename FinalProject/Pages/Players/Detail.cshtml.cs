using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinalProject.Model;
using FinalProject.Data;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace FinalProject.Pages.Players
{
    public class DetailModel : PageModel
    {
        private readonly FinalProjectContext _context;

        public DetailModel(FinalProjectContext context)
        {
            _context = context;
        }

        public FinalProject.Model.Players allofplayers { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            allofplayers = await _context.allplayers.FindAsync(id);

            if (allofplayers == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}


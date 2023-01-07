using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Data;
using FinalProject.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Pages.Teams
{
	public class IndexModel : PageModel
    {
        private readonly FinalProjectContext _context;

        public IndexModel(FinalProjectContext context)
        {
            _context = context;
        }

        public List<FinalProject.Model.Teams> Teams { get; set; }
        public async Task OnGetAsync()
        {
            Teams = await _context.teams.ToListAsync();
        }



        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FinalProject.Model.Players? teamDeleted = await _context.teams.FindAsync(id);

            if (teamDeleted != null)
            {
                _context.allplayers.Remove(teamDeleted);
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

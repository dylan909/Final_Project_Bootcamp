using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Data;
using FinalProject.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace razorPageFinalProject.Pages.Players
{
    public class IndexModel : PageModel
    {
        private readonly FinalProjectContext _context;

        public IndexModel(FinalProjectContext context)
        {
            _context = context;
        }

        public List<FinalProject.Model.Players> AllPlayers { get; set; }
        public async Task OnGetAsync()
        {
            AllPlayers = await _context.allplayers.ToListAsync();
        }

      

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FinalProject.Model.Players alltheplayers = await _context.allplayers.FindAsync(id);

            if (alltheplayers != null)
            {
                _context.allplayers.Remove(alltheplayers);
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
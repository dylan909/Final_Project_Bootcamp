using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Pages.Teams
{
    public class editModel : PageModel
    {
        private readonly FinalProjectContext _context;

        public editModel(FinalProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FinalProject.Model.Teams playingTeams { get; set; }



        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                playingTeams = new FinalProject.Model.Teams();
            }
            else
            {
                playingTeams = await _context.teams.FindAsync(id);

                if (playingTeams == null)
                {
                    return NotFound();
                }
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (id == null)
            {
                _context.allplayers.Add(playingTeams);
            }
            else
            {
                _context.Attach(playingTeams).State = EntityState.Modified;
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

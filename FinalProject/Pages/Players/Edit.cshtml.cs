using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FinalProject.Data;
using FinalProject.Model;

namespace FinalProject.Pages.Players
{
    public class EditModel : PageModel
    {
        private readonly FinalProjectContext _context;

        public EditModel(FinalProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FinalProject.Model.Players? playingplayers { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                playingplayers = new FinalProject.Model.Players();
            }
            else
            {
                playingplayers = await _context.allplayers.FindAsync(id);

                //if (playingplayers == null)
                //{
                //    return NotFound();
                //}
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (id == null)
            {
                _context.allplayers.Add(playingplayers);
            }
            else
            {
                _context.Attach(playingplayers).State = EntityState.Modified;
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

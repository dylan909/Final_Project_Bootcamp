using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FinalProject.Data;
using FinalProject.Model;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace FinalProject.Pages.Players
{
    public class CreateModel : PageModel
    {

        private readonly FinalProjectContext _context;

        public CreateModel(FinalProjectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public FinalProject.Model.Players alloftheplayer{ get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.allplayers.Add(alloftheplayer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

    }
}

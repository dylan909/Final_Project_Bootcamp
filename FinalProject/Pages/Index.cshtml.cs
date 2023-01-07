using System.Diagnostics.Metrics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FinalProject.Data;
using FinalProject.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalProject.Pages;

public class IndexModel : PageModel
{
    private readonly FinalProjectContext _context;

    public IndexModel(FinalProjectContext context) => _context = context;

    public List<Teams>? Teams { get; set; }


    public async Task OnGetAsync()
    {
        Teams = await _context.teams.ToListAsync();
    }
}



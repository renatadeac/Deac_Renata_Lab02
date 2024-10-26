using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Deac_Renata_Lab02.Data;
using Deac_Renata_Lab02.Models;

namespace Deac_Renata_Lab02.Pages.Authors
{
    public class DetailsModel : PageModel
    {
        private readonly Deac_Renata_Lab02.Data.Deac_Renata_Lab02Context _context;

        public DetailsModel(Deac_Renata_Lab02.Data.Deac_Renata_Lab02Context context)
        {
            _context = context;
        }

        public Author Author { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = await _context.Author.FirstOrDefaultAsync(m => m.ID == id);
            if (author == null)
            {
                return NotFound();
            }
            else
            {
                Author = author;
            }
            return Page();
        }
    }
}

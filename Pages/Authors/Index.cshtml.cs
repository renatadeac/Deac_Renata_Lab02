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
    public class IndexModel : PageModel
    {
        private readonly Deac_Renata_Lab02.Data.Deac_Renata_Lab02Context _context;

        public IndexModel(Deac_Renata_Lab02.Data.Deac_Renata_Lab02Context context)
        {
            _context = context;
        }

        public IList<Author> Author { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Author = await _context.Author.ToListAsync();
        }
    }
}

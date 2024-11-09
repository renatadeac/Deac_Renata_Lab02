using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Deac_Renata_Lab02.Data;
using Deac_Renata_Lab02.Models;

namespace Deac_Renata_Lab02.Pages.Borrowings
{
    public class EditModel : PageModel
    {
        private readonly Deac_Renata_Lab02.Data.Deac_Renata_Lab02Context _context;

        public EditModel(Deac_Renata_Lab02.Data.Deac_Renata_Lab02Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Borrowing Borrowing { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrowing = await _context.Borrowing
                .Include(b => b.Member)  // Include datele membrului
                .Include(b => b.Book)    // Include datele cărții
                .FirstOrDefaultAsync(m => m.ID == id);

            if (borrowing == null)
            {
                return NotFound();
            }

            Borrowing = borrowing;

            // Populează lista de membri cu numele complet
            ViewData["MemberID"] = new SelectList(
                await _context.Member
                    .Select(m => new {
                        ID = m.ID,
                        FullName = m.FirstName + " " + m.LastName
                    })
                    .ToListAsync(),
                "ID",
                "FullName"
            );

            // Populează lista de cărți cu titluri
            ViewData["BookID"] = new SelectList(
                await _context.Book
                    .Select(b => new {
                        ID = b.ID,
                        Title = b.Title
                    })
                    .ToListAsync(),
                "ID",
                "Title"
            );

            return Page();
        }


        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Borrowing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BorrowingExists(Borrowing.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BorrowingExists(int id)
        {
            return _context.Borrowing.Any(e => e.ID == id);
        }
    }
}

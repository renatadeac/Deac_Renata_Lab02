using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Deac_Renata_Lab02.Data;
using Deac_Renata_Lab02.Models;
using Deac_Renata_Lab02.Models.ViewModels;

namespace Deac_Renata_Lab02.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Deac_Renata_Lab02.Data.Deac_Renata_Lab02Context _context;

        public IndexModel(Deac_Renata_Lab02.Data.Deac_Renata_Lab02Context context)
        {
            _context = context;
        }
        public IList<Category> Category { get; set; } = default!;
        public CategoryIndexData CategoryData { get; set; }
        public int CategoryID { get; set; }
        public int BookCategoriesID { get; set; }

        public async Task OnGetAsync(int? id)
        {
            CategoryData = new CategoryIndexData();
            CategoryData.Categories = await _context.Category
                .Include(c => c.BookCategories) 
                    .ThenInclude(bc => bc.Book) 
                        .ThenInclude(b => b.Author) 
                .OrderBy(c => c.CategoryName)
                .ToListAsync();

            if (id != null)
            {
                CategoryID = id.Value;
                var category = CategoryData.Categories
                    .Where(c => c.ID == id.Value)
                    .SingleOrDefault();
                CategoryData.BookCategories = category.BookCategories;

                if (category != null)
                {
                    CategoryData.BookCategories = category.BookCategories;
                }
            }
        }
    }
}

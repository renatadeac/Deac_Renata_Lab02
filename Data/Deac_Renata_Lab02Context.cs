using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Deac_Renata_Lab02.Models;

namespace Deac_Renata_Lab02.Data
{
    public class Deac_Renata_Lab02Context : DbContext
    {
        public Deac_Renata_Lab02Context (DbContextOptions<Deac_Renata_Lab02Context> options)
            : base(options)
        {
        }

        public DbSet<Deac_Renata_Lab02.Models.Book> Book { get; set; } = default!;
        public DbSet<Deac_Renata_Lab02.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<Deac_Renata_Lab02.Models.Author> Author { get; set; } = default!;
    }
}

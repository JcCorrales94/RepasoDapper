using Microsoft.EntityFrameworkCore;
using RepasoDapper.Entities.Authors;
using RepasoDapper.Entities.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepasoDapper.Repositorie
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=PC-TORREPRINCIP\\SQLEXPRESS01;Integrated Security=True; Initial Catalog=EjercicioEFCore; TrustServerCertificate=True");
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .HasMany(x => x.Books);
            modelBuilder.Entity<Book>()
                .HasOne(x => x.Author);
        }
    }
}

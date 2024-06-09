
using Filmsammlung.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmSammlung
{
    public class NotenContext : DbContext
    {

        private readonly IConfiguration configuration;
        public DbSet<User> Users { get; set; }
        public DbSet<Noten> Noten { get; set; }

        public NotenContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        //public FilmContext(DbContextOptions<FilmContext> options)
        //    :base(options)
        //{

        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=FilmCollectionDB;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False");
            optionsBuilder.UseSqlServer("Server=BOSS-5CG22012W5\\SQLEXPRESS;Database=NotenDB; Trusted_Connection=True;");
        } 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Noten>().HasKey(e => e.userId);
            modelBuilder.Entity<Noten>().HasOne<User>(u => u.User)
                .WithMany(nl => nl.notenListe).HasForeignKey(u => u.userId);

        }
    }
}

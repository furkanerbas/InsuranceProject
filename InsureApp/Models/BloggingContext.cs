using InsureApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsureApp.Models
{
    public partial class BloggingContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-N2T7QUB;Database=InsuranceDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public BloggingContext(DbContextOptions<BloggingContext> options)
            : base(options)
        { }

        public virtual DbSet<Musteri> Musteri { get; set; }
        public virtual DbSet<Police>  Police { get; set; }
        public virtual DbSet<Police_Turu> Police_Turu { get; set; }
        public virtual DbSet<Arac> Arac { get; set; }
        public virtual DbSet<Konut_Diger> Konut_Diger { get; set; }
        public virtual DbSet<Odemeler> Odemeler { get; set; }

    }
}

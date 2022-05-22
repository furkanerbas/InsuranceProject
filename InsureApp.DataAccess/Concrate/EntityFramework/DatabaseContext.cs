using InsureApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace InsureApp.DataAccess.Concrate.EntityFramework
{
    public class DatabaseContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-N2T7QUB;Database=InsuranceDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        public DbSet<Musteri> Musteri { get; set; }
        public DbSet<Police> Police { get; set; }
        public DbSet<Police_Turu>Police_Turu { get; set; }
        public DbSet<Odemeler> Odemeler { get; set;}
        public DbSet<Arac> Arac { get; set; }
        public DbSet<Konut_Diger> Konut_Diger { get; set; }

    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCA.Web.DataAcces
{
    public class DbContextAsistencia :DbContext 
    {
        public DbContextAsistencia()
        {

        }
        public DbContextAsistencia(DbContextOptions<DbContextAsistencia> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //new Producto.Mapeo(modeloCreador.Entity<Producto>());
            //modelBuilder.Entity<Producto>().ToTable("Producto").HasKey(x => x.Id);
            //modelBuilder.Entity<Producto>().HasOne(x => x.Cliente);
            //modelBuilder.Entity<Cliente>().ToTable("Customers").HasKey(x => x.IdCustomer);

            base.OnModelCreating(modelBuilder);
        }
    }
}

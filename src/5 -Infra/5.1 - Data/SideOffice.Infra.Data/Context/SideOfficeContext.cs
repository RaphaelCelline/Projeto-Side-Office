using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using SideOffice.Domain.Entities;
using System;
using SideOffice.Infra.Data.EntityConfig;

namespace SideOffice.Infra.Data.Context
{
    public class SideOfficeContext : DbContext
    {

        //private readonly IHostingEnvironment _env;
        //public SideOfficeContext(IHostingEnvironment env)
        //{
        //    _env = env;
        //}       

        public DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Rent> Rents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new UsersConfiguration());
            modelBuilder.ApplyConfiguration(new RoomConfiguration());
            modelBuilder.ApplyConfiguration(new RentConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // // Pego as configurações
           // var config = new ConfigurationBuilder()
           //     .SetBasePath(_env.ContentRootPath)
           //     .AddJsonFile("appsettings.json")
           //     .Build();
           // var cn = config.GetConnectionString("SideOfficeDefaultConnection");
            // Base de dados a ser utilizada.
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-NHRBGRO\\SQLEXPRESS;Initial Catalog=SideOffice;Integrated Security=True");
            //optionsBuilder.UseSqlServer(cn);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Animal
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext() { }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) 
        { 

        }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Comida> Comidas { get; set; }
        public DbSet<Juguete> Juguete { get; set; }
        public DbSet<ordenar_Pedido> Ordenar_Pedidos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Raza> Razas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=192.168.11.30;Database=TiendaAnimal;Integrated Security=True;");
            } 
            base.OnConfiguring(optionsBuilder);
        }
    }
}

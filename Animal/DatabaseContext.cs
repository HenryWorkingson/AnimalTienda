﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;


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
        public DbSet<Linea_Pedido> Linea_Pedidos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Clase_Producto> Clase_Productos { get; set; }
        public DbSet<Raza> Razas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Direccion_Envio> Direccion_Envios { get; set; }
        public DbSet<TarjetaPago> TarjetaPagos { get; set; }
        public DbSet<LineaDireccionCliente> LineasDireccionClientes { get; set; }
        public DbSet<LineaTarjetaCliente> LineaTarjetaClientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Atributo> Atributos { get; set; }
        public DbSet<Atributo_Valor> Atributo_Valors { get; set; }
        public DbSet<AtributoProducto> AtributoProductos { get; set; }
        public DbSet<Caracteristica> Caracteristicas { get; set; }
        public DbSet<CaracteristicaProducto> CaracteristicaProductos { get; set; }
        public DbSet<PrecioProducto> PrecioProductos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Carro> Carros { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Pedido>()
                .HasMany(p => p.lineas);
            modelBuilder.Entity<Cliente>()
                .HasMany(p => p.lineasDir);
            modelBuilder.Entity<Cliente>()
                .HasMany(p => p.lineasPedido);
            modelBuilder.Entity<Cliente>()
                .HasMany(p => p.lineasTar);
            modelBuilder.Entity<Producto>()
                .HasMany(p => p.lineasAtri);
            modelBuilder.Entity<Producto>()
                .HasMany(p => p.lineasCarac);
        }
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

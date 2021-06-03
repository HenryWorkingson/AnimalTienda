﻿// <auto-generated />
using Animal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Animal.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20210603103427_AllTables_V3")]
    partial class AllTables_V3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Animal.Animal", b =>
                {
                    b.Property<int>("id_Animal")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("edad")
                        .HasColumnType("int");

                    b.Property<double>("peso")
                        .HasColumnType("float");

                    b.Property<float>("precio")
                        .HasColumnType("real");

                    b.Property<int>("tipo_Raza")
                        .HasColumnType("int");

                    b.HasKey("id_Animal");

                    b.ToTable("Animal");
                });

            modelBuilder.Entity("Animal.Clase_Producto", b =>
                {
                    b.Property<int>("id_Producto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion_Producto")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<int>("Id_Asignado")
                        .HasColumnType("int");

                    b.Property<float>("Precio_Producto")
                        .HasColumnType("real");

                    b.Property<string>("Tipo_Producto")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("id_Producto");

                    b.ToTable("Clase_Producto");
                });

            modelBuilder.Entity("Animal.Cliente", b =>
                {
                    b.Property<int>("id_Cliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido_Cliente")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Nombre_Cliente")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("correo_Cliente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cuenta_Cliente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password_Cliente")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_Cliente");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Animal.Comida", b =>
                {
                    b.Property<int>("id_Comida")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion_Comida")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Nombre_Comida")
                        .HasColumnType("varchar(50)");

                    b.Property<float>("precio")
                        .HasColumnType("real");

                    b.HasKey("id_Comida");

                    b.ToTable("Comida");
                });

            modelBuilder.Entity("Animal.Direccion_Envio", b =>
                {
                    b.Property<int>("id_DireccionEnvio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DNI_Cliente_Rceiv")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Municipal")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Nombre_Cliente_Rec")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Nombre_Direccion")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Provincia")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("id_DireccionEnvio");

                    b.ToTable("Direccion_Envio");
                });

            modelBuilder.Entity("Animal.Juguete", b =>
                {
                    b.Property<int>("id_Juguete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion_Juguete")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Nombre_Juguete")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<float>("precio")
                        .HasColumnType("real");

                    b.HasKey("id_Juguete");

                    b.ToTable("Juguete");
                });

            modelBuilder.Entity("Animal.LineaDireccionCliente", b =>
                {
                    b.Property<int>("id_DireccionCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Id_Cliente")
                        .HasColumnType("int");

                    b.Property<int>("Id_Direccion")
                        .HasColumnType("int");

                    b.Property<bool>("Ultima_Dir_Env")
                        .HasColumnType("bit");

                    b.HasKey("id_DireccionCliente");

                    b.ToTable("LineaDireccionCliente");
                });

            modelBuilder.Entity("Animal.LineaTarjetaCliente", b =>
                {
                    b.Property<int>("id_TarjetaCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Id_Cliente")
                        .HasColumnType("int");

                    b.Property<int>("Id_Tarjeta")
                        .HasColumnType("int");

                    b.Property<bool>("Ultima_Tarjeta")
                        .HasColumnType("bit");

                    b.HasKey("id_TarjetaCliente");

                    b.ToTable("LineaTarjetaCliente");
                });

            modelBuilder.Entity("Animal.Linea_Pedido", b =>
                {
                    b.Property<int>("id_LineaPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<float>("PrecioProductoUnitario")
                        .HasColumnType("real");

                    b.Property<float>("PrecioTotal")
                        .HasColumnType("real");

                    b.Property<int>("id_Pedido")
                        .HasColumnType("int");

                    b.Property<int>("id_Producto")
                        .HasColumnType("int");

                    b.HasKey("id_LineaPedido");

                    b.ToTable("Linea_Pedido");
                });

            modelBuilder.Entity("Animal.Pedido", b =>
                {
                    b.Property<int>("id_Pedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion_Pedido")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<int>("Id_Cliente")
                        .HasColumnType("int");

                    b.Property<int>("Id_Direccion")
                        .HasColumnType("int");

                    b.Property<int>("Id_Tarjeta")
                        .HasColumnType("int");

                    b.Property<float>("Precio_Total")
                        .HasColumnType("real");

                    b.HasKey("id_Pedido");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("Animal.Raza", b =>
                {
                    b.Property<int>("id_Raza")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion_Raza")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Nombre_Raza")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("id_Raza");

                    b.ToTable("Raza");
                });

            modelBuilder.Entity("Animal.TarjetaPago", b =>
                {
                    b.Property<int>("id_TarjetaPago")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FechaCadu_Tarjeta")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Nom_Propietario")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Numero_Tarjeta")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("id_TarjetaPago");

                    b.ToTable("TarjetaPago");
                });
#pragma warning restore 612, 618
        }
    }
}

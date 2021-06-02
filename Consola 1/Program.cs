﻿using Animal;
using Consola_1.DTOS;
using System;

namespace Consola_1
{
    class Program
    {
        public static DtoAnimal CrearDtoAnimal(String nombre, int edad, int peso, int tipoRaza, string color, string Descripcion, int precio)
        {
            DtoAnimal miAnimal = new DtoAnimal()
            {
                Nombre = nombre,
                Color = color,
                Peso = peso,
                Edad = edad,
                descripcion= Descripcion,
                TipoRaza = tipoRaza,
                precio= precio
            };
            return miAnimal;
        }
        public static DtoRaza CrearDtoRaza(string nombre_Raza, string descripcion_Raza)
        {
            DtoRaza miRaza = new DtoRaza ()
            {
                Nombre_Raza = nombre_Raza,
                Descripcion_Raza = descripcion_Raza,
            };
            return miRaza;
        }
        public static DtoJuguete CrearDtoJuguete(string nombre_Juguete, string descripcion_Juguete, float precio)
        {
            DtoJuguete miJuguete = new DtoJuguete()
            {
                precio=precio,
                Nombre_Juguete = nombre_Juguete,
                Descripcion_Juguete = descripcion_Juguete,
            };
            return miJuguete;
        }
        public static DtoComida CrearDtoComida(string nombre_Comida, string descripcion_Comida, float precio)
        {
            DtoComida miComida = new DtoComida()
            {
                precio = precio,
                Nombre_Comida = nombre_Comida,
                Descripcion_Comida = descripcion_Comida,
            };
            return miComida;
        }
        public static DtoClaseProducto CrearDtoClaseProducto(string Tipo_Producto, string Descripcion_Producto,int Id_Asignado, float Precio_Producto)
        {
            DtoClaseProducto miProducto = new DtoClaseProducto()
            {
                Tipo_Producto = Tipo_Producto,
                Descripcion_Producto=Descripcion_Producto,
                Id_Asignado=Id_Asignado,
                Precio_Producto=Precio_Producto
            };
            return miProducto;
        }
        public static DtoDireccion_Envio CrearDtoDireccion(string Nombre_Direccion, string Provincia, string Municipal, string DNI_Cliente_Rceiv, string Nombre_Cliente_Rec)
        {
            DtoDireccion_Envio miDireccion = new DtoDireccion_Envio()
            {
                Nombre_Cliente_Rec = Nombre_Cliente_Rec,
                Provincia=Provincia,
                Municipal=Municipal,
                DNI_Cliente_Rceiv=DNI_Cliente_Rceiv,
                Nombre_Direccion=Nombre_Direccion
            };
            return miDireccion;
        }
        public static DtoLineaDireccionCliente CrearDtoLineaDireccionCliente(int Id_Cliente, int Id_Direccion, bool Ultima_Dir_Env)
        {
            DtoLineaDireccionCliente miLineaDireccionCliente = new DtoLineaDireccionCliente()
            {
                Id_Cliente=Id_Cliente,
                Id_Direccion=Id_Direccion,
                Ultima_Dir_Env=Ultima_Dir_Env
            };
            return miLineaDireccionCliente;
        }
        public static DtoPedido CrearDtoPedido(string Descripcion_Pedido,int Id_Cliente, int Id_Tarjeta, int Id_Direccion, float Precio_Total)
        {
            DtoPedido miPedido = new DtoPedido()
            {
                Descripcion_Pedido=Descripcion_Pedido,
                Id_Cliente=Id_Cliente,
                Id_Tarjeta=Id_Tarjeta,
                Id_Direccion = Id_Direccion,
                Precio_Total=Precio_Total
            };
            return miPedido;
        }
        public static DtoLinea_Pedido CrearDtoLinea_Pedido(int id_Producto, int id_Pedido, int Cantidad, float PrecioProductoUnitario, float PrecioTotal)
        {
            DtoLinea_Pedido miLinea_Pedido = new DtoLinea_Pedido()
            {
                id_Producto=id_Producto,
                id_Pedido=id_Pedido,
                Cantidad=Cantidad,
                PrecioProductoUnitario=PrecioProductoUnitario,
                PrecioTotal = PrecioTotal
            };
            return miLinea_Pedido;
        }
        public static DtoCliente CrearDtoCliente(string Nombre_Cliente, string Apellido_Cliente, string cuenta_Cliente, string password_Cliente, string correo_Cliente)
        {
            DtoCliente miCliente = new DtoCliente()
            {
                Nombre_Cliente=Nombre_Cliente,
                Apellido_Cliente=Apellido_Cliente,
                cuenta_Cliente=cuenta_Cliente,
                password_Cliente=password_Cliente,
                correo_Cliente=correo_Cliente
            };
            return miCliente;
        }
        public static DtoTarjetaPago CrearDtoTarjetaPago(string Numero_Tarjeta, string FechaCadu_Tarjeta, string Nom_Propietario)
        {
            DtoTarjetaPago miTarjeta = new DtoTarjetaPago()
            {
                Numero_Tarjeta=Numero_Tarjeta,
                FechaCadu_Tarjeta=FechaCadu_Tarjeta,
                Nom_Propietario=Nom_Propietario
            };
            return miTarjeta;
        }
        public static DtoDireccion_Envio CrearDireccion_Envio(string Nombre_Direccion, string Provincia, string Municipal, string DNI_Cliente_Rceiv, string Nombre_Cliente_Rec)
        {
            DtoDireccion_Envio miDir = new DtoDireccion_Envio()
            {
                Nombre_Direccion=Nombre_Direccion,
                Provincia=Provincia,
                Municipal=Municipal,
                DNI_Cliente_Rceiv=DNI_Cliente_Rceiv,
                Nombre_Cliente_Rec=Nombre_Cliente_Rec
            };
            return miDir;
        }
        public static void ElinimarBaseDatos(DatabaseContext dbc)
        {
        
            dbc.Animals.RemoveRange(dbc.Animals);
            dbc.Animals.AddRangeAsync(dbc.Animals);

            //var blogs = dbc.FromSqlRaw("SELECT * FROM dbo.Blogs").ToList();
            //dbc.ExecuteStoreCommand("DBCC CHECKIDENT('BibContents',RESEED,1);");
            //dbc.Animals.Exe
            //context.Database.ExecuteSqlRaw("DBCC CHECKIDENT('table.path', RESEED, 0)"); //Reset AUTO_INCREMENT
            //dbc.Animals.UpdateRange
            //dbc.Database.ExecuteSqlCommand(...)
            dbc.SaveChanges();
        }
        public static void CrearBaseDatos(DatabaseContext context)
        {
            //Cear objeto de cada uno
            Animal miAnimal = new Animal(context);
            Raza miRaza = new Raza(context);
            Juguete miJuguete = new Juguete(context);
            Comida miComida = new Comida(context);
            ClaseProducto miClaseProducto = new ClaseProducto(context);
            Linea_Pedido miLineaPedido = new Linea_Pedido(context);
            Pedido miPedido = new Pedido(context);
            Cliente miCliente = new Cliente(context);
            TarjetaPago miTarjeta = new TarjetaPago(context);
            Direccion_Envio miDir = new Direccion_Envio(context);
            LineaDireccionCliente miDirCL = new LineaDireccionCliente(context);
            // <<----------------------------------------------------------------------------->>
            //Crear Dto para los datos de DTOs para que ellos pueden introducir al DB

            //DtoRaza raza1 = CrearDtoRaza("perro", "perror en general");
            //DtoAnimal animal1 = CrearDtoAnimal("perro", 5, 10, 1, "azul", "perror normal ", 100);
            DtoJuguete juguete1 = CrearDtoJuguete("pelota", "una pelota duradera o de buena calidad", 5);
            DtoComida comida1 = CrearDtoComida("pienso Royal", "excelente pienso para perros", 10);
            // DtoClaseProducto Este es diferente porque cada vez que creas un animal tiene que incluir tambien en clase de producto.
            //DtoLinea_Pedido linea_pedido1 = CrearDtoLinea_Pedido() este apartado se hace atraves de pedido.
            DtoCliente cliente1 = CrearDtoCliente("yi", "Zhu", "yi_zhu", "123", "yi@.es");
            DtoDireccion_Envio dir1 = CrearDtoDireccion("calle Gran via 5", "Madrid ", "Madrid ", "X123 ", "yi");
            DtoTarjetaPago tar1 = CrearDtoTarjetaPago("1234 ", "24-05-2027", "yi");

            // <<----------------------------------------------------------------------------->>
            // insertar datos en la BD 
            miJuguete.CreateJuguete(juguete1);
            miComida.CreateComida(comida1);
            miCliente.CreateCliente(cliente1);
            miDir.CreateDireccion_Envio(dir1);
            miTarjeta.CreateTarjetaPago(tar1);

            context.SaveChanges();
        }
        public static void ActulizarDBClaseProducto(ClaseProducto miClaseProducto, string Tipo_Producto, string Descripcion_Producto, int Id_Asignado, float Precio_Producto)
        {
            DtoClaseProducto claseProducto = CrearDtoClaseProducto(Tipo_Producto, Descripcion_Producto, Id_Asignado, Precio_Producto);
            if (miClaseProducto.CreateProducto(claseProducto))
            {
               Console.WriteLine("Clase Prducto Creado");
            };
        }

            static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido a la tienda Animal");
            DatabaseContext _context = new DatabaseContext();

            Juguete miJuguete = new Juguete(_context);
            DtoJuguete juguete1 = CrearDtoJuguete("peluche", "una pelota duradera o de buena calidad", 5);
            miJuguete.CreateJuguete(juguete1);

            ClaseProducto miClaseProducto = new ClaseProducto(_context);
            miJuguete.listarJugueteConsola();
            miClaseProducto.listarProductoConsola();

            //DtoRaza raza1 = CrearDtoRaza("perro", "perror en general");
            //DtoAnimal animal1 = CrearDtoAnimal("perro", 5, 10, 1, "azul", "perror normal ", 100);
            //DtoAnimal mianimal = creardtoanimal("perro", "azul", 100, 20, 1);
            //dtoanimal mianimal2 = creardtoanimal("gato", "negro", 10, 4, 2);
            //dtoanimal mianimal3 = creardtoanimal("perro", "marron", 10, 5, 1);

            //if ( miTienda.CreateAnimal(animal1) ) {
            //    Console.WriteLine("Animal Creado");
            //};
            //miRaza.CreateRaza(raza1);
            //Listar-Todo Animal

            //Listar-espefico Animal
            //miTienda.listarIdAnimal(14);




        }
    }
}

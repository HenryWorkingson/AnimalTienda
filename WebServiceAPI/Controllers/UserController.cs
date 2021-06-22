using Animal;
using Consola_1;
using Consola_1.DTOS;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServiceAPI.Controllers
{
    [Route("v1")]
    [ApiController]
    public class UserController : Controller
    {

        protected DatabaseContext db;
        public UserController(DatabaseContext _db)
        {
            db = _db;
        }
        [HttpGet]
        [Route("api/[controller]/producto")]
        public IActionResult getProducto()
        {
            //var q = (from u in db.Users select u).ToList();
            var q = db.Productos.Select(u => u).ToList();
            return View(q);
        }
        [HttpGet]
        [Route("api/[controller]/producto/createproducto")]
        public IActionResult CreateProducto()
        {
            return View();
        }
        [HttpPost]
        [Route("api/[controller]/producto/createproducto")]
        public IActionResult CreateProducto(DtoProducto product)
        {
            if (ModelState.IsValid)
            {
                //TO DO
                Producto miProducto = new Producto()
                {
                    DescripcionProducto = product.DescripcionProducto,
                    NombreProducto=product.NombreProducto,
                    PrecioBase=product.PrecioBase
                };
                
                db.Productos.Add(miProducto);
                db.SaveChanges();
                return RedirectToAction("getProducto");
            }
            return View();
        }
        [HttpPost]
        [Route("api/[controller]/producto/delete/{idProducto:int}")]
        public IActionResult DeleteProducto(int idProducto)
        {
            Animal.Producto p=db.Productos.Find(idProducto);
            if(p != null)
            {
                db.Productos.Remove(p);
                db.SaveChanges();
            }
            return RedirectToAction("getProducto");

        }
        [HttpGet]
        [Route("api/[controller]/LogIn")]
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        [Route("api/[controller]/LogIn")]
        public IActionResult LogIn(DtoUsuario usuario)
        {
            if (ModelState.IsValid)
            {
                //TO DO
                bool b = false;
                var u = db.Usuarios;
                foreach( var q in u)
                {
                    if (q.privilegio == true)
                        if (q.email == usuario.email)
                            if (q.password == usuario.password)
                            {
                                b = true;
                                break;
                            }
                }
                if(b==true)
                    return RedirectToAction("getProducto");
                else
                    return RedirectToAction("LogIn");
            }
            return View();
        }
        [HttpGet]
        [Route("api/[controller]/CrearUsuario")]
        public IActionResult CrearUsuario()
        {
            return View();
        }
        [HttpPost]
        [Route("api/[controller]/CrearUsuario")]
        public IActionResult CrearUsuario(DtoUsuario usuario)
        {
            if (ModelState.IsValid)
            {
                //TO DO
                Usuario miUsuario = new Usuario()
                {
                    email = usuario.email,
                    Nombre=usuario.Nombre,
                    password=usuario.password,
                    privilegio=usuario.privilegio,
                };

                db.Usuarios.Add(miUsuario);
                db.SaveChanges();
                return RedirectToAction("getProducto");
            }
            return View();
        }
        [HttpGet]
        [Route("api/[controller]/getUsuario")]
        public IActionResult getUsuario ()
        {
            var q = db.Usuarios.Select(u => u).ToList();
            return View(q);
        }
        [HttpPost]
        [Route("api/[controller]/DeleteUsuario")]
        public IActionResult DeleteUsuario(int id)
        {
            Usuario p = db.Usuarios.Find(id);
            if (p != null)
            {
                db.Usuarios.Remove(p);
                db.SaveChanges();
            }
            return RedirectToAction("Usuario");
        }
        [HttpGet]
        [Route("api/[controller]/Carro")]
        public IActionResult Carro ()
        {
            var q=db.Carros.Select(u => u).ToList();
            return View(q);
        }
        [HttpPost]
        [Route("api/[controller]/AddCarro/{idProducto:int}")]
        public IActionResult AddCarro (int idProducto)
        {
            if (ModelState.IsValid)
            {
                var p = db.Productos.Find(idProducto);
                Carro miCarro = new Carro()
                {
                    Cantidad = 1,
                    idProducto = idProducto,
                    nombreProducto = p.NombreProducto,
                    PrecioProductoUnitario = p.PrecioBase,
                };
                miCarro.PrecioTotal = miCarro.Cantidad * miCarro.PrecioProductoUnitario;
                db.Carros.Add(miCarro);
                db.SaveChanges();
                return RedirectToAction("getProducto");
            }
            return View();
        }
        [HttpGet]
        [Route("api/[controller]/AumentarCarro/{id:int}")]
        public IActionResult AumentarCarro(int id)
        {
            if (ModelState.IsValid)
            {
                var p = db.Carros.Find(id);
                p.Cantidad = p.Cantidad + 1;
                p.PrecioTotal = p.Cantidad * p.PrecioProductoUnitario;
                db.SaveChanges();
                return RedirectToAction("Carro");
            }
            return View();
        }
        [HttpPost]
        [Route("api/[controller]/DecrementarCarro/{id:int}")]
        public IActionResult DecrementarCarro(int id)
        {
            if (ModelState.IsValid)
            {
                var p = db.Carros.Find(id);
                p.Cantidad = p.Cantidad - 1;
                if (p.Cantidad == 0)
                {
                    db.Carros.Remove(p);
                    db.SaveChanges();
                    return RedirectToAction("Carro");
                }
                    
                p.PrecioTotal = p.Cantidad * p.PrecioProductoUnitario;
                db.SaveChanges();
                return RedirectToAction("Carro");
            }
            return View();
        }
        [HttpPost]
        [Route("api/[controller]/DeleteCarro/{id:int}")]
        public IActionResult DeleteCarro(int id)
        {
            Carro p = db.Carros.Find(id);
            if (p != null)
            {
                db.Carros.Remove(p);
                db.SaveChanges();
            }
            return RedirectToAction("Carro");
        }
        [HttpGet]
        [Route("api/[controller]/Pedido")]
        public IActionResult Pedido()
        {
            var q = db.Pedidos.Select(u => u).ToList();
            return View(q);
        }
        [HttpPost]
        [Route("api/[controller]/DeletePedido/{id:int}")]
        public IActionResult DeletePedido(int id)
        {
            Animal.Pedido p = db.Pedidos.Find(id);
            if (p != null)
            {
                db.Pedidos.Remove(p);
                db.SaveChanges();
            }
            return RedirectToAction("Pedido");
        }
        [HttpGet]
        [Route("api/[controller]/Clientes")]
        public IActionResult getCliente()
        {
            var q = db.Clientes.Select(u => u).ToList();
            return View(q);
        }
        [HttpPost]
        [Route("api/[controller]/DeleteCliente/{idCliente:int}")]
        public IActionResult DeleteCliente(int idCliente)
        {
            Animal.Cliente p = db.Clientes.Find(idCliente);
            if (p != null)
            {
                db.Clientes.Remove(p);
                db.SaveChanges();
            }
            return RedirectToAction("getCliente");
        }
        [HttpGet]
        [Route("api/[controller]/CreateCliente")]
        public IActionResult CrearCliente()
        {
            return View();
        }
        [HttpPost]
        [Route("api/[controller]/CreateCliente")]
        public IActionResult CrearCliente(DtoCliente cliente)
        {
            if (ModelState.IsValid)
            {
                //TO DO
                Cliente miCliente = new Cliente()
                {
                    Apellido_Cliente= cliente.Apellido_Cliente,
                    correo_Cliente = cliente.correo_Cliente,
                    cuenta_Cliente = cliente.cuenta_Cliente,
                    Nombre_Cliente = cliente.Nombre_Cliente,
                    password_Cliente = cliente.password_Cliente,
                };

                db.Clientes.Add(miCliente);
                db.SaveChanges();
                return RedirectToAction("getCliente");
            }
            return View();
        }
        [HttpGet]
        [Route("api/[controller]/pedido/{id:int}/LineaPedidos")]
        public IActionResult getLineaPedido(int id)
        {
            var q = db.Linea_Pedidos.Select(u => u).Where(i => i.id_Pedido==id).ToList();
            return View(q);
        }
        [HttpPost]
        [Route("api/[controller]/CrearPedido")]
        public IActionResult CrearPedido()
        {
            double precioTotal = 0;
            var l = db.Carros;
            Animal.Pedido miPedido = new Animal.Pedido()
            {
                Id_Cliente = 0,
                Id_Direccion = 0,
                Id_Tarjeta = 0,
                Descripcion_Pedido = "Pedido por Web"
            };
            db.Pedidos.Add(miPedido);
            db.SaveChanges();             
            foreach (var q in l)
            {
                Animal.Linea_Pedido mi = new Animal.Linea_Pedido()
                {
                    Cantidad = q.Cantidad,
                    id_Pedido = miPedido.id_Pedido,
                    id_Producto = q.idProducto,
                    PrecioProductoUnitario = q.PrecioProductoUnitario,
                    PrecioTotal = q.PrecioTotal,
                    
                };
                db.Linea_Pedidos.Add(mi);
                db.Carros.Remove(q);
                precioTotal=q.PrecioTotal + precioTotal;
            }
            miPedido.Precio_Total = precioTotal;
            db.SaveChanges();
            return RedirectToAction("Carro");
        }
        [HttpGet]
        [Route("api/[controller]/cliente/{idCliente:int}/tarjetas")]
        public IActionResult getTarjetas(int idCliente) //get tarjetas or listTarjeta
        {
            var q = db.LineaTarjetaClientes.Select( u => u ).Where(i => i.Id_Cliente == idCliente).ToList();
            if(q==null)
                return View("Cliente");
            List<TarjetaPago> list = new List<TarjetaPago>();
            foreach(var z in q)
            {
                var p= db.TarjetaPagos.Select( u => u ).Where( i => i.id_TarjetaPago == z.Id_Tarjeta ).FirstOrDefault();
                list.Add(p);
            }
            return View(list);
        }
        [HttpPost]
        [Route("api/[controller]/cliente/{idCliente:int}/tarjetas/{idTar:int}")]
        public IActionResult DeleteTarjeta(int idTar)
        {
            Animal.TarjetaPago p = db.TarjetaPagos.Find(idTar);
            if (p != null)
            {
                db.TarjetaPagos.Remove(p);
                db.SaveChanges();
            }
            var q = db.LineaTarjetaClientes.Select(u => u).Where(i => i.Id_Tarjeta == idTar).FirstOrDefault();
            int id = q.Id_Cliente;
            db.LineaTarjetaClientes.Remove(q);
            db.SaveChanges();
            return RedirectToAction("getTarjetas", new { idCliente = id });

        }
        [HttpGet]
        [Route("api/[controller]/cliente/{idCliente:int}/CrearTarjetas")]
        public IActionResult CrearTarjetas(int idCliente)
        {
            return View();
        }
        [HttpPost]
        [Route("api/[controller]/cliente/{idCliente:int}/CrearTarjetas")]
        public IActionResult CrearTarjetas( int idCliente ,DtoTarjetaPago Tarjetas)
        { 
            if (ModelState.IsValid)
            {   //TO DO
                TarjetaPago miTarjetas = new TarjetaPago()
                {
                    FechaCadu_Tarjeta= Tarjetas.FechaCadu_Tarjeta,
                    Nom_Propietario=Tarjetas.Nom_Propietario,
                    Numero_Tarjeta=Tarjetas.Numero_Tarjeta
                };
                db.TarjetaPagos.Add(miTarjetas);
                db.SaveChanges();
                LineaTarjetaCliente lTarCliente = new LineaTarjetaCliente()
                {
                    Id_Tarjeta = miTarjetas.id_TarjetaPago,
                    Id_Cliente = idCliente,
                    Ultima_Tarjeta = false,
                };
                db.LineaTarjetaClientes.Add(lTarCliente);
                db.SaveChanges();                
                return RedirectToAction("getCliente");
            }
            return View();
        }
        [HttpGet]
        [Route("api/[controller]/cliente/{idCliente:int}/Direcciones")]
        public IActionResult getDireccion(int idCliente) //get tarjetas or listTarjeta
        {
            var q = db.LineasDireccionClientes.Select(u => u).Where(i => i.Id_Cliente == idCliente).ToList();
            if (q == null)
                return View("Cliente");
            List<Direccion_Envio> list = new List<Direccion_Envio>();
            foreach (var z in q)
            {
                var p = db.Direccion_Envios.Select(u => u).Where(i => i.id_DireccionEnvio == z.Id_Direccion).FirstOrDefault();
                list.Add(p);
            }
            return View(list);
        }
        [HttpPost]
        [Route("api/[controller]/cliente/{idCliente:int}/Direcciones/{idDir:int}")]
        public IActionResult DeleteDireccion(int idDir)
        {
            Animal.Direccion_Envio p = db.Direccion_Envios.Find(idDir);
            if (p != null)
            {
                db.Direccion_Envios.Remove(p);
                db.SaveChanges();
            }
            var q = db.LineasDireccionClientes.Select(u => u).Where(i => i.Id_Direccion == idDir).FirstOrDefault();
            int id = q.Id_Cliente;
            db.LineasDireccionClientes.Remove(q);
            db.SaveChanges();
            return RedirectToAction("getDireccion", new { idCliente = id });
        }
        [HttpGet]
        [Route("api/[controller]/cliente/{idCliente:int}/CrearDirecciones")]
        public IActionResult CrearDirecciones(int idCliente)
        {
            return View();
        }
        [HttpPost]
        [Route("api/[controller]/cliente/{idCliente:int}/CrearDirecciones")]
        public IActionResult CrearDirecciones(int idCliente, DtoDireccion_Envio Dir)
        {
            if (ModelState.IsValid)
            {   //TO DO
                Direccion_Envio miDir = new Direccion_Envio()
                {
                    DNI_Cliente_Rceiv = Dir.DNI_Cliente_Rceiv,
                    Nombre_Cliente_Rec = Dir.Nombre_Cliente_Rec,
                    Municipal = Dir.Municipal,
                    Provincia = Dir.Provincia,
                    Nombre_Direccion = Dir.Nombre_Direccion
                };
                db.Direccion_Envios.Add(miDir);
                db.SaveChanges();
                LineaDireccionCliente lDirCliente = new LineaDireccionCliente()
                {
                    Id_Direccion = miDir.id_DireccionEnvio,
                    Id_Cliente = idCliente,
                    Ultima_Dir_Env = false,
                };
                db.LineasDireccionClientes.Add(lDirCliente);
                db.SaveChanges();
                return RedirectToAction("getCliente");
            }
            return View();
        }
    }
}

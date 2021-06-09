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
    public class UserController : Controller
    {
        protected DatabaseContext db;
        public UserController(DatabaseContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            //var q = (from u in db.Users select u).ToList();
            var q = db.Productos.Select(u => u).ToList();
            return View(q);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(DtoProducto product)
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
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult DeleteProducto(int id)
        {
            Producto p=db.Productos.Find(id);
            if(p != null)
            {
                db.Productos.Remove(p);
                db.SaveChanges();
            }
            return RedirectToAction("Index");

        }

        public IActionResult TarjetaPago(int id)
        {
            var q = db.TarjetaPagos.Select(u => u).ToList();
            return View(q);
        }
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
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
                    return RedirectToAction("Index");
                else
                    return RedirectToAction("LogIn");
            }
            return View();
        }
        public IActionResult CrearUsuario()
        {
            return View();
        }
        [HttpPost]
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
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Usuario (DtoUsuario usuario)
        {
            var q = db.Usuarios.Select(u => u).ToList();
            return View(q);
        }
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
        public IActionResult Carro ()
        {
            var q=db.Carros.Select(u => u).ToList();
            return View(q);
        }
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
                return RedirectToAction("Index");
            }
            return View();
        }
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
        public IActionResult Pedido()
        {
            var q = db.Pedidos.Select(u => u).ToList();
            return View(q);
        }
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
        public IActionResult Cliente()
        {
            var q = db.Clientes.Select(u => u).ToList();
            return View(q);
        }
        public IActionResult DeleteCliente(int id)
        {
            Cliente p = db.Clientes.Find(id);
            if (p != null)
            {
                db.Clientes.Remove(p);
                db.SaveChanges();
            }
            return RedirectToAction("Cliente");
        }
        public IActionResult LineaPedido(int id)
        {
            var q = db.Linea_Pedidos.Select(u => u).Where(i => i.id_Pedido==id).ToList();
            return View(q);
        }
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
        public IActionResult Tarjetas(int id)
        {
            var q = db.LineaTarjetaClientes.Select(u => u).Where(i => i.Id_Cliente == id).ToList();
            if(q==null)
                return View("Cliente");
            List<TarjetaPago> list = new List<TarjetaPago>();
            foreach(var z in q)
            {
                var p=db.TarjetaPagos.Select(u => u).Where(i => i.id_TarjetaPago == z.id_TarjetaCliente).FirstOrDefault();
                list.Add(p);
                    
            }
            return View(list);
        }
    }
}

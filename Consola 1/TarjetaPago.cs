using Animal;
using Consola_1.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consola_1
{
    class TarjetaPago
    {
        protected DatabaseContext _context;
        public TarjetaPago (DatabaseContext context)
        {
            _context = context;
        }
        public bool CreateTarjetaPago(DtoTarjetaPago tar)
        {
            global::Animal.TarjetaPago miTar = new global::Animal.TarjetaPago()
            {
                Numero_Tarjeta = tar.Numero_Tarjeta,
                Nom_Propietario = tar.Nom_Propietario,
                FechaCadu_Tarjeta = tar.FechaCadu_Tarjeta,
            };
            //Añade al contexto
            _context.TarjetaPagos.Add(miTar);
            //Guarda en BBDD
            _context.SaveChanges();
            return true;
        }
        public void listarTarjetaPagoConsola()
        {
            var list = _context.TarjetaPagos;
            foreach (var ani in list)
            {
                Console.Write(ani.id_TarjetaPago + " ");
                Console.Write(ani.Numero_Tarjeta + " ");
                Console.Write(ani.Nom_Propietario + " ");
                Console.WriteLine(ani.FechaCadu_Tarjeta + " ");
            }
        }
        //buqueda con el id_Animal para devolver a una animal especifico
        public void listarIdTarjetaPago(int id)
        {
            var ani = _context.TarjetaPagos.Find(id);
            //var q = (from u in db.Animals select u).ToList();
            if (ani == null) { Console.WriteLine("No encontrado el id esperado"); }
            else
            {
                Console.Write(ani.id_TarjetaPago + " ");
                Console.Write(ani.Numero_Tarjeta + " ");
                Console.Write(ani.Nom_Propietario + " ");
                Console.WriteLine(ani.FechaCadu_Tarjeta + " ");
            }
        }
        public void upDateTarjetaPago(int id, DtoTarjetaPago tar)
        {
            var q = _context.TarjetaPagos.Find(id);
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); }
            else
            {
                q.Numero_Tarjeta = tar.Numero_Tarjeta;
                q.Nom_Propietario = tar.Nom_Propietario;
                q.FechaCadu_Tarjeta = tar.FechaCadu_Tarjeta;
            }
        }
        public bool EliminarTarjetaPago(int id)
        {
            var q = _context.TarjetaPagos.Find(id);
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); return false; }
            else
            {
                _context.TarjetaPagos.Remove(q);
                _context.SaveChanges();
                return true;
            }
        }
    }
}

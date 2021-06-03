using Animal;
using Consola_1.DTOS;
using System;

namespace Consola_1
{
    class Direccion_Envio
    {
        protected DatabaseContext _context;
        public Direccion_Envio(DatabaseContext context)
        {
            _context = context;
        }
        public bool CreateDireccion_Envio(DtoDireccion_Envio animal)
        {
            global::Animal.Direccion_Envio miDE = new global::Animal.Direccion_Envio()
            {
                Nombre_Direccion = animal.Nombre_Direccion,
                Provincia = animal.Provincia,
                Municipal = animal.Municipal,
                DNI_Cliente_Rceiv = animal.DNI_Cliente_Rceiv,
                Nombre_Cliente_Rec = animal.Nombre_Cliente_Rec,
            };
            //Añade al contexto
            _context.Direccion_Envios.Add(miDE);
            //Guarda en BBDD
            _context.SaveChanges();
            return true;
        }
        public void listarDireccion_EnvioConsola()
        {
            var list = _context.Direccion_Envios;
            foreach (var ani in list)
            {
                Console.Write(ani.id_DireccionEnvio + " ");
                Console.Write(ani.Nombre_Direccion + " ");
                Console.Write(ani.Provincia + " ");
                Console.Write(ani.Municipal + " ");
                Console.Write(ani.DNI_Cliente_Rceiv + " ");
                Console.WriteLine(ani.Nombre_Cliente_Rec + " ");
            }
        }
        //buqueda con el id_Animal para devolver a una animal especifico
        public void listarIdDireccion_Envio(int id)
        {
            var ani = _context.Direccion_Envios.Find(id);
            //var q = (from u in db.Animals select u).ToList();
            if (ani == null) { Console.WriteLine("No encontrado el id esperado"); }
            else
            {
                Console.Write(ani.id_DireccionEnvio + " ");
                Console.Write(ani.Nombre_Direccion + " ");
                Console.Write(ani.Provincia + " ");
                Console.Write(ani.Municipal + " ");
                Console.Write(ani.DNI_Cliente_Rceiv + " ");
                Console.WriteLine(ani.Nombre_Cliente_Rec + " ");
            }
        }
        public void upDateDireccion_Envio(int id, DtoDireccion_Envio animal)
        {
            var q = _context.Direccion_Envios.Find(id);
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); }
            else
            {
                q.Nombre_Direccion = animal.Nombre_Direccion;
                q.Provincia = animal.Provincia;
                q.Municipal = animal.Municipal;
                q.DNI_Cliente_Rceiv = animal.DNI_Cliente_Rceiv;
                q.Nombre_Cliente_Rec = animal.Nombre_Cliente_Rec;
            }
            _context.SaveChanges();
        }
        public bool EliminarDireccion_Envio(int id)
        {
            var q = _context.Direccion_Envios.Find(id);
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); return false; }
            else
            {
                _context.Direccion_Envios.Remove(q);
                _context.SaveChanges();
                return true;
            }
        }
    }
}

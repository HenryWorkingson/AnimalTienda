using Animal;
using Consola_1.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consola_1
{
    public class AtributoProducto
    {
        protected DatabaseContext _context;
        public AtributoProducto(DatabaseContext context)
        {
            _context = context;
        }
        public bool CrearAtributoProducto(DtoAtributoProducto p)
        {            
            global::Animal.AtributoProducto miAtriProducto = new global::Animal.AtributoProducto()
            {
                IdAtributo=p.IdAtributo,
                IdAtributoValor=p.IdAtributoValor,
                IdProducto=p.IdProducto
            };
            
            _context.AtributoProductos.Add(miAtriProducto);
            _context.SaveChanges();
            return true;
        }
    }
}

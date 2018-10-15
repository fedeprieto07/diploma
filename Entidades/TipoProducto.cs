using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Producto_Categoria
    {
        private int _IdProductoCategoria;
        private string _Nombre;

        public int IdProductoCategoria
        {
            get
            {
                return _IdProductoCategoria;
            }

            set
            {
                _IdProductoCategoria = value;
            }
        }

        public string Nombre
        {
            get
            {
                return _Nombre;
            }

            set
            {
                _Nombre = value;
            }
        }
    }
}

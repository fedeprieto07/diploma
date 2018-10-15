using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class Producto
    {
        private int _id_Producto;
        private string _Nombre;
        private string _Descripcion;
        private double _Costo;
        private int _Stock;
        private Producto_Categoria _Categoria;

        public int Stock
        {
            get
            {
                return _Stock;
            }

            set
            {
                _Stock = value;
            }
        }

        public double Costo
        {
            get
            {
                return _Costo;
            }

            set
            {
                _Costo = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return _Descripcion;
            }

            set
            {
                _Descripcion = value;
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

        public int Id_Producto
        {
            get
            {
                return _id_Producto;
            }

            set
            {
                _id_Producto = value;
            }
        }

        public Producto_Categoria Categoria
        {
            get
            {
                return _Categoria;
            }

            set
            {
                _Categoria = value;
            }
        }
    }
}

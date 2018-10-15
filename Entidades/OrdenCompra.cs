using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class OrdenCompra
    {

        private int _Id_Orden_Compra;
        private EstadoOrdenCompra _EstadoOrden;
        private DateTime _Fecha;
        private string _Nombre;
        private string _Descripcion;
        public DateTime Fecha
        {
            get
            {
                return _Fecha;
            }

            set
            {
                _Fecha = value;
            }
        }

        public EstadoOrdenCompra EstadoOrden
        {
            get
            {
                return _EstadoOrden;
            }

            set
            {
                _EstadoOrden = value;
            }
        }

        public int Id_Orden_Compra
        {
            get
            {
                return _Id_Orden_Compra;
            }

            set
            {
                _Id_Orden_Compra = value;
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
    }
}

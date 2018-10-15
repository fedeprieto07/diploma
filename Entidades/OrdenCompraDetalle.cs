using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class OrdenCompraDetalle
    {
        private int _id_orden_compra_detalle;
        private int _cantidad;
        private Producto _Producto;
        private OrdenCompra _Orden;

        public OrdenCompra Orden
        {
            get
            {
                return _Orden;
            }

            set
            {
                _Orden = value;
            }
        }

        public Producto Producto
        {
            get
            {
                return _Producto;
            }

            set
            {
                _Producto = value;
            }
        }

        public int Cantidad
        {
            get
            {
                return _cantidad;
            }

            set
            {
                _cantidad = value;
            }
        }

        public int Id_orden_compra_detalle
        {
            get
            {
                return _id_orden_compra_detalle;
            }

            set
            {
                _id_orden_compra_detalle = value;
            }
        }
    }
}

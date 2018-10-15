using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EstadoOrdenCompra
    {
        private int _idestadoOrdenCompra;
        private string _nombre;
        private string _descricion;

        public string Descricion
        {
            get
            {
                return _descricion;
            }

            set
            {
                _descricion = value;
            }
        }

        public string Nombre
        {
            get
            {
                return _nombre;
            }

            set
            {
                _nombre = value;
            }
        }

        public int IdestadoOrdenCompra
        {
            get
            {
                return _idestadoOrdenCompra;
            }

            set
            {
                _idestadoOrdenCompra = value;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using BackEnd;


namespace Buisness
{
    public class nOrdenCompra
    {
        //Estado orden de compra

        public void EliminarPorID(string id)
        {
            bOrdenCompra borden = new bOrdenCompra();
            borden.EliminarPorId(id);




        }

        public void cambiarEstadoOC(string id, string estado) {
            bOrdenCompra borden = new bOrdenCompra();

            borden.cambiarEstadoOC(id,estado);


        }

        public void CrearNuevaCategoriaOC(EstadoOrdenCompra Estado) {

            BackEnd.bOrdenCompra objOrdenDesc = new BackEnd.bOrdenCompra();

            objOrdenDesc.InsertarNuevaCategoria(Estado);

        }

        public List<EstadoOrdenCompra> MostrarEstados()
        {
            List<EstadoOrdenCompra> Lista = new List<EstadoOrdenCompra>();
            BackEnd.bOrdenCompra Estado = new BackEnd.bOrdenCompra();
            Lista = Estado.ShowCategoriasOC();
            
            return Lista;
        }

        public List<EstadoOrdenCompra> MostrarEstadosBynombre(string nombreAbuscar)
        {
            List<EstadoOrdenCompra> Lista = new List<EstadoOrdenCompra>();
            BackEnd.bOrdenCompra Estado = new BackEnd.bOrdenCompra();
            Lista = Estado.ShowCategoriasOCbyNombre(nombreAbuscar);

            return Lista;
        }

        //Orden de compra

        public List<OrdenCompra> ShowOrdenCompra()
        {

            List<OrdenCompra> Lista = new List<OrdenCompra>();
            BackEnd.bOrdenCompra InstOrden = new BackEnd.bOrdenCompra();
            Lista = InstOrden.ShowOrdenCompra();

            return Lista;



        }

        public OrdenCompra ShowOrdenCompraByID(string id ) {
            bOrdenCompra Borden = new bOrdenCompra();
            OrdenCompra InstORden = new OrdenCompra();


            InstORden = Borden.ShowOrdenCompraById(id);

            return InstORden;



        }

        //Orden Compra Detalle

        public List<OrdenCompraDetalle> ShowOrdenCompraDetalleByIdOC(string id){

            bOrdenCompra Borden = new bOrdenCompra();
            List<OrdenCompraDetalle> List = new List<OrdenCompraDetalle>();


            List = Borden.ShowOrdenDetalleByOrdenID(id);

            return List;
            
        }


    }
}

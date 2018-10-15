using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using BackEnd;
namespace Buisness
{
    public class nProducto
    {
        //Categorias producto

        public void EliminarCategoriaPorID(string id)
        {
            bProducto bpro = new bProducto();
            bpro.EliminarCategoriaPorId(id);




        }

        public void CrearNuevaCategoriaProducto(Producto_Categoria Estado)
        {

            bProducto objOrdenDesc = new bProducto();
            
            objOrdenDesc.InsertarNuevaCategoriaProducto(Estado);

        }

        public List<Producto_Categoria> MostrarCategoriasProducto()
        {
            List<Producto_Categoria> Lista = new List<Producto_Categoria>();
            bProducto Estado = new bProducto();
            Lista = Estado.ShowCategoriasProducto();

            return Lista;
        }

        public List<Producto_Categoria> MostrarCategoriasProductoBynombre(string nombreAbuscar)
        {
            List<Producto_Categoria> Lista = new List<Producto_Categoria>();
            BackEnd.bProducto Estado = new BackEnd.bProducto();
            Lista = Estado.ShowCategoriasProductobyNombre(nombreAbuscar);

            return Lista;
        }

        //Producto

        public void CrearNuevoProducto(Producto Producto)
        {

            bProducto beProducto = new bProducto();

            beProducto.InsertarNuevoProducto(Producto);





        }

        public List<Producto> MostrarProductos() {

            List<Producto> Lista = new List<Producto>();
            bProducto bProd = new bProducto();

            Lista = bProd.MostrarProductos();

            return Lista;






        }

        public void EliminarProductoPorID(string id) {
            bProducto bpro = new bProducto();
            bpro.EliminarProductoPorID(id);

        }

        public List<Producto> BuscarProductoByNombre(string nombre) {


            List<Producto> Lista = new List<Producto>();
            bProducto bProd = new bProducto();

            Lista = bProd.MostrarProductosByNombre(nombre);

            return Lista;







        }

        public Producto BuscarProductoById(string id) {



            Producto instprod = new Producto();
            bProducto bProd = new bProducto();

            instprod = bProd.MostrarProductoByID(id);

            return instprod;




        }

    }
}

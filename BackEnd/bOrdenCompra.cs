using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
namespace BackEnd
{
    public class bOrdenCompra
    {

        SqlConnection conexion = new SqlConnection(@"Data Source = DESKTOP-45F3K51\SQLEXPRESS; Initial Catalog = Campo; Integrated Security = True");

        //Estado Orden de Compra

        public void EliminarPorId(string id)
        {
            conexion.Open();
            string query = "DELETE FROM Estad_Orden_Compra where idEstadoOrdenCompra = @id";
            SqlCommand cnn = new SqlCommand(query, conexion);
            cnn.Parameters.AddWithValue("@id", id);
            cnn.ExecuteNonQuery();
            conexion.Close();

        }

        public void InsertarNuevaCategoria(EstadoOrdenCompra Estado)
        {
            conexion.Open();
           
            if (conexion != null && conexion.State == ConnectionState.Closed) ;
            string query = "INSERT into Estad_Orden_Compra(nombre,descripcion) VALUES (@nombre,@descripcion)";
            SqlCommand cmd = new SqlCommand(query, conexion);

            cmd.Parameters.AddWithValue("@nombre", Estado.Nombre);

            cmd.Parameters.AddWithValue("@descripcion", Estado.Descricion);

            cmd.ExecuteNonQuery();
        }

        public List<EstadoOrdenCompra> ShowCategoriasOC()
        {

            conexion.Open();
            string query = "SELECT * FROM Estad_Orden_Compra";

            SqlCommand cmd = new SqlCommand(query, conexion);

            SqlDataReader dr = cmd.ExecuteReader();

            List<EstadoOrdenCompra> Lista = new List<EstadoOrdenCompra>();
            int number;

            while (dr.Read())
            {
                EstadoOrdenCompra Estate = new EstadoOrdenCompra();
                Estate.Nombre = dr["nombre"].ToString();
                Estate.Descricion = dr["descripcion"].ToString();
                Estate.IdestadoOrdenCompra = Convert.ToInt32(dr["idestadoOrdenCompra"]);
                Lista.Add(Estate);
            }

            return Lista;
    
        }

        public List<EstadoOrdenCompra> ShowCategoriasOCbyNombre(string nombre)
        {

            conexion.Open();
            string query = "SELECT * FROM Estad_Orden_Compra WHERE nombre like @nombre + '%'";

            SqlCommand cmd = new SqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            SqlDataReader dr = cmd.ExecuteReader();

            List<EstadoOrdenCompra> Lista = new List<EstadoOrdenCompra>();
            int number;

            while (dr.Read())
            {
                EstadoOrdenCompra Estate = new EstadoOrdenCompra();
                Estate.Nombre = dr["nombre"].ToString();
                Estate.Descricion = dr["descripcion"].ToString();
                Estate.IdestadoOrdenCompra = Convert.ToInt32(dr["idestadoOrdenCompra"]);
                Lista.Add(Estate);
            }

            return Lista;

        }

        //Orden de Compra

        public List<OrdenCompra> ShowOrdenCompra() {

            conexion.Open();

            string query = "select orden_compra.id_orden_compra,orden_compra.nombre,orden_compra.descripcion,orden_compra.fecha,orden_compra.id_estado_orden_compra as 'EstadoID',estad_orden_compra.nombre as 'EstadoNombre',orden_Compra.descripcion as 'EstadoDescripcion'" +
            "from orden_Compra inner join Estad_Orden_Compra on (orden_Compra.id_estado_orden_compra = Estad_Orden_Compra.idestadoOrdenCompra) ";
            SqlCommand cmm = new SqlCommand(query, conexion);
            List<OrdenCompra> Lista = new List<OrdenCompra>();
            SqlDataReader dr = cmm.ExecuteReader();

            while (dr.Read()) {
                OrdenCompra InstOrden = new OrdenCompra();
                EstadoOrdenCompra InstEstado = new EstadoOrdenCompra();
                InstOrden.Id_Orden_Compra = Convert.ToInt32( dr["id_orden_compra"]);
                InstOrden.Fecha =Convert.ToDateTime( dr["Fecha"]);
                InstOrden.EstadoOrden = InstEstado;
                InstOrden.EstadoOrden.IdestadoOrdenCompra = Convert.ToInt32(dr["EstadoID"]);
                InstOrden.EstadoOrden.Nombre = Convert.ToString(dr["EstadoNombre"]);
                InstOrden.Descripcion = Convert.ToString(dr["Descripcion"]);
                InstOrden.Nombre = Convert.ToString(dr["nombre"]);


                Lista.Add(InstOrden);

            }

            return Lista;

        }

        public OrdenCompra ShowOrdenCompraById(string id) {
            conexion.Open();
            OrdenCompra Instorden = new OrdenCompra();
            string query = "select orden_compra.id_orden_compra,orden_compra.nombre,orden_compra.descripcion,orden_compra.fecha,orden_compra.id_estado_orden_compra as 'EstadoID',estad_orden_compra.nombre as 'EstadoNombre',orden_Compra.descripcion as 'EstadoDescripcion'" +
            "from orden_Compra inner join Estad_Orden_Compra on (orden_Compra.id_estado_orden_compra = Estad_Orden_Compra.idestadoOrdenCompra) where id_orden_compra = @id";

            SqlCommand cmm = new SqlCommand(query, conexion);

            cmm.Parameters.AddWithValue("@id", id);
            SqlDataReader dr = cmm.ExecuteReader();

            while (dr.Read())
            {

                EstadoOrdenCompra InstEstado = new EstadoOrdenCompra();
                Instorden.EstadoOrden = InstEstado;

                Instorden.Id_Orden_Compra = Convert.ToInt32( dr["Id_orden_compra"]);
                Instorden.Nombre = Convert.ToString(dr["nombre"]);
                Instorden.Descripcion = Convert.ToString(dr["Descripcion"]);
                Instorden.Fecha = Convert.ToDateTime(dr["fecha"]);
                Instorden.EstadoOrden.IdestadoOrdenCompra = Convert.ToInt32(dr["EstadoID"]);
                Instorden.EstadoOrden.Nombre = Convert.ToString(dr["EstadoNombre"]);
                Instorden.EstadoOrden.Descricion = Convert.ToString(dr["EstadoDescripcion"]);

            }

            return Instorden ;


        }


        //Orden de compra detalle

        public void cambiarEstadoOC(string id,string estado) {
            conexion.Open();

            string query = "UPDATE orden_compra SET id_estado_orden_compra = @estado WHERE id_orden_compra =@id";
            SqlCommand cmm = new SqlCommand(query, conexion);
            cmm.Parameters.AddWithValue("@id", id);
            cmm.Parameters.AddWithValue("@estado", estado);

            cmm.ExecuteNonQuery();



        }

        public List<OrdenCompraDetalle> ShowOrdenDetalleByOrdenID(string id) {
            List<OrdenCompraDetalle> List = new List<OrdenCompraDetalle>();
            conexion.Open();
            string Query = " select orden_compra_detalle.id_orden_compra,orden_compra_detalle.id_orden_compra_detalle,orden_compra_detalle.cantidad,producto.nombre,producto.costo from orden_compra_detalle inner join producto on(orden_compra_detalle.id_producto = producto.id_producto) where id_orden_compra = @id";

            SqlCommand cmm = new SqlCommand(Query, conexion);
            cmm.Parameters.AddWithValue("@id", id);

            SqlDataReader dr = cmm.ExecuteReader();

            while (dr.Read()) {
                OrdenCompraDetalle InstDetalle = new OrdenCompraDetalle();
                Producto InsProd = new Producto();
                OrdenCompra InsOrden = new OrdenCompra();
                InstDetalle.Id_orden_compra_detalle = Convert.ToInt32(dr["id_orden_compra_detalle"]);
                InstDetalle.Cantidad = Convert.ToInt32(dr["cantidad"]);
                InstDetalle.Orden = InsOrden;
                InstDetalle.Producto = InsProd;

                InstDetalle.Producto.Nombre = Convert.ToString(dr["nombre"]);
                InstDetalle.Orden.Id_Orden_Compra = Convert.ToInt32(dr["id_orden_compra"]);
                InstDetalle.Producto.Costo = Convert.ToInt32(dr["costo"]);

                List.Add(InstDetalle);







            }

            return List;

        }



    }

    
}

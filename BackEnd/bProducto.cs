using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;

namespace BackEnd
{
    public class bProducto
    {

        SqlConnection conexion = new SqlConnection(@"Data Source = DESKTOP-45F3K51\SQLEXPRESS; Initial Catalog = Campo; Integrated Security = True");
       
        //Categorias producto

        public void EliminarCategoriaPorId(string id)
        {
            conexion.Open();
            string query = "DELETE FROM producto_categoria where id_producto_categoria = @id";
            SqlCommand cnn = new SqlCommand(query, conexion);
            cnn.Parameters.AddWithValue("@id", id);
            cnn.ExecuteNonQuery();
            conexion.Close();

        }

        public void InsertarNuevaCategoriaProducto(Producto_Categoria Estado)
        {
            conexion.Open();

            if (conexion != null && conexion.State == ConnectionState.Closed) ;
            string query = "INSERT into Categoria_Producto(nombre) VALUES (@nombre)";
            SqlCommand cmd = new SqlCommand(query, conexion);

            cmd.Parameters.AddWithValue("@nombre", Estado.Nombre);


            cmd.ExecuteNonQuery();
        }

        public List<Producto_Categoria> ShowCategoriasProducto()
        {

            conexion.Open();
            string query = "SELECT * FROM Producto_Categoria";

            SqlCommand cmd = new SqlCommand(query, conexion);

            SqlDataReader dr = cmd.ExecuteReader();

            List<Producto_Categoria> Lista = new List<Producto_Categoria>();
            int number;

            while (dr.Read())
            {
                Producto_Categoria Estate = new Producto_Categoria();
                Estate.Nombre = dr["nombre"].ToString();
                Estate.IdProductoCategoria = Convert.ToInt32(dr["Id_Producto_Categoria"]);
                Lista.Add(Estate);
            }

            return Lista;

        }

        public List<Producto_Categoria> ShowCategoriasProductobyNombre(string nombre)
        {

            conexion.Open();
            string query = "SELECT * FROM Producto_Categoria WHERE nombre like @nombre + '%'";

            SqlCommand cmd = new SqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            SqlDataReader dr = cmd.ExecuteReader();

            List<Producto_Categoria> Lista = new List<Producto_Categoria>();
            int number;

            while (dr.Read())
            {
                Producto_Categoria Estate = new Producto_Categoria();
                Estate.IdProductoCategoria = Convert.ToInt32(dr["Id_Producto_Categoria"]);
                Estate.Nombre = dr["nombre"].ToString();
                Lista.Add(Estate);
            }

            return Lista;

        }

        //Producto

        public void InsertarNuevoProducto(Producto Producto)
        {
            conexion.Open();
            String Query = "INSERT INTO Producto(Nombre,Descripcion,Costo,Stock,Id_Producto_Categoria) VALUES (@Nombre,@Descripcion,@Costo,@Stock,@Id_Producto_Categoria) ";
            SqlCommand cmm = new SqlCommand(Query, conexion);

            cmm.Parameters.AddWithValue("@Nombre", Producto.Nombre);
            cmm.Parameters.AddWithValue("@Descripcion", Producto.Descripcion);
            cmm.Parameters.AddWithValue("@Costo", Producto.Costo);
            cmm.Parameters.AddWithValue("@Stock", Producto.Stock);
            cmm.Parameters.AddWithValue("@Id_Producto_Categoria", Producto.Categoria.IdProductoCategoria);

            cmm.ExecuteNonQuery();

            conexion.Close();



        }

        public List<Producto> MostrarProductos() {

            conexion.Open();
            string Query = "select Id_Producto,Producto.Nombre,Descripcion,costo,Stock,producto.Id_Producto_Categoria,Producto_Categoria.Nombre as 'NombreCategoria' from Producto inner join Producto_Categoria on (Producto.Id_Producto_Categoria = Producto_Categoria.Id_Producto_Categoria)";

            SqlCommand cmm = new SqlCommand(Query,conexion);

            List<Producto> Lista = new List<Producto>();


            SqlDataReader dr = cmm.ExecuteReader();

            while (dr.Read()) {
                Producto producto1 = new Producto();
                Producto_Categoria cat = new Producto_Categoria();
                producto1.Categoria = cat;
                producto1.Id_Producto = Convert.ToInt32( dr["id_producto"]);
                producto1.Nombre = dr["Nombre"].ToString();
                producto1.Descripcion = dr["descripcion"].ToString();
                producto1.Costo = Convert.ToInt32(dr["costo"]);
                producto1.Stock = Convert.ToInt32(dr["stock"]);
                producto1.Categoria.IdProductoCategoria = Convert.ToInt32(dr["id_producto_categoria"]);
                producto1.Categoria.Nombre = dr["NombreCategoria"].ToString();
                Lista.Add(producto1);
            }

            return Lista;



        }

        public void EliminarProductoPorID(string id)
        {
            conexion.Open();
            string query = "DELETE FROM Producto where id_producto = @id";
            SqlCommand cnn = new SqlCommand(query, conexion);
            cnn.Parameters.AddWithValue("@id", id);
            cnn.ExecuteNonQuery();
            conexion.Close();
        }

        public List<Producto> MostrarProductosByNombre(string nombre) {

            conexion.Open();
            string query = "SELECT * FROM Producto WHERE nombre like @nombre + '%'";

            SqlCommand cmd = new SqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            SqlDataReader dr = cmd.ExecuteReader();

            List<Producto> Lista = new List<Producto>();
            int number;

            while (dr.Read())
            {
                Producto producto1 = new Producto();
                Producto_Categoria cat = new Producto_Categoria();
                producto1.Categoria = cat;
                producto1.Id_Producto = Convert.ToInt32(dr["id_producto"]);
                producto1.Nombre = dr["Nombre"].ToString();
                producto1.Descripcion = dr["descripcion"].ToString();
                producto1.Costo = Convert.ToInt32(dr["costo"]);
                producto1.Stock = Convert.ToInt32(dr["stock"]);
                producto1.Categoria.IdProductoCategoria = Convert.ToInt32(dr["id_producto_categoria"]);

                Lista.Add(producto1);
            }

            return Lista;




        }

        public Producto MostrarProductoByID(string id) {

            conexion.Open();
            Producto producto1 = new Producto();
            string query = "select Id_Producto,Producto.Nombre,Descripcion,costo,Stock,producto.Id_Producto_Categoria,Producto_Categoria.Nombre as 'NombreCategoria' from Producto inner join Producto_Categoria on (Producto.Id_Producto_Categoria = Producto_Categoria.Id_Producto_Categoria) where Id_Producto = @id";
            SqlCommand cmm = new SqlCommand(query, conexion);

            cmm.Parameters.AddWithValue("@id", id);
            SqlDataReader dr = cmm.ExecuteReader();

            while (dr.Read()) {

                
                Producto_Categoria cat = new Producto_Categoria();
                producto1.Categoria = cat;
                producto1.Id_Producto = Convert.ToInt32(dr["id_producto"]);
                producto1.Nombre = dr["Nombre"].ToString();
                producto1.Descripcion = dr["descripcion"].ToString();
                producto1.Costo = Convert.ToInt32(dr["costo"]);
                producto1.Stock = Convert.ToInt32(dr["stock"]);
                producto1.Categoria.IdProductoCategoria = Convert.ToInt32(dr["id_producto_categoria"]);
                producto1.Categoria.Nombre = dr["NombreCategoria"].ToString();


            }

            return producto1;


        }

    }
}

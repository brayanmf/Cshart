using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;




namespace Capadatos
{
    public class CD_productos
    {
        private Conexion conexion = new Conexion();
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable mostrar() {


            comando.Connection = conexion.abrirconexion();
     
            comando.CommandText = "MostrarProductos";
            comando.CommandType = CommandType.StoredProcedure;

            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
            

        }
        public void insertar(string nombre,string descripcion,string marca,double precio,int stock )
        {
            comando.Connection = conexion.abrirconexion();
            comando.CommandText = "InsertarProductos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@desc", descripcion);
            comando.Parameters.AddWithValue("@marca", marca);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@stock", stock);
          


          
            comando.ExecuteNonQuery();

            comando.Parameters.Clear();

        }
        public void Editar(string nombre, string descripcion, string marca, double precio, int stock,int id)
        {
            comando.Connection = conexion.abrirconexion();
            comando.CommandText = "EditarProductos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@desc", descripcion);
            comando.Parameters.AddWithValue("@marca", marca);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@stock", stock);
            comando.Parameters.AddWithValue("@id", id);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();



        }
       
        public void Eliminar(int id)
        {
            comando.Connection = conexion.abrirconexion();
            comando.CommandText = "EliminarProducto";
                comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idpro", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }
    }
}

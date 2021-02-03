using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; 
using System.Data.SqlClient;


namespace Capadatos
{
    public class Conexion
    {
        private SqlConnection conexion = new SqlConnection("");
        public SqlConnection abrirconexion()

        {
            if (conexion.State == ConnectionState.Closed)
                conexion.Open();
            return conexion;
             }
        public SqlConnection CerrarConexion()
        { if (conexion.State == ConnectionState.Open)
                conexion.Close();
                return conexion;
                    }


        }
    }


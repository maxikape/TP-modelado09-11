using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DatosConexionBD
    {
        public SqlConnection conexion;
        public string cadenaConexion = "Server=DESKTOP-GCMI0HO\\SQLEXPRESS;DataBase= mauri;Integrated Security = true";
        //private SqlConnection Conexion = new SqlConnection("Server=DESKTOP-GCMI0HO\\SQLEXPRESS;DataBase= ControlStock;Integrated Security=true");


        public DatosConexionBD()
        {
            conexion = new SqlConnection (cadenaConexion);
        }
       
 public SqlConnection Abrirconexion()
        {
            try
            {
                if (conexion.State == ConnectionState.Broken || conexion.State ==
               ConnectionState.Closed)
                    conexion.Open();
            }
            catch (Exception e)
            {
                throw new Exception("Error al tratar de abrir la conexión", e);
            }
            return conexion;
        }
        public SqlConnection Cerrarconexion()
        {
            try
            {
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Error al tratar de cerrar la conexión", e);
            }
            return conexion;
        }
    }
}


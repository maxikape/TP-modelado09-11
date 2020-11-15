using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;


namespace Datos
{
    public class DatosMateriales : DatosConexionBD
    {
       
        private DatosConexionBD Conexcion = new DatosConexionBD();
        private SqlCommand comando = new SqlCommand();
        private SqlDataReader leerfilas;
        public int InstarMateriales(string accion, Materiales objMateriales, int idmat)
        {
            int resultado = -1;
            string orden = string.Empty;
            if (accion == "Alta")
                orden = "insert into Materiales values (" + "\'" + objMateriales.Pedido_id + "\'"+ " , " + "\'"+ objMateriales.Insumo_id + "\'"+ " ,  "
                    + "\'"+ objMateriales.Cantidad+ "\'"+ ")" + "\n"+ "update Insumos set stock = stock - " + objMateriales.Cantidad +  " " +  "where id =  "+ "\'"+idmat + "\'"+" ;";

   
            SqlCommand cmd = new SqlCommand(orden, conexion);
            try
            {
                Abrirconexion();
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                 throw new Exception("Error ABM ", e);
            }

            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
            return resultado;
        }
    }


}


  


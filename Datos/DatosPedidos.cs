using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;
using System.Runtime.InteropServices;
using System.ComponentModel.Design;

namespace Datos
{
    public class DatosPedidos : DatosConexionBD
    {
        private DatosConexionBD Conexcion = new DatosConexionBD();
        private SqlCommand comando = new SqlCommand();
        private SqlDataReader leerfilas;


        public int abmPedidos(string accion, Pedidos objpedidos)
        {
            int resultado = -1;
            string orden = string.Empty;
            if (accion == "Alta")
                orden = "insert into Pedidos values ('" + objpedidos.Cliente + "' ,  '" + objpedidos.Tipo_pedido + "', '" + objpedidos.Fecha_pedido + "');";

            if (accion == "Modificar")
                orden = "update mauri set Pedidos = '" + objpedidos.Tipo_pedido + "' , '" + objpedidos.Fecha_pedido + "' where Cliente = '" + objpedidos.Cliente + "';";
            
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


        public DataSet MostrarPedidos(string cual)
        {
            string orden = string.Empty;
            if (cual != "Todos")
                orden = "selec * from Pedidos where id = " + int.Parse(cual) + ";";
            else
                orden = "select * from Pedidos;";

            SqlCommand cmd = new SqlCommand(orden, conexion);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                Abrirconexion();
                cmd.ExecuteNonQuery();
                da.SelectCommand = cmd;
                da.Fill(ds);

            }
            catch (Exception e)
            {

                throw new Exception("error al mostrar pedidos", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();

            }
            
            return ds;
        }


        public DataTable ListarPedidos()
        {
            DataTable tabla = new DataTable();
            comando.Connection = Conexcion.Abrirconexion(); 
            comando.CommandText = "select * from Pedidos";
            leerfilas = comando.ExecuteReader();
            tabla.Load(leerfilas);

            return tabla;

        }


    }
}

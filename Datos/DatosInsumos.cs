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
    public class DatosInsumos : DatosConexionBD
    {
        public int AbmInsumos(string accion, Insumos objInsumos)
        {
            int resultado = 0;
            string orden = string.Empty;

            switch (accion)
            { 
                case "Alta":
                    orden = "insert into Clientes " + "values ("
                                            + "" + objInsumos.Cod_articulo + ","
                                            + "'" + objInsumos.Descripcion + "',"
                                            + "" + objInsumos.Stock + ","
                                            + "" + objInsumos.Valor_unitario + ","
                                            + ");";
                    break;

                case "Modificar":
                    orden = "update Clientes set "
                                        + "descripcion= '" + objInsumos.Descripcion + "',"
                                        + "stock= '" + objInsumos.Stock + ","
                                        + "valor_unitario= " + objInsumos.Valor_unitario + ","
                                        + "where cod_articulo= " + objInsumos.Cod_articulo;
                    break;

                case "Eliminar":
                    orden = "Delete from Clientes where Id = " + objInsumos.Id;
                    break;


            }

            SqlCommand sqlcmd = new SqlCommand(orden, conexion);
            try
            {
                Abrirconexion();
                resultado = sqlcmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                throw new Exception("Error al tratar de moficiar los registros de Clientes", e);
            }
            finally
            {
                Cerrarconexion();
                sqlcmd.Dispose();
            }
            return resultado;
        }


        public DataSet MostrarInsumos(string cual)
        { 
            string orden = string.Empty;
            if (cual != "Todos")
                orden = "select * from Insumos where id = " + int.Parse(cual) + ";";
            else
                orden = "select * from Insumos;"; 

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

                throw new Exception("error al mostrar insumos", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();

            }

            return ds;
        }

        public DataSet MostrarReporte(int cual)
        {
            string orden = string.Empty;

            orden = "select p.cliente, p.tipo_pedido, i.descripcion, m.cantidad from pedidos p, insumos i, materiales m where p.id = m.pedido_id and i.id = m.insumo_id and p.id = " +(cual) + ";";

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

                throw new Exception("error al mostrar insumos", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();

            }

            return ds;
        }
    }

}


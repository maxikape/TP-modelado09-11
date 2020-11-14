using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;
using Entidades;

namespace Negocios
{
    public class NegPedidos
    {
        DatosPedidos objDatosPedidos = new DatosPedidos();

        public int abmPedidos(string accion, Pedidos objPedidos,int idmodifica)
        {
            return objDatosPedidos.abmPedidos(accion, objPedidos, idmodifica);
        }

        public DataSet MostrarPedidos(string cual)
        {
            return objDatosPedidos.MostrarPedidos(cual);
        }


        public DataTable Listarbox()
        {
            return objDatosPedidos.ListarPedidos();
        }
    }
}

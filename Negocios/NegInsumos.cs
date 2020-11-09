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
    public class NegInsumos
    {
        DatosInsumos objDatosInsumos = new DatosInsumos();
        public int AbmInsumos(string accion, Insumos objInsumos)
        {
            return objDatosInsumos.AbmInsumos(accion, objInsumos);
        }

        public DataSet MostrarInsumos(string cual)
        {
            return objDatosInsumos.MostrarInsumos(cual);
        }

        public DataSet MostrarReporte(int cual)
        {
            return objDatosInsumos.MostrarReporte(cual);
        }
    }
}

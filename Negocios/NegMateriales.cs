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
   public class NegMateriales
    {
        DatosMateriales objDatosMat = new DatosMateriales();
        

        public int InsertMateriales(string accion, Materiales objMateriales,int idmat)
        {
            return objDatosMat.InstarMateriales(accion, objMateriales, idmat);
        }
    }
}

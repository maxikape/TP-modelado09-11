using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
      public class Materiales
    {

            #region Atributos
            private int id;
            private int pedido_id;
            private int insumo_id;
            private int cantidad;
            private bool pendiente;


        #endregion


        //constructor
        public Materiales()
        {
            id = 0;
            pedido_id = 0;
            insumo_id = 0;
            cantidad = 0;
            pendiente = false;
        }


        #region Propiedades
        public int Id
            {
                get { return id; }
                set { id = value; }
            }
            public int Pedido_id
            {
                get { return pedido_id; }
                set { pedido_id = value; }
            }
            public int Insumo_id
            {
                get { return insumo_id; }
                set { insumo_id = value; }
            }
            public int Cantidad
            {
                get { return cantidad; }
                set { cantidad = value; }
            }
            public bool Pendiente
            {
                get { return pendiente; }
                set { pendiente = value; }
            }


            #endregion

        }
    }


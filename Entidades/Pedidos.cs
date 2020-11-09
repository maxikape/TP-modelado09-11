using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class Pedidos
    {
        #region Atributos
        private int id;
        private string cliente;
        private string tipo_pedido;
        private string fecha_pedido;

        #endregion

        #region Propiedades
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }
        public string Tipo_pedido
        {
            get { return tipo_pedido; }
            set { tipo_pedido = value; }
        }
        public string Fecha_pedido
        {
            get { return fecha_pedido; }
            set { fecha_pedido = value; }
        }
        #endregion

        public Pedidos()
        {
            cliente = string.Empty;
            tipo_pedido = string.Empty;
            fecha_pedido = string.Empty;
        }
        //public Pedidos(string cli, string tipo_ped, string fecha_ped)
        //{
        //    cliente = cli;
        //    tipo_pedido = tipo_ped;
        //   fecha_pedido = fecha_ped;

        //}

        //public Clientes(/*int id,*/ int cuil, string nom, string dir, string tel, string email)
        //{
        //    //Metodo = variable por parametro;
        //    //Id = id;
        //    Cuil = cuil;
        //    Nombre = nom;
        //    Direccion = dir;
        //    Telefono = tel;
        //    Email = email;
        //}

    }
}

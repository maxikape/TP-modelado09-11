using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Insumos
    {
        #region Atributos
        private int id;
        private int cod_articulo;
        private string descripcion;
        private int stock;
        private int valor_unitario;

        #endregion

        public Insumos()
        {
            id = 0;
            cod_articulo = 0;
            descripcion = string.Empty;
            stock = 0;
            valor_unitario = 0;

        }

        #region Propiedades
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int Cod_articulo
        {
            get { return cod_articulo; }
            set { cod_articulo = value; }
        }
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public int Stock
        {
            get { return stock; }
            set { stock = value; }
        }

        public int Valor_unitario
        {
            get { return stock; }
            set { stock = value; }
        }
        #endregion

        //public Pedidos()
        //{
        //    cliente = string.Empty;
        //    tipo_pedido = string.Empty;
        //    fecha_pedido = DateTime.Now;
        //}
        //public Pedidos(string cliente, string tipo_pedido, DateTime fecha_pedido)
        //{
        //    Cliente = cliente;
        //    Tipo_pedido = tipo_pedido;
        //    Fecha_pedido = fecha_pedido;

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

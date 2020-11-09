using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Negocios;

namespace Presentacion
   
{
    public partial class fPedidos : Form
    {
        public fPedidos()
        {
            InitializeComponent();
            dgvPedidos.ColumnCount = 4;
            dgvPedidos.Columns[1].HeaderText = "Nombre";
            dgvPedidos.Columns[2].HeaderText = "Descripción";
            dgvPedidos.Columns[3].HeaderText = "Fecha de pedido";

            IniDgv();
            
        }

        public Pedidos objEntPedidos = new Pedidos();
        public NegPedidos objNegPedidos = new NegPedidos();
        

        private void IniDgv()
        {
            dgvPedidos.Rows.Clear();
            DataSet ds = new DataSet();
            ds = objNegPedidos.MostrarPedidos("Todos");
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dgvPedidos.Rows.Add(dr[0], dr[1], dr[2], dr[3]);
                }
            }
               
        }

        private void TxtBox_a_Obj()  // prepara elobjeto que se va a mandar a la capa negocios
        {
            objEntPedidos.Cliente = txtNombre.Text;
            objEntPedidos.Tipo_pedido = txtTipoPed.Text;
            objEntPedidos.Fecha_pedido = dtpFeha.Text;

            
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
             int nGrabados = -1;
            //cargo los datos al objeto
            TxtBox_a_Obj();

            nGrabados = objNegPedidos.abmPedidos("Alta", objEntPedidos);//invocacion ala capa de negocio

            if (nGrabados == -1)
                
                MessageBox.Show("No se pudo agregar el pedido al sistema");
            
            else
            {
                MessageBox.Show("Se agrego el registro correctamente!");
                IniDgv();
                
            }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int nResultado = -1;
            TxtBox_a_Obj();
            nResultado = objNegPedidos.abmPedidos("Modificar", objEntPedidos); 
           
            if (nResultado != -1)
            {
  //              Mensaje("Aviso", "El Profesional fue Modificado con éxito");
  //              Limpiar();
                IniDgv();
                //               txtCodigo.Enabled = true;
                MessageBox.Show("Pedido actualizado con exito");
            }
            else
                MessageBox.Show("Error al intentar modificar");
        }

        private void btnAgregarMateriales_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dgvPedidos.CurrentRow.Cells[0].Value.ToString());
            fInsumos ins = new fInsumos(id);
            ins.Show();
        }
    }
}

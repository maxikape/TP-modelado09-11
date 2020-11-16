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
            dgvPedidos.Columns[0].HeaderText = "Codigo";

            dgvPedidos.Columns[1].HeaderText = "Nombre";
            dgvPedidos.Columns[2].HeaderText = "Descripción";
            dgvPedidos.Columns[3].HeaderText = "Fecha de pedido";

            IniDgv();
            
        }

        public Pedidos objEntPedidos = new Pedidos();
        public NegPedidos objNegPedidos = new NegPedidos();
        int idmodifica;


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

        //private void Dgv_a_Textbox()
        //{
        //    txtNombre.Text = cli;
        //    txtTipoPed.Text = tipo;
        //    dtpFeha.Value = DateTime.Parse(fecha); 


        //}


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
            if (String.IsNullOrEmpty(txtNombre.Text) || String.IsNullOrEmpty(txtTipoPed.Text))
            {
                MessageBox.Show("Complete todos los campos para realizar esta acción");
            }
            else
            {
                nGrabados = objNegPedidos.abmPedidos("Alta", objEntPedidos, idmodifica);//invocacion ala capa de negocio

                if (nGrabados == -1)

                    MessageBox.Show("No se pudo agregar el pedido al sistema");

                else
                {
                    MessageBox.Show("Se agrego el registro correctamente!");
                    IniDgv();

                }

            }


        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int nResultado = -1;
            TxtBox_a_Obj();
            nResultado = objNegPedidos.abmPedidos("Modificar", objEntPedidos, idmodifica); 
           
            if (nResultado != -1)
            {
 
                
                MessageBox.Show("Pedido actualizado con exito");
                IniDgv();
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

        private void dgvPedidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idmodifica = int.Parse(dgvPedidos.Rows[dgvPedidos.CurrentRow.Index].Cells[0].Value.ToString());
            txtNombre.Text = dgvPedidos.Rows[dgvPedidos.CurrentRow.Index].Cells[1].Value.ToString();
            txtTipoPed.Text = dgvPedidos.Rows[dgvPedidos.CurrentRow.Index].Cells[2].Value.ToString();
            dtpFeha.Value = Convert.ToDateTime(dgvPedidos.Rows[dgvPedidos.CurrentRow.Index].Cells[3].Value.ToString());
 

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
        
            int nGrabados = -1;
            //cargo los datos al objeto
       

            nGrabados = objNegPedidos.abmPedidos("Eliminar", objEntPedidos, idmodifica);//invocacion ala capa de negocio

            if (nGrabados == -1)

                MessageBox.Show("No se pudo Eliminar el pedido al sistema");

            else
            {
                MessageBox.Show("Se elimino el registro correctamente!");
                IniDgv();

            }

        }
    }
}

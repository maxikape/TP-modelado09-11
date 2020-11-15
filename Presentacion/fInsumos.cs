using Entidades;
using Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class fInsumos : Form
    {
        private int id;
        private int idMaterial;


        public fInsumos(int id)
        {
            InitializeComponent();
            dgvInsumos.ColumnCount = 5;
            dgvInsumos.Columns[2].HeaderText = "Material";
            dgvInsumos.Columns[3].HeaderText = "Cantidad";
            dgvInsumos.Columns[4].HeaderText = "Precio";

            dgvReporte.ColumnCount = 4;
            dgvReporte.Columns[0].HeaderText = "Nombre";
            dgvReporte.Columns[1].HeaderText = "Descripcion";
            dgvReporte.Columns[2].HeaderText = "Material";
            dgvReporte.Columns[3].HeaderText = "Cantidad";

            IniDgv();
            this.id = id;
            DgvMostrarRep();

        }
        public NegMateriales objNegMateriales = new NegMateriales();
        public Materiales objEntMater = new Materiales();
        public Insumos objEntInsumos = new Insumos();
        public NegInsumos objNegInsumos = new NegInsumos();
        //public NegPedidos objNegPedidos = new NegPedidos();

        private void IniDgv()
        {
            dgvInsumos.Rows.Clear();
            DataSet ds = new DataSet();
            ds = objNegInsumos.MostrarInsumos("Todos");
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dgvInsumos.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4]);
                }
            }

        }

        private void  DgvMostrarRep()
        {
            dgvReporte.Rows.Clear();
            DataSet ds1 = new DataSet();
            ds1 = objNegInsumos.MostrarReporte(id);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds1.Tables[0].Rows)
                {
                    dgvReporte.Rows.Add(dr[0], dr[1], dr[2], dr[3]);
                }
            }

        }



        private void btnAgregarMaterial_Click(object sender, EventArgs e)
        {
             idMaterial = int.Parse(dgvInsumos.CurrentRow.Cells[0].Value.ToString());
            
  
            if (String.IsNullOrEmpty(txtCantidad.Text))
            {
                MessageBox.Show("Complete todos los campos para realizar esta acción");
            }
            else { 
            int nGrabados = -1;
            nGrabados = objNegMateriales.InsertMateriales("Alta", objEntMater,idMaterial);//invocacion ala capa de negocio

            if (nGrabados == -1)

                MessageBox.Show("No se pudo agregar el pedido al sistema");

            else
            {
                    objEntMater.Pedido_id = id;
                    objEntMater.Insumo_id = idMaterial;
                    objEntMater.Cantidad = int.Parse(txtCantidad.Text);
                    MessageBox.Show("Se agrego el registro correctamente!");
                IniDgv();
                DgvMostrarRep(); 

            }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fInsumos_Load(object sender, EventArgs e)
        {

        }
    }
}

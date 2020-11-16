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
    public partial class Form1 : Form
    {
        int  id;
        public Form1()
        {
            InitializeComponent();
            PersonalizarDiseño();
            
        }
        
        #region Metodos Submenu

        public void PersonalizarDiseño()
        {

            panelSubPedido.Visible = false;
            panelSubInsumos.Visible = false;

        }
        public void EsconderSubmenu()
        {

            if (panelSubPedido.Visible == true)
                panelSubPedido.Visible = false;

            if (panelSubInsumos.Visible == true)
                panelSubInsumos.Visible = false;



        } 
        public void MostrarSubmenu(Panel submenu)
        {
            if (submenu.Visible == false) 
            {
                EsconderSubmenu();
                submenu.Visible = true;
            }
                else
                {
                    submenu.Visible = false;
                }
            

        }

        #endregion



        #region botones Submenus 

        private void btnInsumos_Click(object sender, EventArgs e)
        {
            
            AbrirFormHijo(new fInsumos(id));
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
           
            AbrirFormHijo(new fPedidos());


        }

        private void button2_Click(object sender, EventArgs e)
        {
            EsconderSubmenu();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EsconderSubmenu();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EsconderSubmenu();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            EsconderSubmenu();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            EsconderSubmenu();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            EsconderSubmenu();

        }
        #endregion



        #region Foirmularios Hijos
        // variable para cerrar el formulario anterior
        private Form FormuActivo = null;
        public void AbrirFormHijo(Form FormuHijo)
        {
            if (FormuActivo != null)
                FormuActivo.Close();
            FormuActivo = FormuHijo;
            //fomulario hijo no es de nivel superio , se comporta como un control
            FormuHijo.TopLevel = false;
            FormuHijo.FormBorderStyle = FormBorderStyle.None;
            FormuHijo.Dock = DockStyle.Fill;
            //agrego formulario ala lista de controles del panel contenedor
            panelContenedor.Controls.Add(FormuHijo);
            //se hasocia el formulario con el panel contenedor
            panelContenedor.Tag = FormuHijo;
            //logo formulario acia el frente
            FormuHijo.BringToFront();
            FormuHijo.Show();
            
        }


        #endregion

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

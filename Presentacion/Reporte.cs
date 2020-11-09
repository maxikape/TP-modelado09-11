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
    public partial class Reporte : Form
    {
        private int id;
        public Reporte(int id)
        {
            InitializeComponent();
            this.id = id;
            label1.Text = id.ToString();
        }

    }
}

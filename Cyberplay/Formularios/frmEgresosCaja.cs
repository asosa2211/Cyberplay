using Cyberplay.Core;
using Cyberplay.Modelos;
using Cyberplay.Persistencia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cyberplay.Formularios
{
    public partial class frmEgresosCaja : Form
    {
        private PersistenciaEgresosCaja persistenciaEgresos = new PersistenciaEgresosCaja();

        private List<EgresoCaja> egresos = new List<EgresoCaja>();

        //CONSTRUCTOR
        public frmEgresosCaja()
        {
            InitializeComponent();
            
        }

        

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
          
        }
    }
}

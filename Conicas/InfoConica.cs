using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace Conicas
{
    /*
        Aqui vamos mostrar as informacoes retornadas pela clase Elementos Geometricos
        
     */
    public partial class InfoConica : MaterialForm
    {
        ElementosGeometricos elementos;
        public InfoConica(string nomeConica, double[] coeficientes)
        {
            InitializeComponent();
            elementos = new ElementosGeometricos(nomeConica, coeficientes);
        }

        void ShowDetails()
        {

        }

        private void InfoConica_FormClosing(object sender, FormClosingEventArgs e)
        {
            var res = MessageBox.Show(this, "Deseja Realmente Sair?", "Sair",
              MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (res != DialogResult.Yes)
            {
                e.Cancel = true;
                return;
            }
        }
    }
}

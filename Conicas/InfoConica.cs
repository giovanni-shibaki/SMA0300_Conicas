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
        public InfoConica(string nomeConica, double []coeficientes)
        {
            InitializeComponent();
            elementos = new ElementosGeometricos(nomeConica, coeficientes);
        }

        void ShowDetails()
        {
            
        }
        
    }
}
